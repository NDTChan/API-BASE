using System;
using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using System.Web;
using BTS.SP.PHF.ENTITY;
using System.IO;
using OfficeOpenXml;
using Repository.Pattern.Infrastructure;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD
{
    public interface INV_BM_01TT_TCXDService : IBaseService<PHF_BM_01TT_TCXD>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong);
    }
    public class NV_BM_01TT_TCXDService : BaseService<PHF_BM_01TT_TCXD>, INV_BM_01TT_TCXDService
    {
        private readonly IRepositoryAsync<PHF_BM_01TT_TCXD> _repository;
        public NV_BM_01TT_TCXDService(IRepositoryAsync<PHF_BM_01TT_TCXD> repository) : base(repository)
        {
            _repository = repository;
        }
        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong)
        {
            try
            {
                List<PHF_BM_01TT_TCXD> listInsert = new List<PHF_BM_01TT_TCXD>();
                var path = request.MapPath("~/UploadFile/" + unitCode + "/BaoCaoTT_TCXD");
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

                        PHF_BM_FILE_TCXD bmfile_cqhc = new PHF_BM_FILE_TCXD()
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
                            ObjectState = ObjectState.Added
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
                                bmfile_cqhc.TEN_BIEUMAU = "Biểu mẫu: 01/TTTC-XD ";
                            }
                        }

                        int rowTitle = 2;
                        if (workSheet.Cells[rowTitle, 3] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 3].Value?.ToString()))
                            {
                                bmfile_cqhc.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 3].Value?.ToString();
                            }
                            else
                            {
                                bmfile_cqhc.TIEUDE_BIEUMAU = "THỦ TỤC, THẨM QUYỀN PHÊ DUYỆT TỔNG MỨC ĐẦU TƯ";
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
                                PHF_BM_01TT_TCXD detail = new PHF_BM_01TT_TCXD()
                                {
                                    ObjectState = ObjectState.Added,
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
                                if (workSheet.Cells[startRow, 2].Style.Font.Bold)
                                {
                                    detail.IS_BOLD = 1;
                                }
                                else
                                {
                                    detail.IS_BOLD = 0;
                                }
                                if (workSheet.Cells[startRow, 2].Style.Font.Italic)
                                {
                                    detail.IS_ITALIC = 1;
                                }
                                else
                                {
                                    detail.IS_ITALIC = 0;
                                }
                                detail.TEN_THUTUC = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.COQUAN_DUYET = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.GIATRI_KHOANMUC = workSheet.Cells[startRow, 4] != null ? workSheet.Cells[startRow, 4].Value?.ToString() : null;
                                detail.TRANGTHAI_THUTUC = workSheet.Cells[startRow, 5] != null ? workSheet.Cells[startRow, 5].Value?.ToString() : null;
                                detail.NGUYENNHAN_THIEU = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_TCXD>().Insert(bmfile_cqhc);
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

    }
}
