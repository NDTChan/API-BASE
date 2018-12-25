using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD;
using BTS.SP.PHF.SERVICE.UTILS;
using Newtonsoft.Json.Linq;
using Repository.Pattern.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.PHF.SERVICE.SERVICES;
using System.IO;
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_TCXD.NV_BM_FILE_TCXDVm;
using Repository.Pattern.Infrastructure;
using System.Collections.Generic;
using BTS.SP.TOOLS.BuildQuery.Implimentations;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvBaoCaoTTTCXD")]
    [Route("{id?}")]
    [Authorize]
    public class NvBaoCaoTT_TCXDController : ApiController
    {
        public readonly INV_BM_FILE_TCXDService _service;
        public readonly INV_BM_01TT_TCXDService _serviceBM_01TT_TCXD;
        public readonly INV_BM_02TT_TCXDService _serviceBM_02TT_TCXD;
        public readonly INV_BM_03TT_TCXDService _serviceBM_03TT_TCXD;
        public readonly INV_BM_04TT_TCXDService _serviceBM_04TT_TCXD;
        public readonly INV_BM_05TT_TCXDService _serviceBM_05TT_TCXD;
        public readonly INV_BM_06TT_TCXDService _serviceBM_06TT_TCXD;
        public readonly INV_BM_07TT_TCXDService _serviceBM_07TT_TCXD;
        public readonly INV_BM_08TT_TCXDService _serviceBM_08TT_TCXD;
        public readonly INV_BM_10TT_TCXDService _serviceBM_10TT_TCXD;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvBaoCaoTT_TCXDController(INV_BM_FILE_TCXDService service, INV_BM_01TT_TCXDService serviceBM_01TT_TCXD, INV_BM_02TT_TCXDService serviceBM_02TT_TCXD,
            INV_BM_03TT_TCXDService serviceBM_03TT_TCXD, INV_BM_04TT_TCXDService serviceBM_04TT_TCXD, INV_BM_05TT_TCXDService serviceBM_05TT_TCXD,
            INV_BM_06TT_TCXDService serviceBM_06TT_TCXD, INV_BM_07TT_TCXDService serviceBM_07TT_TCXD, INV_BM_08TT_TCXDService serviceBM_08TT_TCXD,
            INV_BM_10TT_TCXDService serviceBM_10TT_TCXD, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceBM_01TT_TCXD = serviceBM_01TT_TCXD;
            _serviceBM_02TT_TCXD = serviceBM_02TT_TCXD;
            _serviceBM_03TT_TCXD = serviceBM_03TT_TCXD;
            _serviceBM_04TT_TCXD = serviceBM_04TT_TCXD;
            _serviceBM_05TT_TCXD = serviceBM_05TT_TCXD;
            _serviceBM_06TT_TCXD = serviceBM_06TT_TCXD;
            _serviceBM_07TT_TCXD = serviceBM_07TT_TCXD;
            _serviceBM_08TT_TCXD = serviceBM_08TT_TCXD;
            _serviceBM_10TT_TCXD = serviceBM_10TT_TCXD;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvBaoCaoTTTCXD")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_BM_FILE_TCXD>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_BM_FILE_TCXDVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_BM_FILE_TCXD>>();
            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1
            };
            try
            {
                var filterResult = await _service.FilterAsync(filtered, query);
                if (!filterResult.WasSuccessful)
                {
                    return NotFound();
                }
                result.Data = filterResult.Value;
                result.Error = false;
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [CustomAuthorize(Method ="XOA", State = "phf_nvBaoCaoTTTCXD")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_BM_FILE_TCXD item = await _service.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);
                switch (item.MA_FILE)
                {
                    case "TEMPLATE_BM_01TT_TCXD":
                        var details_BM01 = _serviceBM_01TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM01)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_01TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_02TT_TCXD":
                        var details_BM02 = _serviceBM_02TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM02)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_02TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_03TT_TCXD":
                        var details_BM03 = _serviceBM_03TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM03)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_03TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_04TT_TCXD":
                        var details_BM04 = _serviceBM_04TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM04)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_04TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_05TT_TCXD":
                        var details_BM05 = _serviceBM_05TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM05)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_05TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_06TT_TCXD":
                        var details_BM06 = _serviceBM_06TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM06)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_06TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_07TT_TCXD":
                        var details_BM07 = _serviceBM_07TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM07)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_07TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_08TT_TCXD":
                        var details_BM08 = _serviceBM_08TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM08)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_08TT_TCXD.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_010TT_TCXD":
                        var details_BM10 = _serviceBM_10TT_TCXD.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM10)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceBM_10TT_TCXD.Delete(itemDetail);
                        }
                        break;
                }

                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Xóa thành công.";
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi cập nhập dữ liệu.";
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPut]
        [CustomAuthorize(Method ="SUA", State = "phf_nvBaoCaoTTTCXD")]
        public async Task<IHttpActionResult> Put(string id, JObject model)
        {
            Response<string> response = new Response<string>();
            try
            {
                var postData = (dynamic)model;
                var detailFile = ((JObject)postData).ToObject<PHF_BM_FILE_TCXD>();
                if (detailFile.MA_FILE.Equals("TEMPLATE_BM_01TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_01TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_01TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_THUTUC = bm.TEN_THUTUC;
                            tmp.COQUAN_DUYET = bm.COQUAN_DUYET;
                            tmp.GIATRI_KHOANMUC = bm.GIATRI_KHOANMUC;
                            tmp.TRANGTHAI_THUTUC = bm.TRANGTHAI_THUTUC;
                            tmp.NGUYENNHAN_THIEU = bm.NGUYENNHAN_THIEU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_01TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_02TT_TCXD"))
                    {
                        var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_02TT_TCXD>>();
                        foreach (var bm in paged)
                        {
                            var tmp = _serviceBM_02TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                            try
                            {
                                tmp.TEN_SAIPHAM = bm.TEN_SAIPHAM;
                                tmp.GIATRI = bm.GIATRI;
                                tmp.NGUYENNHAN = bm.NGUYENNHAN;
                                tmp.TRACHNHIEM = bm.TRACHNHIEM;
                                tmp.HAUQUA = bm.HAUQUA;
                                tmp.GHICHU = bm.GHICHU;
                                tmp.MA_FILE = bm.MA_FILE;
                                tmp.MA_FILE_PK = bm.MA_FILE_PK;
                                tmp.ObjectState = ObjectState.Modified;
                                _serviceBM_02TT_TCXD.Update(tmp);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_03TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_03TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_03TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_CHIPHI_DAUTU = bm.TEN_CHIPHI_DAUTU;
                            tmp.VON_NSNN_KHV = bm.VON_NSNN_KHV;
                            tmp.VONVAY_KHV = bm.VONVAY_KHV;
                            tmp.VONKHAC_KHV = bm.VONKHAC_KHV;                  
                            tmp.TONGCONG_KHV = bm.TONGCONG_KHV;

                            tmp.VON_NSNN_GNV = bm.VON_NSNN_GNV;
                            tmp.VONVAY_GNV = bm.VONVAY_GNV;
                            tmp.VONKHAC_GNV = bm.VONKHAC_GNV;
                            tmp.TONGCONG_GNV = bm.TONGCONG_GNV;

                            tmp.VON_NSNN_TLGN = bm.VON_NSNN_TLGN;
                            tmp.VONVAY_TLGN = bm.VONVAY_TLGN;
                            tmp.VONKHAC_TLGN = bm.VONKHAC_TLGN;
                            tmp.TONGCONG_TLGN = bm.TONGCONG_TLGN;

                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_03TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_04TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_04TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_04TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_THUTUC = bm.TEN_THUTUC;
                            tmp.GIATRI = bm.GIATRI;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.KETQUA = bm.KETQUA;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_04TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_05TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_05TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_05TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_DUTOAN = bm.TEN_DUTOAN;
                            tmp.GIATRI = bm.GIATRI;
                            tmp.SO = bm.SO;
                            tmp.NGAY = bm.NGAY;
                            tmp.THAMQUYEN_DUYET = bm.THAMQUYEN_DUYET;
                            tmp.THUTUC_DACO = bm.THUTUC_DACO;
                            tmp.NGUYENNHAN_THIEU = bm.NGUYENNHAN_THIEU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_05TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_06TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_06TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_06TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.KL_DUTOAN = bm.KL_DUTOAN;
                            tmp.KL_TINHLAI = bm.KL_TINHLAI;
                            tmp.KL_CHENHLECH = bm.KL_CHENHLECH;
                            tmp.DG_DUTOAN = bm.DG_DUTOAN;
                            tmp.DG_TINHLAI = bm.DG_TINHLAI;
                            tmp.DG_CHENHLECH = bm.DG_CHENHLECH;
                            tmp.DM_DUTOAN = bm.DM_DUTOAN;
                            tmp.DM_TINHLAI = bm.DM_TINHLAI;
                            tmp.DM_CHENHLECH = bm.DM_CHENHLECH;
                            tmp.GIATRI_CHENHLECH = bm.GIATRI_CHENHLECH;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_06TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_07TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_07TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_07TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_GOITHAU = bm.TEN_GOITHAU;
                            tmp.DT_DUYET = bm.DT_DUYET;
                            tmp.DT_TINHLAI = bm.DT_TINHLAI;
                            tmp.GGT_DUYET = bm.GGT_DUYET;
                            tmp.GGT_TINHLAI = bm.GGT_TINHLAI;
                            tmp.GIATRI_HOPDONG = bm.GIATRI_HOPDONG;
                            tmp.HINHTHUC_HOPDONG = bm.HINHTHUC_HOPDONG;
                            tmp.GIATRI_HOPDONG_VUOTGIA = bm.GIATRI_HOPDONG_VUOTGIA;
                            tmp.GIATRI_KHOILUONG = bm.GIATRI_KHOILUONG;
                            tmp.GIATRI_GIAINGAN = bm.GIATRI_GIAINGAN;
                            tmp.GHICHU = bm.GHICHU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_07TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_08TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_08TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_08TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_HANGMUC = bm.TEN_HANGMUC;
                            tmp.GIATRI_HOPDONG = bm.GIATRI_HOPDONG;
                            tmp.GIATRI_KHOILUONG = bm.GIATRI_KHOILUONG;
                            tmp.GIATRI_GIAINGAN = bm.GIATRI_GIAINGAN;
                            tmp.SOSANH_GIAINGAN_KHOILUONG = bm.SOSANH_GIAINGAN_KHOILUONG;               
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_08TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (detailFile.MA_FILE.Equals("TEMPLATE_BM_10TT_TCXD"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_10TT_TCXD>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_10TT_TCXD.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.TEN_HANGMUC = bm.TEN_HANGMUC;
                            tmp.THOIGIAN_QUYETTOAN = bm.THOIGIAN_QUYETTOAN;
                            tmp.GIATRI_DENGHI = bm.GIATRI_DENGHI;
                            tmp.GIATRI_XACDINH = bm.GIATRI_XACDINH;
                            tmp.CHENHLECH = bm.CHENHLECH;
                            tmp.THOIGIAN_QUYETTOAN_CHAM = bm.THOIGIAN_QUYETTOAN_CHAM;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.GHICHU = bm.GHICHU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_10TT_TCXD.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }

                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Cập nhật thành công.";
                    return Ok(response);
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi cập nhật dữ liệu.";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok();
        }

        [Route("GetUrlDownloadTemplate/{report}")]
        [HttpGet]
        public IHttpActionResult GetUrlDownloadTemplate(string report)
        {
            var result = new TransferObj<string>();
            if (!string.IsNullOrEmpty(report))
            {
                string path = HttpContext.Current.Server.MapPath("~") + "Template\\ExcelTCXD\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + report + ".xlsx"))
                {
                    result.Status = true;
                    result.Message = "Tải template";
                    result.Data = "\\Template\\ExcelTCXD\\" + report + ".xlsx";
                }
                else
                {
                    result.Status = false;
                    result.Message = "Không tồn tại Template Excel '" + report + "'";
                }
            }
            else
            {
                result.Status = false;
                result.Message = "Tham số template không đúng";
            }
            return Ok(result);
        }

        [Route("UploadFileReport")]
        [HttpPost]
        public async Task<IHttpActionResult> UploadFileReport()
        {
            Response<string> response = new Response<string>();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string currentUser = RequestContext.Principal.Identity.Name;
                string UNITCODE = httpRequest["unitCode"];
                string REPORT = httpRequest["report"];
                string PERIOD = httpRequest["period"];
                string DOITUONG = httpRequest["doiTuong"];
                if (!string.IsNullOrEmpty(UNITCODE))
                {   
                    var checkExist = _service.Queryable().FirstOrDefault(x => x.MA_FILE.Equals(REPORT) && x.MA_DOT.Equals(PERIOD) && x.UnitCode.Equals(UNITCODE) && x.MA_DOITUONG.Equals(DOITUONG));
                    if (checkExist != null)
                    {
                        response.Error = true;
                        response.Message = "Existed";
                    }
                    else
                    {
                        if (REPORT.Equals("TEMPLATE_BM_01TT_TCXD"))
                        {
                            string result = _serviceBM_01TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_02TT_TCXD"))
                        {
                            string result = _serviceBM_02TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_03TT_TCXD"))
                        {
                            string result = _serviceBM_03TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_04TT_TCXD"))
                        {
                            string result = _serviceBM_04TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_05TT_TCXD"))
                        {
                            string result = _serviceBM_05TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_06TT_TCXD"))
                        {
                            string result = _serviceBM_06TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_07TT_TCXD"))
                        {
                            string result = _serviceBM_07TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_08TT_TCXD"))
                        {
                            string result = _serviceBM_08TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_10TT_TCXD"))
                        {
                            string result = _serviceBM_10TT_TCXD.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (_unitOfWorkAsync.SaveChanges() > 0)
                        {
                            response.Error = false;
                            response.Message = "Inserted";
                        }
                    }
                }
                else
                {
                    response.Error = true;
                    response.Message = "UnitCodeIsNull";
                }
            }
            else
            {
                response.Error = true;
                response.Message = ErrorMessage.EMPTY_DATA;
            }
            return Ok(response);
        }

        [Route("GetDataReport/{fileName}/{fileNamePk}")]
        [HttpGet]
        public IHttpActionResult GetDataReport(string fileName, string fileNamePk)
        {
            Response<DTO_BM_TT_TCXD> response = new Response<DTO_BM_TT_TCXD>();
            DTO_BM_TT_TCXD data = new DTO_BM_TT_TCXD();
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(fileNamePk))
            {
                var dto = _service.Queryable().FirstOrDefault(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk));
                if (dto != null)
                {
                    data.ID = dto.Id;
                    data.MA_FILE = dto.MA_FILE;
                    data.MA_FILE_PK = dto.MA_FILE_PK;
                    data.TEN_FILE = dto.TEN_FILE;
                    data.NAM = dto.NAM;
                    data.MA_DOT = dto.MA_DOT;
                    data.MA_DOITUONG = dto.MA_DOITUONG;
                    data.THOIGIAN = dto.THOIGIAN;
                    data.TEN_BIEUMAU = dto.TEN_BIEUMAU;
                    data.TIEUDE_BIEUMAU = dto.TIEUDE_BIEUMAU;
                    if (fileName.Equals("TEMPLATE_BM_01TT_TCXD"))
                    {
                        var details = _serviceBM_01TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_01TT_TCXD_DTO row = new PHF_BM_01TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_THUTUC = record.TEN_THUTUC;
                                row.COQUAN_DUYET = record.COQUAN_DUYET;
                                row.GIATRI_KHOANMUC = record.GIATRI_KHOANMUC;
                                row.TRANGTHAI_THUTUC = record.TRANGTHAI_THUTUC;
                                row.NGUYENNHAN_THIEU = record.NGUYENNHAN_THIEU;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_01TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_02TT_TCXD"))
                    {
                        var details = _serviceBM_02TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_02TT_TCXD_DTO row = new PHF_BM_02TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_SAIPHAM = record.TEN_SAIPHAM;
                                row.GIATRI = record.GIATRI;
                                row.NGUYENNHAN = record.NGUYENNHAN;
                                row.TRACHNHIEM = record.TRACHNHIEM;
                                row.HAUQUA = record.HAUQUA;
                                row.GHICHU = record.GHICHU;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_02TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_03TT_TCXD"))
                    {
                        var details = _serviceBM_03TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_03TT_TCXD_DTO row = new PHF_BM_03TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_CHIPHI_DAUTU = record.TEN_CHIPHI_DAUTU;
                                row.VON_NSNN_KHV = record.VON_NSNN_KHV;
                                row.VONVAY_KHV = record.VONVAY_KHV;
                                row.VONKHAC_KHV = record.VONKHAC_KHV;
                                row.TONGCONG_KHV = record.TONGCONG_KHV;
                                row.VON_NSNN_GNV = record.VON_NSNN_GNV;
                                row.VONVAY_GNV = record.VONVAY_GNV;
                                row.VONKHAC_GNV = record.VONKHAC_GNV;
                                row.TONGCONG_GNV = record.TONGCONG_GNV;
                                row.VON_NSNN_TLGN = record.VON_NSNN_TLGN;
                                row.VONVAY_TLGN = record.VONVAY_TLGN;
                                row.VONKHAC_TLGN = record.VONKHAC_TLGN;
                                row.TONGCONG_TLGN = record.TONGCONG_TLGN;
                                row.NGUYENNHAN = record.NGUYENNHAN;

                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_03TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_04TT_TCXD"))
                    {
                        var details = _serviceBM_04TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_04TT_TCXD_DTO row = new PHF_BM_04TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_THUTUC = record.TEN_THUTUC;
                                row.GIATRI = record.GIATRI;
                                row.NGUYENNHAN = record.NGUYENNHAN;
                                row.KETQUA = record.KETQUA;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_04TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_05TT_TCXD"))
                    {
                        var details = _serviceBM_05TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_05TT_TCXD_DTO row = new PHF_BM_05TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_DUTOAN = record.TEN_DUTOAN;
                                row.GIATRI = record.GIATRI;
                                row.SO = record.SO;
                                row.NGAY = record.NGAY;
                                row.THAMQUYEN_DUYET = record.THAMQUYEN_DUYET;
                                row.THUTUC_DACO = record.THUTUC_DACO;
                                row.NGUYENNHAN_THIEU = record.NGUYENNHAN_THIEU;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_05TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_06TT_TCXD"))
                    {
                        var details = _serviceBM_06TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_06TT_TCXD_DTO row = new PHF_BM_06TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_CONGVIEC = record.TEN_CONGVIEC;
                                row.KL_DUTOAN = record.KL_DUTOAN;
                                row.KL_TINHLAI = record.KL_TINHLAI;
                                row.KL_CHENHLECH = record.KL_CHENHLECH;
                                row.DG_DUTOAN = record.DG_DUTOAN;
                                row.DG_TINHLAI = record.DG_TINHLAI;
                                row.DG_CHENHLECH = record.DG_CHENHLECH;
                                row.DM_DUTOAN = record.DM_DUTOAN;
                                row.DM_TINHLAI = record.DM_TINHLAI;
                                row.DM_CHENHLECH = record.DM_CHENHLECH;
                                row.GIATRI_CHENHLECH = record.GIATRI_CHENHLECH;
                                row.NGUYENNHAN = record.NGUYENNHAN;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_06TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_07TT_TCXD"))
                    {
                        var details = _serviceBM_07TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_07TT_TCXD_DTO row = new PHF_BM_07TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_GOITHAU = record.TEN_GOITHAU;
                                row.DT_DUYET = record.DT_DUYET;
                                row.DT_TINHLAI = record.DT_TINHLAI;
                                row.GGT_DUYET = record.GGT_DUYET;
                                row.GGT_TINHLAI = record.GGT_TINHLAI;
                                row.GIATRI_HOPDONG = record.GIATRI_HOPDONG;
                                row.HINHTHUC_HOPDONG = record.HINHTHUC_HOPDONG;
                                row.GIATRI_HOPDONG_VUOTGIA = record.GIATRI_HOPDONG_VUOTGIA;
                                row.GIATRI_KHOILUONG = record.GIATRI_KHOILUONG;
                                row.GIATRI_GIAINGAN = record.GIATRI_GIAINGAN;
                                row.GHICHU = record.GHICHU;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_07TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_08TT_TCXD"))
                    {
                        var details = _serviceBM_08TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_08TT_TCXD_DTO row = new PHF_BM_08TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_HANGMUC = record.TEN_HANGMUC;
                                row.GIATRI_HOPDONG = record.GIATRI_HOPDONG;
                                row.GIATRI_KHOILUONG = record.GIATRI_KHOILUONG;
                                row.GIATRI_GIAINGAN = record.GIATRI_GIAINGAN;
                                row.SOSANH_GIAINGAN_KHOILUONG = record.SOSANH_GIAINGAN_KHOILUONG;
                                row.NGUYENNHAN = record.NGUYENNHAN;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_08TT_TCXD_DTO.Add(row);
                            }
                        }
                    }
                    else if (fileName.Equals("TEMPLATE_BM_10TT_TCXD"))
                    {
                        var details = _serviceBM_10TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                        if (details.Count > 0)
                        {
                            foreach (var record in details)
                            {
                                PHF_BM_10TT_TCXD_DTO row = new PHF_BM_10TT_TCXD_DTO();
                                row.ID = record.Id;
                                row.STT = record.STT;
                                row.STT_TIEUDE = record.STT_TIEUDE;
                                row.STT_CHA = record.STT_CHA;
                                row.MA_FILE = record.MA_FILE;
                                row.MA_FILE_PK = record.MA_FILE_PK;
                                row.TEN_HANGMUC = record.TEN_HANGMUC;
                                row.THOIGIAN_QUYETTOAN = record.THOIGIAN_QUYETTOAN;
                                row.GIATRI_DENGHI = record.GIATRI_DENGHI;
                                row.GIATRI_XACDINH = record.GIATRI_XACDINH;
                                row.CHENHLECH = record.CHENHLECH;
                                row.THOIGIAN_QUYETTOAN_CHAM = record.THOIGIAN_QUYETTOAN_CHAM;
                                row.NGUYENNHAN = record.NGUYENNHAN;
                                row.GHICHU = record.GHICHU;
                                row.IS_BOLD = record.IS_BOLD;
                                row.IS_ITALIC = record.IS_ITALIC;
                                data.PHF_BM_10TT_TCXD_DTO.Add(row);
                            }

                        }
                    }
                    response.Error = false;
                    response.Message = "Oke";
                    response.Data = data;
                }
                else
                {
                    response.Error = true;
                    response.Message = ErrorMessage.EMPTY_DATA;
                }
            }
            else
            {
                response.Error = true;
                response.Message = ErrorMessage.EMPTY_DATA;
            }
            return Ok(response);
        }

        [Route("OverWriteReport")]
        [HttpPost]
        public async Task<IHttpActionResult> OverWriteReport()
        {
            Response<string> response = new Response<string>();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string currentUser = RequestContext.Principal.Identity.Name;
                string UNITCODE = httpRequest["unitCode"];
                string REPORT = httpRequest["report"];
                string PERIOD = httpRequest["period"];
                if (!string.IsNullOrEmpty(UNITCODE))
                {
                    var checkExist = _service.Queryable().FirstOrDefault(x => x.MA_FILE.Equals(REPORT) && x.MA_DOT.Equals(PERIOD) && x.UnitCode.Equals(UNITCODE));
                    if (checkExist != null)
                    {
                        var checkExistBM_01TT_TCXD = _serviceBM_01TT_TCXD.Queryable().Where(x => x.MA_FILE.Equals(checkExist.MA_FILE) && x.MA_FILE_PK.Equals(checkExist.MA_FILE_PK) && x.UnitCode.Equals(UNITCODE)).ToList();
                        if (checkExistBM_01TT_TCXD.Count > 0)
                        {
                            foreach (PHF_BM_01TT_TCXD row in checkExistBM_01TT_TCXD)
                            {
                                _serviceBM_01TT_TCXD.Delete(row);
                            }
                        }
                        _service.Delete(checkExist);
                    }
                    if (_unitOfWorkAsync.SaveChanges() > 0)
                    {
                        response.Error = false;
                        response.Message = "Overwrited";
                    }
                }
                else
                {
                    response.Error = true;
                    response.Message = "UnitCodeIsNull";
                }
            }
            else
            {
                response.Error = true;
                response.Message = ErrorMessage.EMPTY_DATA;
            }
            return Ok(response);
        }
    }
}