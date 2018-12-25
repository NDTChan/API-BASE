using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Sys;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungQuyen
{
    public interface IAuNguoiDungQuyenService:IService<AU_NGUOIDUNG_QUYEN>
    {
        Task<Response<List<AuNguoiDungQuyenViewModel>>> GetByUsername(string phanhe,string username);
    }
    public class AuNguoiDungQuyenService: Service<AU_NGUOIDUNG_QUYEN>,IAuNguoiDungQuyenService
    {
        private readonly IRepositoryAsync<AU_NGUOIDUNG_QUYEN> _repository;
        public AuNguoiDungQuyenService(IRepositoryAsync<AU_NGUOIDUNG_QUYEN> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<Response<List<AuNguoiDungQuyenViewModel>>> GetByUsername(string phanhe, string username)
        {
            Response<List<AuNguoiDungQuyenViewModel>> response =new Response<List<AuNguoiDungQuyenViewModel>>();
            try
            {
                var reponguoiDungQuyen = _repository.GetRepository<AU_NGUOIDUNG_QUYEN>();
                var repoSysChucNang = _repository.GetRepository<SYS_CHUCNANG>();
                var item = await reponguoiDungQuyen.Queryable().Where(x => x.USERNAME.Equals(username) && x.PHANHE.Equals(phanhe))
                    .Join(repoSysChucNang.Queryable().Where(x => x.TRANGTHAI == 1 && x.PHANHE.Equals(phanhe)), x => x.MACHUCNANG,
                        y => y.MACHUCNANG, (x, y) => new AuNguoiDungQuyenViewModel()
                        {
                            Id = x.Id,
                            PHANHE = x.PHANHE,
                            USERNAME = x.USERNAME,
                            MACHUCNANG = x.MACHUCNANG,
                            TENCHUCNANG = y.TENCHUCNANG,
                            SOTHUTU = y.SOTHUTU,
                            XEM = x.XEM,
                            THEM = x.THEM,
                            SUA = x.SUA,
                            XOA = x.XOA,
                            DUYET = x.DUYET
                        }).ToListAsync();
                response.Data = item;
                response.Error = false;
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
