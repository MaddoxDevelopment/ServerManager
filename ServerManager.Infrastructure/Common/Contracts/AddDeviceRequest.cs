using System.ComponentModel.DataAnnotations;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Common.Contracts
{
    public class AddDeviceRequest
    {
        public string ProjectId { get; set; }
        [Required]
        public string LocationId { get; set; }
        [Required]
        public string PlanId { get; set; }
        [Required]
        public string OperatingSystemId { get; set; }
        [Required]
        public ServerProvider Provider { get; set; }

        public AddDeviceRequest(string projectId, string locationId, string planId, string operatingSystemId, ServerProvider provider)
        {
            ProjectId = projectId;
            LocationId = locationId;
            PlanId = planId;
            OperatingSystemId = operatingSystemId;
            Provider = provider;
        }

        public AddDeviceRequest()
        {
        }
    }
}