using System.Net;

namespace Vacancies.Services.Responses
{
    public class ResponseResult<T> 
    {
        public string ErrorMessage { get; set; }

        public T Result { get; set; }

        public HttpStatusCode StatusCode { 
            get 
            { 
                if(Result == null) 
                    return HttpStatusCode.NotFound;
                if(ErrorMessage!=null)
                    return HttpStatusCode.InternalServerError;

                return HttpStatusCode.OK;
            }  
            private set { } }
    }
}
