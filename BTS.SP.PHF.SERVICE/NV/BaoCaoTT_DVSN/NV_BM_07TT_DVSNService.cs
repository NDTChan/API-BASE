using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN
{
    public interface INV_BM_07TT_DVSNService : IBaseService<PHF_BM_07TT_DVSN>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period);
    }

    public class NV_BM_07TT_DVSNService : BaseService<PHF_BM_07TT_DVSN>, INV_BM_07TT_DVSNService
    {
        private readonly IRepositoryAsync<PHF_BM_07TT_DVSN> _repository;

        public NV_BM_07TT_DVSNService(IRepositoryAsync<PHF_BM_07TT_DVSN> repository) : base(repository)
        {
            _repository = repository;
        }

        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period)
        {
            try
            {
                List<PHF_BM_07TT_DVSN> listInsert = new List<PHF_BM_07TT_DVSN>();
                var path = request.MapPath("~/UploadFile/" + unitCode + "/DonViSuNghiep");
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
                        PHF_BM_FILE_DVSN bmfile_dvsn = new PHF_BM_FILE_DVSN()
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
                            ObjectState = ObjectState.Added
                        };
                        int rowHeader = 1;
                        if (workSheet.Cells[rowHeader, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 1].Value?.ToString()))
                            {
                                bmfile_dvsn.TEN_BIEUMAU = workSheet.Cells[rowHeader, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_dvsn.TEN_BIEUMAU = "Biểu mẫu số: 07/TTr.ĐVSN";
                            }
                        }

                        int rowTitle = 3;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_dvsn.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_dvsn.TIEUDE_BIEUMAU = "TỔNG HỢP KẾT QUẢ THANH TRA HOẠT ĐỘNG SXKDDV";
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
                                PHF_BM_07TT_DVSN detail = new PHF_BM_07TT_DVSN()
                                {
                                    ObjectState = ObjectState.Added,
                                    MA_FILE = bmfile_dvsn.MA_FILE,
                                    MA_FILE_PK = bmfile_dvsn.MA_FILE_PK,
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
                                detail.STT = workSheet.Cells[startRow, 1] != null ? Convert.ToInt32(workSheet.Cells[startRow, 1].Value?.ToString()) : 0;
                                detail.NOIDUNG = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.BAOCAO_DONVI = workSheet.Cells[startRow, 3] != null ? Convert.ToDecimal(workSheet.Cells[startRow, 3].Value?.ToString()) : 0;
                                detail.THANHTRA_XACDINH = workSheet.Cells[startRow, 4] != null ? Convert.ToDecimal(workSheet.Cells[startRow, 4].Value?.ToString()) : 0;
                                detail.NGUYENNHAN = workSheet.Cells[startRow, 6] != null ? workSheet.Cells[startRow, 6].Value?.ToString() : null;
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                        }
                        _repository.GetRepository<PHF_BM_FILE_DVSN>().Insert(bmfile_dvsn);
                        request.Files[0].SaveAs(path + "/" + bmfile_dvsn.MA_FILE_PK + ".xlsx");
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
