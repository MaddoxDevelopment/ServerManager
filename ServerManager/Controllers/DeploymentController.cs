using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Services.Deployment.Base;

namespace ServerManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeploymentController : ControllerBase
    {
        private readonly IDeploymentService _deployment;

        public DeploymentController(IDeploymentService deployment)
        {
            _deployment = deployment;
        }

        [HttpGet]
        public async Task<ActionResult<Device>> OperatingSystems([FromQuery] ServerProvider provider, string plan)
        {
            var systems = await _deployment.GetOperatingSystems(provider, new Plan { Name = plan });
            return Ok(systems);
        }
        
        [HttpPost]
        public async Task<ActionResult<Device>> Deploy([FromBody] AddDeviceRequest request)
        {
            var device = await _deployment.Deploy(request);
            return Ok(device);
        }
        
        [HttpGet]
        public async Task<ActionResult<Device>> Deployed([FromQuery] ServerProvider provider)
        {
            var device = await _deployment.GetDevices(provider);
            return Ok(device);
        }
    }
}