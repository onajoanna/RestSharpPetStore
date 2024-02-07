using FluentAssertions;
using FluentAssertions.Execution;
using Joanna.RestApi.Framework.Models.Common;
using Joanna.RestApi.Framework.Models.User;
using Joanna.RestApi.Framework.Utils;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Joanna.RestApi.Tests.Tests.User
{
    public class PostUserApiTests : PetApiTestsBase
    {
        [Test]
        public void CreateUser_WthValidData_ShouldBeCreated()
        {
            //Arrange
            var userBody = new UserApiModelV2
            {
                Email = "test@test.com",
                FirstName = "TestUserFirstName",
                LastName = "TestUserLastName",
                Password = "123456",
                Phone = "1234567890",
                UserStatus = 1
            };

            //Act
            RestResponse response = PetApi!.UserSection().ExecutePostUserRequest(userBody);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //Assert
            CommonApiResponseModel responseBody = response.ConvertToModel<CommonApiResponseModel>();

            using (new AssertionScope())
            {
                responseBody.Code.Should().Be(200);
                responseBody.Type.Should().Be("unknown");
            }

        }
    }
}
