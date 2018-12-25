using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Repository.Pattern.UnitOfWork;
using BTS.SP.PHF.SERVICE.NV.ThanhTraThuocBo;
using System.Threading.Tasks;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using Newtonsoft.Json.Linq;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.PHF.ENTITY.Nv;
using Repository.Pattern.Infrastructure;
using AutoMapper;
using System.Threading;
using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.SERVICE.NV.ThuMucFile;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvXayDungKeHoachThuocBo")]
    [Route("{id?}")]
    [Authorize]
    public class NvXdKhTtThuocBoController : ApiController
    {
        public readonly INV_XD_KH_TT_THUOC_BOService _service;
        public readonly ITHUMUCFILEService _serviceThuMuc;
        public readonly INV_XD_KH_TT_THUOC_BO_CTService _serviceDetail;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public static string CODE_GEN = "KHTTDVTB";
        public static string LOAI_CHUNGTU = "PHF";

        public NvXdKhTtThuocBoController(INV_XD_KH_TT_THUOC_BOService service, INV_XD_KH_TT_THUOC_BO_CTService serviceDetail, IUnitOfWorkAsync unitOfWorkAsync, ITHUMUCFILEService serviceThuMuc)
        {
            _service = service;
            _serviceDetail = serviceDetail;
            _unitOfWorkAsync = unitOfWorkAsync;
            _serviceThuMuc = serviceThuMuc;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvKhThanhTraThuocBo")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_XD_KH_TT_THUOC_BO>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_XD_KH_TT_THUOC_BOVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_XD_KH_TT_THUOC_BO>>();

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

        [Route("GetNewInstance")]
        [HttpGet]
        public async Task<IHttpActionResult> GetNewInstance()
        {
            var model = new NV_XD_KH_TT_THUOC_BOVm.DTO();
            var result = new TransferObj();
            model.MA_PHIEU = _service.BuildCodeWithParameter(CODE_GEN, LOAI_CHUNGTU, false);
            model.NGAY_LUU_DL = DateTime.Now;
            result.Data = model;
            result.Status = true;
            return Ok(result);
        }

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_nvKhThanhTraThuocBo")]
        public async Task<IHttpActionResult> Post(NV_XD_KH_TT_THUOC_BOVm.DTO model)
        {

            var response = new Response<string>();
            try
            {
                var found = _service.Queryable().Where(x => x.MA_PHIEU == model.MA_PHIEU).ToList();
                if (found.Count > 0)
                {
                    response.Error = true;
                    response.Message = "Phiếu đã tồn tại !";
                }
                else
                {
                    PHF_XD_KH_TT_THUOC_BO obj = new PHF_XD_KH_TT_THUOC_BO();
                    obj = Mapper.Map<NV_XD_KH_TT_THUOC_BOVm.DTO,PHF_XD_KH_TT_THUOC_BO>(model);
                    obj.MA_PHIEU = _service.BuildCodeWithParameter(CODE_GEN, LOAI_CHUNGTU, true);
                    obj.ObjectState = ObjectState.Added;
                    _service.Insert(obj);
                    if (model.DETAILS != null && model.DETAILS.Count > 0)
                    {
                        var lstChiTiet = Mapper.Map<List<NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS>, List<PHF_XD_KH_TT_THUOC_BO_CT>>(model.DETAILS);
                        foreach(var item in lstChiTiet)
                        {
                            item.MA_PHIEU = obj.MA_PHIEU;
                        }
                        _serviceDetail.InsertRange(lstChiTiet);
                    }
                    var a = await _unitOfWorkAsync.SaveChangesAsync(CancellationToken.None);
                    if (a > 0)
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

        [Route("GetDetailByRefId/{refid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDetailByRefId(string refid)
        {
            if (string.IsNullOrEmpty(refid)) return BadRequest();
            var response = new Response<NV_XD_KH_TT_THUOC_BOVm.DTO>();
            try
            {
                var found = _service.Queryable().FirstOrDefault(x => x.MA_PHIEU.Equals(refid));
                if(found != null)
                {
                    var data = Mapper.Map<PHF_XD_KH_TT_THUOC_BO, NV_XD_KH_TT_THUOC_BOVm.DTO>(found);
                    var details = _serviceDetail.Queryable().Where(x => x.MA_PHIEU.Equals(refid))
                        .OrderBy(x => x.Id).ToList();
                    if (details != null && details.Count > 0)
                    {
                        foreach (var item in details)
                        {
                            NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS itemDetails = new NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS();
                            itemDetails = Mapper.Map<PHF_XD_KH_TT_THUOC_BO_CT, NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS>(item);
                            data.DETAILS.Add(itemDetails);
                        }
                    }
                    response.Error = false;
                    response.Data = data;
                }
                else
                {
                    response.Error = true;
                    response.Message = "Không tìm thấy kế hoạch thanh tra";
                }
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ErrorMessage.ERROR_SYSTEM;
            }
            return Ok(response);
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_nvKhThanhTraThuocBo")]
        public async Task<IHttpActionResult> Put(string id, NV_XD_KH_TT_THUOC_BOVm.DTO model)
        {
            if (string.IsNullOrEmpty(id) || !id.Equals(model.Id.ToString())) return BadRequest();
            Response<string> response = new Response<string>();
            try
            {
                var temp = _service.FindById(model.Id);
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
                            temp.MA_DOITUONG = model.MA_DOITUONG;
                            temp.NAM_THANHTRA = model.NAM_THANHTRA;
                            temp.NOI_DUNG = model.NOI_DUNG;
                            temp.NGAY_LUU_DL = model.NGAY_LUU_DL;
                            temp.ObjectState = ObjectState.Modified;
                            if (model.DETAILS != null && model.DETAILS.Count > 0)
                            {
                                foreach (var itemDetail in model.DETAILS)
                                {
                                    PHF_XD_KH_TT_THUOC_BO_CT itemInsert = new PHF_XD_KH_TT_THUOC_BO_CT();
                                    itemInsert = Mapper.Map<NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS, PHF_XD_KH_TT_THUOC_BO_CT>(itemDetail);
                                    itemInsert.MA_PHIEU = temp.MA_PHIEU;
                                    //itemInsert.MA_PHIEU = model.MA_PHIEU;
                                    //itemInsert.DOI_TUONG_TT = itemDetail.DOI_TUONG_TT;
                                    //itemInsert.KE_HOACH_TT = itemDetail.KE_HOACH_TT;
                                    //itemInsert.LOAI_TT = itemDetail.LOAI_TT;
                                    //itemInsert.NHOM_TT = itemDetail.NHOM_TT;
                                    //itemInsert.PHONG_TT = itemDetail.PHONG_TT;
                                    //itemInsert.TRUONGDOAN_TT = itemDetail.TRUONGDOAN_TT;
                                    //itemInsert.THANHVIEN_DOAN = itemDetail.THANHVIEN_DOAN;
                                    //itemInsert.SO_NGAY_THANG_QG = itemDetail.SO_NGAY_THANG_QG;
                                    //itemInsert.THOIHAN_TT = itemDetail.THOIHAN_TT;
                                    //itemInsert.NGAY_TRIENKHAI = itemDetail.NGAY_TRIENKHAI;
                                    //itemInsert.NGAY_KETTHUC = itemDetail.NGAY_KETTHUC;
                                    //itemInsert.GIAMSAT_DOAN = itemDetail.GIAMSAT_DOAN;

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
                        temp.MA_DOITUONG = model.MA_DOITUONG;
                        temp.NAM_THANHTRA = model.NAM_THANHTRA;
                        temp.NOI_DUNG = model.NOI_DUNG;
                        temp.NGAY_LUU_DL = model.NGAY_LUU_DL;
                        temp.ObjectState = ObjectState.Modified;
                        if (model.DETAILS != null && model.DETAILS.Count > 0)
                        {
                            foreach (var itemDetail in model.DETAILS)
                            {
                                PHF_XD_KH_TT_THUOC_BO_CT itemInsert = new PHF_XD_KH_TT_THUOC_BO_CT();
                                itemInsert = Mapper.Map<NV_XD_KH_TT_THUOC_BOVm.DTO_DETAILS, PHF_XD_KH_TT_THUOC_BO_CT>(itemDetail);

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
        [CustomAuthorize(Method = "XOA", State = "phf_nvKhThanhTraThuocBo")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_XD_KH_TT_THUOC_BO item = await _service.FindByIdAsync(long.Parse(id));
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