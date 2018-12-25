using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyenChucNang
{
    public interface IAuNhomQuyenChucNangService:IService<AU_NHOMQUYEN_CHUCNANG>
    {
        Task<List<AuNhomQuyenChucNangViewModel>> GetByMaNhomQuyen(string phanhe,string manhomquyen);
    }
    public class AuNhomQuyenChucNangService : Service<AU_NHOMQUYEN_CHUCNANG>,IAuNhomQuyenChucNangService
    {
        private readonly IRepositoryAsync<AU_NHOMQUYEN_CHUCNANG> _repository;

        public AuNhomQuyenChucNangService(IRepositoryAsync<AU_NHOMQUYEN_CHUCNANG> repository) : base(repository)
        {
            _repository = repository;

        }
        public async Task<List<AuNhomQuyenChucNangViewModel>> GetByMaNhomQuyen(string phanhe, string manhomquyen)
        {
            try
            {
                using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT VC.ID,VC.MANHOMQUYEN,VC.MACHUCNANG,CN.TENCHUCNANG,CN.""STATE"",CN.SOTHUTU,VC.XEM,VC.THEM,VC.SUA,VC.XOA,VC.DUYET 
                            FROM AU_NHOMQUYEN_CHUCNANG VC RIGHT JOIN SYS_CHUCNANG CN ON VC.MACHUCNANG = CN.MACHUCNANG WHERE VC.PHANHE='" + phanhe + "' AND CN.PHANHE='" + phanhe + "' AND VC.MANHOMQUYEN = '" + manhomquyen + "' ORDER BY CN.SOTHUTU";
                        using (var oracleDataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return new List<AuNhomQuyenChucNangViewModel>();
                            List<AuNhomQuyenChucNangViewModel> lst = new List<AuNhomQuyenChucNangViewModel>();
                            while (oracleDataReader.Read())
                            {
                                AuNhomQuyenChucNangViewModel item = new AuNhomQuyenChucNangViewModel();
                                item.Id = Int32.Parse(oracleDataReader["ID"].ToString());
                                item.MACHUCNANG = oracleDataReader["MACHUCNANG"].ToString();
                                item.MANHOMQUYEN = oracleDataReader["MANHOMQUYEN"]?.ToString() ?? string.Empty;
                                item.SOTHUTU = oracleDataReader["SOTHUTU"].ToString();
                                item.STATE = oracleDataReader["STATE"]?.ToString() ?? string.Empty;
                                item.TENCHUCNANG = oracleDataReader["TENCHUCNANG"].ToString();
                                if (oracleDataReader["XEM"] != null)
                                {
                                    item.XEM = oracleDataReader["XEM"].ToString().Equals("1");
                                }
                                if (oracleDataReader["THEM"] != null)
                                {
                                    item.THEM = oracleDataReader["THEM"].ToString().Equals("1");
                                }
                                if (oracleDataReader["SUA"] != null)
                                {
                                    item.SUA = oracleDataReader["SUA"].ToString().Equals("1");
                                }
                                if (oracleDataReader["XOA"] != null)
                                {
                                    item.XOA = oracleDataReader["XOA"].ToString().Equals("1");
                                }
                                if (oracleDataReader["DUYET"] != null)
                                {
                                    item.DUYET = oracleDataReader["DUYET"].ToString().Equals("1");
                                }
                                lst.Add(item);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

    }
}
