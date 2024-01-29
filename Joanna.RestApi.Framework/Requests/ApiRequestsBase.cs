using RestSharp;

namespace Joanna.RestApi.Framework.Requests
{
    public abstract class ApiRequestsBase
    {
        protected readonly RestClient? Client;

        protected readonly Dictionary<string, string> Headers = new()
        {
             { "accept", "application/json" },
             { "Content-Type", "application/json" }
        };

        protected ApiRequestsBase(string baseUrl)
        {
             Client = new RestClient(baseUrl);
        }

    }
}
