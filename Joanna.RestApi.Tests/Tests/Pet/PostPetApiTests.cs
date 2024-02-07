using FluentAssertions;
using FluentAssertions.Execution;
using Joanna.RestApi.Framework.Models.Pet;
using Joanna.RestApi.Framework.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Joanna.RestApi.Tests.Tests.Pet
{
    public class PostPetApiTests : PetApiTestsBase
    {
        [Test]
        public void CreatePet_WithCorrectData_ShouldBeCreated()
        {
            // Arrange
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

            // Act
            RestResponse response = PetApi!.PetSection().ExecuteApiPostPetRequest(petBody);


            // Assert
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            PetApiModelV2 responseBody = response.ConvertToModel<PetApiModelV2>();


            using (new AssertionScope())
            {
                responseBody
                    .Should()
                    .BeEquivalentTo(petBody, res => res
                        .Excluding(res => res.Id));
                responseBody!.Id
                    .Should()
                    .NotBeNull()
                    .And
                    .BeGreaterThan(0);
            }

        }

        [Test]
        public void CreatePet_WithCategoryDoesNotExist_ShouldBeCreated()
        {
            // Arrange
            var petBody = new PetApiModelV2
            {
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

            // Act
            RestResponse response = PetApi!.PetSection().ExecuteApiPostPetRequest(petBody);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            PetApiModelV2 responseBody = response.ConvertToModel<PetApiModelV2>();
            responseBody.Should().BeEquivalentTo(petBody, res => res.Excluding(res => res.Id));


        }
    }
}
