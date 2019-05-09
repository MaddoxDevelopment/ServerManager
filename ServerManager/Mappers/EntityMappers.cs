using Nelibur.ObjectMapper;
using ServerManager.Infastructure.Common.Contracts;
using ServerManager.Infastructure.Common.Entities;
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
                // Couldn't get this to map properly with reflection so just ignore it and set it manually.
               config.Ignore(w => w.Spec);
            });
            TinyMapper.Bind<PacketOperatingSystem, OperatingSystem>();
            TinyMapper.Bind<AddDeviceRequest, PacketAddDeviceRequest>(config =>
            {
                config.Ignore(w => w.ProjectId);
                config.Bind(source => source.LocationId, target => target.Facility);
                config.Bind(source => source.PlanId, target => target.Plan);
                config.Bind(source => source.OperatingSystemId, target => target.OperatingSystem);
            });
        }
    }
}