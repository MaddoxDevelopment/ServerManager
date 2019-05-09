using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Infastructure.Common.Base
{
    public interface IServerProvider
    {
        Task<Device> Deploy(AddDeviceRequest request);
        Task<IEnumerable<Device>> GetDevices();
        Task DeleteDevice(Device device);
        Task<IEnumerable<Facility>> GetFacilities();
        Task<IEnumerable<OperatingSystem>> GetOperatingSystems(Plan plan);
        Task<IEnumerable<Plan>> GetPlans(Facility facility);
    }
}