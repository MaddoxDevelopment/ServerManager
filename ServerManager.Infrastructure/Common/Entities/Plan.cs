using System;
using System.Collections.Generic;
using ServerManager.Infastructure.Providers.Packet.Entities;

namespace ServerManager.Infastructure.Providers.Common.Entities
{
    public class Plan
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Line { get; set; }

        public Specs Spec { get; set; }

        public bool Legacy { get; set; }

        public IEnumerable<string> DeploymentTypes { get; set; } = new List<string>();

        public IEnumerable<PacketFacility> AvailableIn { get; set; } = new List<PacketFacility>();

        public string Class { get; set; }

        public PlanPricing Pricing { get; set; }

        public class PlanPricing
        {
            public double Hour { get; set; }
        }

        public class Specs
        {
            public IEnumerable<Cpus> Cpus { get; set; }

            public Memory Memory { get; set; }

            public IEnumerable<Drive> Drives { get; set; }

            public IEnumerable<Cpus> Nics { get; set; }

            public Dictionary<string, bool> Features { get; set; }

            public IEnumerable<Cpus> Gpu { get; set; }
        }

        public class Cpus
        {
            public long Count { get; set; }

            public string Type { get; set; }
        }

        public class Drive
        {
            public long Count { get; set; }

            public string Size { get; set; }

            public string Type { get; set; }
        }

        public class Memory
        {
            public string Total { get; set; }
        }
    }
}