using System.Collections.Generic;
using Newtonsoft.Json;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.Packet.Entities
{
    public class PacketFacilities
    {
        [JsonProperty("facilities")]
        public IEnumerable<PacketFacility> Facilities { get; set; }
    }
    public class PacketFacility : Facility
    {
        [JsonProperty("id")] public new string Id { get; set; }

        [JsonProperty("name")] public new string Name { get; set; }
        [JsonProperty("code")] public new string Code { get; set; }

        [JsonProperty("features")] public new IEnumerable<string> Features { get; set; } = new List<string>();

        [JsonProperty("address")] public new Address Address { get; set; }

        [JsonProperty("ip_ranges")] public new IEnumerable<string> IpRanges { get; set; } = new List<string>();
    }

    public class Address
    {
        [JsonProperty("href")] public string Href { get; set; }
    }
}