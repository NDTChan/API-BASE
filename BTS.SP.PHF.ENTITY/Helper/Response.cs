using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.ENTITY.Helper
{
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public Response()
        {

        }
        public Response(bool error, string message = null, T data = default(T))
            : base(error, message)
        {
            Data = data;
        }
    }

    public class Response
    {
        public bool Error { get; set; }

        public string Message { get; set; }

        public Response()
        {
            
        }
        public Response(bool error, string message = null)
        {
            Error = error;
            Message = message;
        }
    }
}
