using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.SERVICE.SERVICES;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.ENTITY;
using Service.Pattern;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNguoiDung
{
    public interface IAuNguoiDungService : IService<AU_NGUOIDUNG>
    {
        AU_NGUOIDUNG FindUser(string username, string password);
        List<AuNguoiDungVm.ViewModel> GetAllUserPhongBan(string maDonVi);
        bool CheckExistCode(string username);
        bool InsertUser(AuNguoiDungVm.ModelInsert dataInsert);
        bool UpdateUser(AuNguoiDungVm.ModelUpdate dataInsert);
        bool DeleteUser(int ID);
        AuNguoiDungVm.ViewModel GetInfoUserByUserName(AuNguoiDungVm.ParameterModel param);
    }
    public class AuNguoiDungService : Service<AU_NGUOIDUNG>, IAuNguoiDungService
    {
        private readonly IRepositoryAsync<AU_NGUOIDUNG> _repository;

        public AuNguoiDungService(IRepositoryAsync<AU_NGUOIDUNG> repository) : base(repository)
        {
            _repository = repository;
        }

        public bool DeleteUser(int ID)
        {
            bool result = false;
            using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Format(@"SELECT ID,USERNAME,MA_DONVI FROM AU_NGUOIDUNG WHERE ID = "+ ID + "");
                    OracleDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["ID"] != null)
                            {
                                using (var commandDelete = connection.CreateCommand())
                                {
                                    commandDelete.CommandType = CommandType.Text;
                                    commandDelete.CommandText = string.Format(@"DELETE AU_NGUOIDUNG WHERE ID=:ID AND USERNAME=:USERNAME AND MA_DONVI=:MA_DONVI");
                                    commandDelete.Parameters.Add("ID", OracleDbType.Int32).Value = ID;
                                    commandDelete.Parameters.Add("USERNAME", OracleDbType.NVarchar2, 50).Value = dataReader["USERNAME"].ToString().Trim();
                                    commandDelete.Parameters.Add("MA_DONVI", OracleDbType.NVarchar2, 50).Value = dataReader["MA_DONVI"].ToString().Trim();
                                    if (commandDelete.ExecuteNonQuery() > 0)
                                    {
                                        result = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public AuNguoiDungVm.ViewModel GetInfoUserByUserName(AuNguoiDungVm.ParameterModel param)
        {
            AuNguoiDungVm.ViewModel result = new AuNguoiDungVm.ViewModel();
            if (!string.IsNullOrEmpty(param.MA_DONVI) && !string.IsNullOrEmpty(param.USERNAME))
            {
                using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText =
                            string.Format(
                                @"SELECT USERNAME,FULLNAME,EMAIL,PHONE,GHICHU,TRANGTHAI,MA_DONVI FROM AU_NGUOIDUNG WHERE USERNAME = '" +
                                param.USERNAME.Trim() + "' AND MA_DONVI = '" + param.MA_DONVI.Trim() + "' ");
                        OracleDataReader dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                result.USERNAME = dataReader["USERNAME"].ToString();
                                result.FULLNAME = dataReader["FULLNAME"].ToString();
                                result.EMAIL = dataReader["EMAIL"].ToString();
                                result.PHONE = dataReader["PHONE"].ToString();
                                result.GHICHU = dataReader["GHICHU"].ToString();
                                result.TRANGTHAI = int.Parse(dataReader["TRANGTHAI"].ToString());
                                result.MA_DONVI = dataReader["MA_DONVI"].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                result = null;
            }
            return result;
        }
        public bool InsertUser(AuNguoiDungVm.ModelInsert dataInsert)
        {
            bool result = false;
            using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Format(@"INSERT INTO AU_NGUOIDUNG (USERNAME,PASSWORD,FULLNAME,EMAIL,PHONE,CHUCVU,MA_PHONGBAN,GHICHU,TRANGTHAI,MA_DBHC_CHA,LOAI,MA_DBHC,MA_QHNS,MA_DONVI) VALUES (
                    :USERNAME,:PASSWORD,:FULLNAME,:EMAIL,:PHONE,:CHUCVU,:MA_PHONGBAN,:GHICHU,:TRANGTHAI,:MA_DBHC_CHA,:LOAI,:MA_DBHC,:MA_QHNS,:MA_DONVI)");
                    command.Parameters.Add("USERNAME", OracleDbType.NVarchar2, 50).Value = dataInsert.USERNAME;
                    command.Parameters.Add("PASSWORD", OracleDbType.NVarchar2, 50).Value = dataInsert.PASSWORD;
                    command.Parameters.Add("FULLNAME", OracleDbType.NVarchar2, 500).Value = dataInsert.FULLNAME;
                    command.Parameters.Add("EMAIL", OracleDbType.NVarchar2, 500).Value = dataInsert.EMAIL;
                    command.Parameters.Add("PHONE", OracleDbType.NVarchar2, 50).Value = dataInsert.PHONE;
                    command.Parameters.Add("CHUCVU", OracleDbType.NVarchar2, 50).Value = dataInsert.CHUCVU;
                    command.Parameters.Add("MA_PHONGBAN", OracleDbType.NVarchar2, 50).Value = dataInsert.MA_PHONGBAN;
                    command.Parameters.Add("GHICHU", OracleDbType.NVarchar2, 500).Value = dataInsert.GHICHU;
                    command.Parameters.Add("TRANGTHAI", OracleDbType.Int32).Value = dataInsert.TRANGTHAI;
                    command.Parameters.Add("MA_DBHC_CHA", OracleDbType.NVarchar2, 50).Value = dataInsert.MA_DBHC_CHA;
                    command.Parameters.Add("LOAI", OracleDbType.NVarchar2, 50).Value = dataInsert.LOAI;
                    command.Parameters.Add("MA_DBHC", OracleDbType.NVarchar2, 50).Value = dataInsert.MA_DBHC;
                    command.Parameters.Add("MA_QHNS", OracleDbType.NVarchar2, 50).Value = dataInsert.MA_QHNS;
                    command.Parameters.Add("MA_DONVI", OracleDbType.NVarchar2, 50).Value = dataInsert.MA_DONVI;
                    if (command.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool UpdateUser(AuNguoiDungVm.ModelUpdate dataUpdate)
        {
            bool result = false;
            using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Format(@"UPDATE AU_NGUOIDUNG SET USERNAME=:USERNAME,PASSWORD=:PASSWORD,FULLNAME=:FULLNAME,EMAIL=:EMAIL,PHONE=:PHONE,
                    CHUCVU=:CHUCVU,GHICHU=:GHICHU,TRANGTHAI=:TRANGTHAI,MA_DBHC_CHA=:MA_DBHC_CHA,LOAI=:LOAI,MA_DBHC=:MA_DBHC,MA_QHNS=:MA_QHNS,MA_DONVI=:MA_DONVI
                    WHERE USERNAME = :USERNAME AND MA_DONVI=:MA_DONVI");
                    command.Parameters.Add("USERNAME", OracleDbType.NVarchar2, 50).Value = dataUpdate.USERNAME;
                    command.Parameters.Add("PASSWORD", OracleDbType.NVarchar2, 50).Value = dataUpdate.PASSWORD;
                    command.Parameters.Add("FULLNAME", OracleDbType.NVarchar2, 500).Value = dataUpdate.FULLNAME;
                    command.Parameters.Add("EMAIL", OracleDbType.NVarchar2, 500).Value = dataUpdate.EMAIL;
                    command.Parameters.Add("PHONE", OracleDbType.NVarchar2, 50).Value = dataUpdate.PHONE;
                    command.Parameters.Add("CHUCVU", OracleDbType.NVarchar2, 50).Value = dataUpdate.CHUCVU;
                    command.Parameters.Add("GHICHU", OracleDbType.NVarchar2, 500).Value = dataUpdate.GHICHU;
                    command.Parameters.Add("TRANGTHAI", OracleDbType.Int32).Value = dataUpdate.TRANGTHAI;
                    command.Parameters.Add("MA_DBHC_CHA", OracleDbType.NVarchar2, 50).Value = dataUpdate.MA_DBHC_CHA;
                    command.Parameters.Add("LOAI", OracleDbType.NVarchar2, 50).Value = dataUpdate.LOAI;
                    command.Parameters.Add("MA_DBHC", OracleDbType.NVarchar2, 50).Value = dataUpdate.MA_DBHC;
                    command.Parameters.Add("MA_QHNS", OracleDbType.NVarchar2, 50).Value = dataUpdate.MA_QHNS;
                    command.Parameters.Add("MA_DONVI", OracleDbType.NVarchar2, 50).Value = dataUpdate.MA_DONVI;
                    if (command.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public bool CheckExistCode(string userName)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
                    {
                        connection.Open();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = string.Format(@"SELECT USERNAME FROM AU_NGUOIDUNG WHERE USERNAME='"+ userName.Trim()+"' ");
                            using (OracleDataReader oracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                if (oracleDataReader.HasRows)
                                {
                                    result = true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public List<AuNguoiDungVm.ViewModel> GetAllUserPhongBan(string maDonVi)
        {
            var result = new List<AuNguoiDungVm.ViewModel>();
            try
            {
                using (var connection = new OracleConnection(new PHFContext().Database.Connection.ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        if (!string.IsNullOrEmpty(maDonVi))
                        {
                            command.CommandText = string.Format(@"SELECT ID,USERNAME,FULLNAME,EMAIL,PHONE,GHICHU,TRANGTHAI,MA_DONVI FROM AU_NGUOIDUNG WHERE MA_DONVI = '" + maDonVi.Trim() + "'");
                        }
                        else
                        {
                            string currentUser = "";
                            if (HttpContext.Current != null && HttpContext.Current.User is ClaimsPrincipal)
                            {
                                currentUser = (HttpContext.Current.User as ClaimsPrincipal).Identity.Name;
                            }
                            command.CommandText = string.Format(@"SELECT ID,USERNAME,FULLNAME,EMAIL,PHONE,GHICHU,TRANGTHAI,MA_DONVI FROM AU_NGUOIDUNG WHERE MA_DONVI = (SELECT MA_DONVI FROM AU_NGUOIDUNG WHERE USERNAME = '" + currentUser.Trim()+"')");
                        }
                        using (OracleDataReader oracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (oracleDataReader.HasRows)
                            {
                                while (oracleDataReader.Read())
                                {
                                    AuNguoiDungVm.ViewModel item = new AuNguoiDungVm.ViewModel()
                                    {
                                        ID = int.Parse(oracleDataReader["ID"].ToString()),
                                        USERNAME = oracleDataReader["USERNAME"].ToString(),
                                        FULLNAME = oracleDataReader["FULLNAME"].ToString(),
                                        EMAIL = oracleDataReader["EMAIL"].ToString(),
                                        PHONE = oracleDataReader["PHONE"].ToString(),
                                        GHICHU = oracleDataReader["GHICHU"].ToString(),
                                        TRANGTHAI = int.Parse(oracleDataReader["TRANGTHAI"].ToString()),
                                        MA_DONVI = oracleDataReader["MA_DONVI"].ToString()
                                    };
                                    result.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public AU_NGUOIDUNG FindUser(string username, string password)
        {
            return _repository.Queryable().FirstOrDefault(x =>
                x.USERNAME.Equals(username) && x.PASSWORD.Equals(password) && x.TRANGTHAI == 1);
        }
    }
}
