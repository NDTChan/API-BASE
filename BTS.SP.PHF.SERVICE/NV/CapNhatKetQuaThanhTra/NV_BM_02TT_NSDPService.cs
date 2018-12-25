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
namespace BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra
{
    public interface INV_BM_02TT_NSDPService : IBaseService<PHF_BM_02TT_NSDP>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period);
    }
    public class NV_BM_02TT_NSDPService : BaseService<PHF_BM_02TT_NSDP>, INV_BM_02TT_NSDPService
    {
        private readonly IRepositoryAsync<PHF_BM_02TT_NSDP> _repository;
        public NV_BM_02TT_NSDPService(IRepositoryAsync<PHF_BM_02TT_NSDP> repository) : base(repository)
        {
            _repository = repository;
        }
        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period)
        {
            try
            {
                List<PHF_BM_02TT_NSDP> listInsert = new List<PHF_BM_02TT_NSDP>();
                var path = request.MapPath("~/UploadFile/" + unitCode + "/CapNhatKetQua");
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
                        if(rowCount < 34 && colCount > 10)
                        {
                            return "NotTemplate";
                        }
                        PHF_BM_FILE_NSDP bmfile_ncdp = new PHF_BM_FILE_NSDP()
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
                            ObjectState = ObjectState.Added
                        };
                        int rowHeader = 1;
                        if (workSheet.Cells[rowHeader, 10] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 10].Value?.ToString()))
                            {
                                bmfile_ncdp.TEN_BIEUMAU = workSheet.Cells[rowHeader, 10].Value?.ToString();
                            }
                            else
                            {
                                bmfile_ncdp.TEN_BIEUMAU = "Biểu số 02/TTTC-NSĐP";
                            }
                        }

                        int rowTitle = 2;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_ncdp.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_ncdp.TIEUDE_BIEUMAU = "BẢNG TỔNG HỢP SỐ LIỆU, QUYẾT ĐỊNH GIAO DỰ TOÁN THU NGÂN SÁCH ĐỊA PHƯƠNG";
                            }
                        }
                        int startRow = 8;
                        int stt = 1;
                        int stt_cha = 0;
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if (!header.Equals("…") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_02TT_NSDP detail = new PHF_BM_02TT_NSDP()
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
                                detail.CHITIEU = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
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
                                detail.TW_GIAO = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.HDND_TINH_QD = workSheet.Cells[startRow, 4] != null ? workSheet.Cells[startRow, 4].Value?.ToString() : null;
                                detail.UBND_TINH_GIAO = workSheet.Cells[startRow, 5] != null ? workSheet.Cells[startRow, 5].Value?.ToString() : null;
                                detail.SS_HDNS_PHANTRAM = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;
                                detail.SS_HDNS_CHENHLECH = workSheet.Cells[startRow, 7] != null ? workSheet.Cells[startRow, 7].Value?.ToString() : null;
                                detail.SS_UBND_PHANTRAM = workSheet.Cells[startRow, 8] != null ? workSheet.Cells[startRow, 8].Value?.ToString() : null;
                                detail.SS_UBND_CHENHLECH = workSheet.Cells[startRow, 9] != null ? workSheet.Cells[startRow, 9].Value?.ToString() : null;
                                detail.GHICHU = workSheet.Cells[startRow, 10] != null ? workSheet.Cells[startRow, 10].Value?.ToString() : null;
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_NSDP>().Insert(bmfile_ncdp);
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
    }
}
