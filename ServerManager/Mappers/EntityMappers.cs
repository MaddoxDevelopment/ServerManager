using Nelibur.ObjectMapper;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.Packet.Entities;

namespace ServerManager.Mappers
{
    public class EntityMappers
    {
        public static void Register()
        {
            TinyMapper.Bind<PacketDevice, Device>();
            TinyMapper.Bind<PacketFacility, Facility>();
            TinyMapper.Bind<PacketPlan, Plan>(config =>
            {
               config.Ignore(w => w.Spec);
            });
        }
    }
}