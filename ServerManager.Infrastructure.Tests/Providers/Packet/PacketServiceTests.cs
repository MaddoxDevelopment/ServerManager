using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using ServerManager.Infastructure.Providers.Common.Authentication;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.Packet;
using ServerManager.Infastructure.Providers.Packet.Entities;
using ServerManager.Infrastructure.Tests.Util;
using ServerManager.Mappers;

namespace ServerManager.Infrastructure.Tests.Providers.Packet
{
    public class PacketServiceTests
    {
        private PacketService _service;
        private IHttpClientFactory _factory;

        private Func<ServerProvider, ApiConfigProvider> config = provider =>
            new ApiConfigProvider("fake_token", "https://api.fake.com", "fake_id");

        private static readonly PacketFacility One = new PacketFacility
        {
            Code = "test"
        };

        private static readonly PacketFacility Two = new PacketFacility
        {
            Code = "test 2"
        };

        private PacketPlans Plans = new PacketPlans
        {
            Plans = new[]
            {
                new PacketPlan
                {
                    Name = "plan 1",
                    AvailableIn = new[]
                    {
                        One, Two,
                    }
                },
                new PacketPlan
                {
                    Name = "plan 2",
                    AvailableIn = new[]
                    {
                        One
                    }
                },
            }
        };

        public PacketServiceTests()
        {
            EntityMappers.Register();
        }

        [Test]
        public async Task Should_Only_Return_Plans_For_Your_Facility()
        {
            _factory = new FakeHttpClientFactory(JsonConvert.SerializeObject(Plans), HttpStatusCode.OK);
            _service = new PacketService(config, _factory);
            
            var plans = await _service.GetPlans(One);
            Assert.True(plans.Count() == 2);

            
            _factory = new FakeHttpClientFactory(JsonConvert.SerializeObject(Plans), HttpStatusCode.OK);
            _service = new PacketService(config, _factory);
            
            var plansTwo = await _service.GetPlans(Two);
            
            Assert.True(plansTwo.Count() == 1);
            Assert.True((plansTwo.First() as PacketPlan).Name == "plan 1");
        }
    }
}