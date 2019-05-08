using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Providers.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.DigitalOcean.Base;

namespace ServerManager.Infastructure.Providers.DigitalOcean
{
    public class DigitalOceanService : IDigitalOceanService
    {
        public Task<Device> Deploy(AddDeviceRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetLocations()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetOperatingSystems()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetPlans()
        {
            throw new System.NotImplementedException();
        }
    }
}