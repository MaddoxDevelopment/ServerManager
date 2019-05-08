using System.Collections.Generic;
using System.Threading.Tasks;
using ServerManager.Infastructure.Providers.Common.Contracts;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.Packet.Base;

namespace ServerManager.Infastructure.Providers.Packet
{
    public class PacketService : IPacketService
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