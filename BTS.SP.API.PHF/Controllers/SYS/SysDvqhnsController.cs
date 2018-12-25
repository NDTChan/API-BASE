using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.SERVICE.SYS.SysDvqhns;
using BTS.SP.PHF.SERVICE.UTILS;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.UnitOfWork;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Types;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.DM;

namespace BTS.SP.API.PHF.Controllers.SYS
{
    [RoutePrefix("api/sys/sysDvqhns")]
    [Route("{id?}")]
    public class SysDvqhnsController : ApiController
    {
        private readonly ISysDvqhnsService _service;
        private readonly IDM_SYS_TUDIENService _service_SYS_TUDIEN;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public SysDvqhnsController(ISysDvqhnsService service, IUnitOfWorkAsync unitOfWorkAsync, IDM_SYS_TUDIENService service_SYS_TUDIEN)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _service_SYS_TUDIEN = service_SYS_TUDIEN;
        }

        [Route("paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new TransferObj();
            var postData = ((dynamic)jsonData);
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<SysDvqhnsVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<SYS_DVQHNS>>();
            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1
            };
            try
            {
                var filterResult = _service.Filter(filtered, query);
                if (!filterResult.WasSuccessful)
                {
                    return NotFound();
                }
                result.Data = filterResult.Value;
                result.Status = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("pagingForReport")]
        [HttpPost]
        public async Task<IHttpActionResult> PagingForReport(JObject jsonData)
        {
            var result = new Response<PagedObj<SysDvqhnsVm.ViewModel>>();
            try
            {
                var postData = ((dynamic)jsonData);
                var paged = ((JObject)postData.paged).ToObject<PagedObj<SysDvqhnsVm.ViewModel>>();
                var loaiBc = postData.LOAI_BC;
                var maQhnsCha = postData.MA_QHNS_CHA;
                var maQhns = postData.MA_QHNS;
                var minRn = (paged.currentPage - 1) * paged.itemsPerPage;
                var maxRn = minRn + paged.itemsPerPage;
                using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT MA_QHNS FROM AU_NGUOIDUNG WHERE USERNAME='" + RequestContext.Principal.Identity.Name + "'";
                        command.Parameters.Clear();
                        var lstQhns = await command.ExecuteScalarAsync();
                        if (!string.IsNullOrEmpty(lstQhns.ToString()))
                        {
                            var clauseWhere = "";
                            if (loaiBc.ToString().Equals("2"))
                            {
                                clauseWhere += " MA_DVQHNS IN(" + lstQhns + ")";
                                if (maQhns != null && !string.IsNullOrEmpty(maQhns.ToString()))
                                {
                                    clauseWhere += " AND MA_DVQHNS LIKE '" + maQhns + "%'";
                                }
                            }
                            else if (loaiBc.ToString().Equals("3"))
                            {
                                clauseWhere += " MA_DVQHNS_CHA IN(" + lstQhns + ")";
                                if (maQhnsCha!=null && !string.IsNullOrEmpty(maQhnsCha.ToString()))
                                {
                                    clauseWhere += " AND MA_DVQHNS_CHA ='" + maQhnsCha + "'";
                                }
                                if (maQhns !=null && !string.IsNullOrEmpty(maQhns.ToString()))
                                {
                                    clauseWhere += " AND MA_DVQHNS LIKE '" + maQhns + "%'";
                                }
                            }
                            command.CommandText =
                                "SELECT outer.*FROM (SELECT ROWNUM rn,COUNT(*) OVER () RESULT_COUNT,inner2.* FROM (" +
                                "SELECT MA_DVQHNS,TEN_DVQHNS,MA_DVQHNS_CHA,MA_CHUONG FROM SYS_DVQHNS WHERE"
                                + clauseWhere + 
                                " ORDER BY MA_DVQHNS" +
                                ") inner2) outer " +
                                "WHERE outer.rn > " + minRn + " AND outer.rn <=" + maxRn;

                            using (var dataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                            {
                                if (!dataReader.HasRows)
                                {
                                    result.Error = false;
                                    result.Data = new PagedObj<SysDvqhnsVm.ViewModel>()
                                    {
                                        Data = new List<SysDvqhnsVm.ViewModel>(),
                                        itemsPerPage = paged.itemsPerPage,
                                        totalItems = 0,
                                        currentPage = 1,
                                        takeAll = false
                                    };
                                }
                                else
                                {
                                    int totalItems = 0;
                                    var lst = new List<SysDvqhnsVm.ViewModel>();
                                    while (dataReader.Read())
                                    {
                                        totalItems = int.Parse(dataReader["RESULT_COUNT"].ToString());
                                        lst.Add(new SysDvqhnsVm.ViewModel()
                                        {
                                            TEN_QHNS = dataReader["TEN_DVQHNS"].ToString(),
                                            MA_QHNS = dataReader["MA_DVQHNS"].ToString(),
                                            MA_QHNS_CHA = dataReader["MA_DVQHNS_CHA"]?.ToString(),
                                            MA_CHUONG = dataReader["MA_CHUONG"].ToString(),
                                        });
                                    }
                                    result.Error = false;
                                    result.Data = new PagedObj<SysDvqhnsVm.ViewModel>()
                                    {
                                        Data = lst,
                                        itemsPerPage = paged.itemsPerPage,
                                        totalItems = totalItems,
                                        currentPage = paged.currentPage,
                                        takeAll = false
                                    };
                                }
                            }
                        }
                        else
                        {
                            return InternalServerError();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                result.Error = true;
                result.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(result);
        }

        [Route("GetDsDvQhnsByUser")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDsDvQhnsByUser()
        {
            var response = new List<SysDvqhnsVm.ViewModel>();
            try
            {
                using (var connection =
                    new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT MA_QHNS FROM AU_NGUOIDUNG WHERE USERNAME='" + RequestContext.Principal.Identity.Name + "'";
                        command.Parameters.Clear();
                        var lstQhns = await command.ExecuteScalarAsync();
                        if (!string.IsNullOrEmpty(lstQhns.ToString()))
                        {
                            command.CommandText = "SELECT MA_DVQHNS,TEN_DVQHNS,MA_DVQHNS_CHA,MA_CHUONG FROM SYS_DVQHNS WHERE MA_DVQHNS IN("+lstQhns+")";
                            command.Parameters.Clear();
                            using (var dataReader = command.ExecuteReaderAsync())
                            {
                                if (dataReader.Result.HasRows)
                                {
                                    while (dataReader.Result.Read())
                                    {
                                        response.Add(new SysDvqhnsVm.ViewModel()
                                        {
                                            MA_QHNS = dataReader.Result["MA_DVQHNS"].ToString(),
                                            TEN_QHNS = dataReader.Result["TEN_DVQHNS"].ToString(),
                                            MA_QHNS_CHA = dataReader.Result["MA_DVQHNS_CHA"].ToString(),
                                            MA_CHUONG = dataReader.Result["MA_CHUONG"].ToString(),
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
            }
            return Ok(response);
        }

        [Route("GetSelectData")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectData()
        {
            try
            {
                return _service.Queryable().Where(x => x.TRANG_THAI.Equals("A")).Select(x => new ChoiceObj()
                {
                    Value = x.MA_DVQHNS,
                    Text = x.TEN_DVQHNS,
                    Parent = x.MA_DVQHNS_CHA,
                    ExtendValue = x.MA_CHUONG
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("GetSelectDataLoaiNamBat")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectDataLoaiNamBat()
        {
            try
            {
                var a = _service_SYS_TUDIEN.Queryable().Where(x => x.LOAI_TUDIEN.Equals("LOAINAMBAT")).ToList();
                return _service_SYS_TUDIEN.Queryable().Where(x => x.LOAI_TUDIEN.Equals("LOAINAMBAT")).OrderBy(x=>x.TEN_TUDIEN).Select(x => new ChoiceObj()
                {
                    Value = x.MA_TUDIEN,
                    Text = x.TEN_TUDIEN,
                    Parent = x.MA_TUDIEN_CHA,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("GetByMaDvqhns/{maDvhqns}")]
        [HttpGet]
        [Authorize]
        public async Task<IList<SysDvqhnsVm.ViewModel>> GetByMaDvqhns(string maDvhqns)
        {
            if (string.IsNullOrEmpty(maDvhqns)) return new List<SysDvqhnsVm.ViewModel>();
            var lst = new List<SysDvqhnsVm.ViewModel>();
            try
            {
                using (var connection =new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;

                        command.CommandText = "SELECT MA_QHNS FROM AU_NGUOIDUNG WHERE USERNAME='" +
                                              RequestContext.Principal.Identity.Name + "'";
                        command.Parameters.Clear();
                        var lstQhns = await command.ExecuteScalarAsync();
                        if (!string.IsNullOrEmpty(lstQhns.ToString()))
                        {
                            command.CommandText =
                                "SELECT MA_DVQHNS,TEN_DVQHNS,MA_DVQHNS_CHA,MA_CHUONG " +
                                "FROM SYS_DVQHNS WHERE MA_DVQHNS LIKE '"+maDvhqns+"%' AND (MA_DVQHNS IN(" + lstQhns + ") OR MA_DVQHNS_CHA IN(" + lstQhns +
                                "))";
                            command.Parameters.Clear();
                            using (var dataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                            {
                                if (!dataReader.HasRows)
                                {
                                    return null;
                                }
                                while (dataReader.Read())
                                {
                                    lst.Add(new SysDvqhnsVm.ViewModel()
                                    {
                                        TEN_QHNS = dataReader["TEN_DVQHNS"].ToString(),
                                        MA_QHNS = dataReader["MA_DVQHNS"].ToString(),
                                        MA_QHNS_CHA = dataReader["MA_DVQHNS_CHA"]?.ToString(),
                                        MA_CHUONG = dataReader["MA_CHUONG"].ToString(),
                                    });
                                }
                            }
                        }
                        else
                        {
                            return new List<SysDvqhnsVm.ViewModel>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return new List<SysDvqhnsVm.ViewModel>();
            }
            return lst;
        }

        [Route("GetByTenDvqhns")]
        [HttpPost]
        [Authorize]
        public async Task<IList<SysDvqhnsVm.ViewModel>> GetByTenDvqhns(SYS_DVQHNS searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.TEN_DVQHNS)) return new List<SysDvqhnsVm.ViewModel>();
            searchModel.TEN_DVQHNS = searchModel.TEN_DVQHNS.ToLower();
            var lst = new List<SysDvqhnsVm.ViewModel>();
            try
            {
                using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;

                        command.CommandText = "SELECT MA_QHNS FROM AU_NGUOIDUNG WHERE USERNAME='" +
                                              RequestContext.Principal.Identity.Name + "'";
                        command.Parameters.Clear();
                        var lstQhns = await command.ExecuteScalarAsync();
                        if (!string.IsNullOrEmpty(lstQhns.ToString()))
                        {
                            command.CommandText =
                                "SELECT MA_DVQHNS,TEN_DVQHNS,MA_DVQHNS_CHA,MA_CHUONG " +
                                "FROM SYS_DVQHNS WHERE LOWER(TEN_DVQHNS) LIKE '%" + searchModel.TEN_DVQHNS + "%' AND (MA_DVQHNS IN(" + lstQhns + ") OR MA_DVQHNS_CHA IN(" + lstQhns +
                                "))";
                            command.Parameters.Clear();
                            using (var dataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                            {
                                if (!dataReader.HasRows)
                                {
                                    return null;
                                }
                                while (dataReader.Read())
                                {
                                    lst.Add(new SysDvqhnsVm.ViewModel()
                                    {
                                        TEN_QHNS = dataReader["TEN_DVQHNS"].ToString(),
                                        MA_QHNS = dataReader["MA_DVQHNS"].ToString(),
                                        MA_QHNS_CHA = dataReader["MA_DVQHNS_CHA"]?.ToString(),
                                        MA_CHUONG = dataReader["MA_CHUONG"].ToString(),
                                    });
                                }
                            }
                        }
                        else
                        {
                            return new List<SysDvqhnsVm.ViewModel>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return new List<SysDvqhnsVm.ViewModel>();
            }
            return lst;
        }



        [HttpGet]
        [Route("GetAllDBHC")]
        public IHttpActionResult GetAllDBHC()
        {
            Response<List<DM_SYS_TUDIENVm.DM_DBHCVm>> response = new Response<List<DM_SYS_TUDIENVm.DM_DBHCVm>>();
            try
            {
                response.Error = false;
                response.Data = _service.GetAllDBHC();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [Route("PagingLOAI")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> PagingLOAI(JObject jsonData)
        {
            var result = new TransferObj();
            var inputParam = new SysDvqhnsVm.ParamInput();
            inputParam.TableName = "SYS_TUDIEN";
            inputParam.FieldValue = "MA_TUDIEN";
            inputParam.FieldText = "MO_TA";
            inputParam.WhereClause = " AND (FIELDNAME = 'MA_LOAI')";
            try
            {
                result.Data = _service.GetCTMT(jsonData, inputParam);
                result.Status = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("PagingNGANHKT")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> PagingNGANHKT(JObject jsonData)
        {
            var result = new TransferObj();
            var inputParam = new SysDvqhnsVm.ParamInput();
            inputParam.TableName = "DM_NGANHKT";
            inputParam.FieldValue = "MA_NGANHKT";
            inputParam.FieldText = "TEN_NGANHKT";
            inputParam.WhereClause = "";
            try
            {
                result.Data = _service.GetCTMT(jsonData, inputParam);
                result.Status = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("PagingMUC")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> PagingMUC(JObject jsonData)
        {
            var result = new TransferObj();
            var inputParam = new SysDvqhnsVm.ParamInput();
            inputParam.TableName = "DM_MUC";
            inputParam.FieldValue = "MA_MUC";
            inputParam.FieldText = "TEN_MUC";
            inputParam.WhereClause = "";
            try
            {
                result.Data = _service.GetCTMT(jsonData, inputParam);
                result.Status = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("PagingTIEUMUC")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> PagingTIEUMUC(JObject jsonData)
        {
            var result = new TransferObj();
            var inputParam = new SysDvqhnsVm.ParamInput();
            inputParam.TableName = "DM_TIEUMUC";
            inputParam.FieldValue = "MA_TIEUMUC";
            inputParam.FieldText = "TEN_TIEUMUC";
            inputParam.WhereClause = "";
            try
            {
                result.Data = _service.GetCTMT(jsonData, inputParam);
                result.Status = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("PagingCTMT")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "sysDvqhns")]
        public async Task<IHttpActionResult> PagingCTMT(JObject jsonData)
        {
            var result = new TransferObj();
            var inputParam = new SysDvqhnsVm.ParamInput();
            inputParam.TableName = "DM_CTMTQG";
            inputParam.FieldValue = "MA_CTMTQG";
            inputParam.FieldText = "TEN_CTMTQG";
            inputParam.WhereClause = "";
            try
            {
                result.Data = _service.GetCTMT(jsonData, inputParam);
                result.Status = true;
                return Ok(result);
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