using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.BaoCao_NSDVN;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.PHF.SERVICE.UTILS;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Repository.Pattern.UnitOfWork;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/phf_nvBaoCaoNSDVN")]
    [Route("{id?}")]
    [Authorize]
    public class NvBaoCaoTT_NSDVNController : ApiController
    {
        public readonly INV_BM_FILE_NSDVNService _service;
        public readonly INV_BM_60TT_NSDVNService _serviceBM_60TT_NSDVN;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public NvBaoCaoTT_NSDVNController(INV_BM_FILE_NSDVNService service, IUnitOfWorkAsync unitOfWorkAsync, INV_BM_60TT_NSDVNService serviceBM_60TT_NSDVN)
        {
            _service = service;
            _serviceBM_60TT_NSDVN = serviceBM_60TT_NSDVN;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [Route("Paging")]
        [HttpPost]
        [CustomAuthorize(Method = "XEM", State = "phf_nvBaoCaoNSDVN")]
        public async Task<IHttpActionResult> Paging(JObject jsonData)
        {
            var result = new Response<PagedObj<PHF_BM_FILE_NSDVN>>();
            var postData = (dynamic)jsonData;
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<NV_BM_FILE_NSDVNVm.Search>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<PHF_BM_FILE_NSDVN>>();
            var query = new TOOLS.BuildQuery.Implimentations.QueryBuilder
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

    }
}