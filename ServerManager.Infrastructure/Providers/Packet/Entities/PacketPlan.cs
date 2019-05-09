using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServerManager.Infastructure.Common.Entities;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.Packet.Entities
{
    public class PacketPlans
    {
        [JsonProperty("plans")] public IEnumerable<PacketPlan> Plans { get; set; }
    }

    public class PacketPlan : Plan
    {
        [JsonProperty("id")] public Guid Id { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("line")] public string Line { get; set; }

        [JsonProperty("specs")] public PacketSpecs Spec { get; set; }

        [JsonProperty("legacy")] public bool Legacy { get; set; }

        [JsonProperty("deployment_types")] public IEnumerable<string> DeploymentTypes { get; set; }
        [JsonProperty("available_in")] public IEnumerable<PacketFacility> AvailableIn { get; set; }

        [JsonProperty("class")] public string Class { get; set; }

        [JsonProperty("pricing")] public PacketPricing Pricing { get; set; }

        public class PacketPricing : PlanPricing
        {
            [JsonProperty("hour")] public double Hour { get; set; }
        }

        public class PacketSpecs : Specs
        {
            [JsonProperty("cpus")] public IEnumerable<PacketCpus> Cpus { get; set; }

            [JsonProperty("memory")] public PacketMemory PacketMemory { get; set; }

            [JsonProperty("drives")] public IEnumerable<PacketDrive> Drives { get; set; } = new List<PacketDrive>();

            [JsonProperty("nics")] public IEnumerable<PacketCpus> Nics { get; set; } = new List<PacketCpus>();

            [JsonProperty("features")] public Dictionary<string, bool> Features { get; set; }

            [JsonProperty("gpu")] public IEnumerable<PacketCpus> Gpu { get; set; } = new List<PacketCpus>();
        }

        public class PacketCpus : Cpus
        {
            [JsonProperty("count")] public long Count { get; set; }

            [JsonProperty("type")] public string Type { get; set; }
        }

        public class PacketDrive : Drive
        {
            [JsonProperty("count")] public long Count { get; set; }

            [JsonProperty("size")] public string Size { get; set; }

            [JsonProperty("type")] public string Type { get; set; }
        }

        public class PacketMemory : Memory
        {
            [JsonProperty("total")] public string Total { get; set; }
        }
    }
}