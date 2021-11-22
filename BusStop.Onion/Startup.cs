using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusStop.Core.BusStop;
using BusStop.Core.Client;
using BusStop.Data;
using BusStop.Data.BusStop;
using BusStop.Data.Client;
using BusStop.Orchestrators.BusStop;
using BusStop.Orchestrators.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BusStop.Onion
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
            services.AddAutoMapper(typeof(OrchBusStationProfile), typeof(DaoBusStationProfile), typeof(DaoClientProfile),
                typeof(OrchClientProfile));
            
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IBusService, BusService>();
            string connString = "Host=localhost;Port=5432;Database=BankDb;Username=postgres;Password=159753";
            services.AddDbContext<BusStopContext>(options => options.UseNpgsql(connString));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bus.Onion", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bus.Onion v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}