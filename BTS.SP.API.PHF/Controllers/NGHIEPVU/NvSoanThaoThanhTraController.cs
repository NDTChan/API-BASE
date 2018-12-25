﻿using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.SoanThaoNoiDungThanhTraBo;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.NV.ThuMucFile;
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
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvSoanThao")]
    [Route("{id?}")]
    [Authorize]
    public class NvSoanThaoThanhTraController : ApiController
    {
        public readonly INV_SOANTHAO_THANHTRAService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public readonly ITHUMUCFILEService _serviceThuMuc;

        public NvSoanThaoThanhTraController(IUnitOfWorkAsync UnitOfWorkAsync, INV_SOANTHAO_THANHTRAService service, ITHUMUCFILEService serviceThuMuc)
        {
            _service = service;
            _unitOfWorkAsync = UnitOfWorkAsync;
            _serviceThuMuc = serviceThuMuc;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvSoanThao")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_SOANTHAO_THANHTRA>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_SOANTHAO_THANHTRAVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_SOANTHAO_THANHTRA>>();

            try
            {
                var listSoanThao = _service.Queryable().ToList();
            }
            catch (Exception ex)
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
        [CustomAuthorize(Method = "THEM", State = "phf_nvSoanThao")]
        public async Task<IHttpActionResult> Post(PHF_SOANTHAO_THANHTRA model)
        {
            Response<PHF_SOANTHAO_THANHTRA> response = new Response<PHF_SOANTHAO_THANHTRA>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.MA_PHIEU == model.MA_PHIEU).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Mã phiếu đã tồn tại !";
                    }
                    else
                    {
                        model.ObjectState = ObjectState.Added;
                        string prefix = "ST";
                        model.MA_PHIEU = _service.BuildCodeWithParameter(prefix, "MaPhieu", true);
                        _service.Insert(model);
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = false;
                            response.Message = "Thêm mới thành công.";
                        }
                        else
                        {
                            response.Error = true;
                            response.Message = "Lỗi thêm mới dữ liệu.";
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
        [CustomAuthorize(Method = "SUA", State = "phf_nvSoanThao")]
        public async Task<IHttpActionResult> Put(string id, PHF_SOANTHAO_THANHTRA model)
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
        [CustomAuthorize(Method = "XOA", State = "phf_nvSoanThao")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_SOANTHAO_THANHTRA item = await _service.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);
                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Xóa thành công.";
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi xóa dữ liệu.";
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
        public async Task<IHttpActionResult> GetNewInstance(PHF_SOANTHAO_THANHTRA model)
        {
            var result = new TransferObj();
            model.MA_PHIEU = _service.BuildCodeWithParameter("ST", "MaPhieu", false);
            if (model.MA_PHIEU == null)
            {
                result.Data = null;
                result.Status = false;
            }
            else
            {
                result.Data = model.MA_PHIEU;
                result.Status = true;
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
                    tmf.ObjectState = ObjectState.Added;
                    tmf.SO_PHIEU = _serviceThuMuc.BuildCodeWithParameter("ST", "MAPHIEU", true);
                    _serviceThuMuc.Insert(tmf);
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        response.Error = true;
                        response.Message = "Thêm mới thành công";
                    }
                    else
                    {
                        response.Error = false;
                        response.Message = "Lỗi cập nhật dữ liệu";
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

        [HttpPost]
        [Route("UpdateThuMucFile")]

        public async Task<IHttpActionResult> UpdateThuMucFile(PHF_THUMUC_FILE utmf)
        {
            Response<string> response = new Response<string>();
            if (ModelState.IsValid)
            {
                try
                {
                    var sophieu = utmf.SO_PHIEU;
                    var found = _serviceThuMuc.Queryable().FirstOrDefault(x => x.SO_PHIEU == sophieu);
                    if (found != null)
                    {
                        found.SO_PHIEU = utmf.SO_PHIEU;
                        found.URL = utmf.URL;
                        found.ObjectState = ObjectState.Modified;
                        _serviceThuMuc.Update(found);
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = true;
                            response.Message = "Cập nhập thành công";
                        }
                        else
                        {
                            response.Error = false;
                            response.Message = "Lỗi cập nhật dữ liệu";
                        }
                    }
                    else
                    {
                        return BadRequest("Lỗi cập nhật dữ liệu");
                    }

                }
                catch(Exception ex)
                {
                    WriteLogs.LogError(ex);
                    response.Error = false;
                    response.Message = ex.Message;
                }
                return Ok(response);
            }
            return BadRequest(ModelState);
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
            var path = httpRequest.MapPath("~/UploadFile/" + madbhc + "/SoanThao/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day + "");
            Directory.CreateDirectory(path);
            if (httpRequest.Files.Count > 0)
            {
                string fileName = "" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day
                                    + DateTime.Today.Hour + DateTime.Today.Minute + DateTime.Today.Second
                                    + "_" + httpRequest.Files[0].FileName.Replace(" ", "_");
                try
                {
                    httpRequest.Files[0].SaveAs(path + "/" + fileName + "");
                    response.Data = "/UploadFile/" + madbhc + "/SoanThao/" + DateTime.Today.Year + "/" +
                                    DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + fileName;
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