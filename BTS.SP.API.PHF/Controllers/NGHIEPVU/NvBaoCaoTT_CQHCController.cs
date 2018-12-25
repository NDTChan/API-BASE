using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC.NV_BM_FILE_CQHCVm;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvBaoCaoTTCQHC")]
    [Route("{id?}")]
    [Authorize]
    public class NvBaoCaoTT_CQHCController : ApiController
    {
        public readonly INV_BM_FILE_CQHCService _service;
        public readonly INV_BM_01TT_CQHCService _serviceBM_01TT_CQHC;
        public readonly INV_BM_02TT_CQHCService _serviceBM_02TT_CQHC;
        public readonly INV_BM_03TT_CQHCService _serviceBM_03TT_CQHC;
        public readonly INV_BM_04TT_CQHCService _serviceBM_04TT_CQHC;
        public readonly INV_BM_05TT_CQHCService _serviceBM_05TT_CQHC;
        public readonly INV_BM_06TT_CQHCService _serviceBM_06TT_CQHC;
        public readonly INV_BM_07TT_CQHCService _serviceBM_07TT_CQHC;
        public readonly INV_BM_08TT_CQHCService _serviceBM_08TT_CQHC;      
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvBaoCaoTT_CQHCController(INV_BM_FILE_CQHCService service, IUnitOfWorkAsync unitOfWorkAsync, INV_BM_01TT_CQHCService serviceBM_01TT_CQHC, INV_BM_02TT_CQHCService serviceBM_02TT_CQHC, INV_BM_03TT_CQHCService serviceBM_03TT_CQHC,
            INV_BM_04TT_CQHCService serviceBM_04TT_CQHC, INV_BM_05TT_CQHCService serviceBM_05TT_CQHC, INV_BM_06TT_CQHCService serviceBM_06TT_CQHC,INV_BM_07TT_CQHCService serviceBM_07TT_CQHC, INV_BM_08TT_CQHCService serviceBM_08TT_CQHC)
        {
            _service = service;
            _serviceBM_01TT_CQHC = serviceBM_01TT_CQHC;
            _serviceBM_02TT_CQHC = serviceBM_02TT_CQHC;
            _serviceBM_03TT_CQHC = serviceBM_03TT_CQHC;
            _serviceBM_04TT_CQHC = serviceBM_04TT_CQHC;
            _serviceBM_05TT_CQHC = serviceBM_05TT_CQHC;
            _serviceBM_06TT_CQHC = serviceBM_06TT_CQHC;
            _serviceBM_07TT_CQHC = serviceBM_07TT_CQHC;
            _serviceBM_08TT_CQHC = serviceBM_08TT_CQHC;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvBaoCaoTTCQHC")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_BM_FILE_CQHC>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_BM_FILE_CQHCVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_BM_FILE_CQHC>>();
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
        [CustomAuthorize(Method = "XOA", State = "phf_nvBaoCaoTTCQHC")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_BM_FILE_CQHC item = await _service.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);

                switch (item.MA_FILE)
                {
                    case "TEMPLATE_BM_01TT_CQHC":
                        var details_BM01 = _serviceBM_01TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM01)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_01TT_CQHC.Delete(itemDetail);
                        }
                        break;

                    case "TEMPLATE_BM_02TT_CQHC":
                        var details_BM02 = _serviceBM_02TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM02)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_02TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_03TT_CQHC":
                        var details_BM03 = _serviceBM_03TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM03)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_03TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_04TT_CQHC":
                        var details_BM04 = _serviceBM_04TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM04)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_04TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_05TT_CQHC":
                        var details_BM05 = _serviceBM_05TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM05)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_05TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_06TT_CQHC":
                        var details_BM06 = _serviceBM_06TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach( var itemDetail in details_BM06)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_06TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_07TT_CQHC":
                        var details_BM07 = _serviceBM_07TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM07)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_07TT_CQHC.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_08TT_CQHC":
                        var details_BM08 = _serviceBM_08TT_CQHC.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM08)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_08TT_CQHC.Delete(itemDetail);
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
                    response.Message = "Lỗi cập nhật dữ liệu.";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvBaoCaoTTCQHC")]
        public async Task<IHttpActionResult> Put(string id, JObject model)
        {
            Response<string> response = new Response<string>();
            try
            {
                var postData = (dynamic)model;
                var cha = ((JObject)postData).ToObject<PHF_BM_FILE_CQHC>();
                if (cha.MA_FILE.Equals("TEMPLATE_BM_01TT_CQHC"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_01TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_01TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.NOIDUNG = bm.NOIDUNG;
                            tmp.NAMTRUOC_LIENKE = bm.NAMTRUOC_LIENKE;
                            tmp.NAMLAP_DUTOAN = bm.NAMLAP_DUTOAN;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.GHICHU = bm.GHICHU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_01TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_02TT_CQHC"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_02TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_02TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        {
                            try
                            {
                                tmp.NOIDUNG = bm.NOIDUNG;
                                tmp.DUTOAN_DUOCGIAO_LK = bm.DUTOAN_DUOCGIAO_LK;
                                tmp.QUYETTOANCHI_LK = bm.QUYETTOANCHI_LK;
                                tmp.DUTOAN_DONVILAP_NAM = bm.DUTOAN_DONVILAP_NAM;
                                tmp.DUTOAN_DUOCGIAO_NAM = bm.DUTOAN_DUOCGIAO_NAM;
                                tmp.QUYETTOANCHI_NAM = bm.QUYETTOANCHI_NAM;
                                tmp.NGUYENNHAN = bm.NGUYENNHAN;
                                tmp.MA_FILE = bm.MA_FILE;
                                tmp.MA_FILE_PK = bm.MA_FILE_PK;
                                tmp.ObjectState = ObjectState.Modified;
                                _serviceBM_02TT_CQHC.Update(tmp);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_03TT_CQHC"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_03TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_03TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {   
                            tmp.NOIDUNG = bm.NOIDUNG;
                            tmp.DUTOAN_DUOCGIAO = bm.DUTOAN_DUOCGIAO;
                            tmp.THANHTRA_XACDINH = bm.THANHTRA_XACDINH;
                            tmp.TITLE_NGUYENNHAN = bm.TITLE_NGUYENNHAN;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.GHICHU = bm.GHICHU;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_03TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_04TT_CQHC"))
                {
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_04TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_04TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.NOIDUNG = bm.NOIDUNG;
                            tmp.SOTIEN = bm.SOTIEN;
                            tmp.THUKHONG_QDNC_NN = bm.THUKHONG_QDNC_NN;
                            tmp.THUCAOTHAP_QDNC_NN = bm.THUCAOTHAP_QDNC_NN;
                            tmp.THUKHONG_SSQT_NN = bm.THUKHONG_SSQT_NN;
                            tmp.CHUAGHI_THUCHI_NN = bm.CHUAGHI_THUCHI_NN;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_04TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_05TT_CQHC"))
                {
                    var temp = postData.DETAIL;
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_05TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_05TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.CHI_BHYTBHXH_SCD = bm.CHI_BHYTBHXH_SCD;
                            tmp.CHI_KHAC = bm.CHI_KHAC;
                            tmp.CHI_KHENTHUONG = bm.CHI_KHENTHUONG;
                            tmp.CHI_LUONGSCD = bm.CHI_LUONGSCD;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.CHI_THUNHAP = bm.CHI_THUNHAP;
                            tmp.HO_VATEN = bm.HO_VATEN;
                            tmp.GHI_CHU = bm.GHI_CHU;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_05TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if ( cha.MA_FILE.Equals("TEMPLATE_BM_06TT_CQHC"))
                {
                    var temp = postData.DETAIL;
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_06TT_CQHC>>();
                    foreach ( var bm in paged)
                    {
                        var tmp = _serviceBM_06TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.NOIDUNG = bm.NOIDUNG;
                            tmp.SOTIEN = bm.SOTIEN;
                            tmp.TITLE_NGUYENNHAN = bm.TITLE_NGUYENNHAN;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_06TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_07TT_CQHC"))
                {
                    var temp = postData.DETAIL;
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_07TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_07TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.NOIDUNG_SAIPHAM = bm.NOIDUNG_SAIPHAM;
                            tmp.SOTIEN = bm.SOTIEN;
                            tmp.TRICHSAI_TYLE = bm.TRICHSAI_TYLE;
                            tmp.TRICHKHONG_DUNGNGUON = bm.TRICHKHONG_DUNGNGUON;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.GHICHU = bm.GHICHU;                        
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_07TT_CQHC.Update(tmp);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                else if (cha.MA_FILE.Equals("TEMPLATE_BM_08TT_CQHC"))
                {
                    var temp = postData.DETAIL;
                    var paged = ((JArray)postData.DETAIL).ToObject<List<PHF_BM_08TT_CQHC>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_08TT_CQHC.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        try
                        {
                            tmp.SLCDV_THUNHAP_CHIUTHUE = bm.SLCDV_THUNHAP_CHIUTHUE;
                            tmp.SLCDV_SOTHUE_PHAINOP = bm.SLCDV_SOTHUE_PHAINOP;
                            tmp.TTXD_THUNHAP_CHIUTHUE = bm.TTXD_THUNHAP_CHIUTHUE;
                            tmp.TTXD_SOTHUE_PHAINOP = bm.TTXD_SOTHUE_PHAINOP;
                            tmp.CL_THUNHAP_CHIUTHUE = bm.CL_THUNHAP_CHIUTHUE;
                            tmp.CL_SOTHUE_PHAINOP = bm.CL_SOTHUE_PHAINOP;
                            tmp.NGUYENNHAN = bm.NGUYENNHAN;
                            tmp.MA_FILE = bm.MA_FILE;
                            tmp.MA_FILE_PK = bm.MA_FILE_PK;
                            tmp.HO_VATEN = bm.HO_VATEN;
                            tmp.ObjectState = ObjectState.Modified;
                            _serviceBM_08TT_CQHC.Update(tmp);
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
                string path = HttpContext.Current.Server.MapPath("~") + "Template\\ExcelCQHC\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + report + ".xlsx"))
                {
                    result.Status = true;
                    result.Message = "Tải template";
                    result.Data = "\\Template\\ExcelCQHC\\" + report + ".xlsx";
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
                string PERIOD  = httpRequest["period"];
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
                        if (REPORT.Equals("TEMPLATE_BM_01TT_CQHC"))
                        {
                            string result = _serviceBM_01TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_02TT_CQHC"))
                        {
                            string result = _serviceBM_02TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_03TT_CQHC"))
                        {
                            string result = _serviceBM_03TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_04TT_CQHC"))
                        {
                            string result = _serviceBM_04TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_05TT_CQHC"))
                        {
                            string result = _serviceBM_05TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if(REPORT.Equals("TEMPLATE_BM_06TT_CQHC"))
                        {
                            string result = _serviceBM_06TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                                return Ok(response);
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_07TT_CQHC"))
                        {
                            string result = _serviceBM_07TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_08TT_CQHC"))
                        {
                            string result = _serviceBM_08TT_CQHC.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD, DOITUONG);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = false;
                            response.Message = "Inserted";
                            return Ok(response);
                        }
                    }
                }
                else
                {
                    response.Error = true;
                    response.Message = "UnitCodeIsNull";
                    return Ok(response);
                }
            }
            else
            {
                response.Error = true;
                response.Message = ErrorMessage.EMPTY_DATA;
                return Ok(response);
            }
            return Ok();
        }

        [Route("GetDataReport/{fileName}/{fileNamePk}")]
        [HttpGet]
        public IHttpActionResult GetDataReport(string fileName, string fileNamePk)
        {
            try
            {
                switch (fileName)
                {
                    case ("TEMPLATE_BM_01TT_CQHC"):
                        {
                            Response<DTO_BM_01_FILE_CQHC> response = new Response<DTO_BM_01_FILE_CQHC>();
                            response.Data = _serviceBM_01TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }

                    case ("TEMPLATE_BM_02TT_CQHC"):
                        {
                            Response<DTO_BM_02_FILE_CQHC> response = new Response<DTO_BM_02_FILE_CQHC>();
                            response.Data = _serviceBM_02TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_03TT_CQHC"):
                        {
                            Response<DTO_BM_03_FILE_CQHC> response = new Response<DTO_BM_03_FILE_CQHC>();
                            response.Data = _serviceBM_03TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_04TT_CQHC"):
                        {
                            Response<DTO_BM_04_FILE_CQHC> response = new Response<DTO_BM_04_FILE_CQHC>();
                            response.Data = _serviceBM_04TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_05TT_CQHC"):
                        {
                            Response<DTO_BM_05_FILE_CQHC> response = new Response<DTO_BM_05_FILE_CQHC>();
                            response.Data = _serviceBM_05TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_06TT_CQHC"):
                        {
                            Response<DTO_BM_06_FILE_CQHC> response = new Response<DTO_BM_06_FILE_CQHC>();
                            response.Data = _serviceBM_06TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_07TT_CQHC"):
                        {
                            Response<DTO_BM_07_FILE_CQHC> response = new Response<DTO_BM_07_FILE_CQHC>();
                            response.Data = _serviceBM_07TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                    case ("TEMPLATE_BM_08TT_CQHC"):
                        {
                            Response<DTO_BM_08_FILE_CQHC> response = new Response<DTO_BM_08_FILE_CQHC>();
                            response.Data = _serviceBM_08TT_CQHC.GetDataReport(fileName, fileNamePk);
                            return Ok(response);
                        }
                }
            }
            catch(Exception ex)
            {            
              
            }
            return NotFound();
        }
    }
}