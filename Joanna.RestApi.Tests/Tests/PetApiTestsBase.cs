using Joanna.RestApi.Framework.Requests;
using Joanna.RestApi.Framework.Requests.Pet;
using NUnit.Framework;

namespace Joanna.RestApi.Tests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public abstract class PetApiTestsBase

    {
        protected PetStoreApiFacade? PetApi;
        protected static string? BaseUrl;

        [OneTimeSetUp]
        public void BeforeFixture()
        {
            BaseUrl = GlobalSetup.BaseUrl;
            PetApi = new PetStoreApiFacade(BaseUrl!);
        }
    }
}
