using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Implimentations;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BTS.SP.TOOLS.BuildQuery.Types;
using AutoMapper;
using BTS.SP.PHF.ENTITY.Dm;

namespace BTS.SP.API.PHF.Controllers.SYS
{
    [RoutePrefix("api/sys/SysTuDien")]
    [Route("{id?}")]
    [Authorize]
    public class SysTuDienController : ApiController
    {
        public readonly IDM_SYS_TUDIENService _service;
        public readonly IDM_DOITUONGService _serviceDoiTuong;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public SysTuDienController(IDM_SYS_TUDIENService service, IDM_DOITUONGService serviceDoiTuong, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _serviceDoiTuong = serviceDoiTuong;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("PostSelectData")]
        [HttpPost]
        public async Task<IHttpActionResult> PostSelectData(JObject jsonData)
        {

            var result = new Response<PagedObj<ChoiceObj>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<DM_SYS_TUDIENVm.Search>>();
            if(filtered.AdvanceData.LOAI_TUDIEN == "DOITUONG")
            {
                var filtered2 = ((JObject)postData.filtered).ToObject<FilterObj<DM_DOITUONGVm.Search>>();
                var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_DM_DOITUONG>>();
                var query = new QueryBuilder
                {
                    Take = paged.itemsPerPage,
                    Skip = paged.fromItem - 1,
                };
                try
                {
                    var filterResult = await _serviceDoiTuong.FilterAsync(filtered2, query);
                    if (!filterResult.WasSuccessful)
                    {
                        return NotFound();
                    }
                    var resultData = new PagedObj<ChoiceObj>();
                    resultData.currentPage = filterResult.Value.currentPage;
                    resultData.itemsPerPage = filterResult.Value.itemsPerPage;
                    resultData.takeAll = filterResult.Value.takeAll;
                    resultData.totalItems = filterResult.Value.totalItems;
                    if (filterResult.Value.Data.Count > 0)
                    {
                        foreach (var item in filterResult.Value.Data)
                        {
                            var temp = new ChoiceObj();
                            temp.Value = item.MA_DOITUONG;
                            temp.Text = item.TEN_DOITUONG;
                            resultData.Data.Add(temp);
                        }
                    }
                    result.Data = resultData;
                    result.Error = false;
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return InternalServerError();
                }
            }
            else
            {
                var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_SYS_TUDIEN>>();
                var query = new QueryBuilder
                {
                    Take = paged.itemsPerPage,
                    Skip = paged.fromItem - 1,
                    Filter = new QueryFilterLinQ()
                    {
                        Property = ClassHelper.GetProperty(() => new PHF_SYS_TUDIEN().LOAI_TUDIEN),
                        Value = filtered.AdvanceData.LOAI_TUDIEN,
                        Method = FilterMethod.EqualTo,
                    }
                };
                try
                {
                    var filterResult = await _service.FilterAsync(filtered, query);
                    if (!filterResult.WasSuccessful)
                    {
                        return NotFound();
                    }
                    var resultData = new PagedObj<ChoiceObj>();
                    resultData.currentPage = filterResult.Value.currentPage;
                    resultData.itemsPerPage = filterResult.Value.itemsPerPage;
                    resultData.takeAll = filterResult.Value.takeAll;
                    resultData.totalItems = filterResult.Value.totalItems;
                    if (filterResult.Value.Data.Count > 0)
                    {
                        foreach (var item in filterResult.Value.Data)
                        {
                            var temp = new ChoiceObj();
                            temp.Value = item.MA_TUDIEN;
                            temp.Text = item.TEN_TUDIEN;
                            temp.Parent = item.MA_TUDIEN_CHA;
                            resultData.Data.Add(temp);
                        }
                    }
                    result.Data = resultData;
                    result.Error = false;
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return InternalServerError();
                }
            }
        }

    }
}