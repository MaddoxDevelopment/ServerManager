using System.ComponentModel.DataAnnotations;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Common.Contracts
{
    public class AddDeviceRequest
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Plan { get; set; }
        [Required]
        public string OperatingSystem { get; set; }
        [Required]
        public ServerProvider Provider { get; set; }

        public AddDeviceRequest(string projectId, string location, string plan, string operatingSystem, ServerProvider provider)
        {
            ProjectId = projectId;
            Location = location;
            Plan = plan;
            OperatingSystem = operatingSystem;
            Provider = provider;
        }

        public AddDeviceRequest()
        {
        }
    }
}