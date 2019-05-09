using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServerManager.Infastructure.Common.Entities;
using OperatingSystem = ServerManager.Infastructure.Common.Entities.OperatingSystem;

namespace ServerManager.Infastructure.Providers.Packet.Entities
{
    public class PacketOperatingSystems
    {
        [JsonProperty("operating_systems")]
        public IEnumerable<PacketOperatingSystem> OperatingSystems { get; set; } = new List<PacketOperatingSystem>();
    }

    public class PacketOperatingSystem : OperatingSystem
    {
        [JsonProperty("id")] public Guid Id { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("distro")] public string Distro { get; set; }

        [JsonProperty("version")] public string Version { get; set; }

        [JsonProperty("provisionable_on")] public List<string> ProvisionableOn { get; set; }

        [JsonProperty("preinstallable")] public bool Preinstallable { get; set; }

        [JsonProperty("pricing")] public PacketPricing Pricing { get; set; }

        [JsonProperty("licensed")] public bool Licensed { get; set; }
    }

    public class PacketPricing : Pricing
    {
        [JsonProperty("hour")] public PacketHour Hour { get; set; }
    }

    public class PacketHour : Hour
    {
        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("multiplier")] public string Multiplier { get; set; }
    }
}