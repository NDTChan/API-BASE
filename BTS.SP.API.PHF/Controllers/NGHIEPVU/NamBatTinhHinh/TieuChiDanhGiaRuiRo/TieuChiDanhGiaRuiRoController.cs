using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.NamBatTinhHinh.TieuChiDanhGiaRuiRo;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using BTS.SP.TOOLS.BuildQuery.Types;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU.NamBatTinhHinh.TieuChiDanhGiaRuiRo
{
    [RoutePrefix("api/nv/phf_TieuChiDanhGiaRuiRo")]
    [Route("{id?}")]
    [Authorize]
    public class TieuChiDanhGiaRuiRoController : ApiController
    {
        public readonly IPHF_TIEUCHI_DGRRService _pHF_TIEUCHI_DGRRService;
        public readonly IPHF_TIEUCHI_DGRR_DETAILService _pHF_TIEUCHI_DGRR_DETAILService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public TieuChiDanhGiaRuiRoController(IPHF_TIEUCHI_DGRRService pHF_TIEUCHI_DGRRService, IPHF_TIEUCHI_DGRR_DETAILService pHF_TIEUCHI_DGRR_DETAILService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _pHF_TIEUCHI_DGRRService = pHF_TIEUCHI_DGRRService;
            _pHF_TIEUCHI_DGRR_DETAILService = pHF_TIEUCHI_DGRR_DETAILService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        #region CHẬM NỘP BÁO CÁO QUYẾT TOÁN
        [Route("PagingChamNopBaoCao")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_ChamNopBaoCaoQuyetToan")]
        public async Task<IHttpActionResult> PagingChamNopBaoCao(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_TIEUCHI_DGRR>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<PHF_TIEUCHI_DGRRVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_TIEUCHI_DGRR>>();
            var query = new QueryBuilder
            {
                Take = paged.itemsPerPage,
                Skip = paged.fromItem - 1,
                Filter = new QueryFilterLinQ()
                {
                    Property = ClassHelper.GetProperty(() => new PHF_TIEUCHI_DGRR().LOAINHAP_TIEUCHI_DGRR),
                    Method = FilterMethod.EqualTo,
                    Value = LOAINHAP_TIEUCHI_DGRR.CHAMNOPBAOCAOQUYETTOAN
                }
            };
            try
            {
                var filterResult = await _pHF_TIEUCHI_DGRRService.FilterAsync(filtered, query);
                if (!filterResult.WasSuccessful)
                {
                    return NotFound();
                }
                result.Data = filterResult.Value;
                result.Error = false;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("GetChamNopBaoCao/{id:long}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetChamNopBaoCao(long id)
        {
            var response = new Response<PHF_TIEUCHI_DGRRVm.ViewModel>();
            try
            {
                var item = await _pHF_TIEUCHI_DGRRService.Queryable().FirstOrDefaultAsync(x => x.Id == id && x.LOAINHAP_TIEUCHI_DGRR == LOAINHAP_TIEUCHI_DGRR.CHAMNOPBAOCAOQUYETTOAN);
                if (item == null) return NotFound();
                PHF_TIEUCHI_DGRRVm.ViewModel data = new PHF_TIEUCHI_DGRRVm.ViewModel();
                data.Id = item.Id;
                data.LOAIMANHAP = item.LOAIMANHAP;
                data.LOAINHAP_TIEUCHI_DGRR = item.LOAINHAP_TIEUCHI_DGRR;
                data.MA_DOTTHANHTRA = item.MA_DOTTHANHTRA;
                data.MA_LOAITHANHTRA = item.MA_LOAITHANHTRA;
                data.REF_ID = item.REF_ID;
                data.TUNGAY = item.TUNGAY;
                data.DENNGAY = item.DENNGAY;
                data.DETAILS = new List<PHF_TIEUCHI_DGRR_DETAILVm.ViewModel>();
                var lstDetail = await _pHF_TIEUCHI_DGRR_DETAILService.Queryable().Where(x => x.REF_ID.Equals(item.REF_ID)).Select(x => new PHF_TIEUCHI_DGRR_DETAILVm.ViewModel()
                {
                    Id = x.Id,
                    REF_ID = x.REF_ID,
                    MA = x.MA,
                    TEN = x.TEN,
                    SONGAYNOPCHAM = x.SONGAYNOPCHAM,
                    THOIGIANNOP = x.THOIGIANNOP
                }).ToListAsync();
                response.Error = false;
                response.Data = data;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("PostChamNopBaoCao")]
        [CustomAuthorize(Method = "THEM", State = "phf_ChamNopBaoCaoQuyetToan")]
        public async Task<IHttpActionResult> Post(PHF_TIEUCHI_DGRRVm.InsertModel model)
        {
            Response response = new Response();
            if (ModelState.IsValid)
            {
                try
                {
                    var refId = Guid.NewGuid().ToString("D");

                    PHF_TIEUCHI_DGRR insertItem = new PHF_TIEUCHI_DGRR();
                    insertItem.LOAINHAP_TIEUCHI_DGRR = LOAINHAP_TIEUCHI_DGRR.CHAMNOPBAOCAOQUYETTOAN;
                    insertItem.LOAIMANHAP = model.LOAIMANHAP;
                    insertItem.MA_DOTTHANHTRA = model.MA_DOTTHANHTRA;
                    insertItem.MA_LOAITHANHTRA = model.MA_LOAITHANHTRA;
                    insertItem.TUNGAY = model.TUNGAY;
                    insertItem.DENNGAY = model.DENNGAY;
                    insertItem.ObjectState = ObjectState.Added;
                    insertItem.REF_ID = refId;
                    _pHF_TIEUCHI_DGRRService.Insert(insertItem);

                    foreach (var detailItem in model.DETAILS)
                    {
                        PHF_TIEUCHI_DGRR_DETAIL insertDetailItem = new PHF_TIEUCHI_DGRR_DETAIL();
                        insertDetailItem.REF_ID = refId;
                        insertDetailItem.MA = detailItem.MA;
                        insertDetailItem.TEN = detailItem.TEN;
                        insertDetailItem.THOIGIANNOP = detailItem.THOIGIANNOP;
                        insertDetailItem.SONGAYNOPCHAM = detailItem.SONGAYNOPCHAM;
                        insertDetailItem.ObjectState = ObjectState.Added;
                        _pHF_TIEUCHI_DGRR_DETAILService.Insert(insertDetailItem);
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
                catch (Exception ex)
                {
                    response.Error = true;
                    response.Message = ex.Message;
                }

                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteChamNopBaoCao/{id:long}")]
        [CustomAuthorize(Method = "XOA", State = "phf_ChamNopBaoCaoQuyetToan")]
        public async Task<IHttpActionResult> DeleteChamNopBaoCao(long id)
        {
            try
            {
                Response response = new Response();
                PHF_TIEUCHI_DGRR item = await _pHF_TIEUCHI_DGRRService.Queryable().FirstOrDefaultAsync(x => x.Id == id && x.LOAINHAP_TIEUCHI_DGRR == LOAINHAP_TIEUCHI_DGRR.CHAMNOPBAOCAOQUYETTOAN);
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _pHF_TIEUCHI_DGRRService.Delete(item);
                List<PHF_TIEUCHI_DGRR_DETAIL> lstDetail = await _pHF_TIEUCHI_DGRR_DETAILService.Queryable().Where(x => x.REF_ID.Equals(item.REF_ID)).ToListAsync();
                foreach (var detailItem in lstDetail)
                {
                    detailItem.ObjectState = ObjectState.Deleted;
                    _pHF_TIEUCHI_DGRR_DETAILService.Delete(detailItem);
                }
                if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                {
                    response.Error = false;
                    response.Message = "Xóa thành công.";
                }
                else
                {
                    response.Error = true;
                    response.Message = "Lỗi cập nhật dữ liệu.";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        #endregion
    }
}
