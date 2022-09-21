using CrookedCactusApiSdk.Exceptions;
using RestSharp;

namespace CrookedCactusApiSdk.Http
{
    public class Connection
    {
        private RestClient Client { get; set; }

        public Connection(RestClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Executes a REST call and attempts to serialize the result
        /// </summary>
        /// <typeparam name="T">Type to serialize the data to</typeparam>
        /// <param name="endpoint">Endpoint to hit</param>
        /// <param name="parameters">Parameters to pass in the query string</param>
        /// <param name="data">Data to pass in the request body</param>
        /// <param name="method">HTTP request <see cref="Method"/></param>
        /// <returns><see cref="RestResponse"/></returns>
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

        /// <summary>
        /// Executes a REST call
        /// </summary>
        /// <param name="endpoint">Endpoint to hit</param>
        /// <param name="parameters">Parameters to pass in the query string</param>
        /// <param name="data">Data to pass in the request body</param>
        /// <param name="method">HTTP request <see cref="Method"/></param>
        /// <returns><see cref="RestResponse"/></returns>
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

        /// <summary>
        /// Builds a <see cref="RestRequest"/>
        /// </summary>
        /// <param name="endpoint">Endpoint to hit</param>
        /// <param name="parameters">Parameters to pass to the API call</param>
        /// <returns><see cref="RestRequest"/></returns>
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
