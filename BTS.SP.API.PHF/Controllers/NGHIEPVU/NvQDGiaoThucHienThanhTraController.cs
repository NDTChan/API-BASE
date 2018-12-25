using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienThanhTra;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json.Linq;
using OpenXmlPowerTools;
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
using System.Xml.Linq;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvQDGiaoThucHienThanhTra")]
    [Route("{id?}")]
    [Authorize]
    public class NvQDGiaoThucHienThanhTraController : ApiController
    {
        public readonly IQDGiaoThucHienThanhTraService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvQDGiaoThucHienThanhTraController(IQDGiaoThucHienThanhTraService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvQDGiaoThucHienThanhTra")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_QD_GIAOTHUCHIEN_THANHTRA>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<QDGiaoThucHienThanhTraVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_QD_GIAOTHUCHIEN_THANHTRA>>();
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
        [CustomAuthorize(Method = "THEM", State = "phf_nvQDGiaoThucHienThanhTra")]
        public async Task<IHttpActionResult> Post(PHF_QD_GIAOTHUCHIEN_THANHTRA model)
        {
            Response<PHF_QD_GIAOTHUCHIEN_THANHTRA> response = new Response<PHF_QD_GIAOTHUCHIEN_THANHTRA>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.SO_QUYETDINH == model.SO_QUYETDINH).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Số quyết định đã tồn tại !";
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
        [CustomAuthorize(Method = "SUA", State = "phf_nvQDGiaoThucHienThanhTra")]
        public async Task<IHttpActionResult> Put(string id, PHF_QD_GIAOTHUCHIEN_THANHTRA model)
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
        [CustomAuthorize(Method = "XOA", State = "phf_nvQDGiaoThucHienThanhTra")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_QD_GIAOTHUCHIEN_THANHTRA item = await _service.FindByIdAsync(long.Parse(id));
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
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        [Route("GetAllQuyetDinh")]
        [HttpGet]
        public IHttpActionResult GetAllQuyetDinh()
        {
            var result = new TransferObj<List<PHF_QD_GIAOTHUCHIEN_THANHTRA>>();
            var data = _service.Queryable().ToList();
            if (data.Count > 0)
            {
                result.Data = data;
                result.Status = true;
                result.Message = "Oke";
            }
            else
            {
                result.Status = false;
                result.Message = "Không có dữ liệu";
            }
            return Ok(result);
        }

        [Route("DownloadWord")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvQDGiaoThucHienThanhTra")]
        public string DownloadWord(PHF_QD_GIAOTHUCHIEN_THANHTRA model)
        {
            string fileNameResult = "TEMPLATE_QUETDINH_GIAO_THANHTRA.docx";
            string folderServer = @"\Template\";
            string time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss").Replace("/", "-").Replace(" ", "_").Replace(":", "-");
            string filePathResult = HttpContext.Current.Server.MapPath(folderServer);
            if (!Directory.Exists(filePathResult))
            {
                Directory.CreateDirectory(filePathResult);
            }
            string resourceTemplate = HttpContext.Current.Server.MapPath(folderServer + "/WordResult/");
            if (!Directory.Exists(resourceTemplate))
            {
                Directory.CreateDirectory(resourceTemplate);
            }
            string filePathSource = resourceTemplate + fileNameResult;
            if (File.Exists(filePathSource))
            {
                byte[] file = File.ReadAllBytes(filePathSource);
                string filePathDes = _service.UploadFile(file, String.Empty, fileNameResult, filePathResult, false);
                try
                {
                    using (WordprocessingDocument document = WordprocessingDocument.Open(filePathDes, true))
                    {
                        if (filePathResult == null)
                        {
                            return null;
                        }
                        MainDocumentPart mainPart = document.MainDocumentPart;
                        var tmp = model.ICreateDate.Value.Day.ToString();
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_SoQD"), model.SO_QUYETDINH);
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Ngay_QD"), model.ICreateDate.Value.Day.ToString());
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Thang_QD"), model.ICreateDate.Value.Month.ToString());
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam_QD"), model.ICreateDate.Value.Year.ToString());
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam"), model.NAM_THANHTRA.ToString());
                        mainPart.Document.Save();
                    }
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                }
                return folderServer + fileNameResult;
            }
            else
            {
                return "NotFound";
            }
        }

        [Route("FilterWordOnWeb")]
        [HttpPost]
        public async Task<IHttpActionResult> FilterWordOnWeb(PHF_QD_GIAOTHUCHIEN_THANHTRA model)
        {
            Response<string> response = new Response<string>();
            try
            {
                string fileNameResult = "TEMPLATE_QUYETDINH_GIAO_THANHTRA.docx";
                string folderServer = @"\Template\WordResult\";
                string time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss").Replace("/", "-").Replace(" ", "_").Replace(":", "-");
                string filePathResult = HttpContext.Current.Server.MapPath(@"\Template\ContentWordToHtml\");
                if (!Directory.Exists(filePathResult))
                {
                    Directory.CreateDirectory(filePathResult);
                }


                string resourceTemplate = HttpContext.Current.Server.MapPath(folderServer);
                if (!Directory.Exists(resourceTemplate))
                {
                    Directory.CreateDirectory(resourceTemplate);
                }
                string filePathSource = resourceTemplate + fileNameResult;
                byte[] file = File.ReadAllBytes(filePathSource);
                string filePathDes = _service.UploadFile(file, String.Empty, fileNameResult, filePathResult, false);
                // response.Message = filePathDes;
                using (WordprocessingDocument doc = WordprocessingDocument.Open(filePathDes, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;
                    var tmp = model.ICreateDate.Value.Day.ToString();
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_SoQD"), model.SO_QUYETDINH);
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Ngay_QD"), model.ICreateDate.Value.Day.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Thang_QD"), model.ICreateDate.Value.Month.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam_QD"), model.ICreateDate.Value.Year.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam"), model.NAM_THANHTRA.ToString());
                    //OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam"), model.NAM_THANHTRA.ToString());
                    mainPart.Document.Save();
                    #region Convert Word To Html
                    HtmlConverterSettings settings = new HtmlConverterSettings()
                    {
                        PageTitle = "My Page Title"
                    };
                    XElement html = HtmlConverter.ConvertToHtml(doc, settings);
                    response.Message = html.ToString();
                    #endregion
                }
            }

            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
            }
            return Ok(response);

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
            var path = httpRequest.MapPath("~/UploadFile/" + madbhc + "/QDGiaoThucHienThanhTra/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day + "");
            Directory.CreateDirectory(path);
            if (httpRequest.Files.Count > 0)
            {
                string fileName = "" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day
                                    + DateTime.Today.Hour + DateTime.Today.Minute + DateTime.Today.Second
                                    + "_" + httpRequest.Files[0].FileName.Replace(" ", "_");
                try
                {
                    httpRequest.Files[0].SaveAs(path + "/" + fileName + "");
                    response.Data = "/UploadFile/" + madbhc + "/QDGiaoThucHienThanhTra/" + DateTime.Today.Year + "/" +
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
    }
}
