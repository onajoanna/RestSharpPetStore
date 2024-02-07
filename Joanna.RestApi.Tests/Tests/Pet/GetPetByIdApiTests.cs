using FluentAssertions;
using Joanna.RestApi.Framework.Actions;
using Joanna.RestApi.Framework.Models.Pet;
using Joanna.RestApi.Framework.Utils;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Joanna.RestApi.Tests.Tests.Pet
{
    public class GetPetByIdApiTests : PetApiTestsBase
    {
        [Test]
        public void GetFirstPet_IdExists_ShouldBeReturned()
        {
            //Arange
            PetApiModelV2 expectedResponse = PetActionRequests.CreateNewPet(BaseUrl!);

            //Act

            RestResponse response = PetApi!.PetSection().ExecuteApiGetPetByIdRequest(expectedResponse.Id!.Value);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            PetApiModelV2 responseBody = response.ConvertToModel<PetApiModelV2>();
            responseBody.Should().BeEquivalentTo(expectedResponse);

        }
    }
}
