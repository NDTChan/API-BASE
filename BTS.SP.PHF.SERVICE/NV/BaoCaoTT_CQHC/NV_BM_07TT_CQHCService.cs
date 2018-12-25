using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;
using System;
using OfficeOpenXml;
using Repository.Pattern.Infrastructure;
using System.Web;
using BTS.SP.PHF.ENTITY;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC.NV_BM_FILE_CQHCVm;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC
{
    public interface INV_BM_07TT_CQHCService : IBaseService<PHF_BM_07TT_CQHC>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong);
        DTO_BM_07_FILE_CQHC GetDataReport(string fileName, string fileNamePk);
    }
    public class NV_BM_07TT_CQHCService : BaseService<PHF_BM_07TT_CQHC>, INV_BM_07TT_CQHCService
    {
        private readonly IRepositoryAsync<PHF_BM_07TT_CQHC> _repository;
        public NV_BM_07TT_CQHCService(IRepositoryAsync<PHF_BM_07TT_CQHC> repository) : base(repository)
        {
            _repository = repository;
        }

        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong)
        {
            try
            {
                List<PHF_BM_07TT_CQHC> listInsert = new List<PHF_BM_07TT_CQHC>();
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
                        if (rowCount < 23 && colCount > 7)
                        {
                            return "NotTemplate";
                        }
                        PHF_BM_FILE_CQHC bmfile_ncdp = new PHF_BM_FILE_CQHC()
                        {
                            ICreateBy = currentUser,
                            ICreateDate = DateTime.Now,
                            MA_FILE = report,
                            MA_FILE_PK = report + DateTime.Now.ToString("ddMMyyyyHHmmss"),
                            THOIGIAN = DateTime.Now.ToString("HH:mm:ss"),
                            TEN_FILE = request.Files[0].FileName,
                            NAM = DateTime.Now.Year,
                            UnitCode = unitCode,
                            IState = "10",
                            MA_DOT = period,
                            MA_DOITUONG = doiTuong,
                            ObjectState = ObjectState.Added
                        };
                        int rowHeader = 2;
                        if (workSheet.Cells[rowHeader, 6] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 6].Value?.ToString()))
                            {
                                bmfile_ncdp.TEN_BIEUMAU = workSheet.Cells[rowHeader, 6].Value?.ToString();
                            }
                            else
                            {
                                bmfile_ncdp.TEN_BIEUMAU = "Biểu số 07/TTr-CQHC";
                            }
                        }

                        int rowTitle = 3;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_ncdp.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_ncdp.TIEUDE_BIEUMAU = "TỔNG HỢP SAI PHẠM TRONG VIỆC QUẢN LÝ VÀ SỬ DỤNG CAC QUỸ";
                            }
                        }

                        int startRow = 11;
                      
                        int stt = 1;
                        int stt_cha = 0;
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if (!header.Equals("…") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_07TT_CQHC detail = new PHF_BM_07TT_CQHC()
                                {
                                    ObjectState = ObjectState.Added,
                                    MA_FILE = bmfile_ncdp.MA_FILE,
                                    MA_FILE_PK = bmfile_ncdp.MA_FILE_PK,
                                    UnitCode = unitCode,
                                    ICreateBy = currentUser,
                                    ICreateDate = DateTime.Now,
                                    IState = "10"
                                };
                                detail.STT = stt;
                                detail.STT_TIEUDE = workSheet.Cells[startRow, 1] != null ? workSheet.Cells[startRow, 1].Value?.ToString() : null;
                                if (workSheet.Cells[startRow, 1].Value?.ToString() != "" && workSheet.Cells[startRow, 1].Value?.ToString().Trim() == "Trích quỹ không đúng chế độ")
                                {
                                    detail.STT_TIEUDE = "KDCD";
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                                else if (workSheet.Cells[startRow, 1].Value?.ToString() != "" && workSheet.Cells[startRow, 1].Value?.ToString().Trim() == "Sử dụng quỹ sai quy định")
                                {
                                    detail.STT_TIEUDE = "QSQD";
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                               
                                detail.NOIDUNG_SAIPHAM = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.SOTIEN = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.TRICHSAI_TYLE = workSheet.Cells[startRow, 4] != null ? workSheet.Cells[startRow, 4].Value?.ToString() : null;
                                detail.TRICHKHONG_DUNGNGUON = workSheet.Cells[startRow, 5] != null ? workSheet.Cells[startRow, 5].Value?.ToString() : null;
                                detail.GHICHU = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;                              
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_CQHC>().Insert(bmfile_ncdp);
                        request.Files[0].SaveAs(path + "/" + bmfile_ncdp.MA_FILE_PK + ".xlsx");
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

        public DTO_BM_07_FILE_CQHC GetDataReport(string fileName, string fileNamePk)
        {
            DTO_BM_07_FILE_CQHC result = new DTO_BM_07_FILE_CQHC();
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
                            PHF_BM_07TT_CQHC_DTO row = new PHF_BM_07TT_CQHC_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.STT_TIEUDE = record.STT_TIEUDE;
                            row.STT_CHA = record.STT_CHA;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_SAIPHAM = record.NOIDUNG_SAIPHAM;
                            row.SOTIEN = record.SOTIEN;
                            row.TRICHSAI_TYLE = record.TRICHSAI_TYLE;
                            row.TRICHKHONG_DUNGNGUON = record.TRICHKHONG_DUNGNGUON;
                            row.GHICHU = record.GHICHU;
                          
                            //row.IS_BOLD = record.IS_BOLD;
                            //row.IS_ITALIC = record.IS_ITALIC;
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
