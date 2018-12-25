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
    public interface INV_BM_08TT_TCXDService : IBaseService<PHF_BM_08TT_TCXD>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong);
    }
    public class NV_BM_08TT_TCXDService : BaseService<PHF_BM_08TT_TCXD>, INV_BM_08TT_TCXDService
    {
        private readonly IRepositoryAsync<PHF_BM_08TT_TCXD> _repository;
        public NV_BM_08TT_TCXDService(IRepositoryAsync<PHF_BM_08TT_TCXD> repository) : base(repository)
        {
            _repository = repository;
        }

        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period, string doiTuong)
        {
            try
            {
                List<PHF_BM_08TT_TCXD> listInsert = new List<PHF_BM_08TT_TCXD>();
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
                        PHF_BM_FILE_TCXD bmfile_ncdp = new PHF_BM_FILE_TCXD()
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
                                bmfile_ncdp.TEN_BIEUMAU = workSheet.Cells[rowHeader, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_ncdp.TEN_BIEUMAU = "Biểu mẫu số: 08/TTTC-XD";
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
                                bmfile_ncdp.TIEUDE_BIEUMAU = "THỐNG KÊ TÌNH HÌNH NGHIỆM THU, THANH TOÁN GIÁ TRỊ KHỐI LƯỢNG HOÀN THÀNH";
                            }
                        }

                        int startRow = 7;
                        int stt = 1;
                        int stt_cha = 0;
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if(!header.Equals("...") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_08TT_TCXD detail = new PHF_BM_08TT_TCXD()
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
                                detail.TEN_HANGMUC = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.GIATRI_HOPDONG = workSheet.Cells[startRow, 3] != null ? workSheet.Cells[startRow, 3].Value?.ToString() : null;
                                detail.GIATRI_KHOILUONG = workSheet.Cells[startRow, 4] != null ? workSheet.Cells[startRow, 4].Value?.ToString() : null;
                                detail.GIATRI_GIAINGAN = workSheet.Cells[startRow, 5] != null ? workSheet.Cells[startRow, 5].Value?.ToString() : null;
                                detail.SOSANH_GIAINGAN_KHOILUONG = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;
                                detail.NGUYENNHAN = workSheet.Cells[startRow, 7] != null ? workSheet.Cells[startRow, 7].Value?.ToString() : null;
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
                        }
                        _repository.GetRepository<PHF_BM_FILE_TCXD>().Insert(bmfile_ncdp);
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
