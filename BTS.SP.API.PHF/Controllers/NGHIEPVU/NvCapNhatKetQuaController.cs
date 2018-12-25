using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using Newtonsoft.Json.Linq;
using BTS.SP.TOOLS.BuildQuery.Result;
using Repository.Pattern.UnitOfWork;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BTS.SP.PHF.SERVICE.DM;
using static BTS.SP.PHF.SERVICE.NV.CapNhatKetQuaThanhTra.NV_BM_FILE_NSDPVm;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/capNhatKetQuaThanhTra")]
    [Route("{id?}")]
    [Authorize]
    public class NvCapNhatKetQuaController : ApiController
    {
        public readonly INV_BM_FILE_NSDPService _service;
        public readonly INV_BM_01TT_NSDPService _serviceBM_01TT_NSDP;
        public readonly INV_BM_02TT_NSDPService _serviceBM_02TT_NSDP;
        public readonly INV_BM_03TT_NSDPService _serviceBM_03TT_NSDP;
        public readonly INV_BM_05TT_NSDPService _serviceBM_05TT_NSDP;
        public readonly INV_BM_10TT_NSDPService _serviceBM_10TT_NSDP;
        public readonly INV_BM_11TT_NSDPService _serviceBM_11TT_NSDP;
        public readonly INV_BM_12TT_NSDPService _serviceBM_12TT_NSDP;
        public readonly INV_BM_14TT_NSDPService _serviceBM_14TT_NSDP;
        public readonly INV_BM_15TT_NSDPService _serviceBM_15TT_NSDP;
        public readonly INV_BM_16TT_NSDPService _serviceBM_16TT_NSDP;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvCapNhatKetQuaController(INV_BM_FILE_NSDPService service, IUnitOfWorkAsync unitOfWorkAsync, INV_BM_01TT_NSDPService serviceBM_01TT_NSDP, INV_BM_02TT_NSDPService serviceBM_02TT_NSDP, INV_BM_03TT_NSDPService serviceBM_03TT_NSDP, INV_BM_05TT_NSDPService serviceBM_05TT_NSDP, INV_BM_10TT_NSDPService serviceBM_10TT_NSDP, INV_BM_11TT_NSDPService serviceBM_11TT_NSDP, INV_BM_12TT_NSDPService serviceBM_12TT_NSDP, INV_BM_14TT_NSDPService serviceBM_14TT_NSDP, INV_BM_15TT_NSDPService serviceBM_15TT_NSDP, INV_BM_16TT_NSDPService serviceBM_16TT_NSDP)
        {
            _service = service;
            _serviceBM_01TT_NSDP = serviceBM_01TT_NSDP;
            _serviceBM_02TT_NSDP = serviceBM_02TT_NSDP;
            _serviceBM_03TT_NSDP = serviceBM_03TT_NSDP;
            _serviceBM_05TT_NSDP = serviceBM_05TT_NSDP;
            _serviceBM_10TT_NSDP = serviceBM_10TT_NSDP;
            _serviceBM_11TT_NSDP = serviceBM_11TT_NSDP;
            _serviceBM_12TT_NSDP = serviceBM_12TT_NSDP;
            _serviceBM_14TT_NSDP = serviceBM_14TT_NSDP;
            _serviceBM_15TT_NSDP = serviceBM_15TT_NSDP;
            _serviceBM_16TT_NSDP = serviceBM_16TT_NSDP;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("GetPeriodTest")]
        [HttpGet]
        public IHttpActionResult GetPeriodTest()
        {
            var result = new Response<List<DM_DOTTHANHTRAVm.TreeRootModel>>();
            List<DM_DOTTHANHTRAVm.TreeRootModel> data = new List<DM_DOTTHANHTRAVm.TreeRootModel>();
            using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
            {
                connection.Open();
                using (var commandTree = connection.CreateCommand())
                {
                    commandTree.CommandType = CommandType.Text;
                    commandTree.CommandText = string.Format(@"SELECT EXTRACT(YEAR FROM DEN_NGAY) AS YEAR, N'Năm ' || EXTRACT(YEAR FROM DEN_NGAY) AS NAME FROM PHF_DM_DOTTHANHTRA WHERE TRANG_THAI = {0} GROUP BY EXTRACT(YEAR FROM DEN_NGAY)", 1);
                    using (var oracleDataReaderTree = commandTree.ExecuteReader())
                    {
                        if (oracleDataReaderTree.HasRows)
                        {
                            while (oracleDataReaderTree.Read())
                            {
                                DM_DOTTHANHTRAVm.TreeRootModel root = new DM_DOTTHANHTRAVm.TreeRootModel();
                                root.value = oracleDataReaderTree["YEAR"] != null ? oracleDataReaderTree["YEAR"].ToString() : "";
                                root.text = oracleDataReaderTree["NAME"] != null ? oracleDataReaderTree["NAME"].ToString() : "";
                                root.spriteCssClass = "rootfolder";
                                root.expanded = true;
                                using (var commandLeaf = connection.CreateCommand())
                                {
                                    commandLeaf.CommandType = CommandType.Text;
                                    commandLeaf.CommandText = string.Format(@"SELECT MA_DOT,TEN_DOT FROM PHF_DM_DOTTHANHTRA WHERE EXTRACT(YEAR FROM DEN_NGAY) = {0} AND TRANG_THAI = {1}", root.value, 1);
                                    using (var oracleDataReaderLeaf = commandLeaf.ExecuteReader())
                                    {
                                        if (oracleDataReaderLeaf.HasRows)
                                        {
                                            while (oracleDataReaderLeaf.Read())
                                            {
                                                DM_DOTTHANHTRAVm.TreeLeafModel leaf = new DM_DOTTHANHTRAVm.TreeLeafModel();
                                                leaf.value = oracleDataReaderLeaf["MA_DOT"] != null ? oracleDataReaderLeaf["MA_DOT"].ToString() : "";
                                                leaf.text = oracleDataReaderLeaf["TEN_DOT"] != null ? oracleDataReaderLeaf["TEN_DOT"].ToString() : "";
                                                leaf.spriteCssClass = "folder";
                                                leaf.expanded = false;
                                                root.items.Add(leaf);
                                            }
                                        }
                                    }
                                }
                                data.Add(root);
                            }
                        }
                    }
                    if(data.Count > 0)
                    {
                        result.Data = data;
                        result.Error = false;
                        result.Message = "Oke";
                    }
                    else
                    {
                        result.Data = null;
                        result.Error = true;
                        result.Message = "Error";
                    }
                }
            }
            return Ok(result);
        }

        [Route("GetUnitDepartment")]
        [HttpGet]
        public IHttpActionResult GetUnitDepartment()
        {
            var result = new Response<List<DM_DONVI_PHONGBANVm.TreeRootModel>>();
            List<DM_DONVI_PHONGBANVm.TreeRootModel> data = new List<DM_DONVI_PHONGBANVm.TreeRootModel>();
            using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
            {
                connection.Open();
                using (var commandDepartment = connection.CreateCommand())
                {
                    commandDepartment.CommandType = CommandType.Text;
                    commandDepartment.CommandText = string.Format(@"SELECT MA, TEN FROM PHF_DM_DONVI_PHONGBAN WHERE TRANGTHAI = {0} AND MA_CHA IS NULL GROUP BY MA, TEN", 1);
                    using (var dataReaderDepartment = commandDepartment.ExecuteReader())
                    {
                        if (dataReaderDepartment.HasRows)
                        {
                            while (dataReaderDepartment.Read())
                            {
                                DM_DONVI_PHONGBANVm.TreeRootModel root = new DM_DONVI_PHONGBANVm.TreeRootModel();
                                root.value = dataReaderDepartment["MA"] != null ? dataReaderDepartment["MA"].ToString() : "";
                                root.text = dataReaderDepartment["TEN"] != null ? dataReaderDepartment["TEN"].ToString() : "";
                                root.spriteCssClass = "rootfolder";
                                root.expanded = true;
                                using (var commandLeaf = connection.CreateCommand())
                                {
                                    commandLeaf.CommandType = CommandType.Text;
                                    commandLeaf.CommandText = string.Format(@"SELECT MA, TEN FROM PHF_DM_DONVI_PHONGBAN WHERE MA_CHA = '{0}' AND TRANGTHAI = {1} GROUP BY MA, TEN", root.value, 1);
                                    using (var oracleDataReaderLeaf = commandLeaf.ExecuteReader())
                                    {
                                        if (oracleDataReaderLeaf.HasRows)
                                        {
                                            while (oracleDataReaderLeaf.Read())
                                            {
                                                DM_DONVI_PHONGBANVm.TreeLeafModel leaf = new DM_DONVI_PHONGBANVm.TreeLeafModel();
                                                leaf.value = oracleDataReaderLeaf["MA"] != null ? oracleDataReaderLeaf["MA"].ToString() : "";
                                                leaf.text = oracleDataReaderLeaf["TEN"] != null ? oracleDataReaderLeaf["TEN"].ToString() : "";
                                                leaf.spriteCssClass = "folder";
                                                leaf.expanded = true;
                                                using (var commandLevel = connection.CreateCommand())
                                                {
                                                    commandLevel.CommandType = CommandType.Text;
                                                    commandLevel.CommandText = string.Format(@"SELECT MA, TEN FROM PHF_DM_DONVI_PHONGBAN WHERE MA_CHA = '{0}' AND TRANGTHAI = {1} GROUP BY MA, TEN", leaf.value, 1);
                                                    using (var oracleDataReaderLevel = commandLevel.ExecuteReader())
                                                    {
                                                        if (oracleDataReaderLevel.HasRows)
                                                        {
                                                            leaf.items = new List<DM_DONVI_PHONGBANVm.TreeLevelModel>();
                                                            while (oracleDataReaderLevel.Read())
                                                            {
                                                                DM_DONVI_PHONGBANVm.TreeLevelModel level = new DM_DONVI_PHONGBANVm.TreeLevelModel();
                                                                level.value = oracleDataReaderLevel["MA"] != null ? oracleDataReaderLevel["MA"].ToString() : "";
                                                                level.text = oracleDataReaderLevel["TEN"] != null ? oracleDataReaderLevel["TEN"].ToString() : "";
                                                                level.spriteCssClass = "rootfolder";
                                                                level.expanded = false;
                                                                leaf.items.Add(level);
                                                            }
                                                        }
                                                    }
                                                }
                                                root.items.Add(leaf);
                                            }
                                        }
                                    }
                                }
                                data.Add(root);
                            }
                        }
                    }
                    if (data.Count > 0)
                    {
                        result.Data = data;
                        result.Error = false;
                        result.Message = "Oke";
                    }
                    else
                    {
                        result.Data = null;
                        result.Error = true;
                        result.Message = "Error";
                    }
                }
            }
            return Ok(result);
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvNhatKy")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_BM_FILE_NSDP>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_BM_FILE_NSDPVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_BM_FILE_NSDP>>();
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
                string path = HttpContext.Current.Server.MapPath("~") + "Template\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + report + ".xlsx"))
                {
                    result.Status = true;
                    result.Message = "Tải template";
                    result.Data = "\\Template\\" + report + ".xlsx";
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
                        if (REPORT.Equals("TEMPLATE_BM_01TT_NSDP"))
                        {
                            string result = _serviceBM_01TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_02TT_NSDP"))
                        {
                            string result = _serviceBM_02TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_03TT_NSDP"))
                        {
                            string result = _serviceBM_03TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_05TT_NSDP"))
                        {
                            string result = _serviceBM_05TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_10TT_NSDP"))
                        {
                            string result = _serviceBM_10TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_11TT_NSDP"))
                        {
                            string result = _serviceBM_11TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_12TT_NSDP"))
                        {
                            string result = _serviceBM_12TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_14TT_NSDP"))
                        {
                            string result = _serviceBM_14TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_15TT_NSDP"))
                        {
                            string result = _serviceBM_15TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                            if (result.Equals("NotTemplate") || result.Equals("NotWorkSheet") || result.Equals("Error"))
                            {
                                response.Error = true;
                                response.Message = result;
                                return Ok(response);
                            }
                        }
                        else if (REPORT.Equals("TEMPLATE_BM_16TT_NSDP"))
                        {
                            string result = _serviceBM_16TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
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

        [Route("OverWriteReport")]
        [HttpPost]
        public async Task<IHttpActionResult> OverWriteReport()
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
                        var checkExistBM_01TT_NSDP = _serviceBM_01TT_NSDP.Queryable().Where(x => x.MA_FILE.Equals(checkExist.MA_FILE) && x.MA_FILE_PK.Equals(checkExist.MA_FILE_PK) && x.UnitCode.Equals(UNITCODE)).ToList();
                        if (checkExistBM_01TT_NSDP.Count > 0)
                        {
                            foreach (PHF_BM_01TT_NSDP row in checkExistBM_01TT_NSDP)
                            {
                                _serviceBM_01TT_NSDP.Delete(row);
                            }
                        }
                        _service.Delete(checkExist);
                    }
                    _serviceBM_01TT_NSDP.UploadFileReport(httpRequest, currentUser, UNITCODE, REPORT, PERIOD);
                    if (_unitOfWorkAsync.SaveChanges() > 0)
                    {
                        response.Error = false;
                        response.Message = "Overwrited";
                    }
                }
                else
                {
                    response.Error = true;
                    response.Message = "UnitCodeIsNull";
                }
            }
            else
            {
                response.Error = true;
                response.Message = ErrorMessage.EMPTY_DATA;
            }
            return Ok(response);
        }

        [Route("GetDataReport/{fileName}/{fileNamePk}")]
        [HttpGet]
        public IHttpActionResult GetDataReport(string fileName, string fileNamePk)
        {
            Response<DTO_BM_01TT_NSDP> response = new Response<DTO_BM_01TT_NSDP>();
            DTO_BM_01TT_NSDP data = new DTO_BM_01TT_NSDP();
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(fileNamePk))
            {
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
                    var details = _serviceBM_01TT_NSDP.Queryable().Where(x => x.MA_FILE.Equals(fileName) && x.MA_FILE_PK.Equals(fileNamePk)).ToList();
                    if (details.Count > 0)
                    {
                        foreach (var record in details)
                        {
                            PHF_BM_01TT_NSDP_DTO row = new PHF_BM_01TT_NSDP_DTO();
                            row.STT = record.STT;
                            row.STT_TIEUDE = record.STT_TIEUDE;
                            row.STT_CHA = record.STT_CHA;
                            row.MA_FILE = record.MA_FILE;
                            row.MA_FILE_PK = record.MA_FILE_PK;
                            row.NOIDUNG = record.NOIDUNG;
                            row.CONGVIEC = record.CONGVIEC;
                            row.TRANGTHAI_TRIENKHAI = record.TRANGTHAI_TRIENKHAI;
                            row.VANBAN_SAIPHAM = record.VANBAN_SAIPHAM;
                            row.HAUQUA = record.HAUQUA;
                            row.NGUYENNHAN = record.NGUYENNHAN;
                            row.IS_BOLD = record.IS_BOLD;
                            row.IS_ITALIC = record.IS_ITALIC;
                            data.PHF_BM_01TT_NSDP_DTO.Add(row);
                        }
                        response.Error = false;
                        response.Message = "Oke";
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
    }
}