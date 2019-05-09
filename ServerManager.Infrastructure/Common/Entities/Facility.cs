using System.Collections.Generic;
using ServerManager.Infastructure.Providers.Packet.Entities;

namespace ServerManager.Infastructure.Providers.Common.Entities
{
    public class Facility
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public IEnumerable<string> Features { get; set; } = new List<string>();

        public Address Address { get; set; }

        public IEnumerable<string> IpRanges { get; set; } = new List<string>();
    }
}