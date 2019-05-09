using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Providers.Common.Entities;

namespace ServerManager.Services.Facilities.Base
{
    public interface IFacilityService
    {
        Task<IEnumerable<Facility>> GetFacilities(ServerProvider provider);
    }
}