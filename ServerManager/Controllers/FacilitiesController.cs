using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Services.Facilities.Base;

namespace ServerManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _facility;

        public FacilitiesController(IFacilityService facility)
        {
            _facility = facility;
        }

        public async Task<ActionResult<IEnumerable<Facility>>> List([FromQuery] ServerProvider provider)
        {
            return Ok(await _facility.GetFacilities(provider));
        }
    }
}