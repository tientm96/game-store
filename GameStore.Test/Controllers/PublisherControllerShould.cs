﻿using GameStore.Test.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameStore.Test.Controllers
{
    [Collection("GameE2E")]
  public  class PublisherControllerShould :BaseController
    {
        private readonly ITestOutputHelper _output;

        public PublisherControllerShould(ITestOutputHelper output) : base(49914)
        {
            _output = output;
        }
        [Fact]
        [Trait("Publisher", "GameE2E")]
        public void TestGetAllPublishersController()
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/publishers").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                PublishersResponse publishersResponse = JsonConvert.DeserializeObject<PublishersResponse>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(5, publishersResponse.Payload.Count);
                Assert.True(publishersResponse.IsSuccess);
            }

        }


        [Theory]
        [InlineData("0703A244-3012-4725-B9A5-2E3D5AF9F0FE")]
        [InlineData("B49D6EDB-140D-46CC-BD0B-482BE03C8C46")]
        [InlineData("773F8D2E-B12D-4A9F-91D9-9E5DA568F0EB")]
        [InlineData("DC23F861-FF43-45AF-845C-AF4514DF22A2")]
        [InlineData("CA1ACA5F-CDEE-43A6-BDCB-E596D1B909A5")]
        [InlineData("0E276582-8CA0-4DE3-A465-ED721530AE2C")]
        [Trait("Publisher", "GameE2E")]
        public void TestGetPublisherByIdController(string Id)
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync($"api/publishers/{Id}").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                PublisherResponse publisherResponse = JsonConvert.DeserializeObject<PublisherResponse>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(publisherResponse.IsSuccess);
            }

        }
    }
}
