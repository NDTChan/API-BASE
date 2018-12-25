using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;

namespace BTS.SP.PHF.SERVICE.AUTH.Shared
{
    public interface ISharedService
    {
        Task<RoleState> GetRoleStateByMaChucNang(string phanhe,string username,string machucnang);
    }
    public class SharedService: ISharedService
    {
        public async Task<RoleState> GetRoleStateByMaChucNang(string phanhe, string username, string machucnang)
        {
            var roleState = new RoleState();
            if (username.Equals("admin"))
            {
                roleState=new RoleState()
                {
                    Approve = true,Delete = true,Add = true,STATE = "all",Edit = true,View = true
                };
            }
            else
            {
                var cacheData = MemoryCacheHelper.GetValue(phanhe + "|" + username + "|" + machucnang);
                if (cacheData == null)
                {
                    using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText =
                                @"SELECT XEM,THEM,SUA,XOA,DUYET FROM AU_NHOMQUYEN_CHUCNANG WHERE PHANHE='" + phanhe + "' AND MACHUCNANG='" + machucnang +
                                "' AND MANHOMQUYEN IN (SELECT MANHOMQUYEN FROM AU_NGUOIDUNG_NHOMQUYEN WHERE PHANHE='" + phanhe + "' AND USERNAME='" +
                                username + "') UNION SELECT AU_NGUOIDUNG_QUYEN.XEM,AU_NGUOIDUNG_QUYEN.THEM,AU_NGUOIDUNG_QUYEN.SUA,AU_NGUOIDUNG_QUYEN.XOA,AU_NGUOIDUNG_QUYEN.DUYET " +
                                "FROM AU_NGUOIDUNG_QUYEN WHERE AU_NGUOIDUNG_QUYEN.PHANHE='" + phanhe + "' AND AU_NGUOIDUNG_QUYEN.MACHUCNANG='" + machucnang + "' AND AU_NGUOIDUNG_QUYEN.USERNAME='" + username + "'";
                            using (var oracleDataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
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
                                    MemoryCacheHelper.Add(phanhe + "|" + username + "|" + machucnang, roleState,
                                        DateTimeOffset.Now.AddHours(6));
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
