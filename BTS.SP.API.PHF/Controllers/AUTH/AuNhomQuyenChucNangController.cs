using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNhomQuyenChucNang;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.AUTH
{
    [RoutePrefix("api/auth/AuNhomQuyenChucNang")]
    [Route("{id?}")]
    [Authorize]
    public class AuNhomQuyenChucNangController : ApiController
    {
        private readonly IAuNhomQuyenChucNangService _auNhomQuyenChucNangService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly string PHANHE = "B";

        public AuNhomQuyenChucNangController(IAuNhomQuyenChucNangService auNhomQuyenChucNangService,
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _auNhomQuyenChucNangService = auNhomQuyenChucNangService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("GetByMaNhomQuyen/{manhomquyen}")]
        public async Task<IHttpActionResult> GetByMaNhomQuyen(string manhomquyen)
        {
            if (string.IsNullOrEmpty(manhomquyen)) return BadRequest();
            Response<List<AuNhomQuyenChucNangViewModel>> response =new Response<List<AuNhomQuyenChucNangViewModel>>();
            try
            {
                response.Data = await _auNhomQuyenChucNangService.GetByMaNhomQuyen(PHANHE,manhomquyen);
                response.Error = false;
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [Route("Config")]
        [HttpPost]
        public async Task<IHttpActionResult> Config(AuNhomQuyenChucNangConfigModel model)
        {
            if (string.IsNullOrEmpty(model.MANHOMQUYEN)) return BadRequest();
            Response<string> response=new Response<string>();
            bool hasValue = false;
            try
            {
                #region Delete
                if (model.LstDelete != null && model.LstDelete.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstDelete)
                    {
                        AU_NHOMQUYEN_CHUCNANG obj = _auNhomQuyenChucNangService.Queryable().FirstOrDefault(x=>x.Id == item.Id);
                        if (obj != null)
                        {
                            obj.ObjectState = ObjectState.Deleted;
                            _auNhomQuyenChucNangService.Delete(obj);
                        }
                    }
                }


                #endregion

                #region Add
                if (model.LstAdd != null && model.LstAdd.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstAdd)
                    {
                        AU_NHOMQUYEN_CHUCNANG obj = new AU_NHOMQUYEN_CHUCNANG()
                        {
                            ObjectState = ObjectState.Added,
                            PHANHE = PHANHE,
                            MANHOMQUYEN = item.MANHOMQUYEN,
                            MACHUCNANG = item.MACHUCNANG,
                            XOA = item.XOA,
                            DUYET = item.DUYET,
                            SUA = item.SUA,
                            THEM = item.THEM,
                            TRANGTHAI = 1,
                            XEM = item.XEM
                        };
                        _auNhomQuyenChucNangService.Insert(obj);
                    }
                }


                #endregion

                #region Edit
                if (model.LstEdit != null && model.LstEdit.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstEdit)
                    {
                        AU_NHOMQUYEN_CHUCNANG obj = _auNhomQuyenChucNangService.Queryable().FirstOrDefault(x => x.Id == item.Id);
                        if (obj != null && obj.Id > 0)
                        {
                            obj.ObjectState = ObjectState.Modified;
                            obj.PHANHE = PHANHE;
                            obj.XEM = item.XEM;
                            obj.THEM = item.THEM;
                            obj.SUA = item.SUA;
                            obj.XOA = item.XOA;
                            obj.DUYET = item.DUYET;
                            _auNhomQuyenChucNangService.Update(obj);
                        }
                    }
                }
                #endregion

                if (hasValue)
                {
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
                else
                {
                    response.Error = true;
                    response.Message = "Không có dữ liệu cập nhật.";
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
