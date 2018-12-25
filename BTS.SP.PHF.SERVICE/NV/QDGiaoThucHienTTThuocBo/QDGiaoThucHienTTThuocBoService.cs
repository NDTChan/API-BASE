using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienTTThuocBo
{
    public interface IQDGiaoThucHienTTThuocBoService : IBaseService<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO>
    {
    }
    public class QDGiaoThucHienTTThuocBoService : BaseService<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO>, IQDGiaoThucHienTTThuocBoService
    {
        private readonly IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO> _repository;
        public QDGiaoThucHienTTThuocBoService(IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_TT_THUOCBO> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
