using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BTS.SP.PHF.SERVICE.NV.XayDungKeHoachThanhTraCoQuanThuocBo;
using Repository.Pattern.UnitOfWork;
using BTS.SP.PHF.SERVICE.UTILS;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.PHF.ENTITY;
using Repository.Pattern.Infrastructure;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_KeHoachThanhTraCoQuan")]
    [Route("{id?}")]
    [Authorize]
    public class NvKeHoachThanhTraCoQuanController : ApiController
    {
        public readonly IPHF_KH_THANHTRA_COQUANService _service;
        public readonly IPHF_KH_THANHTRA_COQUAN_CTService _serviceDetail;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public NvKeHoachThanhTraCoQuanController(IPHF_KH_THANHTRA_COQUANService service, IPHF_KH_THANHTRA_COQUAN_CTService serviceDetail, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDetail = serviceDetail;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_KeHoachThanhTraCoQuan")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_KH_THANHTRA_COQUAN>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<PHF_KH_THANHTRA_COQUANVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_KH_THANHTRA_COQUAN>>();

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
            var response = new Response<PHF_KH_THANHTRA_COQUANVm.DTO>();
            try
            {
                var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(refid))
                    .OrderBy(x => x.Id).ToList();
                var data = new PHF_KH_THANHTRA_COQUANVm.DTO
                {
                    MA_PHIEU = refid
                };
                if (details != null && details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        PHF_KH_THANHTRA_COQUANVm.DTO_DETAILS itemDetails = new PHF_KH_THANHTRA_COQUANVm.DTO_DETAILS();
                        itemDetails.MA_PHIEU = item.MA_PHIEU;
                        itemDetails.LOAI_THANHTRA = item.LOAI_THANHTRA;
                        itemDetails.NHOM_THANHTRA = item.NHOM_THANHTRA;
                        itemDetails.DOITUONG_THANHTRA = item.DOITUONG_THANHTRA;
                        itemDetails.COQUAN_THANHTRA = item.COQUAN_THANHTRA;
                        itemDetails.NOIDUNG_THANHTRA = item.NOIDUNG_THANHTRA;
                        itemDetails.THOIKY_THANHTRA = item.THOIKY_THANHTRA;
                        itemDetails.TEP_DINHKEM = item.TEP_DINHKEM;
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
                var lastestID = _service.BuildCodeWithParameter("KHTTCQTB_", "KHTTCQTB_", true);
                return Ok(lastestID);
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }
        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_KeHoachThanhTraCoQuan")]
        public async Task<IHttpActionResult> Post(PHF_KH_THANHTRA_COQUANVm.DTO model)
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
                    PHF_KH_THANHTRA_COQUAN obj = new PHF_KH_THANHTRA_COQUAN();
                    obj.MA_PHIEU = model.MA_PHIEU;
                    obj.NGAYTHANG_LUUTRU = model.NGAYTHANG_LUUTRU;
                    obj.NAM_THANHTRA = model.NAM_THANHTRA;
                    obj.NOIDUNG = model.NOIDUNG;
                    obj.DOT_THANHTRA = model.DOT_THANHTRA;
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (model.DETAILS != null && model.DETAILS.Count > 0)
                    {
                        foreach (var itemDetail in model.DETAILS)
                        {
                            PHF_KH_THANHTRA_COQUAN_CT itemInsert = new PHF_KH_THANHTRA_COQUAN_CT();
                            itemInsert.MA_PHIEU = model.MA_PHIEU;
                            itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                            itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                            itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                            itemInsert.COQUAN_THANHTRA = itemDetail.COQUAN_THANHTRA;
                            itemInsert.NOIDUNG_THANHTRA = itemDetail.NOIDUNG_THANHTRA;
                            itemInsert.THOIKY_THANHTRA = itemDetail.THOIKY_THANHTRA;
                            itemInsert.TEP_DINHKEM = itemDetail.TEP_DINHKEM;
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
        [CustomAuthorize(Method = "SUA", State = "phf_KeHoachThanhTraCoQuan")]
        public async Task<IHttpActionResult> Put(string id, PHF_KH_THANHTRA_COQUANVm.DTO model)
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
                            temp.NGAYTHANG_LUUTRU = model.NGAYTHANG_LUUTRU;
                            temp.NAM_THANHTRA = model.NAM_THANHTRA;
                            temp.NOIDUNG = model.NOIDUNG;
                            temp.DOT_THANHTRA = model.DOT_THANHTRA;
                            temp.ObjectState = ObjectState.Modified;
                            if (model.DETAILS != null && model.DETAILS.Count > 0)
                            {
                                foreach (var itemDetail in model.DETAILS)
                                {
                                    PHF_KH_THANHTRA_COQUAN_CT itemInsert = new PHF_KH_THANHTRA_COQUAN_CT();
                                    itemInsert.MA_PHIEU = model.MA_PHIEU;
                                    itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                                    itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                                    itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                                    itemInsert.COQUAN_THANHTRA = itemDetail.COQUAN_THANHTRA;
                                    itemInsert.NOIDUNG_THANHTRA = itemDetail.NOIDUNG_THANHTRA;
                                    itemInsert.THOIKY_THANHTRA = itemDetail.THOIKY_THANHTRA;
                                    itemInsert.TEP_DINHKEM = itemDetail.TEP_DINHKEM;
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
                        temp.NGAYTHANG_LUUTRU = model.NGAYTHANG_LUUTRU;
                        temp.NAM_THANHTRA = model.NAM_THANHTRA;
                        temp.NOIDUNG = model.NOIDUNG;
                        temp.DOT_THANHTRA = model.DOT_THANHTRA;
                        temp.ObjectState = ObjectState.Modified;
                        if (model.DETAILS != null && model.DETAILS.Count > 0)
                        {
                            foreach (var itemDetail in model.DETAILS)
                            {
                                PHF_KH_THANHTRA_COQUAN_CT itemInsert = new PHF_KH_THANHTRA_COQUAN_CT();
                                itemInsert.MA_PHIEU = model.MA_PHIEU;
                                itemInsert.LOAI_THANHTRA = itemDetail.LOAI_THANHTRA;
                                itemInsert.NHOM_THANHTRA = itemDetail.NHOM_THANHTRA;
                                itemInsert.DOITUONG_THANHTRA = itemDetail.DOITUONG_THANHTRA;
                                itemInsert.COQUAN_THANHTRA = itemDetail.COQUAN_THANHTRA;
                                itemInsert.NOIDUNG_THANHTRA = itemDetail.NOIDUNG_THANHTRA;
                                itemInsert.THOIKY_THANHTRA = itemDetail.THOIKY_THANHTRA;
                                itemInsert.TEP_DINHKEM = itemDetail.TEP_DINHKEM;
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
        [CustomAuthorize(Method = "XOA", State = "phf_KeHoachThanhTraCoQuan")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_KH_THANHTRA_COQUAN item = await _service.FindByIdAsync(long.Parse(id));
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