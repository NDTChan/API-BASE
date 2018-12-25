using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.SERVICES;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;
using Service.Pattern;
using BTS.SP.PHF.SERVICE.DM;

namespace BTS.SP.PHF.SERVICE.SYS.SysChucNang
{
    public interface ISysChucNangService : IService<SYS_CHUCNANG>
    {
        List<SYS_CHUCNANG> GetAllForConfigNhomQuyen(string phanhe, string manhomquyen);

        List<SYS_CHUCNANG> GetAllForConfigQuyen(string phanhe, string username);

        List<DM_SYS_TUDIENVm.DM_DBHCVm> GetAllDBHC();

    }
    public class SysChucNangService : Service<SYS_CHUCNANG>, ISysChucNangService
    {
        private readonly IRepositoryAsync<SYS_CHUCNANG> _repository;
        public SysChucNangService(IRepositoryAsync<SYS_CHUCNANG> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<SYS_CHUCNANG> GetAllForConfigNhomQuyen(string phanhe, string manhomquyen)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT B.MACHUCNANG,B.TENCHUCNANG,B.""STATE"",B.SOTHUTU FROM SYS_CHUCNANG B WHERE B.MACHUCNANG 
                                                NOT IN (SELECT A.MACHUCNANG FROM AU_NHOMQUYEN_CHUCNANG A WHERE A.PHANHE='" + phanhe + "' AND A.MANHOMQUYEN='" + manhomquyen + "') AND " +
                                              "B.PHANHE='" + phanhe + "' AND B.STATE IS NOT NULL ORDER BY B.SOTHUTU";
                        using (OracleDataReader oracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return null;
                            List<SYS_CHUCNANG> lst = new List<SYS_CHUCNANG>();
                            while (oracleDataReader.Read())
                            {
                                SYS_CHUCNANG item = new SYS_CHUCNANG();
                                item.MACHUCNANG = oracleDataReader["MACHUCNANG"].ToString();
                                item.SOTHUTU = oracleDataReader["SOTHUTU"].ToString();
                                item.STATE = oracleDataReader["STATE"].ToString();
                                item.TENCHUCNANG = oracleDataReader["TENCHUCNANG"].ToString();
                                lst.Add(item);
                            }
                            return lst;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SYS_CHUCNANG> GetAllForConfigQuyen(string phanhe, string username)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT SYSCHUCNANG.MACHUCNANG,SYSCHUCNANG.TENCHUCNANG,SYSCHUCNANG.SOTHUTU,SYSCHUCNANG.STATE FROM SYS_CHUCNANG SYSCHUCNANG 
                                                WHERE TRANGTHAI =1 AND PHANHE='" + phanhe + "' AND STATE IS NOT NULL AND SYSCHUCNANG.MACHUCNANG NOT IN(SELECT MACHUCNANG FROM AU_NGUOIDUNG_QUYEN " +
                                              "WHERE AU_NGUOIDUNG_QUYEN.PHANHE='" + phanhe + "' AND AU_NGUOIDUNG_QUYEN.USERNAME='" + username + "') ORDER BY SYSCHUCNANG.SOTHUTU";

                        using (OracleDataReader oracleDataReader =
                            command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return null;
                            List<SYS_CHUCNANG> lst = new List<SYS_CHUCNANG>();
                            while (oracleDataReader.Read())
                            {
                                SYS_CHUCNANG item = new SYS_CHUCNANG();
                                item.MACHUCNANG = oracleDataReader["MACHUCNANG"].ToString();
                                item.SOTHUTU = oracleDataReader["SOTHUTU"].ToString();
                                item.STATE = oracleDataReader["STATE"].ToString();
                                item.TENCHUCNANG = oracleDataReader["TENCHUCNANG"].ToString();
                                lst.Add(item);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<DM_SYS_TUDIENVm.DM_DBHCVm> GetAllDBHC()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT * FROM DM_DBHC DM_DBHC ";

                        using (OracleDataReader oracleDataReader =
                            command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return null;
                            List<DM_SYS_TUDIENVm.DM_DBHCVm> lst = new List<DM_SYS_TUDIENVm.DM_DBHCVm>();
                            while (oracleDataReader.Read())
                            {
                                DM_SYS_TUDIENVm.DM_DBHCVm item = new DM_SYS_TUDIENVm.DM_DBHCVm();
                                item.MA_DBHC = oracleDataReader["MA_DBHC"].ToString();
                                item.MA_DBHC_CHA = oracleDataReader["MA_DBHC_CHA"].ToString();
                                item.TEN_DBHC = oracleDataReader["TEN_DBHC"].ToString();
                                lst.Add(item);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
