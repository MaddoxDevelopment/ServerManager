using System.Threading.Tasks;
using ServerManager.Infastructure.Providers.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Services.Deployment.Base
{
    public interface IDeploymentService
    {
        Task<Device> Deploy(AddDeviceRequest request);
    }
}