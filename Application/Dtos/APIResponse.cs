using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public APIResponse()
        {
        }

        public APIResponse(T data, int statusCode = 200, string message = null)
        {
            Success = true;
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }

        public APIResponse(string message, int statusCode)
        {
            Success = false;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
