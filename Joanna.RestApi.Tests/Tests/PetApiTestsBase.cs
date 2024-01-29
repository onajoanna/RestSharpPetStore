using Joanna.RestApi.Framework.Requests.Pet;
using NUnit.Framework;
using FluentAssertions;

namespace Joanna.RestApi.Tests.Tests
{
    [TestFixture]
    public abstract class PetApiTestsBase
    {
        protected PetApiRequests? PetApiRequests;
        protected static string? BaseUrl;

        [OneTimeSetUp]
        public void BeforeFixture()
        {
            BaseUrl = GlobalSetup.BaseUrl;
            PetApiRequests = new PetApiRequests(BaseUrl!);
        }
    }
}
