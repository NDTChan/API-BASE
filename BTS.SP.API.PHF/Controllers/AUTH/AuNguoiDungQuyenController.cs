using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Auth;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDungQuyen;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.AUTH
{
    [RoutePrefix("api/auth/AuNguoiDungQuyen")]
    [Route("{id?}")]
    public class AuNguoiDungQuyenController : ApiController
    {
        private readonly IAuNguoiDungQuyenService _auNguoiDungQuyenService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly string PHANHE = "B";

        public AuNguoiDungQuyenController(IAuNguoiDungQuyenService auNguoiDungQuyenService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _auNguoiDungQuyenService = auNguoiDungQuyenService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        [HttpPost]
        [Route("Config")]
        public async Task<IHttpActionResult> Config(AuNguoiDungQuyenConfigModel model)
        {
            Response<string> response = new Response<string>();
            bool hasValue = false;
            try
            {
                #region Delete
                if (model.LstDelete != null && model.LstDelete.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstDelete)
                    {
                        AU_NGUOIDUNG_QUYEN obj = _auNguoiDungQuyenService.Queryable()
                            .FirstOrDefault(x => x.Id == item.Id);
                        if (obj != null)
                        {
                            obj.ObjectState = ObjectState.Deleted;
                            _auNguoiDungQuyenService.Delete(obj);
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
                        AU_NGUOIDUNG_QUYEN obj = new AU_NGUOIDUNG_QUYEN()
                        {
                            ObjectState = ObjectState.Added,
                            PHANHE = PHANHE,
                            USERNAME = item.USERNAME,
                            MACHUCNANG = item.MACHUCNANG,
                            XOA = item.XOA,
                            DUYET = item.DUYET,
                            SUA = item.SUA,
                            THEM = item.THEM,
                            TRANGTHAI = 1,
                            XEM = item.XEM
                        };
                        _auNguoiDungQuyenService.Insert(obj);
                    }
                }
                #endregion

                #region Edit
                if (model.LstEdit != null && model.LstEdit.Count > 0)
                {
                    hasValue = true;
                    foreach (var item in model.LstEdit)
                    {
                        AU_NGUOIDUNG_QUYEN obj = _auNguoiDungQuyenService.Queryable()
                            .FirstOrDefault(x => x.Id == item.Id);
                        if (obj != null)
                        {
                            obj.ObjectState = ObjectState.Modified;
                            obj.PHANHE = PHANHE;
                            obj.XEM = item.XEM;
                            obj.THEM = item.THEM;
                            obj.SUA = item.SUA;
                            obj.XOA = item.XOA;
                            obj.DUYET = item.DUYET;
                            _auNguoiDungQuyenService.Update(obj);
                        }
                    }
                }
                #endregion

                if (hasValue)
                {
                    if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                    {
                        response.Error = false;
                        response.Message = "Cập nhật thành công";
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

        [HttpGet]
        [Route("GetByUsername/{username}")]
        public async Task<IHttpActionResult> GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return BadRequest();
            var result = await _auNguoiDungQuyenService.GetByUsername(PHANHE,username);
            return Ok(result);
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
