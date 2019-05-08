using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerManager.Infastructure.Providers.Common.Base;
using ServerManager.Infastructure.Providers.Common.Entities;
using ServerManager.Infastructure.Providers.DigitalOcean.Base;
using ServerManager.Infastructure.Providers.Packet.Base;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}