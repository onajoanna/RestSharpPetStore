
using FluentAssertions;
using Joanna.RestApi.Framework.Models.Pet;
using Joanna.RestApi.Framework.Requests.Pet;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.NetworkInformation;

namespace Joanna.RestApi.Framework.Actions
{
    public class PetActionRequests
    {
        public static PetApiModelV2 CreateNewPet(string baseUrl)
        {
            var petBody = new PetApiModelV2
            {
                Category = new Category
                {
                    Id = 1,
                },
                Name = "Penny",
                PhotoUrls = new List<string>
            {
                "https://www.google"
                },
                Tags = new List<Tag>
                   {
                new Tag
                    {
                    Id = 1,
                    Name = "dog"
            }
    },
                Status = "available"
            };

            RestResponse response = new PetApiRequests(baseUrl)
                    .ExecuteApiPostPetRequest(petBody);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            var responseBody = JsonConvert.DeserializeObject<PetApiModelV2>(response.Content!);
            responseBody.Should().NotBeNull();
            return responseBody!;
        }

    }
}
