using System;
using System.Collections.Generic;
using BTS.SP.API.ENTITY.Models.Nv.PHF;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.PHF.SERVICE.BuildQuery;
using BTS.SP.PHF.SERVICE.BuildQuery.Implimentations;
using BTS.SP.PHF.SERVICE.BuildQuery.Types;
using BTS.SP.PHF.SERVICE.Services;

namespace BTS.SP.PHF.SERVICE.NV.KEHOACH_THANHTRA
{
    public class NvKhThanhTraVm
    {
        public class Search : IDataSearch
        {
            public string MaChungTu { get; set; }
            public string MaDot { get; set; }
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
            public string GhiChu { get; set; }
            public string Loai { get; set; }
            public DateTime? NgayTao { get; set; }
            public string MaDonVi { get; set; }
            public string NguoiTao { get; set; }

            public string DefaultOrder
            {
                get
                {
                    return ClassHelper.GetPropertyName(() => new PHF_KEHOACH_THANHTRA_H().MaChungTu);
                }
            }

            public List<IQueryFilter> GetFilters()
            {
                var result = new List<IQueryFilter>();
                var refObj = new PHF_KEHOACH_THANHTRA_H();
                if (!string.IsNullOrEmpty(this.MaChungTu))
                {
                    result.Add(new QueryFilterLinQ
                    {
                        Property = ClassHelper.GetProperty(() => refObj.MaChungTu),
                        Value = this.MaChungTu,
                        Method = FilterMethod.Like
                    });                
                }


                return result;
            }

            public List<IQueryFilter> GetQuickFilters()
            {
                return null;
            }

            public void LoadGeneralParam(string summary)
            {
                MaChungTu = summary;
                   
            }
        }
        public class Dto
        {
            public int Id { get; set; }
            public string MaChungTu { get; set; }
            public string MaDot { get; set; }
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
            public string GhiChu { get; set; }
            public string Loai { get; set; }
            public DateTime? NgayTao { get; set; }
            public string MaDonVi { get; set; }
            public string NguoiTao { get; set; }
            public int? TrangThai { get; set; }
            public List<DtoDetail> DataDetails { get; set; }
            public Dto()
            {
                DataDetails = new List<DtoDetail>();
            }
            

        }
        public class DtoDetail
        {
            public string MaChungTu { get; set; }
            public string MaLoai { get; set; }
            public string MaNhom { get; set; }
            public string MaKeHoach { get; set; }
            public string MaDoiTuong { get; set; }
            public string MaPhong { get; set; }
            public string LyDo { get; set; }
            public int? SapXep { get; set; }
        }
    }
}
