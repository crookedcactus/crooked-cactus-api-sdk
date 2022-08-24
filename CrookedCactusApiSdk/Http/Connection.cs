using CrookedCactusApiSdk.Exceptions;
using CrookedCactusApiSdk.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk.Http
{
    public class Connection
    {
        private RestClient Client { get; set; }

        public Connection(RestClient client)
        {
            Client = client;
        }

        public async Task<RestResponse<T>> ExecuteAsync<T>(string endpoint, List<Parameter>? parameters, object? data = null, Method method = Method.Get)
        {
            RestRequest request = BuildRequest(endpoint, parameters);
            request.Method = method;

            if(data != null && method != Method.Get)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(data);
            }

            return await Client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> ExecuteAsync(string endpoint, List<Parameter>? parameters, object? data = null, Method method = Method.Get)
        {
            RestRequest request = BuildRequest(endpoint, parameters);
            request.Method = method;

            if (data != null && method != Method.Get)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(data);
            }

            return await Client.ExecuteAsync(request);
        }

        private RestRequest BuildRequest(string endpoint, List<Parameter>? parameters)
        {
            RestRequest request = new RestRequest(endpoint);

            if (parameters is null)
                return request;

            foreach (Parameter parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            return request;
        }

        /// <summary>
        /// Validates the response and throws an error if invalid
        /// </summary>
        /// <param name="response">Response to validate</param>
        /// <exception cref="ApiException">Exception containing the error</exception>
        public void ValidateResponse(RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new ApiException(response);
            }
        }
    }
}
