using System.Collections.Generic;
using Newtonsoft.Json;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.Packet.Entities
{
    public class PacketAddDeviceRequest : AddDeviceRequest
    {
        [JsonProperty("facility")] public string Facility { get; set; }

        [JsonProperty("plan")] public string Plan { get; set; }

        [JsonProperty("hostname")] public string Hostname { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("billing_cycle")] public string BillingCycle { get; set; }

        [JsonProperty("operating_system")] public string OperatingSystem { get; set; }

        [JsonProperty("always_pxe")] public string AlwaysPxe { get; set; }

        [JsonProperty("ipxe_script_url")] public string IpxeScriptUrl { get; set; }

        [JsonProperty("userdata")] public string UserData { get; set; }

        [JsonProperty("locked")] public string Locked { get; set; }

        [JsonProperty("customdata")] public string CustomData { get; set; }

        [JsonProperty("hardware_reservation_id")]
        public string HardwareReservationId { get; set; }

        [JsonProperty("spot_instance")] public string SpotInstance { get; set; }

        [JsonProperty("spot_price_max")] public string SpotPriceMax { get; set; }

        [JsonProperty("termination_time")] public string TerminationTime { get; set; }

        [JsonProperty("tags")] public List<string> Tags { get; set; }

        [JsonProperty("project_ssh_keys")] public List<string> ProjectSshKeys { get; set; }

        [JsonProperty("user_ssh_keys")] public List<string> UserSshKeys { get; set; }

        [JsonProperty("features")] public List<string> Features { get; set; }

        [JsonProperty("public_ipv4_subnet_size")]
        public string PublicIpv4SubnetSize { get; set; }

        [JsonProperty("private_ipv4_subnet_size")]
        public string PrivateIpv4SubnetSize { get; set; }

        [JsonProperty("ip_addresses")] public List<IpAddress> IpAddresses { get; set; }

        public PacketAddDeviceRequest(string projectId, string location, string plan, string operatingSystem) 
            : base(projectId, location, plan, operatingSystem, ServerProvider.Packet)
        {
        }
    }

    public class IpAddress
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("address_family")] public string AddressFamily { get; set; }

        [JsonProperty("public")] public string Public { get; set; }

        [JsonProperty("cidr")] public string Cidr { get; set; }
    }
}