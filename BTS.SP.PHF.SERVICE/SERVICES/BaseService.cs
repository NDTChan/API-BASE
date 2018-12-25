using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;
using Service.Pattern;
using BTS.SP.PHF.ENTITY;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;
using BTS.SP.PHF.ENTITY.Dm;
using System.Configuration;
using System.IO;

namespace BTS.SP.PHF.SERVICE.SERVICES
{
    public class CurrentUser
    {
        public string Username { get; set; }
        public string Ma_DBHC { get; set; }
    }
    public interface IBaseService<T> : IService<T> where T : BaseEntity
    {
        T FindById(long id);
        Task<T> FindByIdAsync(long id);
        new void Insert(T entity);
        string BuildCodeWithParameter(string codeParam, string LoaiChungTu, bool _isSave);
        string UploadFile(byte[] data, string pathfile, string fileName, string rootPath = null, bool createDirectory = true);
    }
    public class BaseService<T> : Service<T>, IBaseService<T> where T : BaseEntity
    {
        private readonly IRepositoryAsync<T> _repository;
        public BaseService(IRepositoryAsync<T> repository) : base(repository)
        {
            _repository = repository;
        }

        protected virtual Expression<Func<T, bool>> GetKeyFilter(T instance)
        {
            return x => x.Id == instance.Id;
        }

        public T FindById(long id)
        {
            return _repository.Queryable().FirstOrDefault(x => x.Id == id);
        }
        public string BuildCodeWithParameter(string codeParam, string LoaiChungTu, bool _isSave)
        {
            try
            {
                var result = "";
                var idRepo = _repository.GetRepository<PHF_DM_TAOMA>();
                bool isInsert = false;
                //DateTime nowDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime tomorrowDay = DateTime.Now.AddDays(1);
                var config = idRepo.Queryable().FirstOrDefault(x => x.LoaiMa == codeParam && x.MaDonVi == LoaiChungTu);
                if (config == null)
                {
                    isInsert = true;
                    config = new PHF_DM_TAOMA
                    {
                        MaDonVi = LoaiChungTu,
                        LoaiMa = codeParam.ToString(),
                        Ma = codeParam,
                        HienTai = "00",
                    };
                }
                var maChungTuGenerate = config.GenerateNumber();
                config.HienTai = maChungTuGenerate;
                result = string.Format("{0}{1}", config.Ma, maChungTuGenerate);
                if (_isSave)
                {
                    if (isInsert)
                    {
                        config.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                        idRepo.Insert(config);
                    }
                    else
                    {
                        config.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                        idRepo.Update(config);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<T> FindByIdAsync(long id)
        {
            return await _repository.Queryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override void Insert(T entity)
        {
            var cur = GetCurrentUser();
            if (cur != null && !string.IsNullOrEmpty(cur.Username) && !string.IsNullOrEmpty(cur.Ma_DBHC))
            {
                entity.ICreateDate = DateTime.Now;
                entity.UnitCode = cur.Ma_DBHC;
                entity.ICreateBy = cur.Username;
                _repository.Insert(entity);
            }
            else
            {
                throw new Exception();
            }
        }

        private CurrentUser GetCurrentUser()
        {
            try
            {
                var cur = new CurrentUser();
                var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                if(identity != null && !string.IsNullOrEmpty(identity.Name)){
                    cur.Username = identity.Name;
                    cur.Ma_DBHC = identity.Claims.FirstOrDefault(x => x.Type.Equals("MA_DBHC"))?.Value;
                }
                return cur;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string UploadFile(byte[] data, string pathfile, string fileName, string rootPath = null, bool createDirectory = true)
        {
            try
            {
                if (rootPath == null)
                {
                    rootPath = ConfigurationManager.AppSettings["folder:RootPath"];
                }
                string directoryPath = rootPath;
                if (createDirectory)
                {
                    directoryPath = Path.Combine(rootPath + pathfile);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);
                string uniqueFilePath = directoryPath + fileNameWithoutExtension + extension;
                try
                {
                    MemoryStream stream = new MemoryStream(data);
                    FileStream stream2 = new FileStream(uniqueFilePath, FileMode.Create);
                    stream.WriteTo(stream2);
                    stream.Close();
                    stream2.Close();
                    stream2.Dispose();
                }
                catch
                {
                }
                return uniqueFilePath;
            }
            catch (Exception exception)
            {
                return exception.Message.ToString();
            }
        }
    }
}
