using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.DigitalOcean.Entities
{
    public class DigitalOceanAddDeviceRequest : AddDeviceRequest
    {
        public DigitalOceanAddDeviceRequest(string projectId, string locationId, string planId, string operatingSystemId) 
            : base(projectId, locationId, planId, operatingSystemId, ServerProvider.DigitalOcean)
        {
        }
    }
}