using Joanna.RestApi.Framework.Models.User;
using Joanna.RestApi.Framework.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Joanna.RestApi.Framework.Requests.User
{
    public class UserApiRequests : ApiRequestsBase
    {
        public UserApiRequests(string baseUrl) : base(baseUrl)
        {
        }

        public RestResponse ExecutePostUserRequest(UserApiModelV2 body)
        {
            var request = new RestRequest(EndpointPaths.UserResourceUrl(), Method.Post); ;
            request.AddHeaders(Headers);
            string stringJson = JsonConvert.SerializeObject(body);
            request.AddBody(stringJson);

            return Client!.Execute(request);
        }
    }
}
