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

        public async Task<Token?> RefreshToken(Token token)
        {
            RestResponse<Token> response = await _connection.ExecuteAsync<Token>("/api/token/refresh", null, token, Method.Post);
            _connection.ValidateResponse(response);
            return response.Data;
        }

        public async Task RevokeToken(string username)
        {
            RestResponse response = await _connection.ExecuteAsync($"/api/token/revoke/{username}", null, method: Method.Post);
            _connection.ValidateResponse(response);
        }
    }
}
