using CrookedCactusApiSdk.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace CrookedCactusApiSdk.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public override string Message
        {
            get
            {
                return ResponseMessage ?? "No error messsage found";
            }
        }
        private string? ResponseMessage { get; set; }

        public ApiException(RestResponse response)
        {
            if (response.Content is null)
                return;

            ApiResponse? apiResponse = null;
            DefaultErrorResponse? defaultErrorResponse = JsonConvert.DeserializeObject<DefaultErrorResponse>(response.Content);

            if (defaultErrorResponse is null)
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);


            StatusCode = response.StatusCode;
            ResponseMessage = defaultErrorResponse is not null ? defaultErrorResponse.Errors?.ToString() : apiResponse?.Message;
        }
    }
}
