using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDung;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Oracle.ManagedDataAccess.Client;

namespace BTS.SP.API.PHF.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var user = new AuNguoiDungVm.ViewModel();
                using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText =
                            "SELECT USERNAME,FULLNAME,PHONE,EMAIL,MA_DBHC,MA_QHNS,CHUCVU,MA_DONVI FROM AU_NGUOIDUNG WHERE USERNAME=:username AND PASSWORD=:password AND TRANGTHAI = 1";
                        command.Parameters.Add("username", OracleDbType.NVarchar2, 20).Value = context.UserName;
                        command.Parameters.Add("username", OracleDbType.NVarchar2, 50).Value = MD5Encrypt.MD5Hash(context.Password);
                        using (var oracleDataReader = command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.Result.HasRows)
                            {
                                user = null;
                            }
                            else
                            {
                                while (oracleDataReader.Result.Read())
                                {
                                    user.USERNAME = oracleDataReader.Result["USERNAME"]?.ToString();
                                    user.FULLNAME = oracleDataReader.Result["FULLNAME"]?.ToString();
                                    user.PHONE = oracleDataReader.Result["PHONE"]?.ToString();
                                    user.EMAIL = oracleDataReader.Result["EMAIL"]?.ToString();
                                    user.MA_DBHC = oracleDataReader.Result["MA_DBHC"]?.ToString();
                                    user.MA_QHNS = oracleDataReader.Result["MA_QHNS"]?.ToString();
                                    user.CHUCVU = oracleDataReader.Result["CHUCVU"]?.ToString();
                                    user.MA_DONVI = oracleDataReader.Result["MA_DONVI"]?.ToString();
                                }
                            }
                        }
                    }
                }
                Action<ClaimsIdentity, string> addClaim = (ClaimsIdentity obj, string username) => { return; };
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                if (user != null)
                {
                    addClaim.Invoke(identity, user.USERNAME);
                    identity.AddClaim(new Claim(ClaimTypes.Role,"Administrator"));
                    identity.AddClaim(new Claim("MA_DBHC", user.MA_DBHC));
                    identity.AddClaim(new Claim("LST_QHNS", user.MA_QHNS));
                    identity.AddClaim(new Claim("unitCode", user.MA_DONVI));
                    var props = new AuthenticationProperties(
                        new Dictionary<string, string>{
                            {
                                "userName",user.USERNAME
                            },
                            {
                                "email", user.EMAIL
                            },
                            {
                                "fullName", user.FULLNAME
                            },
                            {
                                "phone", user.PHONE
                            },
                            {
                                "maDBHC", user.MA_DBHC
                            },
                            {
                                "lstQHNS",user.MA_QHNS
                            },
                            {
                                "chucVu",user.CHUCVU
                            },
                            {
                                "unitCode", user.MA_DONVI
                            }
                    });
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "Sai thông tin đăng nhập !");
                    return;
                }
            }
            catch (Exception e)
            {
                WriteLogs.LogError(e);
                context.SetError("invalid_grant", "Lỗi hệ thống !");
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}