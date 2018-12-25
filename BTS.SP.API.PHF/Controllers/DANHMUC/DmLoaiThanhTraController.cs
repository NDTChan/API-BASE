using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Types;
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
    [RoutePrefix("api/dm/dmLoaiThanhTra")]
    [Route("{id?}")]
    [Authorize]
    public class DmLoaiThanhTraController : ApiController
    {
        public readonly IDM_SYS_TUDIENService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public DmLoaiThanhTraController(IDM_SYS_TUDIENService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_dmLoaiThanhTra")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_SYS_TUDIEN>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<DM_SYS_TUDIENVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_SYS_TUDIEN>>();
            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1,
                Filter = new QueryFilterLinQ()
                {
                    Property = ClassHelper.GetProperty(() => new PHF_SYS_TUDIEN().LOAI_TUDIEN),
                    Method = FilterMethod.EqualTo,
                    Value = SP.PHF.ENTITY.CommonEnum.LOAI_SYS_TUDIEN.LOAITHANHTRA.ToString()
                }
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
        [Route("GetSelectData")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectData()
        {
            try
            {
                return _service.Queryable().Where(x => x.TRANG_THAI == 1 && x.LOAI_TUDIEN.Equals("LOAITHANHTRA")).Select(x => new ChoiceObj()
                {
                    Value = x.MA_TUDIEN,
                    Text = x.TEN_TUDIEN,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }
        [Route("Export")]
        [AllowAnonymous]
        public HttpResponseMessage Export()
        {
            HttpResponseMessage result = null;
            try
            {
                var listLoaiThanhTra = new List<PHF_SYS_TUDIEN>();
                listLoaiThanhTra = _service.Queryable().Where(x => x.LOAI_TUDIEN == SP.PHF.ENTITY.CommonEnum.LOAI_SYS_TUDIEN.LOAITHANHTRA.ToString()).OrderBy(x => x.MA_TUDIEN).ToList();
                DateTime now = DateTime.Now;
                string date = now.ToString("dd-MM-yyyy");
                var urlFile = HttpContext.Current.Server.MapPath("~/UploadFile/ExcelTemp/");
                var filename = urlFile + "LoaiThanhTra_Export_(" + date + ")_TM" + now.Ticks + ".xls";
                if (listLoaiThanhTra.Count > 0)
                {
                    FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                    using (var excelPackage = new ExcelPackage())
                    {
                        excelPackage.Workbook.Properties.Author = "SystemAccount";
                        excelPackage.Workbook.Properties.Title = "LoaiThanhTra_Export";
                        excelPackage.Workbook.Worksheets.Add(date);
                        var workSheet = excelPackage.Workbook.Worksheets[1];
                        string TenSysTuDien = "Loại thanh tra";
                        _service.BindingDataToExcel(TenSysTuDien, workSheet, listLoaiThanhTra);
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
                        result.Content.Headers.ContentDisposition.FileName = "KeHoachThanhTra_Export_(" + DateTime.Now.ToString("dd-MM-yyyy") + ").xls";
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
        [CustomAuthorize(Method = "THEM", State = "phf_dmLoaiThanhTra")]
        public async Task<IHttpActionResult> Post(PHF_SYS_TUDIEN model)
        {
            Response<PHF_SYS_TUDIEN> response = new Response<PHF_SYS_TUDIEN>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.MA_TUDIEN == model.MA_TUDIEN).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Mã loại thanh tra đã tồn tại !";
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
        [CustomAuthorize(Method = "SUA", State = "phf_dmLoaiThanhTra")]
        public async Task<IHttpActionResult> Put(string id, PHF_SYS_TUDIEN model)
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
        [CustomAuthorize(Method = "XOA", State = "phf_dmLoaiThanhTra")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_SYS_TUDIEN item = await _service.FindByIdAsync(long.Parse(id));
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

        [Route("CheckCodeExist/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> CheckCodeExist(string id)
        {
            var result = new TransferObj();
            var instance = _service.Queryable().FirstOrDefault(x => x.MA_TUDIEN == id);
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