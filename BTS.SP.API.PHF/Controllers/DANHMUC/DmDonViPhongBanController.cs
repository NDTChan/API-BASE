using BTS.SP.API.PHF.Utils;
using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BTS.SP.API.PHF.Controllers.DANHMUC
{
    [RoutePrefix("api/dm/phf_dmDonViPhongBan")]
    [Route("{id?}")]
    [Authorize]
    public class DmDonViPhongBanController : ApiController
    {
        public readonly IDM_DONVI_PHONGBANService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public DmDonViPhongBanController(IDM_DONVI_PHONGBANService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_dmDonViPhongBan")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_DM_DONVI_PHONGBAN>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<DM_CANBOVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_DM_DONVI_PHONGBAN>>();
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

        [Route("GetSelectData")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectData()
        {
            try
            {
                return _service.Queryable().Where(x => x.TRANGTHAI == 1).Select(x => new ChoiceObj()
                {
                    Value = x.MA,
                    Text = x.TEN,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("GetSelectDataDonViTB")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectDataDonViTB()
        {
            try
            {
                return _service.Queryable().Where(x => x.MA_CHA == "TTr2").Select(x => new ChoiceObj()
                {
                    Value = x.MA,
                    Text = x.TEN,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("GetSelectDataDonVi")]
        [HttpGet]
        public IList<ChoiceObj> GetSelectDataDonVi()
        {
            try
            {
                return _service.Queryable().Where(x => x.MA_CHA == "TTr1").Select(x => new ChoiceObj()
                {
                    Value = x.MA,
                    Text = x.TEN,
                }).ToList();
            }
            catch (Exception ex)
            {
                WriteLogs.LogError(ex);
                return null;
            }
        }

        [Route("GetAllDonVi")]
        [HttpGet]
        [CustomAuthorize(Method = "XEM", State = "phf_dmDonViPhongBan")]
        public async Task<IHttpActionResult> GetAllDonVi()
        {
            var result = new Response<List<DM_DONVI_PHONGBANVm.DTO>>();
            var lstTemp = new List<DM_DONVI_PHONGBANVm.DTO>();
            try
            {
                var obj = _service.Queryable().ToList();
                foreach(var item in obj)
                {
                    DM_DONVI_PHONGBANVm.DTO tempDTO = new DM_DONVI_PHONGBANVm.DTO();
                    tempDTO.MA = item.MA;
                    tempDTO.TEN = item.TEN;
                    tempDTO.MA_CHA = item.MA_CHA;
                    lstTemp.Add(tempDTO);
                }
                result.Data = lstTemp;
                result.Error = false;
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.ToString();

            }
            return Ok(result);
        }

        [HttpPost]
        [CustomAuthorize(Method = "THEM", State = "phf_dmCanBo")]
        public async Task<IHttpActionResult> Post(PHF_DM_DONVI_PHONGBAN model)
        {
            Response<PHF_DM_DONVI_PHONGBAN> response = new Response<PHF_DM_DONVI_PHONGBAN>();
            if (ModelState.IsValid)
            {
                try
                {
                    var found = _service.Queryable().Where(x => x.MA == model.MA).ToList();
                    if (found.Count > 0)
                    {
                        response.Error = true;
                        response.Message = "Mã đơn vị đã tồn tại !";
                    }
                    else
                    {
                        model.ObjectState = ObjectState.Added;
                        _service.Insert(model);
                        if (await _unitOfWorkAsync.SaveChangesAsync() > 0)
                        {
                            response.Error = false;
                            response.Message = "Thêm mới thành công.";
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
                    WriteLogs.LogError(ex);
                    response.Error = true;
                    response.Message = ex.Message;
                }

                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [CustomAuthorize(Method = "SUA", State = "phf_dmCanBo")]
        public async Task<IHttpActionResult> Put(string id, PHF_DM_DONVI_PHONGBAN model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id) || !id.Equals(model.Id.ToString())) return BadRequest();
            model.ObjectState = ObjectState.Modified;
            _service.Update(model);
            Response<string> response = new Response<string>();
            try
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
            catch (Exception ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                response.Error = true;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [CustomAuthorize(Method = "XOA", State = "phf_dmChucVu")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            try
            {
                Response<string> response = new Response<string>();
                PHF_DM_DONVI_PHONGBAN item = await _service.FindByIdAsync(long.Parse(id));
                if (item == null) return NotFound();
                item.ObjectState = ObjectState.Deleted;
                _service.Delete(item);
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
            catch (FormatException ex)
            {
                SP.PHF.ENTITY.WriteLogs.LogError(ex);
                return BadRequest();
            }
        }

        public void GetTreeView(List<DM_DONVI_PHONGBANVm.DTO> list, DM_DONVI_PHONGBANVm.DTO current, ref List<DM_DONVI_PHONGBANVm.DTO> returnList)
        {
            try
            {
                //get child of curent node
                var childs = list.Where(x => x.MA_CHA == current.MA.ToString()).ToList();
                current.items = new List<DM_DONVI_PHONGBANVm.DTO>();
                current.items.AddRange(childs);
                foreach (var i in childs)
                {
                    GetTreeView(list, i, ref returnList);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DM_DONVI_PHONGBANVm.DTO> BuildTreeData(List<DM_DONVI_PHONGBANVm.DTO> list)
        {
            List<DM_DONVI_PHONGBANVm.DTO> returnList = new List<DM_DONVI_PHONGBANVm.DTO>();
            //find top level
            var topLevel = list.Where(x => x.MA_CHA == null).OrderBy(x => x.MA).ToList();
            returnList.AddRange(topLevel);
            int st = 0;
            foreach (var i in topLevel)
            {
                //i.isFirst = st == 0 ? 1 : 2;
                st++;
                GetTreeView(list, i, ref returnList);
            }
            return returnList;
        }

        [Route("GetDataTree")]
        [AllowAnonymous]
        [HttpPost]
        public List<DM_DONVI_PHONGBANVm.DTO> GetDataTree()
        {
            var response = new Response<DM_DONVI_PHONGBANVm.DTO>();
            List<PHF_DM_DONVI_PHONGBAN> list = new List<PHF_DM_DONVI_PHONGBAN>();
            List<DM_DONVI_PHONGBANVm.DTO> listMenu = new List<DM_DONVI_PHONGBANVm.DTO>();
            List<DM_DONVI_PHONGBANVm.DTO> listDataTree = new List<DM_DONVI_PHONGBANVm.DTO>();

            try
            {
                var result = _service.Queryable().ToList();
                if (result != null)
                {
                    list = result;
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (list.Count > 0)
            {
                foreach (var itemChild in list)
                {
                    if (itemChild.MA != null)
                    {
                        DateTime date = DateTime.Now;
                        DM_DONVI_PHONGBANVm.DTO record = new DM_DONVI_PHONGBANVm.DTO();
                        DM_DONVI_PHONGBANVm.DTO recordChild = new DM_DONVI_PHONGBANVm.DTO();
                        record.MA = itemChild.MA;
                        record.MADONVI = itemChild.MADONVI;
                        record.MA_CHA = itemChild.MA_CHA;
                        record.TEN = itemChild.TEN;
                        record.LOAI = itemChild.LOAI;
                        record.MA_DVQHNS = itemChild.MA_DVQHNS;
                        record.TRANGTHAI = itemChild.TRANGTHAI;
                        record.FIELDNAME = itemChild.FIELDNAME;
                        listMenu.Add(record);
                    }
                }
                listDataTree = BuildTreeData(listMenu);
            }
            return listDataTree;
        }
    }
}