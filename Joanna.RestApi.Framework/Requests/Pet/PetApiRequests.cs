﻿using Joanna.RestApi.Framework.Models.Pet;
using Joanna.RestApi.Framework.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Joanna.RestApi.Framework.Requests.Pet
{
    public class PetApiRequests: ApiRequestsBase
    {
       
        public PetApiRequests(string baseUrl) : base(baseUrl)
        { 
        }

        public RestResponse ExecuteApiPostPetRequest(PetApiModelV2 requestBody)
        {
            var request = new RestRequest(EndpointPaths.PetResourceUrl(), Method.Post); ;
            request.AddHeaders(Headers);

            string stringJson = JsonConvert.SerializeObject(requestBody);
            request.AddBody(stringJson);
            return Client!.Execute(request);
        }

        public RestResponse ExecuteApiGetPetByIdRequest(long petId)
        {
            var request = new RestRequest(EndpointPaths.PetByIdResourceUrl(petId), Method.Get); ;
            request.AddHeaders(Headers);
            return Client!.Execute(request);
        }

        public RestResponse ExecuteApiPutPetRequest(long petId, PetApiModelV2 requestBody)
        {
            var request = new RestRequest(EndpointPaths.PetByIdResourceUrl(petId), Method.Put); ;
            request.AddHeaders(Headers);
            string stringJson = JsonConvert.SerializeObject(requestBody);
            request.AddBody(stringJson);
            return Client!.Execute(request);
        }

    }
}
