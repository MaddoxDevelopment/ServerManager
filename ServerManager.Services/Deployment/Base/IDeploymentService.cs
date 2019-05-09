using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Services.Deployment.Base
{
    public interface IDeploymentService
    {
        Task<Device> Deploy(AddDeviceRequest request);
        Task<IEnumerable<OperatingSystem>> GetOperatingSystems(ServerProvider provider, Plan plan);
    }
}