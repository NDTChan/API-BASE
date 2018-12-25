using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV;
using BTS.SP.PHF.SERVICE.NV.ThuMucFile;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvNhatKy")]
    [Route("{id?}")]
    [Authorize]
    public class NvNhatKyController : ApiController
    {
        public readonly INV_TTB_NHATKYService _service;
        public readonly ITHUMUCFILEService _serviceThuMuc;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvNhatKyController(INV_TTB_NHATKYService service, ITHUMUCFILEService serviceThuMuc, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceThuMuc = serviceThuMuc;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        //public NvNhatKyController(INV_TTB_NHATKYService service, IUnitOfWorkAsync unitOfWorkAsync)
        //{
        //    _service = service;
        //    _unitOfWorkAsync = unitOfWorkAsync;
        //}
        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvNhatKy")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_TTB_NHATKY>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_TTB_NHATKYVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_TTB_NHATKY>>();
            
            try
            {
                var listNhatKy = _service.Queryable().ToList();
            }
            catch(Exception ex)
            {

            }
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

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_nvNhatKy")]
        public async Task<IHttpActionResult> Post(PHF_TTB_NHATKY model)
        {           
            Response<PHF_TTB_NHATKY> response = new Response<PHF_TTB_NHATKY>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.SO_PHIEU == model.SO_PHIEU).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Số phiếu đã tồn tại !";
                    }
                    else
                    {
                        model.ObjectState = ObjectState.Added;                     
                        string prefix = "NK";
                        model.SO_PHIEU = _service.BuildCodeWithParameter(prefix, "SoPhieu", true);
                        _service.Insert(model);                                            
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = false;
                            response.Message = "Cập nhật thành công.";
                        }
                        else
                        {
                            response.Error = true;
                            response.Message = "Lỗi cập nhật dữ liệu.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }

                return Ok(response);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvNhatKy")]
        public async Task<IHttpActionResult> Put(string id, PHF_TTB_NHATKY model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id) || !id.Equals(model.Id.ToString())) return BadRequest();
            model.ObjectState = ObjectState.Modified;
            _service.Update(model);
            Response<string> response = new Response<string>();
            try
            {
                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Cập nhật thành công.";
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi cập nhật dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_nvNhatKy")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_TTB_NHATKY item = await _service.FindByIdAsync(long.Parse(id));
                var itemThuMuc = _serviceThuMuc.Queryable().SingleOrDefault(x => x.SO_PHIEU == item.SO_PHIEU);
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                itemThuMuc.ObjectState = ObjectState.Deleted;
                _service.Delete(item);
                _serviceThuMuc.Delete(itemThuMuc);
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
            catch (FormatException ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        [Route("GetNewInstance")]
        [HttpPost]
        public async Task<IHttpActionResult> GetNewInstance(PHF_TTB_NHATKY model)
        {
            var result = new TransferObj();
            model.SO_PHIEU = _service.BuildCodeWithParameter("NK", "SoPhieu", false);
            if (model.SO_PHIEU == null)
            {
                result.Data = null;
                result.Status = false;
            }
            else
            {
                result.Data = model.SO_PHIEU;
                result.Status = true;
            }
            return Ok(result);
        }



        [Route("UploadReportFile")]
        [HttpPost]
        public async Task<IHttpActionResult> UploadReportFile()
        {
            string madbhc = "NO_CODE_LOCATION";
            if (HttpContext.Current != null && HttpContext.Current.User is ClaimsPrincipal)
            {
                var currentUser = (HttpContext.Current.User as ClaimsPrincipal);
                var unit = currentUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country);
                if (unit != null)
                {
                    madbhc = unit.Value;
                }
            }
            Response<string> response = new Response<string>();
            var httpRequest = HttpContext.Current.Request;
            var path = httpRequest.MapPath("~/UploadFile/" + madbhc + "/NhatKy/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day + "");
            Directory.CreateDirectory(path);
            if (httpRequest.Files.Count > 0)
            {
                string fileName = "" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day
                                    + DateTime.Today.Hour + DateTime.Today.Minute + DateTime.Today.Second
                                    + "_" + httpRequest.Files[0].FileName.Replace(" ", "_");
                try
                {
                    httpRequest.Files[0].SaveAs(path + "/" + fileName + "");
                    response.Data = "/UploadFile/" + madbhc + "/NhatKy/" + DateTime.Today.Year + "/" +
                                    DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + fileName;
                    response.Message = httpRequest.Files[0].FileName.Replace(" ", "_");
                }
                catch (Exception ex)
                {
                    response.Error = true;
                    response.Message = "Đã xảy ra lỗi";
                }
            }
            else
            {
                response.Error = true;
                response.Message = "Dữ liệu trống";
            }
            return Ok(response);
        }

        [Route("GetUrlDownloadTemplate/{SO_PHIEU}")]
        [HttpGet]
        public IHttpActionResult GetUrlDownloadTemplate(string SO_PHIEU)
        {
            var result = new TransferObj<string>();
            var pathThuMuc = _serviceThuMuc.Queryable().SingleOrDefault(x => x.SO_PHIEU == SO_PHIEU).URL;
            if (!string.IsNullOrEmpty(pathThuMuc))
            {
                string path = HttpContext.Current.Server.MapPath("~");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + pathThuMuc))
                {
                    result.Status = true;
                    result.Message = "Tải template";
                    result.Data = pathThuMuc;
                }
                else
                {
                    result.Status = false;
                    result.Message = "Không tồn tại Template  '" + pathThuMuc + "'";
                }
            }
            else
            {
                result.Status = false;
                result.Message = "Tham số template không đúng";
            }
            return Ok(result);
        }
      
        [Route("InsertThuMucFile")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertThuMucFile(PHF_THUMUC_FILE tmf)
        {
            Response<string> response = new Response<string>();
            if (ModelState.IsValid)
            {
                try
                {
                    //var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                    tmf.ObjectState = ObjectState.Added;                   
                    _serviceThuMuc.Insert(tmf);
                    _unitOfWorkAsync.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }
                return Ok(response);
            }
            return BadRequest(ModelState);        
        }
        [Route("EditThuMucFile")]
        [HttpPut]
        public async Task<IHttpActionResult> EditThuMucFile(PHF_THUMUC_FILE tmf)
        {
            Response<string> response = new Response<string>();
            if (ModelState.IsValid)
            {
                try
                {
                    //var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                    tmf.ObjectState = ObjectState.Modified;
                    _serviceThuMuc.Update(tmf);
                    _unitOfWorkAsync.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [Route("GetThuMucFileBySoPhieu/{SOPHIEU}")]
        public async Task<IHttpActionResult> GetThuMucFileBySoPhieu(string SOPHIEU)
        {
            Response<int> response = new Response<int>();
            var ID = _serviceThuMuc.Queryable().SingleOrDefault(x => x.SO_PHIEU == SOPHIEU).Id;
            if (ModelState.IsValid)
            {
                try
                {
                    response.Data = ID;
                    response.Error = false;
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }
                return Ok(response);
            }
            return BadRequest(ModelState);
        }


        [Route("DeleleThuMucFile")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleleThuMucFile(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_THUMUC_FILE item = await _serviceThuMuc.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _serviceThuMuc.Delete(item);
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
            catch (FormatException ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }
        [Route("GetLinkDownload")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLinkDownload(PHF_THUMUC_FILE model)
        {
            var result = new TransferObj();
            var link = _serviceThuMuc.Queryable().SingleOrDefault(x => x.SO_PHIEU == model.SO_PHIEU);
            if (link == null)
            {
                result.Data = null;
                result.Status = false;
            }
            else
            {
                result.Data = link;
                result.Status = true;
            }
            return Ok(result);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
   