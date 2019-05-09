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
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("features")] public IEnumerable<string> Features { get; set; }

        [JsonProperty("address")] public Address Address { get; set; }

        [JsonProperty("ip_ranges")] public IEnumerable<string> IpRanges { get; set; }
    }

    public class Address
    {
        [JsonProperty("href")] public string Href { get; set; }
    }
}