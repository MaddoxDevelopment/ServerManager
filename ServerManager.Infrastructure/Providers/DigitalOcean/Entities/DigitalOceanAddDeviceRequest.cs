using ServerManager.Infastructure.Providers.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.DigitalOcean.Entities
{
    public class DigitalOceanAddDeviceRequest : AddDeviceRequest
    {
        public DigitalOceanAddDeviceRequest(string projectId, string location, string plan, string operatingSystem) 
            : base(projectId, location, plan, operatingSystem, ServerProvider.DigitalOcean)
        {
        }
    }
}