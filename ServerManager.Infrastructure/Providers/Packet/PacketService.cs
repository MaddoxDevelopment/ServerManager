using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Authentication;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.Packet.Base;
using ServerManager.Infastructure.Providers.Packet.Entities;
using ServerManager.Infastructure.Utility;

namespace ServerManager.Infastructure.Providers.Packet
{
    public class PacketService : IPacketService
    {
        private readonly HttpClient _client;
        private readonly ApiConfigProvider _config;

        public PacketService(Func<ServerProvider, ApiConfigProvider> provider, IHttpClientFactory factory)
        {
            _config = provider(ServerProvider.Packet);
            _client = factory.CreateClient("Packet");
            _client.DefaultRequestHeaders.Add("X-Auth-Token", _config.Token);
            _client.BaseAddress = new Uri(_config.BaseUrl);
        }

        public Task<Device> Deploy(AddDeviceRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Facility>> GetFacilities()
        {
            var results = await _client.GetAsync($"/projects/{_config.ProjectId}/facilities");
            return await HttpExtensions.SuccessOrThrow(results, data =>
            {
                var facilities = JsonConvert.DeserializeObject<PacketFacilities>(data);
                return facilities.Facilities.Select(w => TinyMapper.Map<PacketFacility, Facility>(w));
            });
        }

        public Task<IEnumerable<string>> GetOperatingSystems()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Plan>> GetPlans(Facility facility)
        {
            var cast = facility as PacketFacility;
            var results = await _client.GetAsync($"/projects/{_config.ProjectId}/plans?include=available_in");
            return await HttpExtensions.SuccessOrThrow<IEnumerable<Plan>>(results, data =>
            {
                var plans = JsonConvert.DeserializeObject<PacketPlans>(data);
                // TODO make more performant. Packet plan api does not let you filter based on facility in the query, so we must do in memory.
                return plans.Plans.Where(w => w.AvailableIn.Select(a => a.Code).Any(a => a == cast.Code)).Select(w =>
                {
                    var mapped = TinyMapper.Map<PacketPlan, Plan>(w);
                    mapped.Spec = w.Spec;
                    return w;
                });
            });
        }
    }
}