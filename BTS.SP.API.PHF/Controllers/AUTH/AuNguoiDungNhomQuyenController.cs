using System;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungNhomQuyen;
using BTS.SP.PHF.SERVICE.UTILS;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.AUTH
{
    [RoutePrefix("api/auth/AuNguoiDungNhomQuyen")]
    [Route("{id?}")]
    [Authorize]
    public class AuNguoiDungNhomQuyenController : ApiController
    {
        private readonly IAuNguoiDungNhomQuyenService _auNguoiDungNhomQuyenService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly string PHANHE = "B";

        public AuNguoiDungNhomQuyenController(IAuNguoiDungNhomQuyenService auNguoiDungNhomQuyenService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _auNguoiDungNhomQuyenService = auNguoiDungNhomQuyenService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        [HttpGet]
        [Route("GetByUsername/{username}")]
        public async Task<IHttpActionResult> GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return BadRequest();
            var result = await _auNguoiDungNhomQuyenService.GetByUsername(PHANHE,username);
            return Ok(result);
        }

        [HttpPost]
        [Route("Config")]
        public async Task<IHttpActionResult> Config(AuNguoiDungNhomQuyenConfigModel model)
        {
            var response = new Response<string>();
            var hasValue = false;
            try
            {
                #region Delete
                if (model.LstDelete != null && model.LstDelete.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstDelete)
                    {
                        var entity = _auNguoiDungNhomQuyenService.Queryable().FirstOrDefault(x => x.Id == item.Id);
                        if (entity != null)
                        {
                            entity.ObjectState = ObjectState.Deleted;
                            _auNguoiDungNhomQuyenService.Delete(entity);
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
                        var entity = new AU_NGUOIDUNG_NHOMQUYEN()
                        {
                            ObjectState = ObjectState.Added,
                            USERNAME = item.USERNAME,
                            MANHOMQUYEN = item.MANHOMQUYEN,
                            PHANHE = PHANHE
                        };
                        _auNguoiDungNhomQuyenService.Insert(entity);
                    }
                }
                #endregion

                if (hasValue)
                {
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        response.Error = false;
                        response.Message = "Cập nhật thành công.";
                        var memoryCache = MemoryCache.Default;
                        var cacheData = memoryCache.FirstOrDefault(x => x.Key.StartsWith(PHANHE + "|" + model.USERNAME));
                        if (cacheData.Value != null)
                        {
                            memoryCache.Remove(cacheData.Key);
                        }
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
