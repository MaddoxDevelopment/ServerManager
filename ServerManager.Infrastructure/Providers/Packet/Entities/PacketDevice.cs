using System.Collections.Generic;
using Newtonsoft.Json;
using ServerManager.Infastructure.Common.Entities;

namespace ServerManager.Infastructure.Providers.Packet.Entities
{
    public class PacketDevices
    {
        [JsonProperty("devices")]
        public IEnumerable<PacketDevice> Devices { get; set; }
    }
    public class PacketDevice : Device
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("short_id")]
        public string ShortId { get; set; }
        
        [JsonProperty("hostname")]
        public string HostName { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
    }
}