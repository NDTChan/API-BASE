using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyen;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Types;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.AUTH
{
    [RoutePrefix("api/auth/AuNhomQuyen")]
    [Route("{id?}")]
    public class AuNhomQuyenController : ApiController
    {
        private readonly IAuNhomQuyenService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly string PHANHE = "F";

        public AuNhomQuyenController(IAuNhomQuyenService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "AuNhomQuyen")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<AU_NHOMQUYEN>>();
            var postData = ((dynamic)jsonData);
            try
            {
                var filtered = ((JObject)postData.filtered).ToObject<FilterObj<AuNhomQuyenVm.Search>>();
                var paged = ((JObject)postData.paged).ToObject<PagedObj<AU_NHOMQUYEN>>();
                var query = new QueryBuilder
                {
                    Take = paged.itemsPerPage,
                    Skip = paged.fromItem - 1,
                    Filter = new QueryFilterLinQ()
                    {
                        Property = ClassHelper.GetProperty(() => new AU_NHOMQUYEN().PHANHE),
                        Method = FilterMethod.EqualTo,
                        Value = PHANHE
                    }
                };
                var filterResult = await _service.FilterAsync(filtered, query);
                if (!filterResult.WasSuccessful)
                {
                    if (filterResult.Logs.Count > 0)
                    {
                        foreach (var ex in filterResult.Logs)
                        {
                            WriteLogs.LogError(ex.Exception);
                        }
                    }
                    return NotFound();
                }
                result.Data = filterResult.Value;
                result.Error = false;
                return Ok(result);
            }
            catch (NullReferenceException ex)
            {
                WriteLogs.LogError(ex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "AuNhomQuyen")]
        public async Task<IHttpActionResult> Post(AU_NHOMQUYEN model)
        {
            if (ModelState.IsValid)
            {
                Response<AU_NHOMQUYEN> response = new Response<AU_NHOMQUYEN>();
                model.ObjectState = ObjectState.Added;
                model.PHANHE = PHANHE;
                _service.Insert(model);
                try
                {
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        var cacheData = MemoryCacheHelper.GetValue("AuNhomQuyen");
                        if (cacheData != null)
                        {
                            Response<List<SelectObject>> lst = (Response<List<SelectObject>>)cacheData;
                            lst.Data.Add(new SelectObject() { Selected = false, Text = model.TENNHOMQUYEN, Value = model.MANHOMQUYEN });
                            MemoryCacheHelper.Add("AuNhomQuyen", lst, DateTimeOffset.Now.AddHours(6));
                        }
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
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }

                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "AuNhomQuyen")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                AU_NHOMQUYEN item = await _service.Queryable().FirstOrDefaultAsync(x=>x.Id == int.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);
                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    var cacheData = MemoryCacheHelper.GetValue("AuNhomQuyen");
                    if (cacheData != null)
                    {
                        Response<List<SelectObject>> lst = (Response<List<SelectObject>>)cacheData;
                        SelectObject data = lst.Data.FirstOrDefault(x => x.Value.Equals(item.MANHOMQUYEN));
                        if (data != null)
                        {
                            lst.Data.Remove(data);
                            MemoryCacheHelper.Add("AuNhomQuyen", lst, DateTimeOffset.Now.AddHours(6));
                        }
                    }
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
                WriteLogs.LogError(ex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "AuNhomQuyen")]
        public async Task<IHttpActionResult> Put(string id, AU_NHOMQUYEN model)
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
                    var cacheData = MemoryCacheHelper.GetValue("AuNhomQuyen");
                    if (cacheData != null)
                    {
                        Response<List<SelectObject>> lst = (Response<List<SelectObject>>)cacheData;
                        SelectObject data = lst.Data.FirstOrDefault(x => x.Value.Equals(model.MANHOMQUYEN));
                        if (data != null)
                        {
                            lst.Data.Remove(data);
                            lst.Data.Add(new SelectObject() { Selected = false, Text = model.TENNHOMQUYEN, Value = model.MANHOMQUYEN });
                            MemoryCacheHelper.Add("AuNhomQuyen", lst, DateTimeOffset.Now.AddHours(6));
                        }
                    }
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
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("getNhomQuyenConfig/{username}")]
        public async Task<IHttpActionResult> GetNhomQuyenConfig(string username)
        {
            var result = await _service.GetNhomQuyenConfigByUsername(PHANHE, username);
            return Ok(result);
        }

        [HttpGet]
        [Route("getSelectData")]
        public async Task<IHttpActionResult> GetSelectData()
        {
            try
            {
                var cacheData = MemoryCacheHelper.GetValue("AuNhomQuyen");
                if (cacheData == null)
                {
                    var data = await _service.Queryable().Where(x => x.TRANGTHAI == 1 && x.PHANHE.Equals(PHANHE))
                        .OrderBy(x => x.MANHOMQUYEN).Select(x =>
                            new SelectObject()
                            {
                                Selected = false,
                                Text = x.MANHOMQUYEN,
                                Value = x.TENNHOMQUYEN
                            }).ToListAsync();
                    MemoryCacheHelper.Add("AuNhomQuyen", data, DateTimeOffset.Now.AddHours(6));
                    return Ok(data);
                }
                return Ok((Response<List<SelectObject>>)cacheData);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
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
