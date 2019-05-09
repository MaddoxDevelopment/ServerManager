using System;
using System.Threading.Tasks;
using ServerManager.Infastructure.Common.Base;
using ServerManager.Infastructure.Providers.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Services.Deployment.Base;

namespace ServerManager.Services.Deployment
{
    public class DeploymentService : IDeploymentService
    {
        private readonly Func<ServerProvider, IServerProvider> _accessor;

        public DeploymentService(Func<ServerProvider, IServerProvider> accessor)
        {
            _accessor = accessor;
        }

        public async Task<Device> Deploy(AddDeviceRequest request)
        {
            return await _accessor(request.Provider).Deploy(request);
        }
    }
}