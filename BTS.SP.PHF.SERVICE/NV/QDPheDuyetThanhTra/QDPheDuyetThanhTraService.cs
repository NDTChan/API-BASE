using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Repositories;
using BTS.SP.PHF.SERVICE.SERVICES;
using System.Collections.Generic;
using static BTS.SP.PHF.SERVICE.NV.QDPheDuyetThanhTra.QDPheDuyetThanhTraVm;

namespace BTS.SP.PHF.SERVICE.NV.QDPheDuyetThanhTra
{
    public interface IQDPheDuyetThanhTraService : IBaseService<PHF_QD_PHEDUYET_THANHTRA>
    {
        void BuildAppendix();
    }
    public class QDPheDuyetThanhTraService : BaseService<PHF_QD_PHEDUYET_THANHTRA>, IQDPheDuyetThanhTraService
    {
        private readonly IRepositoryAsync<PHF_QD_PHEDUYET_THANHTRA> _repository;
        public QDPheDuyetThanhTraService(IRepositoryAsync<PHF_QD_PHEDUYET_THANHTRA> repository) : base(repository)
        {
            _repository = repository;
        }

        public void BuildAppendix()
        {
            List<ArrayAppendix> appendix = new List<ArrayAppendix>();
            appendix.Add(new ArrayAppendix(1, "A", "KẾ HOẠCH THANH TRA"));
            appendix.Add(new ArrayAppendix(2, "I", "THANH TRA NGÂN SÁCH ĐỊA PHƯƠNG"));
            appendix.Add(new ArrayAppendix(3, "1", "Kế hoạch chính thức"));
        }
    }
}
