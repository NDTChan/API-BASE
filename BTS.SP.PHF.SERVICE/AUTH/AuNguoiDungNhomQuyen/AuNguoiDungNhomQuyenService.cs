using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungNhomQuyen
{
    public interface IAuNguoiDungNhomQuyenService:IService<AU_NGUOIDUNG_NHOMQUYEN>
    {
        Task<Response<List<AuNguoiDungNhomQuyenViewModel>>> GetByUsername(string phanhe, string username);

    }
    public class AuNguoiDungNhomQuyenService : Service<AU_NGUOIDUNG_NHOMQUYEN>,IAuNguoiDungNhomQuyenService
    {
        private readonly IRepositoryAsync<AU_NGUOIDUNG_NHOMQUYEN> _repository;
        public AuNguoiDungNhomQuyenService(IRepositoryAsync<AU_NGUOIDUNG_NHOMQUYEN> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<Response<List<AuNguoiDungNhomQuyenViewModel>>> GetByUsername(string phanhe,string username)
        {
            Response<List<AuNguoiDungNhomQuyenViewModel>> response=new Response<List<AuNguoiDungNhomQuyenViewModel>>();
            try
            {
                var reponguoiDungVaiTro = _repository.GetRepository<AU_NGUOIDUNG_NHOMQUYEN>();
                var repoVaiTro = _repository.GetRepository<AU_NHOMQUYEN>();
                var item = await reponguoiDungVaiTro.Queryable().Where(x => x.USERNAME.Equals(username) && x.PHANHE.Equals(phanhe))
                    .Join(repoVaiTro.Queryable().Where(x => x.TRANGTHAI == 1 && x.PHANHE.Equals(phanhe)), x => x.MANHOMQUYEN,
                        y => y.MANHOMQUYEN, (x, y) => new AuNguoiDungNhomQuyenViewModel()
                        {
                            Id = x.Id,
                            PHANHE = phanhe,
                            USERNAME = x.USERNAME,
                            MANHOMQUYEN = x.MANHOMQUYEN,
                            TENNHOMQUYEN = y.TENNHOMQUYEN
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
