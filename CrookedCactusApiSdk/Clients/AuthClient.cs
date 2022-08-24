using CrookedCactusApiSdk.Exceptions;
using CrookedCactusApiSdk.Http;
using CrookedCactusApiSdk.Model;
using RestSharp;

namespace CrookedCactusApiSdk.Clients
{
    public class AuthClient
    {
        private readonly Connection _connection;

        public AuthClient(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Logs user in and returns tokens on success
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        /// <returns><see cref="Token"/> containing the access and refresh token</returns>
        /// <exception cref="ApiException">Exception representing an HTTP error</exception>
        public async Task<Token?> LoginAsync(string username, string password)
        {
            RestResponse<Token> response = await _connection.ExecuteAsync<Token>("/api/auth/login", null, new { username, password }, Method.Post);
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
        /// Registers a new user
        /// </summary>
        /// <param name="username">New username</param>
        /// <param name="email">New email</param>
        /// <param name="password">New password</param>
        /// <param name="confirmPassword">Confirm password</param>
        /// <returns><see cref="Token"/> containing the access and refresh token</returns>
        /// <exception cref="ApiException">Exception containing the error</exception>
        public async Task<Token?> RegisternAsync(string username, string email, string password, string confirmPassword)
        {
            RestResponse<Token> response = await _connection.ExecuteAsync<Token>("/api/auth/register", null, new { username, email, password, confirmPassword }, Method.Post);
            try
            {
                _connection.ValidateResponse(response);
            }
            catch (ApiException)
            {
                throw;
            }
            return response.Data;
        }

        /// <summary>
        /// Adds
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <exception cref="ApiException">Exception containing the error</exception>
        //public async void AddToRole(string username, string email, string password, string confirmPassword)
        //{
        //    RestResponse response = await _connection.ExecuteAsync("/api/auth/register", null, new { username, email, password, confirmPassword }, Method.Put);
        //    try
        //    {
        //        _connection.ValidateResponse(response);
        //    }
        //    catch (ApiException)
        //    {
        //        throw;
        //    }
        //}
    }
}
