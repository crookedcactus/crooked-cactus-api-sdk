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

        public async Task<ReleaseManifest?> GetReleaseManifest(string repository, string stage, string distribution)
        {
            RestResponse<ReleaseManifest> response = await _connection.ExecuteAsync<ReleaseManifest>($"/api/release/{repository}/{stage}/{distribution}", null);
            _connection.ValidateResponse(response);
            return response.Data;
        }

        public async Task<Release?> GetRelease(string sha1)
        {
            RestResponse<Release> response = await _connection.ExecuteAsync<Release>($"/api/release/{sha1}", null);
            _connection.ValidateResponse(response);
            return response.Data;
        }
    }
}
