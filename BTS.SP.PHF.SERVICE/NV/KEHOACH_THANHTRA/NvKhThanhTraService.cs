using System;
using System.Collections.Generic;
using AutoMapper;
using BTS.SP.API.ENTITY;
using BTS.SP.API.ENTITY.Models.Nv.PHF;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.SERVICE.Services;
namespace BTS.SP.PHF.SERVICE.NV.KEHOACH_THANHTRA
{
    public interface INvKhThanhTraService : IDataInfoService<PHF_KEHOACH_THANHTRA_H>
    {
        //Add function here
        NvKhThanhTraVm.Dto TaoMaChungTuService();
        PHF_KEHOACH_THANHTRA_H InsertPhieu(NvKhThanhTraVm.Dto instance);
    }
    public class NvKhThanhTraService : DataInfoServiceBase<PHF_KEHOACH_THANHTRA_H>, INvKhThanhTraService
    {
        public NvKhThanhTraService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public NvKhThanhTraVm.Dto TaoMaChungTuService()
        {
            var maDonVi = GetCurrentUnitCode();
            return new NvKhThanhTraVm.Dto()
            {
                MaChungTu = BuildAndSaveCodeNv(State.LoaiMa.TTB.ToString(), maDonVi, false),
                TuNgay = DateTime.Now,
                DenNgay =  DateTime.Now,
                NgayTao = DateTime.Now,
                NguoiTao = GetCurrentUser(),
                MaDonVi = GetCurrentUnitCode()
            };
        }
        public PHF_KEHOACH_THANHTRA_H InsertPhieu(NvKhThanhTraVm.Dto instance)
        {
            var item = Mapper.Map<NvKhThanhTraVm.Dto, PHF_KEHOACH_THANHTRA_H>(instance);
            var result = AddUnit(item);
            result.MaChungTu = BuildAndSaveCodeNv(State.LoaiMa.TTB.ToString(), instance.MaDonVi, true);
            result = Insert(result);
            var detailData = Mapper.Map<List<NvKhThanhTraVm.DtoDetail>, List<PHF_KEHOACH_THANHTRA_D>>(instance.DataDetails);
            detailData.ForEach(x =>
            {
                x.MaChungTu = result.MaChungTu;
            });
            UnitOfWork.Repository<PHF_KEHOACH_THANHTRA_D>().InsertRange(detailData);
            return result;
        }
    }
}
