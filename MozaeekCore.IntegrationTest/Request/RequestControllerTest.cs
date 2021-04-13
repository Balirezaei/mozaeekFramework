using MozaeekCore.RestAPI;
using Newtonsoft.Json;
using Xunit;

namespace MozaeekCore.IntegrationTest.Request
{
    public class RequestControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public RequestControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

      

    }
}