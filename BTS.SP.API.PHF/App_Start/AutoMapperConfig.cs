using AutoMapper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.ThanhTraThuocBo;
using BTS.SP.TOOLS.BuildQuery.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BTS.SP.PHF.SERVICE.NV.BaoCaoTT_CQHC.NV_BM_FILE_CQHCVm;

namespace BTS.SP.API.PHF.App_Start
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.CreateMap(typeof(PagedObj), typeof(PagedObj));
            Mapper.CreateMap(typeof(PagedObj<>), typeof(PagedObj<>));

            NV();

        }

        public static void DM()
        {

        }

        public static void NV()
        {
            //Automapper Xay dung ke hoach thanh tra don vi thuoc bo
            Mapper.CreateMap<NV_XD_KH_TT_THUOC_BOVm.DTO, PHF_XD_KH_TT_THUOC_BO>();
            Mapper.CreateMap<PHF_XD_KH_TT_THUOC_BO, NV_XD_KH_TT_THUOC_BOVm.DTO>();
            Mapper.CreateMap<NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS, PHF_XD_KH_TT_THUOC_BO_CT>();
            Mapper.CreateMap<PHF_XD_KH_TT_THUOC_BO_CT, NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS>();

            //Automapper BCTT-CQHC
            Mapper.CreateMap<PHF_BM_01TT_CQHC_DTO, PHF_BM_01TT_CQHC>();
            Mapper.CreateMap<PHF_BM_02TT_CQHC_DTO, PHF_BM_02TT_CQHC>();
        }

    }
}