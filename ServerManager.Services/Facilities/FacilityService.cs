using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Providers.Common.Base;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Services.Facilities.Base;

namespace ServerManager.Services.Facilities
{
    public class FacilityService : IFacilityService
    {
        private readonly Func<ServerProvider, IServerProvider> _accessor;

        public FacilityService(Func<ServerProvider, IServerProvider> accessor)
        {
            _accessor = accessor;
        }

        public async Task<IEnumerable<Facility>> GetFacilities(ServerProvider provider)
        {
            return await _accessor(provider).GetFacilities();
        }
    }
}