using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;

namespace BTS.SP.PHF.SERVICE.NV.QDGiaoThucHienThanhTra
{
    public interface IQDGiaoThucHienThanhTraService : IBaseService<PHF_QD_GIAOTHUCHIEN_THANHTRA>
    {
    }
    public class QDGiaoThucHienThanhTraService : BaseService<PHF_QD_GIAOTHUCHIEN_THANHTRA>, IQDGiaoThucHienThanhTraService
    {
        private readonly IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_THANHTRA> _repository;
        public QDGiaoThucHienThanhTraService(IRepositoryAsync<PHF_QD_GIAOTHUCHIEN_THANHTRA> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
