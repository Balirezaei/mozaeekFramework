using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.ResponseMessages;
using MozaeekCore.IntegrationTest.TestUtil;
using MozaeekCore.RestAPI;
using Newtonsoft.Json;
using Xunit;

namespace MozaeekCore.IntegrationTest
{
    public class LabelControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public LabelControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

    

        [Fact]
        public async Task Label_Delete_Run_With_Error_And_InseerNotwork_Again()
        {
            var client = _factory.CreateClient();
            var title = "Test Label Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreateLabelCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var responseDeleteObjectWithRelation = await client.GetAsync("/api/label/Delete?id=1");

            responseDeleteObjectWithRelation.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            //curl -X POST "http://localhost:100/api/Label/Create" -H "accept: */*" -H "Content-Type: application/json" -d "{\"title\":\"string\"}"
            var newLabelCreateResponse = await client.PostAsync("/api/Label/Create", content);
            newLabelCreateResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            var responseText = await newLabelCreateResponse.Content.ReadAsStringAsync();

            var savedLabel = JsonConvert.DeserializeObject<Result<LabelDto>>(responseText);

            savedLabel.Data.Title.Should().Be(title);

        }

    }
}