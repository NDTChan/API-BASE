using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
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
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_DVSN.NV_BM_FILE_DVSNVm;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvBaoCaoTTDVSN")]
    [Route("{id?}")]
    [Authorize]
    public class NvBaoCaoTT_DVSNController : ApiController
    {

        public readonly INV_BM_FILE_DVSNService _service;
        public readonly INV_BM_01TT_DVSNService _serviceBM_01TT_DVSN;
        public readonly INV_BM_02TT_DVSNService _serviceBM_02TT_DVSN;
        public readonly INV_BM_03TT_DVSNService _serviceBM_03TT_DVSN;
        public readonly INV_BM_04TT_DVSNService _serviceBM_04TT_DVSN;
        public readonly INV_BM_05TT_DVSNService _serviceBM_05TT_DVSN;
        public readonly INV_BM_06TT_DVSNService _serviceBM_06TT_DVSN;
        public readonly INV_BM_07TT_DVSNService _serviceBM_07TT_DVSN;
        public readonly INV_BM_08TT_DVSNService _serviceBM_08TT_DVSN;
        public readonly INV_BM_09TT_DVSNService _serviceBM_09TT_DVSN;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvBaoCaoTT_DVSNController(INV_BM_FILE_DVSNService service, 
            INV_BM_01TT_DVSNService serviceBM_01TT_DVSN, 
            INV_BM_02TT_DVSNService serviceBM_02TT_DVSN, 
            INV_BM_03TT_DVSNService serviceBM_03TT_DVSN, 
            INV_BM_04TT_DVSNService serviceBM_04TT_DVSN,
            INV_BM_05TT_DVSNService serviceBM_05TT_DVSN, 
            INV_BM_06TT_DVSNService serviceBM_06TT_DVSN,
            INV_BM_07TT_DVSNService serviceBM_07TT_DVSN,
            INV_BM_08TT_DVSNService serviceBM_08TT_DVSN, 
            INV_BM_09TT_DVSNService serviceBM_09TT_DVSN, 
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceBM_01TT_DVSN = serviceBM_01TT_DVSN;
            _serviceBM_02TT_DVSN = serviceBM_02TT_DVSN;
            _serviceBM_03TT_DVSN = serviceBM_03TT_DVSN;
            _serviceBM_04TT_DVSN = serviceBM_04TT_DVSN;
            _serviceBM_05TT_DVSN = serviceBM_05TT_DVSN;
            _serviceBM_06TT_DVSN = serviceBM_06TT_DVSN;
            _serviceBM_07TT_DVSN = serviceBM_07TT_DVSN;
            _serviceBM_08TT_DVSN = serviceBM_08TT_DVSN;
            _serviceBM_09TT_DVSN = serviceBM_09TT_DVSN;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvBaoCaoTTDVSN")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_BM_FILE_DVSN>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_BM_FILE_DVSNVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_BM_FILE_DVSN>>();
            var query = new TOOLS.BuildQuery.Implimentations.QueryBuilder
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

        [Route("GetUrlDownloadTemplate/{report}")]
        [HttpGet]
        public IHttpActionResult GetUrlDownloadTemplate(string report)
        {
            var result = new TransferObj<string>();
            if (!string.IsNullOrEmpty(report))
            {
                string path = HttpContext.Current.Server.MapPath("~") + "Template\\ExcelDVSN\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + report + ".xlsx"))
                {
                    result.Status = true;
                    result.Message = "Tải template";
                    result.Data = "\\Template\\ExcelDVSN\\" + report + ".xlsx";
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
                if (!string.IsNullOrEmpty(UNITCODE))
                {
                    var checkExist = _service.Queryable().FirstOrDefault(x => x.MA_FILE.Equals(REPORT) && x.MA_DOT.Equals(PERIOD) && x.UnitCode.Equals(UNITCODE));
                    if (checkExist != null)
                    {
                        response.Error = true;
                        response.Message = "Existed";
                    }
                    else
                    {
                        if (REPORT.Equals("TEMPLATE_BM_01TT_DVSN"))
                        {
                            string result = _serviceBM_01TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_02TT_DVSN"))
                        {
                            string result = _serviceBM_02TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_03TT_DVSN"))
                        {
                            string result = _serviceBM_03TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_04TT_DVSN"))
                        {
                            string result = _serviceBM_04TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_05TT_DVSN"))
                        {
                            string result = _serviceBM_05TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_06TT_DVSN"))
                        {
                            string result = _serviceBM_06TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_07TT_DVSN"))
                        {
                            string result = _serviceBM_07TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_08TT_DVSN"))
                        {
                            string result = _serviceBM_08TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        if (REPORT.Equals("TEMPLATE_BM_09TT_DVSN"))
                        {
                            string result = _serviceBM_09TT_DVSN.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
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
            Response<DTO_BM_TT_DVSN> response = new Response<DTO_BM_TT_DVSN>();
            DTO_BM_TT_DVSN data = new DTO_BM_TT_DVSN();
            var dto = _service.Queryable().FirstOrDefault(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk));
            if (dto != null)
            {
                data.ID = dto.Id;
                data.MA_FILE = dto.MA_FILE;
                data.MA_FILE_PK = dto.MA_FILE_PK;
                data.TEN_FILE = dto.TEN_FILE;
                data.NAM = dto.NAM;
                data.MA_DOT = dto.MA_DOT;
                data.THOIGIAN = dto.THOIGIAN;
                data.TEN_BIEUMAU = dto.TEN_BIEUMAU;
                data.TIEUDE_BIEUMAU = dto.TIEUDE_BIEUMAU;
            }
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(fileNamePk))
            {
                if (fileName == "TEMPLATE_BM_01TT_DVSN") {
                    var details = _serviceBM_01TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_01TT_DVSN_DTO row = new PHF_BM_01TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_CHI = record.NOIDUNG_CHI;
                            row.THUCTHI_NAM = record.THUCTHI_NAM;
                            row.QUYETTOAN_CHI_NAM = record.QUYETTOAN_CHI_NAM;
                            row.THUCTHI_DUOCGIAO = record.THUCTHI_DUOCGIAO;
                            row.GHICHU = record.GHICHU;
                            data.PHF_BM_01TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_02TT_DVSN")
                {
                    var details = _serviceBM_02TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_02TT_DVSN_DTO row = new PHF_BM_02TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_CHI = record.NOIDUNG_CHI;
                            row.THUCTHI_DUOCGIAO = record.THUCTHI_DUOCGIAO;
                            row.THANHTRA_XACDINH = record.THANHTRA_XACDINH;
                            row.TITLE_NGUYENNHAN = record.TITLE_NGUYENNHAN;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            row.GHICHU = record.GHICHU;
                            data.PHF_BM_02TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_03TT_DVSN")
                {
                    var details = _serviceBM_03TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_03TT_DVSN_DTO row = new PHF_BM_03TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NGUONTHU = record.NGUONTHU;
                            row.THUCTHI_DUOCGIAO = record.THUCTHI_DUOCGIAO;
                            row.THANHTRA_XACDINH = record.THANHTRA_XACDINH;
                            row.TITLE_NGUYENNHAN = record.TITLE_NGUYENNHAN;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            row.GHICHU = record.GHICHU;
                            data.PHF_BM_03TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_04TT_DVSN")
                {
                    var details = _serviceBM_04TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_04TT_DVSN_DTO row = new PHF_BM_04TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_THU = record.NOIDUNG_THU;
                            row.SOTIEN = record.SOTIEN;
                            row.TITLE_NGUYENNHAN = record.TITLE_NGUYENNHAN;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            data.PHF_BM_04TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_05TT_DVSN")
                {
                    var details = _serviceBM_05TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_05TT_DVSN_DTO row = new PHF_BM_05TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.HOTEN = record.HOTEN;
                            row.CHILUONG_SAI_CHEDO = record.CHILUONG_SAI_CHEDO;
                            row.CHIBH_SAI_CHEDO = record.CHIBH_SAI_CHEDO;
                            row.CHITN_SAI_CHEDO = record.CHITN_SAI_CHEDO;
                            row.CHI_KHAC = record.CHI_KHAC;
                            row.GHICHU = record.GHICHU;
                            data.PHF_BM_05TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_06TT_DVSN")
                {
                    var details = _serviceBM_06TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_06TT_DVSN_DTO row = new PHF_BM_06TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_CHI = record.NOIDUNG_CHI;
                            row.SOTIEN = record.SOTIEN;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            row.TITLE_NGUYENNHAN = record.TITLE_NGUYENNHAN;
                            data.PHF_BM_06TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_07TT_DVSN")
                {
                    var details = _serviceBM_07TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_07TT_DVSN_DTO row = new PHF_BM_07TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG = record.NOIDUNG;
                            row.BAOCAO_DONVI = record.BAOCAO_DONVI;
                            row.THANHTRA_XACDINH = record.THANHTRA_XACDINH;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            data.PHF_BM_07TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_08TT_DVSN")
                {
                    var details = _serviceBM_08TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_08TT_DVSN_DTO row = new PHF_BM_08TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG_CHI = record.NOIDUNG_CHI;
                            row.SOTIEN = record.SOTIEN;
                            row.NGUYENNHAN_TRICH_CAOHON = record.NGUYENNHAN_TRICH_CAOHON;
                            row.NGUYENNHAN_TRICH_SAINGUON = record.NGUYENNHAN_TRICH_SAINGUON;
                            row.NGUYENNHAN_TRICH_SAI_TYLE = record.NGUYENNHAN_TRICH_SAI_TYLE;
                            data.PHF_BM_08TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
                }
                else if (fileName == "TEMPLATE_BM_09TT_DVSN")
                {
                    var details = _serviceBM_09TT_DVSN.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_09TT_DVSN_DTO row = new PHF_BM_09TT_DVSN_DTO();
                            row.ID = record.Id;
                            row.STT = record.STT;
                            row.MA_DONVI = record.MA_DONVI;
                            row.THOI_KY = record.THOI_KY;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.HOTEN = record.HOTEN;
                            row.SOLIEU_DV_CHIUTHUE = record.SOLIEU_DV_CHIUTHUE;
                            row.SOLIEU_DV_PHAINOP = record.SOLIEU_DV_PHAINOP;
                            row.THANHTRA_DV_CHIUTHUE = record.THANHTRA_DV_CHIUTHUE;
                            row.THANHTRA_DV_PHAINOP = record.THANHTRA_DV_PHAINOP;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            data.PHF_BM_09TT_DVSN_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Ok";
                        response.Data = data;
                    }
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

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvBaoCaoTTDVSN")]
        public async Task<IHttpActionResult> Put(string id, JObject model)
        {
            Response<string> response = new Response<string>();
            try
            {
                var postData = (dynamic)model;
                var cha = ((JObject)postData).ToObject<PHF_BM_01TT_DVSN>();
                if (cha.MA_FILE.Equals("TEMPLATE_BM_01TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_01TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_01TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG_CHI = bm.NOIDUNG_CHI;
                        tmp.THUCTHI_NAM = bm.THUCTHI_NAM;
                        tmp.QUYETTOAN_CHI_NAM = bm.QUYETTOAN_CHI_NAM;
                        tmp.THUCTHI_DUOCGIAO = bm.THUCTHI_DUOCGIAO;
                        tmp.GHICHU = bm.GHICHU;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_01TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_02TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_02TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_02TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG_CHI = bm.NOIDUNG_CHI;
                        tmp.THUCTHI_DUOCGIAO = bm.THUCTHI_DUOCGIAO;
                        tmp.THANHTRA_XACDINH = bm.THANHTRA_XACDINH;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.GHICHU = bm.GHICHU;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_02TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_03TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_03TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_03TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NGUONTHU = bm.NGUONTHU;
                        tmp.THUCTHI_DUOCGIAO = bm.THUCTHI_DUOCGIAO;
                        tmp.THANHTRA_XACDINH = bm.THANHTRA_XACDINH;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.GHICHU = bm.GHICHU;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_03TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_04TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_04TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_04TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG_THU = bm.NOIDUNG_THU;
                        tmp.SOTIEN = bm.SOTIEN;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_04TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_05TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_05TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_05TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.HOTEN = bm.HOTEN;
                        tmp.CHILUONG_SAI_CHEDO = bm.CHILUONG_SAI_CHEDO;
                        tmp.CHIBH_SAI_CHEDO = bm.CHIBH_SAI_CHEDO;
                        tmp.CHITN_SAI_CHEDO = bm.CHITN_SAI_CHEDO;
                        tmp.CHI_KHAC = bm.CHI_KHAC;
                        tmp.GHICHU = bm.GHICHU;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_05TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_06TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_06TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_06TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG_CHI = bm.NOIDUNG_CHI;
                        tmp.SOTIEN = bm.SOTIEN;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_06TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_07TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_07TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_07TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG = bm.NOIDUNG;
                        tmp.BAOCAO_DONVI = bm.BAOCAO_DONVI;
                        tmp.THANHTRA_XACDINH = bm.THANHTRA_XACDINH;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_07TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_08TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_08TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_08TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.NOIDUNG_CHI = bm.NOIDUNG_CHI;
                        tmp.SOTIEN = bm.SOTIEN;
                        tmp.NGUYENNHAN_TRICH_CAOHON = bm.NGUYENNHAN_TRICH_CAOHON;
                        tmp.NGUYENNHAN_TRICH_SAINGUON = bm.NGUYENNHAN_TRICH_SAINGUON;
                        tmp.NGUYENNHAN_TRICH_SAI_TYLE = bm.NGUYENNHAN_TRICH_SAI_TYLE;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_08TT_DVSN.Update(tmp);
                    }
                }
                if (cha.MA_FILE.Equals("TEMPLATE_BM_09TT_DVSN"))
                {
                    var paged = ((JArray)postData.DataDetails).ToObject<List<PHF_BM_09TT_DVSN>>();
                    foreach (var bm in paged)
                    {
                        var tmp = _serviceBM_09TT_DVSN.Queryable().FirstOrDefault(x => x.Id.Equals(bm.Id));
                        tmp.HOTEN = bm.HOTEN;
                        tmp.SOLIEU_DV_CHIUTHUE = bm.SOLIEU_DV_CHIUTHUE;
                        tmp.SOLIEU_DV_PHAINOP = bm.SOLIEU_DV_PHAINOP;
                        tmp.THANHTRA_DV_CHIUTHUE = bm.THANHTRA_DV_CHIUTHUE;
                        tmp.THANHTRA_DV_PHAINOP = bm.THANHTRA_DV_PHAINOP;
                        tmp.NGUYENNHAN = bm.NGUYENNHAN;
                        tmp.ObjectState = ObjectState.Modified;
                        _serviceBM_09TT_DVSN.Update(tmp);
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

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_nvBaoCaoTTDVSN")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_BM_FILE_DVSN item = await _service.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);

                switch (item.MA_FILE)
                {
                    case "TEMPLATE_BM_01TT_DVSN":
                        var details_BM01 = _serviceBM_01TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM01)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_01TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_02TT_DVSN":
                        var details_BM02 = _serviceBM_02TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM02)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_02TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_03TT_DVSN":
                        var details_BM03 = _serviceBM_03TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM03)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_03TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_04TT_DVSN":
                        var details_BM04 = _serviceBM_04TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM04)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_04TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_05TT_DVSN":
                        var details_BM05 = _serviceBM_05TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM05)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_05TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_06TT_DVSN":
                        var details_BM06 = _serviceBM_06TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM06)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_06TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_07TT_DVSN":
                        var details_BM07 = _serviceBM_07TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM07)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_07TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_08TT_DVSN":
                        var details_BM08 = _serviceBM_08TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM08)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_08TT_DVSN.Delete(itemDetail);
                        }
                        break;
                    case "TEMPLATE_BM_09TT_DVSN":
                        var details_BM09 = _serviceBM_09TT_DVSN.Queryable().Where(x => x.MA_FILE_PK.Equals(item.MA_FILE_PK)).ToList();
                        foreach (var itemDetail in details_BM09)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceBM_09TT_DVSN.Delete(itemDetail);
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
    }
}
