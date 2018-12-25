using System.Threading.Tasks;
using System.Web.Http;
using BTS.SP.PHF.SERVICE;
using BTS.SP.PHF.SERVICE.AUTH.Shared;
using BTS.SP.PHF.SERVICE.UTILS;
using Repository.Pattern.UnitOfWork;

namespace BTS.SP.API.PHF.Controllers.SHARED
{
    [RoutePrefix("api/Shared")]
    [Route("{id?}")]
    [Authorize]
    public class SharedController : ApiController
    {
        private readonly ISharedService _sharedService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public SharedController(ISharedService sharedService,IUnitOfWorkAsync unitOfWorkAsync)
        {
            _sharedService = sharedService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("GetAccesslist/{machucnang}")]
        public async Task<RoleState> GetAccesslist(string machucnang)
        {
            if (RequestContext.Principal.Identity.Name.StartsWith("admin"))
            {
                return new RoleState()
                {
                    Approve = true,Delete = true,Add = true,STATE = "ALL",Edit = true,View = true
                };
            }
            var roleState = await _sharedService.GetRoleStateByMaChucNang("F",RequestContext.Principal.Identity.Name, machucnang);
            return roleState;
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
