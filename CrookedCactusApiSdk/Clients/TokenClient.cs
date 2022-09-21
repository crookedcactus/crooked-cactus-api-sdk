using CrookedCactusApiSdk.Exceptions;
using CrookedCactusApiSdk.Http;
using CrookedCactusApiSdk.Model;
using RestSharp;

namespace CrookedCactusApiSdk.Clients
{
    public class TokenClient
    {
        private readonly Connection _connection;

        public TokenClient(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Refreshes the provided <paramref name="token"/>
        /// </summary>
        /// <param name="token">Token to be refreshed</param>
        /// <returns><see cref="Token"/></returns>
        /// <exception cref="ApiException">Exception representing an HTTP error</exception>
        public async Task<Token?> RefreshToken(Token token)
        {
            RestResponse<Token> response = await _connection.ExecuteAsync<Token>("/api/token/refresh", null, token, Method.Post);

            try
            {
                _connection.ValidateResponse(response);
            }
            catch(ApiException)
            {
                throw;
            }
            
            return response.Data;
        }

        /// <summary>
        /// Revokes all tokens related to the specified <paramref name="username"/>
        /// </summary>
        /// <param name="username">Username to revoke</param>
        /// <exception cref="ApiException">Exception representing an HTTP error</exception>
        public async Task RevokeToken(string username)
        {
            RestResponse response = await _connection.ExecuteAsync($"/api/token/revoke/{username}", null, method: Method.Post);
            try
            {
                _connection.ValidateResponse(response);
            }
            catch (ApiException)
            {
                throw;
            }
        }
    }
}
