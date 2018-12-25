using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraBo;
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
using BTS.SP.PHF.SERVICE.DM;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_phanCongKeHoach")]
    [Route("{id?}")]
    [Authorize]
    public class NvPhanCongKeHoachThanhTraBoController : ApiController
    {
        public readonly INV_XD_KH_THANHTRA_BOService _service;
        public readonly INV_XD_KH_THANHTRA_BO_CHITIETService _serviceDetail;
        public readonly IDM_DOITUONGService _serviceDoiTuongThanhTra;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvPhanCongKeHoachThanhTraBoController(INV_XD_KH_THANHTRA_BOService service, INV_XD_KH_THANHTRA_BO_CHITIETService serviceDetail, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDetail = serviceDetail;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_phanCongKeHoach")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_XD_KH_THANHTRA_BO>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_XD_KH_THANHTRA_BOVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_XD_KH_THANHTRA_BO>>();

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


        [Route("GetYearData")]
        [HttpGet]
        public List<PHF_XD_KH_THANHTRA_BO> GetYearData()
        {             
            try
            {
                return _service.Queryable().ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }       
        }


        [Route("GetDataDetailByMaDoiTuong/{maDoiTuong}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDataDetailByMaDoiTuong(string maDoiTuong)
        {
            var response = new Response<PHF_XD_KH_THANHTRA_BO_CHITIET>();
            try
            {
                var Details = _serviceDetail.Queryable().FirstOrDefault(x => x.DOITUONG_THANHTRA == maDoiTuong);
                response.Error = false;
                response.Data = Details;
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }
        [Route("GetObjectByDoiTuong/{maPhieu}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetObjectByDoiTuong(string maPhieu)
        {
            var response = new Response<PHF_XD_KH_THANHTRA_BO>();
            try
            {
                var listDetails = _service.Queryable().FirstOrDefault(x => x.MA_PHIEU == maPhieu);
                response.Error = false;
                response.Data = listDetails;
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }
        [Route("GetDetailByRefId/{refid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDetailByRefId(string refid)
        {
            if (string.IsNullOrEmpty(refid)) return BadRequest();
            var response = new Response<NV_XD_KH_THANHTRA_BOVm.DTO>();
            try
            {
                var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(refid))
                    .OrderBy(x => x.Id).ToList();
                var data = new NV_XD_KH_THANHTRA_BOVm.DTO
                {
                    MA_PHIEU = refid
                };
                if (details != null && details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        NV_XD_KH_THANHTRA_BOVm.DTO_DETAILS itemDetails = new NV_XD_KH_THANHTRA_BOVm.DTO_DETAILS();
                        itemDetails.MA_PHIEU = item.MA_PHIEU;
                        itemDetails.KEHOACH_THANHTRA = item.KEHOACH_THANHTRA;
                        itemDetails.LOAI_THANHTRA = item.LOAI_THANHTRA;
                        itemDetails.NHOM_THANHTRA = item.NHOM_THANHTRA;
                        itemDetails.PHONG_THANHTRA = item.PHONG_THANHTRA;
                        itemDetails.DOITUONG_THANHTRA = item.DOITUONG_THANHTRA;
                        itemDetails.LYDO_THANHTRA = item.LYDO_THANHTRA;
                        itemDetails.MA_DOITUONG = item.MA_DOITUONG;
                        itemDetails.MA_DOITUONG_CHA = item.MA_DOITUONG_CHA;
                        itemDetails.TEN_DOITUONG = item.TEN_DOITUONG;
                        itemDetails.PHONG_CHUTRI = item.PHONG_CHUTRI;
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
        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_phanCongKeHoach")]
        public async Task<IHttpActionResult> Post(NV_XD_KH_THANHTRA_BOVm.DTO model)
        {

            var response = new Response<string>();
            try
            {
                model.MA_PHIEU = _service.BuildCodeWithParameter("PCKH_", "PCKH", true);
                var found = _service.Queryable().Where(x => x.MA_PHIEU == model.MA_PHIEU).ToList();
                if (found.Count > 0)
                {
                    response.Error = true;
                    response.Message = "Phiếu đã tồn tại !";
                }
                else
                {
                    PHF_XD_KH_THANHTRA_BO obj = new PHF_XD_KH_THANHTRA_BO();
                    obj.MA_PHIEU = model.MA_PHIEU;
                    obj.DENNGAY = model.DENNGAY;
                    obj.TUNGAY = model.TUNGAY;
                    obj.DOT_THANHTRA = model.DOT_THANHTRA;
                    obj.NGAY_LAPPHIEU = model.NGAY_LAPPHIEU;
                    obj.NOIDUNG = model.NOIDUNG;
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (model.DETAILS != null && model.DETAILS.Count > 0)
                    {
                        foreach (var itemDetail in model.DETAILS)
                        {
                            PHF_XD_KH_THANHTRA_BO_CHITIET itemInsert = new PHF_XD_KH_THANHTRA_BO_CHITIET();
                            itemInsert.MA_PHIEU = obj.MA_PHIEU;
                            itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                            itemInsert.KEHOACH_THANHTRA = itemDetail.KEHOACH_THANHTRA;
                            itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                            itemInsert.LYDO_THANHTRA = itemDetail.LYDO_THANHTRA;
                            itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                            itemInsert.PHONG_THANHTRA = itemDetail.PHONG_THANHTRA;
                            itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                            itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                            itemInsert.TEN_DOITUONG = itemDetail.TEN_DOITUONG;
                            itemInsert.PHONG_CHUTRI = itemDetail.PHONG_CHUTRI;
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
        [CustomAuthorize(Method = "SUA", State = "phf_phanCongKeHoach")]
        public async Task<IHttpActionResult> Put(string id, NV_XD_KH_THANHTRA_BOVm.DTO model)
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
                            temp.DENNGAY = model.DENNGAY;
                            temp.TUNGAY = model.TUNGAY;
                            temp.DOT_THANHTRA = model.DOT_THANHTRA;
                            temp.NGAY_LAPPHIEU = model.NGAY_LAPPHIEU;
                            temp.NOIDUNG = model.NOIDUNG;
                            temp.ObjectState = ObjectState.Modified;
                            if (model.DETAILS != null && model.DETAILS.Count > 0)
                            {
                                foreach (var itemDetail in model.DETAILS)
                                {
                                    PHF_XD_KH_THANHTRA_BO_CHITIET itemInsert = new PHF_XD_KH_THANHTRA_BO_CHITIET();
                                    itemInsert.MA_PHIEU = model.MA_PHIEU;
                                    itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                                    itemInsert.KEHOACH_THANHTRA = itemDetail.KEHOACH_THANHTRA;
                                    itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                                    itemInsert.LYDO_THANHTRA = itemDetail.LYDO_THANHTRA;
                                    itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                                    itemInsert.PHONG_THANHTRA = itemDetail.PHONG_THANHTRA;
                                    itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                                    itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                                    itemInsert.TEN_DOITUONG = itemDetail.TEN_DOITUONG;
                                    itemInsert.PHONG_CHUTRI = itemDetail.PHONG_CHUTRI;
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
                        temp.DENNGAY = model.DENNGAY;
                        temp.TUNGAY = model.TUNGAY;
                        temp.DOT_THANHTRA = model.DOT_THANHTRA;
                        temp.NGAY_LAPPHIEU = model.NGAY_LAPPHIEU;
                        temp.NOIDUNG = model.NOIDUNG;
                        temp.ObjectState = ObjectState.Modified;
                        if (model.DETAILS != null && model.DETAILS.Count > 0)
                        {
                            foreach (var itemDetail in model.DETAILS)
                            {
                                PHF_XD_KH_THANHTRA_BO_CHITIET itemInsert = new PHF_XD_KH_THANHTRA_BO_CHITIET();
                                itemInsert.MA_PHIEU = model.MA_PHIEU;
                                itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                                itemInsert.KEHOACH_THANHTRA = itemDetail.KEHOACH_THANHTRA;
                                itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                                itemInsert.LYDO_THANHTRA = itemDetail.LYDO_THANHTRA;
                                itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                                itemInsert.PHONG_THANHTRA = itemDetail.PHONG_THANHTRA;
                                itemInsert.MA_DOITUONG = itemDetail.MA_DOITUONG;
                                itemInsert.MA_DOITUONG_CHA = itemDetail.MA_DOITUONG_CHA;
                                itemInsert.TEN_DOITUONG = itemDetail.TEN_DOITUONG;
                                itemInsert.PHONG_CHUTRI = itemDetail.PHONG_CHUTRI;
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
        [CustomAuthorize(Method = "XOA", State = "phf_phanCongKeHoach")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_XD_KH_THANHTRA_BO item = await _service.FindByIdAsync(long.Parse(id));
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