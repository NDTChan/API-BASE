using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.PHF.SERVICE.SERVICES;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace BTS.SP.API.PHF.Controllers.DANHMUC
{
    [RoutePrefix("api/dm/phf_dmCanBo")]
    [Route("{id?}")]
    [Authorize]
    public class DmCanBoController:ApiController
    {
        public readonly IDM_CANBOService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public DmCanBoController(IDM_CANBOService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;  
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_dmCanBo")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_DM_CANBO>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<DM_CANBOVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_DM_CANBO>>();
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

        [Route("CheckCodeExist/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> CheckCodeExist(string id)
        {
            var result = new TransferObj();
            var instance = _service.Queryable().FirstOrDefault(x => x.MA_CANBO == id);
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

        [HttpPost]  
        [CustomAuthorize(Method = "THEM", State = "phf_dmCanBo")]
        public async Task<IHttpActionResult> Post(PHF_DM_CANBO model)
        {
            Response<PHF_DM_CANBO> response = new Response<PHF_DM_CANBO>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.MA_CANBO == model.MA_CANBO).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Mã cán bộ đã tồn tại !";
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

        [Route("GetCanBoByPhongBan/{maPhongBan}")]
        [HttpGet]
        public IHttpActionResult GetCanBoByPhongBan()
        {
            //if (string.IsNullOrEmpty(maDuAn)) return BadRequest();
            List<ChoiceObj> lstObj = new List<ChoiceObj>();
            var response = new Response<List<ChoiceObj>>();
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.OpenAsync();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = @"SELECT MA, TEN
                                                FROM PHF_DM_DONVI_PHONGBAN
                                               ";
                        OracleDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ChoiceObj obj = new ChoiceObj();
                                obj.Id = int.Parse(reader["ID"].ToString());
                                obj.Value = reader["MA"] != null ? reader["MA"].ToString() : "";
                                obj.Text = reader["TEN"] != null ? reader["TEN"].ToString() : "";
                                lstObj.Add(obj);
                            }
                        }
                    }
                    response.Data = lstObj;
                    response.Error = false;
                }
            }
            catch
            {
                response.Data = null;
                response.Error = true;
            }
            return Ok(response);
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_dmCanBo")]
        public async Task<IHttpActionResult> Put(string id, PHF_DM_CANBO model)
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
        [CustomAuthorize(Method = "XOA", State = "phf_dmChucVu")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_DM_CANBO item = await _service.FindByIdAsync(long.Parse(id));
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
        [Route("GetSelectData")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectData()
        {
            try
            {
                return _service.Queryable().Where(x => x.TRANG_THAI == 1).Select(x => new ChoiceObj()
                {
                    Value = x.MA_CANBO,
                    Text = x.TEN_CANBO,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }
        [Route("GetTestHtml")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTestHtml()
        {
            Response<string> response = new Response<string>();
            try
            {
                string fileNameResult = "TEMPLATE_QUYETDINH_PHEDUYET_THANHTRA.docx";
                string folderServer = @"\Template\";
                string time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss").Replace("/", "-").Replace(" ", "_").Replace(":", "-");
                string filePathResult = HttpContext.Current.Server.MapPath(folderServer);
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
                        OpenXmlUtils.AddTextToSdt(OpenXmlUtils.WDGetContentControl(mainPart, "Fi_SoQD"), "Thanks");
                        mainPart.Document.Save(); 
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
    }
}