using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTS.SP.PHF.SERVICE.NV.TheoDoiCanBo;
using Repository.Pattern.UnitOfWork;
using System.Web.Http;
using BTS.SP.PHF.SERVICE.UTILS;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.API.PHF.Utils;
using Repository.Pattern.Infrastructure;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.NV.TienDoThucHienThanhTra;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvTheoDoiCanBo")]
    [Route("{id?}")]
    [Authorize]
    public class NvTheoDoiCanBoController : ApiController
    {
        public readonly IPHF_THEODOI_CANBOService _service;
        public readonly IPHF_THEODOI_CANBO_CTService _serviceDetail;
        public readonly INV_TIENDO_THUCHIEN_KHService _serviceTienDoThucHien;
        public readonly INV_TIENDO_THUCHIEN_KH_CTService _serviceTienDoThucHienDetail;
        public readonly IDM_DOTTHANHTRAService _serviceDotThanhTra;
        public readonly IDM_CANBOService _serviceCanBo;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvTheoDoiCanBoController(IPHF_THEODOI_CANBOService service, IPHF_THEODOI_CANBO_CTService serviceDetail, INV_TIENDO_THUCHIEN_KHService serviceTienDoThucHien,
            INV_TIENDO_THUCHIEN_KH_CTService serviceTienDoThucHienDetail, IDM_DOTTHANHTRAService serviceDotThanhTra, IDM_CANBOService serviceCanBo, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDetail = serviceDetail;
            _serviceTienDoThucHien = serviceTienDoThucHien;
            _serviceTienDoThucHienDetail = serviceTienDoThucHienDetail;
            _serviceDotThanhTra = serviceDotThanhTra;
            _serviceCanBo = serviceCanBo;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvTheoDoiCanBo")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_THEODOI_CANBO>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<PHF_THEODOI_CANBOVm.Search>>();
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
            var response = new Response<PHF_THEODOI_CANBOVm.DTO>();
            try
            {
                var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(refid))
                    .OrderBy(x => x.Id).ToList();
                var data = new PHF_THEODOI_CANBOVm.DTO
                {
                    MA_PHIEU = refid
                };
                if (details != null && details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        PHF_THEODOI_CANBOVm.DTO_DETAILS itemDetails = new PHF_THEODOI_CANBOVm.DTO_DETAILS();
                        itemDetails.MA_PHIEU = item.MA_PHIEU;
                        itemDetails.TEN_CANBO = item.TEN_CANBO;
                        itemDetails.CHUCVU = item.CHUCVU;
                        itemDetails.GIOI_TINH = item.GIOI_TINH;
                        itemDetails.STT = item.STT;
                        itemDetails.NGAY_SINH = item.NGAY_SINH;
                        itemDetails.PHONGBAN = item.PHONGBAN;
                        itemDetails.SO_MAY_LE = item.SO_MAY_LE;
                        itemDetails.SO_DI_DONG = item.SO_DI_DONG;
                        itemDetails.TEN_DOT_THANHTRA = item.TEN_DOT_THANHTRA;
                        itemDetails.SO_QUYETDINH = item.SO_QUYETDINH;
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
        [Route("GetMaxID")]
        [HttpGet]
        public async Task<IHttpActionResult> GetMaxID()
        {
            try
            {
                var lastestID = _service.BuildCodeWithParameter("TDCBTGDTT_", "TDCBTGDTT", true);
                return Ok(lastestID);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }
        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_nvTheoDoiCanBo")]
        public async Task<IHttpActionResult> Post(PHF_THEODOI_CANBOVm.DTO model)
        {

            var response = new Response<string>();
            try
            {
                model.MA_PHIEU = _service.BuildCodeWithParameter("TDCBTGDTT_", "TDCBTGDTT", true);
                var found = _service.Queryable().Where(x => x.MA_PHIEU == model.MA_PHIEU).ToList();
                if (found.Count > 0)
                {
                    response.Error = true;
                    response.Message = "Phiếu đã tồn tại !";
                }
                else
                {
                    PHF_THEODOI_CANBO obj = new PHF_THEODOI_CANBO();
                    obj.MA_PHIEU = model.MA_PHIEU;
                    obj.TEN_PHIEU = model.TEN_PHIEU;
                    obj.NAM_THANHTRA = model.NAM_THANHTRA;
                    obj.DOT_THANHTRA = model.DOT_THANHTRA;
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (model.DETAILS != null && model.DETAILS.Count > 0)
                    {
                        foreach (var itemDetail in model.DETAILS)
                        {
                            PHF_THEODOI_CANBO_CT itemInsert = new PHF_THEODOI_CANBO_CT();
                            itemInsert.MA_PHIEU = model.MA_PHIEU;
                            itemInsert.TEN_CANBO = itemDetail.TEN_CANBO;
                            itemInsert.CHUCVU = itemDetail.CHUCVU;
                            itemInsert.GIOI_TINH = itemDetail.GIOI_TINH;
                            itemInsert.NGAY_SINH = itemDetail.NGAY_SINH;
                            itemInsert.PHONGBAN = itemDetail.PHONGBAN;
                            itemInsert.SO_MAY_LE = itemDetail.SO_MAY_LE;
                            itemInsert.SO_DI_DONG = itemDetail.SO_DI_DONG;
                            itemInsert.TEN_DOT_THANHTRA = itemDetail.TEN_DOT_THANHTRA;
                            itemInsert.SO_QUYETDINH = itemDetail.SO_QUYETDINH;
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
        [CustomAuthorize(Method = "SUA", State = "phf_nvTheoDoiCanBo")]
        public async Task<IHttpActionResult> Put(string id, PHF_THEODOI_CANBOVm.DTO model)
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
                            temp.TEN_PHIEU = model.TEN_PHIEU;
                            temp.NAM_THANHTRA = model.NAM_THANHTRA;
                            temp.DOT_THANHTRA = model.DOT_THANHTRA;
                            temp.ObjectState = ObjectState.Modified;
                            if (model.DETAILS != null && model.DETAILS.Count > 0)
                            {
                                foreach (var itemDetail in model.DETAILS)
                                {
                                    PHF_THEODOI_CANBO_CT itemInsert = new PHF_THEODOI_CANBO_CT();
                                    itemInsert.MA_PHIEU = model.MA_PHIEU;
                                    itemInsert.TEN_CANBO = itemDetail.TEN_CANBO;
                                    itemInsert.CHUCVU = itemDetail.CHUCVU;
                                    itemInsert.GIOI_TINH = itemDetail.GIOI_TINH;
                                    itemInsert.NGAY_SINH = itemDetail.NGAY_SINH;
                                    itemInsert.PHONGBAN = itemDetail.PHONGBAN;
                                    itemInsert.SO_MAY_LE = itemDetail.SO_MAY_LE;
                                    itemInsert.SO_DI_DONG = itemDetail.SO_DI_DONG;
                                    itemInsert.TEN_DOT_THANHTRA = itemDetail.TEN_DOT_THANHTRA;
                                    itemInsert.SO_QUYETDINH = itemDetail.SO_QUYETDINH;
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
                        temp.TEN_PHIEU = model.TEN_PHIEU;
                        temp.NAM_THANHTRA = model.NAM_THANHTRA;
                        temp.DOT_THANHTRA = model.DOT_THANHTRA;
                        temp.ObjectState = ObjectState.Modified;
                        if (model.DETAILS != null && model.DETAILS.Count > 0)
                        {
                            foreach (var itemDetail in model.DETAILS)
                            {
                                PHF_THEODOI_CANBO_CT itemInsert = new PHF_THEODOI_CANBO_CT();
                                itemInsert.MA_PHIEU = model.MA_PHIEU;
                                itemInsert.TEN_CANBO = itemDetail.TEN_CANBO;
                                itemInsert.CHUCVU = itemDetail.CHUCVU;
                                itemInsert.GIOI_TINH = itemDetail.GIOI_TINH;
                                itemInsert.NGAY_SINH = itemDetail.NGAY_SINH;
                                itemInsert.PHONGBAN = itemDetail.PHONGBAN;
                                itemInsert.SO_MAY_LE = itemDetail.SO_MAY_LE;
                                itemInsert.SO_DI_DONG = itemDetail.SO_DI_DONG;
                                itemInsert.TEN_DOT_THANHTRA = itemDetail.TEN_DOT_THANHTRA;
                                itemInsert.SO_QUYETDINH = itemDetail.SO_QUYETDINH;
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
        [CustomAuthorize(Method = "XOA", State = "phf_nvTheoDoiCanBo")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_THEODOI_CANBO item = await _service.FindByIdAsync(long.Parse(id));
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

        [Route("GetListUserByMaDot/{maDot}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetListUserByMaDot(string maDot)
        {
            if (string.IsNullOrEmpty(maDot)) return BadRequest();
            var response = new Response<List<PHF_THEODOI_CANBOVm.DTO_DETAILS>>();
            try
            {
                List<PHF_THEODOI_CANBOVm.DTO_DETAILS> listResultTemp = new List<PHF_THEODOI_CANBOVm.DTO_DETAILS>();
                List<PHF_THEODOI_CANBOVm.DTO_DETAILS> listResult = new List<PHF_THEODOI_CANBOVm.DTO_DETAILS>();

                var dotThanhTra = _serviceDotThanhTra.Queryable().FirstOrDefault(x => x.MA_DOT.Equals(maDot));
                var ngayBatDauDotThanhTra = dotThanhTra.TU_NGAY;
                var ngayKetThucDotThanhTra = dotThanhTra.DEN_NGAY;
                var listTienDo = _serviceTienDoThucHienDetail.Queryable().Where(x => x.NGAY_TRIENKHAI >= ngayBatDauDotThanhTra && x.NGAY_KETTHUC <= ngayKetThucDotThanhTra).ToList();
                if (listTienDo != null && listTienDo.Count > 0)
                {
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "I. Lãnh đạo", STT = 0 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "II. Phòng Tổng hợp", STT = 2 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "III. Phòng thanh tra 1", STT = 4 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "IV. Phòng thanh tra 2", STT = 6 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "V. Phòng thanh tra 3", STT = 8 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "VI. Phòng thanh tra 4", STT = 10 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "VII. Phòng thanh tra 5", STT = 12 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "VIII. Phòng thanh tra 6", STT = 14 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "IX. Phòng thanh tra 7", STT = 16 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "X. Phòng Khiếu tố", STT = 18 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "XI. Phòng Xử lý sau thanh tra", STT = 20 });
                    listResultTemp.Add(new PHF_THEODOI_CANBOVm.DTO_DETAILS { NGAY_SINH = null, TEN_CANBO = "XII. Phòng thanh tra 8", STT = 22 });

                    foreach (var itemTienDo in listTienDo)
                    {
                        var thanhvien = itemTienDo.THANHVIEN_DOAN;
                        var listMaThanhVien = thanhvien.Split(',');
                        for (int i = 0; i < listMaThanhVien.Count(); i++)
                        {
                            var macanbo = listMaThanhVien[i];
                            var canbo = _serviceCanBo.Queryable().FirstOrDefault(x => x.MA_CANBO == macanbo);
                            PHF_THEODOI_CANBOVm.DTO_DETAILS itemDTO = new PHF_THEODOI_CANBOVm.DTO_DETAILS();
                            itemDTO.TEN_CANBO = canbo.TEN_CANBO;
                            itemDTO.CHUCVU = canbo.MA_CHUCVU;
                            itemDTO.GIOI_TINH = canbo.GIOI_TINH;
                            itemDTO.NGAY_SINH = canbo.NGAY_SINH;
                            itemDTO.PHONGBAN = canbo.SO_PHONG;
                            itemDTO.SO_MAY_LE = canbo.SO_MAY_LE;
                            itemDTO.SO_DI_DONG = canbo.SO_DI_DONG;
                            itemDTO.SO_QUYETDINH = itemTienDo.SO_NGAY_THANG_QG;
                            itemDTO.TEN_DOT_THANHTRA = itemTienDo.DOI_TUONG_TT;
                            if (canbo.MA_PHONG == "TTr1-LD")
                            {
                                itemDTO.STT = 1;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PTH")
                            {
                                itemDTO.STT = 3;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB1")
                            {
                                itemDTO.STT = 5;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB2")
                            {
                                itemDTO.STT = 7;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB3")
                            {
                                itemDTO.STT = 9;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB4")
                            {
                                itemDTO.STT = 11;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB5")
                            {
                                itemDTO.STT = 13;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB6")
                            {
                                itemDTO.STT = 15;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB7")
                            {
                                itemDTO.STT = 17;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PKT")
                            {
                                itemDTO.STT = 19;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PXLSTT")
                            {
                                itemDTO.STT = 21;
                            }
                            else if (canbo.MA_PHONG == "TTr1-PB8")
                            {
                                itemDTO.STT = 23;
                            }
                            listResultTemp.Add(itemDTO);
                        }
                    }
                }
                listResult = listResultTemp.OrderBy(x => x.STT).ToList();
                response.Error = false;
                response.Data = listResult;
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
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