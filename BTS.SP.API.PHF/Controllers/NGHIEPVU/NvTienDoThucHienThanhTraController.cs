using System;
using System.Linq;
using System.Web.Http;
using Repository.Pattern.UnitOfWork;
using BTS.SP.PHF.ENTITY.Nv;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.UTILS;
using Newtonsoft.Json.Linq;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using Repository.Pattern.Infrastructure;
using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo;
using System.Collections.Generic;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvTienDoThucHienTT")]
    [Route("{id?}")]
    [Authorize]
    public class NvTienDoThucHienThanhTraController : ApiController
    {
        public readonly INV_TIENDO_THUCHIEN_KHService _service;
        public readonly INV_TIENDO_THUCHIEN_KH_CTService _serviceDetail;
        public readonly IDM_DOTTHANHTRAService _serviceDotThanhTra;
        public readonly INV_XD_KH_THANHTRA_BOService _servicekhTTBo;
        public readonly INV_XD_KH_THANHTRA_BO_CHITIETService _servicekhTTBoChiTiet;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvTienDoThucHienThanhTraController(
            INV_TIENDO_THUCHIEN_KHService service,
            INV_TIENDO_THUCHIEN_KH_CTService serviceDetail,
            IDM_DOTTHANHTRAService serviceDotThanhTra,
            INV_XD_KH_THANHTRA_BOService servicekhTTBo,
            INV_XD_KH_THANHTRA_BO_CHITIETService servicekhTTBoChiTiet,
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDetail = serviceDetail;
            _serviceDotThanhTra = serviceDotThanhTra;
            _servicekhTTBo = servicekhTTBo;
            _servicekhTTBoChiTiet = servicekhTTBoChiTiet;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvTienDoThucHienTT")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_TIENDO_THUCHIEN_KH>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_TIENDO_THUCHIEN_KHVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_TIENDO_THUCHIEN_KH>>();

            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1
            };
            try
            {
                var filterResult = await _service.FilterAsync(filtered, query);
                if (!filterResult.WasSuccessful)
                {
                    return NotFound();
                }
                result.Data = filterResult.Value;
                result.Error = false;
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [Route("GetDetailByRefId/{refid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDetailByRefId(string refid)
        {
            if (string.IsNullOrEmpty(refid)) return BadRequest();
            var response = new Response<NV_TIENDO_THUCHIEN_KHVm.DTO>();
            try
            {
                var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(refid))
                    .OrderBy(x => x.Id).ToList();
                var data = new NV_TIENDO_THUCHIEN_KHVm.DTO
                {
                    MA_PHIEU = refid
                };
                if (details != null && details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        NV_TIENDO_THUCHIEN_KHVm.DTO_DETAILS itemDetails = new NV_TIENDO_THUCHIEN_KHVm.DTO_DETAILS();
                        itemDetails.MA_PHIEU = item.MA_PHIEU;
                        itemDetails.DOI_TUONG_TT = item.DOI_TUONG_TT;
                        itemDetails.KE_HOACH_TT = item.KE_HOACH_TT;
                        itemDetails.LOAI_TT = item.LOAI_TT;
                        itemDetails.NHOM_TT = item.NHOM_TT;
                        itemDetails.PHONG_TT = item.PHONG_TT;
                        itemDetails.TRUONGDOAN_TT = item.TRUONGDOAN_TT;
                        itemDetails.THANHVIEN_DOAN = item.THANHVIEN_DOAN;
                        itemDetails.SO_NGAY_THANG_QG = item.SO_NGAY_THANG_QG;
                        itemDetails.THOIHAN_TT = item.THOIHAN_TT;
                        itemDetails.NGAY_TRIENKHAI = item.NGAY_TRIENKHAI;
                        itemDetails.NGAY_KETTHUC = item.NGAY_KETTHUC;
                        itemDetails.GIAMSAT_DOAN = item.GIAMSAT_DOAN;
                        itemDetails.MA_DOITUONG = item.MA_DOITUONG;
                        itemDetails.MA_DOITUONG_CHA = item.MA_DOITUONG_CHA;
                        data.DETAILS.Add(itemDetails);
                    }
                }
                response.Error = false;
                response.Data = data;
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }

        [Route("GetDoiTuongByDot/{maDot}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDoiTuongByDot(string maDot)
        {
            var response = new Response<NV_TIENDO_THUCHIEN_KHVm.DOITUONG_THANHTRA>();
            try
            {
                var data = new List<NV_TIENDO_THUCHIEN_KHVm.DOITUONG_THANHTRA>();
                var results = new List<NV_TIENDO_THUCHIEN_KHVm.DOITUONG_THANHTRA>();
                var khTTBo = _servicekhTTBo.Queryable().Where(x => x.DOT_THANHTRA.Equals(maDot)).ToList();
                for (var i = 0; i < khTTBo.Count; i++)
                {
                    var doiTuong = new NV_TIENDO_THUCHIEN_KHVm.DOITUONG_THANHTRA();
                    var maPhieu = khTTBo[i].MA_PHIEU;
                    doiTuong.MA_PHIEU = maPhieu;
                    var khTTBoChiTiet = _servicekhTTBoChiTiet.Queryable().Where(x => x.MA_PHIEU.Equals(maPhieu)).ToList();
                    for (var j = 0; j < khTTBoChiTiet.Count; j++)
                    {
                        doiTuong.PHF_XD_KH_THANHTRA_BO_CHITIETs.Add(khTTBoChiTiet[j]);
                    }
                    data.Add(doiTuong);
                }

                var firstElement = data[0].PHF_XD_KH_THANHTRA_BO_CHITIETs;

                for (var i = 1; i < data.Count; i++)
                {
                    var chitiet = data[i].PHF_XD_KH_THANHTRA_BO_CHITIETs;
                    for (var j = 0; j < chitiet.Count; j++)
                    {
                        var exist = false;
                        for (var k = 0; k < firstElement.Count; k++)
                        {
                            if(firstElement[k].MA_DOITUONG_CHA == chitiet[j].MA_DOITUONG_CHA && firstElement[k].TEN_DOITUONG == chitiet[j].TEN_DOITUONG)
                            {
                                exist = true;
                                break;
                            }
                            if (chitiet[j].MA_DOITUONG_CHA == null && firstElement[k].TEN_DOITUONG != chitiet[j].TEN_DOITUONG)
                            {
                                exist = false;
                                break;
                            }
                        }
                        if (exist == false)
                        {
                            data[0].PHF_XD_KH_THANHTRA_BO_CHITIETs.Add(chitiet[j]);
                        }
                    }
                }

                response.Error = false;
                response.Data = data[0];
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }

        [Route("GetMaxID")]
        [HttpGet]
        public async Task<IHttpActionResult> GetMaxID()
        {
            try
            {
                var lastestID = _service.BuildCodeWithParameter("TDTHTT_", "TDTHTT", true);
                return Ok(lastestID);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }
        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_nvTienDoThucHienTT")]
        public async Task<IHttpActionResult> Post(NV_TIENDO_THUCHIEN_KHVm.DTO model)
        {

            var response = new Response<string>();
            try
            {
                model.MA_PHIEU = _service.BuildCodeWithParameter("TDTHTT_", "TDTHTT", true);
                var found = _service.Queryable().Where(x => x.MA_PHIEU == model.MA_PHIEU).ToList();
                if (found.Count > 0)
                {
                    response.Error = true;
                    response.Message = "Phiếu đã tồn tại !";
                }
                else
                {
                    PHF_TIENDO_THUCHIEN_KH obj = new PHF_TIENDO_THUCHIEN_KH();
                    obj.MA_PHIEU = model.MA_PHIEU;
                    obj.MA_DOITUONG_TT = model.MA_DOITUONG_TT;
                    obj.NAM_THANHTRA = model.NAM_THANHTRA;
                    obj.NOI_DUNG = model.NOI_DUNG;
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (model.DETAILS != null && model.DETAILS.Count > 0)
                    {
                        foreach (var itemDetail in model.DETAILS)
                        {
                            PHF_TIENDO_THUCHIEN_KH_CT itemInsert = new PHF_TIENDO_THUCHIEN_KH_CT();
                            itemInsert.MA_PHIEU = obj.MA_PHIEU;
                            itemInsert.DOI_TUONG_TT = itemDetail.DOI_TUONG_TT;
                            itemInsert.KE_HOACH_TT = itemDetail.KE_HOACH_TT;
                            itemInsert.LOAI_TT = itemDetail.LOAI_TT;
                            itemInsert.NHOM_TT = itemDetail.NHOM_TT;
                            itemInsert.PHONG_TT = itemDetail.PHONG_TT;
                            itemInsert.TRUONGDOAN_TT = itemDetail.TRUONGDOAN_TT;
                            itemInsert.THANHVIEN_DOAN = itemDetail.THANHVIEN_DOAN;
                            itemInsert.SO_NGAY_THANG_QG = itemDetail.SO_NGAY_THANG_QG;
                            itemInsert.THOIHAN_TT = itemDetail.THOIHAN_TT;
                            itemInsert.NGAY_TRIENKHAI = itemDetail.NGAY_TRIENKHAI;
                            itemInsert.NGAY_KETTHUC = itemDetail.NGAY_KETTHUC;
                            itemInsert.GIAMSAT_DOAN = itemDetail.GIAMSAT_DOAN;
                            itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                            itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                            itemInsert.ObjectState = ObjectState.Added;
                            _serviceDetail.Insert(itemInsert);

                        }
                    }
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        response.Error = false;
                        response.Message = "Thêm thành công.";
                    }
                    else
                    {
                        response.Error = true;
                        response.Message = "Lỗi cập nhật dữ liệu.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvTienDoThucHienTT")]
        public async Task<IHttpActionResult> Put(string id, NV_TIENDO_THUCHIEN_KHVm.DTO model)
        {
            if (string.IsNullOrEmpty(id) || !id.Equals(model.ID.ToString())) return BadRequest();
            Response<string> response = new Response<string>();
            try
            {
                var temp = _service.FindById(model.ID);
                if (temp != null)
                {
                    var lstDetail = _serviceDetail.Queryable().Where(x => x.MA_PHIEU == temp.MA_PHIEU).ToList();
                    if (lstDetail.Count > 0)
                    {
                        foreach (var item in lstDetail)
                        {
                            item.ObjectState = ObjectState.Deleted;
                            _serviceDetail.Delete(item);
                        }
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            temp.MA_PHIEU = model.MA_PHIEU;
                            temp.MA_DOITUONG_TT = model.MA_DOITUONG_TT;
                            temp.NAM_THANHTRA = model.NAM_THANHTRA;
                            temp.NOI_DUNG = model.NOI_DUNG;
                            temp.ObjectState = ObjectState.Modified;
                            if (model.DETAILS != null && model.DETAILS.Count > 0)
                            {
                                foreach (var itemDetail in model.DETAILS)
                                {
                                    PHF_TIENDO_THUCHIEN_KH_CT itemInsert = new PHF_TIENDO_THUCHIEN_KH_CT();
                                    itemInsert.MA_PHIEU = model.MA_PHIEU;
                                    itemInsert.DOI_TUONG_TT = itemDetail.DOI_TUONG_TT;
                                    itemInsert.KE_HOACH_TT = itemDetail.KE_HOACH_TT;
                                    itemInsert.LOAI_TT = itemDetail.LOAI_TT;
                                    itemInsert.NHOM_TT = itemDetail.NHOM_TT;
                                    itemInsert.PHONG_TT = itemDetail.PHONG_TT;
                                    itemInsert.TRUONGDOAN_TT = itemDetail.TRUONGDOAN_TT;
                                    itemInsert.THANHVIEN_DOAN = itemDetail.THANHVIEN_DOAN;
                                    itemInsert.SO_NGAY_THANG_QG = itemDetail.SO_NGAY_THANG_QG;
                                    itemInsert.THOIHAN_TT = itemDetail.THOIHAN_TT;
                                    itemInsert.NGAY_TRIENKHAI = itemDetail.NGAY_TRIENKHAI;
                                    itemInsert.NGAY_KETTHUC = itemDetail.NGAY_KETTHUC;
                                    itemInsert.GIAMSAT_DOAN = itemDetail.GIAMSAT_DOAN;
                                    itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                                    itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                                    itemInsert.ObjectState = ObjectState.Added;
                                    _serviceDetail.Insert(itemInsert);
                                }
                            }
                            if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                            {
                                response.Error = false;
                                response.Message = "Cập nhật thành công.";
                            }
                            else
                            {
                                response.Error = true;
                                response.Message = "Lỗi cập nhật dữ liệu.";
                            }
                        }
                    }
                    else
                    {
                        temp.MA_PHIEU = model.MA_PHIEU;
                        temp.MA_DOITUONG_TT = model.MA_DOITUONG_TT;
                        temp.NAM_THANHTRA = model.NAM_THANHTRA;
                        temp.NOI_DUNG = model.NOI_DUNG;
                        temp.ObjectState = ObjectState.Modified;
                        if (model.DETAILS != null && model.DETAILS.Count > 0)
                        {
                            foreach (var itemDetail in model.DETAILS)
                            {
                                PHF_TIENDO_THUCHIEN_KH_CT itemInsert = new PHF_TIENDO_THUCHIEN_KH_CT();
                                itemInsert.MA_PHIEU = model.MA_PHIEU;
                                itemInsert.DOI_TUONG_TT = itemDetail.DOI_TUONG_TT;
                                itemInsert.KE_HOACH_TT = itemDetail.KE_HOACH_TT;
                                itemInsert.LOAI_TT = itemDetail.LOAI_TT;
                                itemInsert.NHOM_TT = itemDetail.NHOM_TT;
                                itemInsert.PHONG_TT = itemDetail.PHONG_TT;
                                itemInsert.TRUONGDOAN_TT = itemDetail.TRUONGDOAN_TT;
                                itemInsert.THANHVIEN_DOAN = itemDetail.THANHVIEN_DOAN;
                                itemInsert.SO_NGAY_THANG_QG = itemDetail.SO_NGAY_THANG_QG;
                                itemInsert.THOIHAN_TT = itemDetail.THOIHAN_TT;
                                itemInsert.NGAY_TRIENKHAI = itemDetail.NGAY_TRIENKHAI;
                                itemInsert.NGAY_KETTHUC = itemDetail.NGAY_KETTHUC;
                                itemInsert.GIAMSAT_DOAN = itemDetail.GIAMSAT_DOAN;
                                itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                                itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                                itemInsert.ObjectState = ObjectState.Added;
                                _serviceDetail.Insert(itemInsert);
                            }
                        }
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = false;
                            response.Message = "Cập nhật thành công.";
                        }
                        else
                        {
                            response.Error = true;
                            response.Message = "Lỗi cập nhật dữ liệu.";
                        }
                    }

                }
                else
                {
                    response.Error = true;
                    response.Message = "Không tìm thấy kết quả đấu thầu";
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_nvTienDoThucHienTT")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_TIENDO_THUCHIEN_KH item = await _service.FindByIdAsync(long.Parse(id));
                if (item != null)
                {
                    var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(item.MA_PHIEU)).ToList();
                    item.ObjectState = ObjectState.Deleted;
                    _service.Delete(item);
                    if (details.Count != 0)
                    {
                        foreach (var itemDetail in details)
                        {
                            itemDetail.ObjectState = ObjectState.Deleted;
                            _serviceDetail.Delete(itemDetail);
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Xóa thành công.";
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi xóa dữ liệu.";
                }
                return Ok(response);
            }
            catch (FormatException ex)
            {
                WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}