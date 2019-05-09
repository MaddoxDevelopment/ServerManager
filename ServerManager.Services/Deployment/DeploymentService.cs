using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Common.Base;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Services.Deployment.Base;
using OperatingSystem = ServerManager.Infastructure.Common.Entities.OperatingSystem;

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

        public async Task<IEnumerable<OperatingSystem>> GetOperatingSystems(ServerProvider provider, Plan plan)
        {
            return await _accessor(provider).GetOperatingSystems(plan);
        }
    }
}