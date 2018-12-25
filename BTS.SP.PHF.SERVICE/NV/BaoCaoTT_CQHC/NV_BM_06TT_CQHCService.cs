using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;
using System.Web;
using System.IO;
using OfficeOpenXml;
using BTS.SP.PHF.ENTITY;
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC.NV_BM_FILE_CQHCVm;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC
{
    public interface INV_BM_06TT_CQHCService : IBaseService<PHF_BM_06TT_CQHC>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong);
        DTO_BM_06_FILE_CQHC GetDataReport(string fileName, string fileNamePk);
    }
    public class NV_BM_06TT_CQHCService : BaseService<PHF_BM_06TT_CQHC>, INV_BM_06TT_CQHCService
    {
        private readonly IRepositoryAsync<PHF_BM_06TT_CQHC> _repository;
        public NV_BM_06TT_CQHCService(IRepositoryAsync<PHF_BM_06TT_CQHC> repository) : base(repository)
        {
            _repository = repository;
        }
        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong)
        {
            try
            {
                List<PHF_BM_06TT_CQHC> listInsert = new List<PHF_BM_06TT_CQHC>();
                var path = request.MapPath("~/UploadFile/" + unitCode + "/BaoCaoTT_CQHC");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var excelPackage = new ExcelPackage(HttpContext.Current.Request.Files[0].InputStream))
                {
                    var workSheet = excelPackage.Workbook.Worksheets[1];
                    if (workSheet != null)
                    {
                        var rowCount = workSheet.Dimension.End.Row;
                        var colCount = workSheet.Dimension.End.Column;

                        PHF_BM_FILE_CQHC bmfile_cqhc = new PHF_BM_FILE_CQHC()
                        {
                            ICreateBy = currentUser,
                            ICreateDate = DateTime.Now,
                            MA_FILE = report,
                            MA_FILE_PK = report + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss"),
                            THOIGIAN = DateTime.Now.ToString("HH:mm:ss"),
                            TEN_FILE = request.Files[0].FileName,
                            NAM = DateTime.Now.Year,
                            UnitCode = unitCode,
                            IState = "10",
                            MA_DOT = period,
                            MA_DOITUONG = doiTuong,
                            ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                        };
                        int rowHeader = 1;
                        if (workSheet.Cells[rowHeader, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 1].Value?.ToString()))
                            {
                                bmfile_cqhc.TEN_BIEUMAU = workSheet.Cells[rowHeader, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_cqhc.TEN_BIEUMAU = "Biểu số 06/TTr-CQHC";
                            }
                        }
                        int rowTitle = 4;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_cqhc.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_cqhc.TIEUDE_BIEUMAU = "TỔNG HỢP TÌNH HÌNH SAI PHẠM VIỆC THỰC HIỆN DỰ TOÁN CHI ";
                            }
                        }

                        int startRow = 9;
                        int stt = 1;
                        int stt_cha = 0;
                        int startRowReason = 4;
                        while (workSheet.Cells[8, startRowReason].Value != null && !string.IsNullOrEmpty(workSheet.Cells[8, startRowReason].Value.ToString()))
                        {
                            startRowReason += 1;
                        }
                        var titleNguyenNhan = "";
                        for (int i = 4; i < startRowReason; i++)
                        {
                            titleNguyenNhan += workSheet.Cells[8, i].Value != null ? workSheet.Cells[8, i].Value.ToString() + " ; " : "empty;";
                        }
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if (!header.Equals("...") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_06TT_CQHC detail = new PHF_BM_06TT_CQHC()
                                {
                                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added,
                                    MA_FILE = bmfile_cqhc.MA_FILE,
                                    MA_FILE_PK = bmfile_cqhc.MA_FILE_PK,
                                    UnitCode = unitCode,
                                    ICreateBy = currentUser,
                                    ICreateDate = DateTime.Now,
                                    IState = "10"
                                };
                                detail.STT = stt;
                                detail.STT_TIEUDE = workSheet.Cells[startRow, 1] != null ? workSheet.Cells[startRow, 1].Value?.ToString() : null;
                                if (detail.STT_TIEUDE != "" && detail.STT_TIEUDE.Trim() == "I")
                                {
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                                else if (detail.STT_TIEUDE != "" && detail.STT_TIEUDE.Trim() == "II")
                                {
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }

                                detail.STT_CHA = stt_cha;

                                if (workSheet.Cells[startRow, 1].Style.Font.Bold)
                                {
                                    detail.IS_BOLD = 1;
                                }
                                else
                                {
                                    detail.IS_BOLD = 0;
                                }
                                if (workSheet.Cells[startRow, 1].Style.Font.Italic)
                                {
                                    detail.IS_ITALIC = 1;
                                }
                                else
                                {
                                    detail.IS_ITALIC = 0;
                                }
                                detail.NOIDUNG = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.SOTIEN = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.TITLE_NGUYENNHAN = titleNguyenNhan;
                                detail.NGUYENNHAN = "";
                                for (int i = 4; i < startRowReason; i++)
                                {
                                    var str = workSheet.Cells[startRow, i] != null ? workSheet.Cells[startRow, i].Value?.ToString() + " ; " : "empty ;";
                                    detail.NGUYENNHAN += str;
                                }
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_CQHC>().Insert(bmfile_cqhc);
                        request.Files[0].SaveAs(path + "/" + bmfile_cqhc.MA_FILE_PK + ".xlsx");
                        InsertRange(listInsert);
                        return "Success";
                    }
                    else
                    {
                        return "NotWorkSheet";
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                WriteLogs.LogError(ex);
                return "Error";
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return "Error";
            }
        }
        public DTO_BM_06_FILE_CQHC GetDataReport(string fileName, string fileNamePk)
        {
            DTO_BM_06_FILE_CQHC result = new DTO_BM_06_FILE_CQHC();
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(fileNamePk))
            {
                var dto = _repository.GetRepository<PHF_BM_FILE_CQHC>().Queryable().FirstOrDefault(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk));
                if (dto != null)
                {
                    result.ID = dto.Id;
                    result.MA_FILE = dto.MA_FILE;
                    result.MA_FILE_PK = dto.MA_FILE_PK;
                    result.TEN_FILE = dto.TEN_FILE;
                    result.NAM = dto.NAM;
                    result.MA_DOT = dto.MA_DOT;
                    result.MA_DOITUONG = dto.MA_DOITUONG;
                    result.THOIGIAN = dto.THOIGIAN;
                    result.TEN_BIEUMAU = dto.TEN_BIEUMAU;
                    result.TIEUDE_BIEUMAU = dto.TIEUDE_BIEUMAU;
                    var details = _repository.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_06TT_CQHC_DTO row = new PHF_BM_06TT_CQHC_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.STT_TIEUDE = record.STT_TIEUDE;
                            row.STT_CHA = record.STT_CHA;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG = record.NOIDUNG;
                            row.SOTIEN = record.SOTIEN;
                            row.TITLE_NGUYENNHAN = record.TITLE_NGUYENNHAN;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            row.IS_BOLD = record.IS_BOLD;
                            row.IS_ITALIC = record.IS_ITALIC;
                            result.Details.Add(row);
                        }
                    }
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
    }
}