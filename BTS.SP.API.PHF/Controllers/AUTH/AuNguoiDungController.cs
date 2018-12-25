using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.AUTH.AuNguoiDung;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.AUTH
{
    [RoutePrefix("api/auth/AuNguoiDung")]
    [Route("{id?}")]
    [Authorize]
    public class AuNguoiDungController : ApiController
    {
        private readonly IAuNguoiDungService _auNguoiDungService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public AuNguoiDungController(IAuNguoiDungService auNguoiDungService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _auNguoiDungService = auNguoiDungService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("pagingData")]
        [CustomAuthorize(Method = "XEM", State = "AuNguoiDung")]
        [HttpPost]
        public async Task<IHttpActionResult> pagingData(AuNguoiDungVm.ParameterModel param)
        {
            var result = new Response<List<AuNguoiDungVm.ViewModel>>();
            try
            {
                var data = _auNguoiDungService.GetAllUserPhongBan(param.MA_DONVI);
                if (data.Count > 0)
                {
                    result.Data = data;
                    result.Error = true;
                }
                else
                {
                    result.Data = data;
                    result.Error = false;
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                WriteLogs.LogError(e);
                return InternalServerError();
            }
        }
        [Route("AddNew")]
        [HttpPost]
        [ResponseType(typeof(AuNguoiDungVm.ModelInsert))]
        [CustomAuthorize(Method = "THEM", State = "phf_AuNguoiDung")]
        public IHttpActionResult AddNew(AuNguoiDungVm.ModelInsert instance)
        {
            var result = new TransferObj<AuNguoiDungVm.ModelInsert>();
            try
            {
                instance.PASSWORD = MD5Encrypt.MD5Hash(instance.PASSWORD);
                var item = _auNguoiDungService.InsertUser(instance);
                if (item)
                {
                    result.Status = true;
                    result.Message = "Oke";
                }
                else
                {
                    result.Message = "Error";
                    result.Status = false;
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return Ok(result);
        }
        [HttpPut]
        [ResponseType(typeof(AuNguoiDungVm.ModelUpdate))]
        [CustomAuthorize(Method = "SUA", State = "phf_AuNguoiDung")]
        public IHttpActionResult Put(string ID, AuNguoiDungVm.ModelUpdate instance)
        {
            var result = new TransferObj<AuNguoiDungVm.ModelUpdate>();
            try
            {
                instance.PASSWORD = MD5Encrypt.MD5Hash(instance.PASSWORD);
                var item = _auNguoiDungService.UpdateUser(instance);
                if (item)
                {
                    result.Status = true;
                    result.Message = "Oke";
                }
                else
                {
                    result.Message = "Error";
                    result.Status = false;
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return Ok(result);
        }
        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_AuNguoiDung")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = new TransferObj<AuNguoiDungVm>();
            try
            {
                var item = _auNguoiDungService.DeleteUser(id);
                if (item)
                {
                    result.Status = true;
                    result.Message = "Oke";
                }
                else
                {
                    result.Status = false;
                    result.Message = "Error";
                }
            }
            catch (Exception e)
            {
                WriteLogs.LogError(e);
                result.Status = false;
                result.Message = e.Message;
                return InternalServerError();
            }
            return Ok(result);
        }

        [Route("CheckExistCode/{code}")]
        [HttpGet]
        public IHttpActionResult CheckExistCode(string code)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(code))
            {
                result = _auNguoiDungService.CheckExistCode(code);
            }
            return Ok(result);
        }
        [Route("GetInfoUserByUserName")]
        [HttpPost]
        public IHttpActionResult GetInfoUserByUserName(AuNguoiDungVm.ParameterModel parameter)
        {
            var result = new TransferObj<AuNguoiDungVm.ViewModel>(); 
            if (parameter != null)
            {
                result.Data = _auNguoiDungService.GetInfoUserByUserName(parameter);
            }
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
