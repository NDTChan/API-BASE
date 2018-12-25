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
    public interface INV_BM_04TT_DVSNService : IBaseService<PHF_BM_04TT_DVSN>
    {
        string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period);
    }

    public class NV_BM_04TT_DVSNService : BaseService<PHF_BM_04TT_DVSN>, INV_BM_04TT_DVSNService
    {
        private readonly IRepositoryAsync<PHF_BM_04TT_DVSN> _repository;

        public NV_BM_04TT_DVSNService(IRepositoryAsync<PHF_BM_04TT_DVSN> repository) : base(repository)
        {
            _repository = repository;
        }

        public string UploadFileReport(HttpRequest request, string currentUser, string unitCode, string report, string period)
        {
            try
            {
                List<PHF_BM_04TT_DVSN> listInsert = new List<PHF_BM_04TT_DVSN>();
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
                        PHF_BM_FILE_DVSN bmfile_dvsn = new PHF_BM_FILE_DVSN()
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
                        int rowHeader = 3;
                        if (workSheet.Cells[rowHeader, 6] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowHeader, 6].Value?.ToString()))
                            {
                                bmfile_dvsn.TEN_BIEUMAU = workSheet.Cells[rowHeader, 6].Value?.ToString();
                            }
                            else
                            {
                                bmfile_dvsn.TEN_BIEUMAU = "Biểu số 04/TTr.ĐVSN";
                            }
                        }

                        int rowTitle = 1;
                        if (workSheet.Cells[rowTitle, 1] != null)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[rowTitle, 1].Value?.ToString()))
                            {
                                bmfile_dvsn.TIEUDE_BIEUMAU = workSheet.Cells[rowTitle, 1].Value?.ToString();
                            }
                            else
                            {
                                bmfile_dvsn.TIEUDE_BIEUMAU = "TỔNG HỢP KẾT QỦA THANH TRA VIỆC THỰC HIỆN THỰC CHI THU ";
                            }
                        }
                        int startRow = 8;
                        int stt = 1;
                        int rowEnd = 4;
                        while (workSheet.Cells[6, rowEnd].Value != null && !string.IsNullOrEmpty(workSheet.Cells[6, rowEnd].Value.ToString()))
                        {
                            rowEnd += 1;
                        }
                        var titleNguyenNhan = "";
                        for (int i = 4; i < rowEnd; i++)
                        {
                            titleNguyenNhan += workSheet.Cells[6, i].Value != null ? workSheet.Cells[6, i].Value.ToString() + ";" : "empty;";
                        }
                        while (workSheet.Cells[startRow, 1].Value != null && !string.IsNullOrEmpty(workSheet.Cells[startRow, 1].Value.ToString()))
                        {
                            string header = workSheet.Cells[startRow, 1].Value.ToString().Trim();
                            if (!header.Equals("…") || !string.IsNullOrEmpty(header))
                            {
                                PHF_BM_04TT_DVSN detail = new PHF_BM_04TT_DVSN()
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
                                detail.NOIDUNG_THU = workSheet.Cells[startRow, 2] != null ? workSheet.Cells[startRow, 2].Value?.ToString() : null;
                                detail.SOTIEN = workSheet.Cells[startRow, 3] != null ? Convert.ToDecimal(workSheet.Cells[startRow, 3].Value?.ToString()) : 0;
                                detail.TITLE_NGUYENNHAN = titleNguyenNhan;
                                detail.NGUYENNHAN = "";
                                for (int i = 4; i < rowEnd; i++)
                                {
                                    var str = workSheet.Cells[startRow, i].Value != null ? workSheet.Cells[startRow, i].Value.ToString() + ";" : "empty;";
                                    detail.NGUYENNHAN += str;
                                }
                                listInsert.Add(detail);
                            }
                            startRow += 1;
                            stt++;
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
