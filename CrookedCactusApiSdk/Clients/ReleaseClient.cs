using CrookedCactusApiSdk.Exceptions;
using CrookedCactusApiSdk.Http;
using CrookedCactusApiSdk.Model;
using RestSharp;

namespace CrookedCactusApiSdk.Clients
{
    public class ReleaseClient
    {
        private readonly Connection _connection;

        public ReleaseClient(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Retrieves the release manifest for the provided `repository`, `stage`, and `distribution`.
        /// </summary>
        /// <param name="repository">Repository the manifest belongs to</param>
        /// <param name="stage">Stage the artifacts belong to</param>
        /// <param name="distribution">Distribution the artifacts are built for</param>
        /// <returns>A <see cref="ReleaseManifest"/> containing all releases for the specified stage and distribution</returns>
        /// <exception cref="ApiException">Exception representing an HTTP error</exception>
        public async Task<ReleaseManifest?> GetReleaseManifest(string repository, string stage, string distribution)
        {
            RestResponse<ReleaseManifest> response = await _connection.ExecuteAsync<ReleaseManifest>($"/api/release/{repository}/{stage}/{distribution}", null);

            try
            {
                _connection.ValidateResponse(response);
            } catch(ApiException)
            {
                throw;
            }

            return response.Data;
        }

        /// <summary>
        /// Retrieves the release associated with the provided `sha1`
        /// </summary>
        /// <param name="sha1">SHA1 of the artifact to retrieve</param>
        /// <returns><see cref="Release"/></returns>
        /// <exception cref="ApiException">Exception representing an HTTP error</exception>
        public async Task<Release?> GetRelease(string sha1)
        {
            RestResponse<Release> response = await _connection.ExecuteAsync<Release>($"/api/release/{sha1}", null);

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
    }
}
