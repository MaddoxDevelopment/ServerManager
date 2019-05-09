using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerManager.Infastructure.Providers.Common.Authentication;
using ServerManager.Infastructure.Providers.Common.Base;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.DigitalOcean;
using ServerManager.Infastructure.Providers.DigitalOcean.Base;
using ServerManager.Infastructure.Providers.Packet;
using ServerManager.Infastructure.Providers.Packet.Base;
using ServerManager.Mappers;
using ServerManager.Services.Deployment;
using ServerManager.Services.Deployment.Base;
using ServerManager.Services.Facilities;
using ServerManager.Services.Facilities.Base;

namespace ServerManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("Packet");
            services.AddHttpClient("DigitalOcean");

            services.AddScoped<IPacketService, PacketService>();
            services.AddScoped<IDigitalOceanService, DigitalOceanService>();
            
            services.AddTransient<Func<ServerProvider, IServerProvider>>(serviceProvider => provider =>
            {
                switch(provider)
                {
                    case ServerProvider.Packet:
                        return serviceProvider.GetService<IPacketService>();
                    case ServerProvider.DigitalOcean:
                        return serviceProvider.GetService<IDigitalOceanService>();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
                }
            });
            
            services.AddTransient<Func<ServerProvider, ApiConfigProvider>>(serviceProvider => provider =>
            {
                switch(provider)
                {
                    case ServerProvider.Packet:
                        return new ApiConfigProvider(Configuration.GetValue<string>("Packet:Token"), 
                            Configuration.GetValue<string>("Packet:BaseUrl"));
                    case ServerProvider.DigitalOcean:
                        return new ApiConfigProvider(Configuration.GetValue<string>("DigitalOcean:Token"), 
                            Configuration.GetValue<string>("DigitalOcean:BaseUrl"));
                    default:
                        throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
                }
            });
            
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IDeploymentService, DeploymentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            EntityMappers.Register();
            app.UseMvc();
        }
    }
}