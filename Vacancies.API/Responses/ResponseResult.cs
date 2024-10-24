using System.Net;

namespace Vacancies.API.Responses
{
    public class ResponseResult<T> 
    {
        public string Message { get; set; }

        public T Result { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
