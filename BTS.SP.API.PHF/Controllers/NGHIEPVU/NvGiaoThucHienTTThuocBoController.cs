using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienTTThuocBo;
using BTS.SP.PHF.SERVICE.NV.QDPheDuyetThanhTra;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvGiaoThucHienTTThuocBo")]
    [Route("{id?}")]
    [Authorize]
    public class NvGiaoThucHienTTThuocBoController : ApiController
    {
        public readonly IQDGiaoThucHienTTThuocBoService _service;
        public readonly IDM_DONVI_PHONGBANService _serviceDonVi;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvGiaoThucHienTTThuocBoController(IQDGiaoThucHienTTThuocBoService service, IDM_DONVI_PHONGBANService serviceDonVi, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDonVi = serviceDonVi;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("GetAllQuyetDinh")]
        [HttpGet]
        public IHttpActionResult GetAllQuyetDinh()
        {
            var result = new TransferObj<List<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO>>();
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

        [Route("GetAllDonVi")]
        [HttpGet]
        public IHttpActionResult GetAllDonVi()
        {
            var result = new TransferObj<List<PHF_DM_DONVI_PHONGBAN>>();
            var data = _serviceDonVi.Queryable().Where(x => x.MA_CHA.Equals("TTr2")).ToList();
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

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_nvGiaoThucHienTTThuocBo")]
        public async Task<IHttpActionResult> Post(QDGiaoThucHienTTThuocBoVm.DTO model)
        {
            var response = new Response<string>();
            try
            {
                //model.SO_QUYETDINH = _service.BuildCodeWithParameter("QDPDTT_", "QDPDTT", true);
                var found = _service.Queryable().Where(x => x.SO_QUYETDINH == model.SO_QUYETDINH).ToList();
                if (found.Count > 0)
                {
                    response.Error = true;
                    response.Message = "Phiếu đã tồn tại !";
                }
                else
                {
                    PHF_QD_GIAOTHUCHIEN_TT_THUOCBO obj = new PHF_QD_GIAOTHUCHIEN_TT_THUOCBO();
                    obj.SO_QUYETDINH = model.SO_QUYETDINH;
                    obj.NAM_THANHTRA = model.NAM_THANHTRA;
                    obj.NGAY_QUYETDINH = model.NGAY_QUYETDINH;
                    obj.DOT_THANHTRA = model.DOT_THANHTRA;
                    obj.MA_DONVI = model.MA_DONVI;
                    obj.FILE_DINHKEM = model.FILE_DINHKEM;
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        response.Error = false;
                        response.Message = "Thêm thành công.";
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
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvGiaoThucHienTTThuocBo")]
        public async Task<IHttpActionResult> Put(string id, PHF_QD_GIAOTHUCHIEN_TT_THUOCBO model)
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
        [CustomAuthorize(Method = "XOA", State = "phf_nvGiaoThucHienTTThuocBo")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_QD_GIAOTHUCHIEN_TT_THUOCBO item = await _service.FindByIdAsync(long.Parse(id));
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

        [Route("DownloadWord")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvGiaoThucHienTTThuocBo")]
        public string DownloadWord(PHF_QD_GIAOTHUCHIEN_TT_THUOCBO model)
        {
            string fileNameResult = "TEMPLATE_QUYETDINH_GIAO_THANHTRA_THUOCBO.docx";
            string folderServer = @"\Template\";
            string time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss").Replace("/", "-").Replace(" ", "_").Replace(":", "-");
            string filePathResult = HttpContext.Current.Server.MapPath(folderServer);
            var donvi = _serviceDonVi.Queryable().FirstOrDefault(x => x.MA.Equals(model.MA_DONVI));
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
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_DonVi"), donvi.TEN);
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_DonVi"), donvi.TEN);
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

        [Route("defaultFilterWordOnWeb")]
        [HttpGet]
        public async Task<IHttpActionResult> defaultFilterWordOnWeb()
        {
            Response<string> response = new Response<string>();
            try
            {
                string fileNameResult = "TEMPLATE_QUYETDINH_GIAO_THANHTRA_THUOCBO.docx";
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
                    HtmlConverterSettings settings = new HtmlConverterSettings()
                    {
                        PageTitle = "My Page Title"
                    };
                    XElement html = HtmlConverter.ConvertToHtml(doc, settings);
                    response.Message = html.ToString();
                }
            }

            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
            }
            return Ok(response);

        }

        [Route("FilterWordOnWeb")]
        [HttpPost]
        public async Task<IHttpActionResult> FilterWordOnWeb(PHF_QD_GIAOTHUCHIEN_TT_THUOCBO model)
        {
            Response<string> response = new Response<string>();
            try
            {
                string fileNameResult = "TEMPLATE_QUYETDINH_GIAO_THANHTRA_THUOCBO.docx";
                string folderServer = @"\Template\WordResult\";
                string time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss").Replace("/", "-").Replace(" ", "_").Replace(":", "-");
                string filePathResult = HttpContext.Current.Server.MapPath(@"\Template\ContentWordToHtml\");
                var donvi = _serviceDonVi.Queryable().FirstOrDefault(x => x.MA.Equals(model.MA_DONVI));
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
                using (WordprocessingDocument doc = WordprocessingDocument.Open(filePathDes, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;
                    var tmp = model.ICreateDate.Value.Day.ToString();
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_SoQD"), model.SO_QUYETDINH);
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_DonVi"), donvi.TEN);
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_DonVi"), donvi.TEN);
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Ngay_QD"), model.ICreateDate.Value.Day.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Thang_QD"), model.ICreateDate.Value.Month.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam_QD"), model.ICreateDate.Value.Year.ToString());
                    OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Nam"), model.NAM_THANHTRA.ToString());


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
    }
}
