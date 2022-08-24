using CrookedCactusApiSdk.Clients;
using CrookedCactusApiSdk.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk
{
    public class CrookedCactusClient
    {
        public static readonly string CrookedCactusApiUrl = "https://api.crookedcactus.net";
        private readonly Connection _connection;
        private RestClient _client;
        private string? _token;
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                if (value is null)
                {
                    return;
                }

                _token = value;
                _client.AddDefaultHeader("Authorization", $"Bearer {Token}");
            }
        }

        public CrookedCactusClient(string token)
        {
            _client = new RestClient(CrookedCactusApiUrl);
            Token = token;

            _connection = new Connection(_client);

            Authentication = new AuthClient(_connection);
            Tokens = new TokenClient(_connection);
            Release = new ReleaseClient(_connection);
        }

        public AuthClient Authentication { get; private set; }
        public TokenClient Tokens { get; private set; }
        public ReleaseClient Release { get; private set; }
    }
}
