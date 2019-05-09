using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
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

        public Task<IEnumerable<Facility>> GetFacilities()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OperatingSystem>> GetOperatingSystems(Plan plan)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<IEnumerable<Plan>> GetPlans(Facility facility)
        {
            throw new System.NotImplementedException();
        }
    }
}