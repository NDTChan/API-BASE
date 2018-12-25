using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.SERVICE;
using BTS.SP.PHF.SERVICE.AUTH.Shared;
using BTS.SP.PHF.SERVICE.UTILS;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Ef6;

namespace BTS.SP.PHF.SERVICE.UTILS
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string State { get; set; }
        public string Method { get; set; }
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                var response = new System.Net.Http.HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Content = new StringContent("Không có quyền truy cập dữ liệu.")
                };
                actionContext.Response = response;
            }
        }

        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var username = actionContext.RequestContext.Principal.Identity.Name;
            var authorize = base.IsAuthorized(actionContext);
            if (username.StartsWith("admin") && authorize) return true;

            var check = false;
            var roleState = Get("F", username, State);
            if (!string.IsNullOrEmpty(roleState?.STATE))
            {
                switch (Method)
                {
                    case "XEM":
                        if (roleState.View) check = true;
                        break;
                    case "SUA":
                        if (roleState.Edit) check = true;
                        break;
                    case "THEM":
                        if (roleState.Add) check = true;
                        break;
                    case "XOA":
                        if (roleState.Delete) check = true;
                        break;
                    case "DUYET":
                        if (roleState.Approve) check = true;
                        break;
                }
            }
            if (!authorize || !check) return false;
            return true;

        }

        private RoleState Get(string phanhe, string username, string machucnang)
        {
            var roleState = new RoleState();
            if (username.StartsWith("admin"))
            {
                roleState = new RoleState()
                {
                    Approve = true,
                    Delete = true,
                    Add = true,
                    STATE = "all",
                    Edit = true,
                    View = true
                };
            }
            else
            {
                var cacheData = MemoryCacheHelper.GetValue(phanhe + "|" + username + "|" + machucnang);
                if (cacheData == null)
                {
                    using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                    {
                        connection.Open();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText =
                                @"SELECT XEM,THEM,SUA,XOA,DUYET FROM AU_NHOMQUYEN_CHUCNANG WHERE PHANHE='" + phanhe + "' AND MACHUCNANG='" + machucnang +
                                "' AND MANHOMQUYEN IN (SELECT MANHOMQUYEN FROM AU_NGUOIDUNG_NHOMQUYEN WHERE PHANHE='" + phanhe + "' AND USERNAME='" +
                                username + "') UNION SELECT AU_NGUOIDUNG_QUYEN.XEM,AU_NGUOIDUNG_QUYEN.THEM,AU_NGUOIDUNG_QUYEN.SUA,AU_NGUOIDUNG_QUYEN.XOA,AU_NGUOIDUNG_QUYEN.DUYET " +
                                "FROM AU_NGUOIDUNG_QUYEN WHERE AU_NGUOIDUNG_QUYEN.PHANHE='" + phanhe + "' AND AU_NGUOIDUNG_QUYEN.MACHUCNANG='" + machucnang + "' AND AU_NGUOIDUNG_QUYEN.USERNAME='" + username + "'";
                            using (var oracleDataReader = command.ExecuteReader())
                            {
                                if (!oracleDataReader.HasRows)
                                {
                                    roleState = new RoleState()
                                    {
                                        STATE = string.Empty,
                                        View = false,
                                        Approve = false,
                                        Delete = false,
                                        Add = false,
                                        Edit = false
                                    };
                                }
                                else
                                {
                                    roleState.STATE = machucnang;
                                    while (oracleDataReader.Read())
                                    {
                                        if (oracleDataReader["XEM"].ToString().Equals("1"))
                                        {
                                            roleState.View = true;
                                        }
                                        if (oracleDataReader["THEM"].ToString().Equals("1"))
                                        {
                                            roleState.Add = true;
                                        }
                                        if (oracleDataReader["SUA"].ToString().Equals("1"))
                                        {
                                            roleState.Edit = true;
                                        }
                                        if (oracleDataReader["XOA"].ToString().Equals("1"))
                                        {
                                            roleState.Delete = true;
                                        }
                                        if (oracleDataReader["DUYET"].ToString().Equals("1"))
                                        {
                                            roleState.Approve = true;
                                        }
                                    }
                                    MemoryCacheHelper.Add(phanhe + "|" + username + "|" + machucnang, roleState,DateTimeOffset.Now.AddHours(6));
                                }
                            }
                        }
                    }
                }
                else
                {
                    roleState = (RoleState)cacheData;

                }
            }
            return roleState;
        }
    }
}