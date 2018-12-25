using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using Repository.Pattern.Repositories;
using System.Web;

namespace BTS.SP.PHF.SERVICE.NV.BaoCao_NSDVN
{
    public interface INV_BM_60TT_NSDVNService : IBaseService<PHF_BM_60TT_NSDVN>
    {
    }
    public class NV_BM_60TT_NSDVNService : BaseService<PHF_BM_60TT_NSDVN>, INV_BM_60TT_NSDVNService
    {
        private readonly IRepositoryAsync<PHF_BM_60TT_NSDVN> _repository;
        public NV_BM_60TT_NSDVNService(IRepositoryAsync<PHF_BM_60TT_NSDVN> repository) : base(repository)
        {
            _repository = repository;
        }
        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period)
        {
            try
            {
                List<PHF_BM_60TT_NSDVN> listInsert = new List<PHF_BM_60TT_NSDVN>();
                var path = request.MapPath("~/UploadFile/" + unitCode + "/BaoCaoNganSachDVN");
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
                        PHF_BM_FILE_NSDVN bmfile_nsdvn = new PHF_BM_FILE_NSDVN()
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
                            ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                        };
                        int rowHeader = 2;
                        if (workSheet.Cells[rowHeader, 6] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 6].Value?.ToString()))
                            {
                                bmfile_nsdvn.TEN_BIEUMAU = workSheet.Cells[rowHeader, 6].Value?.ToString();
                            }
                            else
                            {
                                bmfile_nsdvn.TEN_BIEUMAU = "Biểu số 60/TTTC-NSĐVN";
                            }
                        }

                        int rowTitle = 3;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_nsdvn.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_nsdvn.TIEUDE_BIEUMAU = "CÂN ĐỐI QUYẾT TOÁN NGÂN SÁCH ĐỊA PHƯƠNG NĂM ";
                            }
                        }
                        int startRow = 7;
                        int stt = 1;
                        int stt_cha = 0;
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if (!header.Equals("…") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_60TT_NSDVN detail = new PHF_BM_60TT_NSDVN()
                                {
                                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added,
                                    MA_FILE = bmfile_nsdvn.MA_FILE,
                                    MA_FILE_PK = bmfile_nsdvn.MA_FILE_PK,
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
                                else if (detail.STT_TIEUDE != "" && detail.STT_TIEUDE.Trim() == "III")
                                {
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                                else if (detail.STT_TIEUDE != "" && detail.STT_TIEUDE.Trim() == "IV")
                                {
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                                else if (detail.STT_TIEUDE != "" && detail.STT_TIEUDE.Trim() == "V")
                                {
                                    detail.STT_CHA = 0;
                                    stt_cha = stt;
                                }
                                detail.STT_CHA = stt_cha;
                                detail.NOIDUNG = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
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
                                detail.CONGVIEC = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.TRANGTHAI_TRIENKHAI = workSheet.Cells[startRow, 4] != null ? workSheet.Cells[startRow, 4].Value?.ToString() : null;
                                detail.VANBAN_SAIPHAM = workSheet.Cells[startRow, 5] != null ? workSheet.Cells[startRow, 5].Value?.ToString() : null;
                                detail.HAUQUA = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;
                                detail.NGUYENNHAN = workSheet.Cells[startRow, 7] != null ? workSheet.Cells[startRow, 7].Value?.ToString() : null;
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_NSDVN>().Insert(bmfile_nsdvn);
                        request.Files[0].SaveAs(path + "/" + bmfile_nsdvn.MA_FILE_PK + ".xlsx");
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
    }
}
