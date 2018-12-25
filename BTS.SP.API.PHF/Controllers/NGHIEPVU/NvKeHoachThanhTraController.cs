using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BTS.SP.API.ENTITY.Models.Nv.PHF;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.NV.KEHOACH_THANHTRA;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using DocumentFormat.OpenXml.Packaging;
using WriteLogs = BTS.SP.API.PHF.Utils.WriteLogs;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/keHoachThanhTra")]
    [Route("{id?}")]
    public class NvKeHoachThanhTraController : ApiController
    {
        private readonly INvKhThanhTraService _service;
        public NvKeHoachThanhTraController(INvKhThanhTraService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("TaoMaChungTu")]
        public NvKhThanhTraVm.Dto TaoMaChungTu()
        {            
            return _service.TaoMaChungTuService();
        }

        [Route("pagingData")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_dmDonVi")]
        public async Task<IHttpActionResult> pagingData()
        {
            var result = new Response<List<PHF_KEHOACH_THANHTRA_H>>();
            try
            {
                var data = _service.Repository.DbSet.Where(x => x.Loai.Equals(State.LoaiThanhTra.TTR_B.ToString())).ToList();
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
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return InternalServerError();
            }
        }

        [Route("getDetails")]
        [HttpPost]
        public async Task<IHttpActionResult> getDetails(NvKhThanhTraVm.Dto instance)
        {
            TransferObj<NvKhThanhTraVm.Dto> result = new TransferObj<NvKhThanhTraVm.Dto>();
            NvKhThanhTraVm.Dto chungTuResult = new NvKhThanhTraVm.Dto();
            try
            {
                PHF_KEHOACH_THANHTRA_H chungTu = _service.FindById(instance.Id);
                if (chungTu != null)
                {
                    chungTuResult = Mapper.Map<PHF_KEHOACH_THANHTRA_H, NvKhThanhTraVm.Dto>(chungTu);
                    List<PHF_KEHOACH_THANHTRA_D> chiTietChungTu = _service.UnitOfWork.Repository<PHF_KEHOACH_THANHTRA_D>().DbSet.Where(x => x.MaChungTu == chungTu.MaChungTu).ToList();
                    chungTuResult.DataDetails = Mapper.Map<List<PHF_KEHOACH_THANHTRA_D>, List<NvKhThanhTraVm.DtoDetail>>(chiTietChungTu);
                    result.Status = true;
                    result.Data = chungTuResult;

                }
                else
                {
                    result.Data = null;
                    result.Message = "Không tìm thấy dòng chi tiết phiếu";
                    result.Status = false;
                    return BadRequest(result.Message);
                }
            }
            catch (Exception e)
            {
                WriteLogs.LogError(e);
                result.Message = e.Message.ToString();
                result.Status = false;
                
            }
            return Ok(result);
        }

        //[Route("UploadWord")]
        //[HttpPost]
        //[AllowAnonymous]
        //public void UploadWord()
        //{
        //    try
        //    {
        //        string pathFolder = _service.CloneFile(_service.MapPath(), "ThongTinKhenThuong.docx");
        //        using (WordprocessingDocument myDoc = WordprocessingDocument.Open(pathFolder + "ThongTinKhenThuong.docx", true))
        //        {
        //            MainDocumentPart mainPart = myDoc.MainDocumentPart;
        //            var sdtElement = OpenXmlUtils.WDGetContentControl(mainPart, "Fi_Test");
        //            OpenXmlUtils.AddTextToSdt(sdtElement, "Tuấn Anh", 10);

        //            mainPart.Document.Save();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        [Route("AddNew")]
        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_doivoittbo")]
        public async Task<IHttpActionResult> AddNew(NvKhThanhTraVm.Dto instance)
        {
            TransferObj<PHF_KEHOACH_THANHTRA_H> result = new TransferObj<PHF_KEHOACH_THANHTRA_H>();
            try
            {
                PHF_KEHOACH_THANHTRA_H item = _service.InsertPhieu(instance);
                if (item != null)
                {
                    if (await _service.UnitOfWork.SaveAsync() > 0)
                    {
                        result.Data = item;
                        result.Message = "Thêm mới thành công";
                        result.Status = true;
                    }
                    else
                    {
                        result.Data = null;
                        result.Message = "Xảy ra lỗi khi thêm mới";
                        result.Status = false;
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    result.Data = null;
                    result.Message = "Không tìm thấy dòng chi tiết phiếu";
                    result.Status = false;
                    return BadRequest(result.Message);
                }
                return CreatedAtRoute("DefaultApi", new { controller = this, id = instance.MaChungTu }, result);

            }
            catch (Exception e)
            {
                WriteLogs.LogError(e);
                result.Message = e.Message.ToString();
                result.Status = false;
            }

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Repository.DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}