using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.SERVICES;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyen
{
    public interface IAuNhomQuyenService : IService<AU_NHOMQUYEN>
    {
        Task<Response<List<SelectObject>>> GetNhomQuyenConfigByUsername(string phanhe, string username);
    }
    public class AuNhomQuyenService : Service<AU_NHOMQUYEN>, IAuNhomQuyenService
    {
        private readonly IRepositoryAsync<AU_NHOMQUYEN> _repository;
        public AuNhomQuyenService(IRepositoryAsync<AU_NHOMQUYEN> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<Response<List<SelectObject>>> GetNhomQuyenConfigByUsername(string phanhe, string username)
        {
            Response<List<SelectObject>> response = new Response<List<SelectObject>>();
            try
            {
                using (var connection =new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText =
                            @"SELECT MANHOMQUYEN,TENNHOMQUYEN FROM AU_NHOMQUYEN WHERE TRANGTHAI=1 AND PHANHE='" + phanhe + "' AND MANHOMQUYEN NOT IN(SELECT MANHOMQUYEN FROM AU_NGUOIDUNG_NHOMQUYEN WHERE AU_NGUOIDUNG_NHOMQUYEN.PHANHE='" + phanhe + "' AND AU_NGUOIDUNG_NHOMQUYEN.USERNAME='" + username + "')";
                        using (var oracleDataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return new Response<List<SelectObject>>()
                            {
                                Error = false,
                                Data = new List<SelectObject>()
                            };
                            List<SelectObject> lst = new List<SelectObject>();
                            while (oracleDataReader.Read())
                            {
                                lst.Add(new SelectObject()
                                {
                                    Text = oracleDataReader["TENNHOMQUYEN"].ToString(),
                                    Value = oracleDataReader["MANHOMQUYEN"].ToString(),
                                    Selected = false
                                });
                            }
                            response.Error = false;
                            response.Data = lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
