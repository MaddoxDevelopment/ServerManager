using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Providers.Common.Contracts
{
    public class AddDeviceRequest
    {
        public string ProjectId { get; set; }
        public string Location { get; set; }
        public string Plan { get; set; }
        public string OperatingSystem { get; set; }
        public ServerProvider Provider { get; set; }

        public AddDeviceRequest(string projectId, string location, string plan, string operatingSystem, ServerProvider provider)
        {
            ProjectId = projectId;
            Location = location;
            Plan = plan;
            OperatingSystem = operatingSystem;
            Provider = provider;
        }
    }
}