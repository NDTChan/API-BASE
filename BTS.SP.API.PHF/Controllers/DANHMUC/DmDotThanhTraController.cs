using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.DANHMUC
{
    [RoutePrefix("api/dm/phf_dmDotThanhTra")]
    [Route("{id?}")]
    [Authorize]
    public class DmDotThanhTraController : ApiController
    {
        public readonly IDM_DOTTHANHTRAService _service;
        public readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public DmDotThanhTraController(IDM_DOTTHANHTRAService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_dmDotThanhTra")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_DM_DOTTHANHTRA>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<DM_DOTTHANHTRAVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_DM_DOTTHANHTRA>>();
            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1,
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

        [Route("Export")]
        [AllowAnonymous]
        public HttpResponseMessage Export()
        {
            HttpResponseMessage result = null;
            try
            {
                var listDotThanhTra = new List<PHF_DM_DOTTHANHTRA>();
                listDotThanhTra = _service.Queryable().OrderBy(x => x.MA_DOT).ToList();
                DateTime now = DateTime.Now;
                string date = now.ToString("dd-MM-yyyy");
                var urlFile = HttpContext.Current.Server.MapPath("~/UploadFile/ExcelTemp/");
                var filename = urlFile + "DotThanhTra_Export_(" + date + ")_TM" + now.Ticks + ".xls";
                if (listDotThanhTra.Count > 0)
                {
                    FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                    using (var excelPackage = new ExcelPackage())
                    {
                        excelPackage.Workbook.Properties.Author = "SystemAccount";
                        excelPackage.Workbook.Properties.Title = "DotThanhTra_Export";
                        excelPackage.Workbook.Worksheets.Add(date);
                        var workSheet = excelPackage.Workbook.Worksheets[1];
                        _service.BindingDataToExcel(workSheet, listDotThanhTra);
                        excelPackage.SaveAs(fileStream);
                        fileStream.Close();
                    }
                }
                if (!string.IsNullOrEmpty(filename))
                {
                    if (!File.Exists(filename))
                    {
                        result = Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.OK);
                        result.Content = new StreamContent(new FileStream(filename, FileMode.Open, FileAccess.Read));
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        result.Content.Headers.ContentDisposition.FileName = "DotThanhTra_Export_(" + DateTime.Now.ToString("dd-MM-yyyy") + ").xls";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_dmDotThanhTra")]
        public async Task<IHttpActionResult> Post(PHF_DM_DOTTHANHTRA model)
        {
            Response<PHF_DM_DOTTHANHTRA> response = new Response<PHF_DM_DOTTHANHTRA>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.MA_DOT == model.MA_DOT).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Mã đợt thanh tra đã tồn tại !";
                    }
                    else
                    {
                        model.ObjectState = ObjectState.Added;
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
        [CustomAuthorize(Method = "SUA", State = "phf_dmDotThanhTra")]
        public async Task<IHttpActionResult> Put(string id, PHF_DM_DOTTHANHTRA model)
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
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_dmDotThanhTra")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_DM_DOTTHANHTRA item = await _service.FindByIdAsync(long.Parse(id));
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
                    response.Message = "Lỗi cập nhật dữ liệu.";
                }
                return Ok(response);
            }
            catch (FormatException ex)
            {
                WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        [Route("GetSelectData")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectData()
        {
            try
            {
                return _service.Queryable().Where(x => x.TRANG_THAI == 1).Select(x => new ChoiceObj()
                {
                    Value = x.MA_DOT,
                    Text = x.TEN_DOT,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("CheckCodeExist/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> CheckCodeExist (string id)
        {
            var result = new TransferObj();
            var instance = _service.Queryable().FirstOrDefault(x => x.MA_DOT == id);
            if (instance == null)
            {
                result.Data = null;
                result.Status = false;
            }
            else
            {
                result.Data = instance;
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