using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Infra.DataAccess;
using StarWars.API.Infra.Repositories;
using StarWars.API.Infra.Services.Synchronize;
using StarWars.API.Shared.Domain.Services;
using StarWars.API.Shared.Infra.Services;

namespace StarWars.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ContextDb>();

            #region Repositories
            services.AddTransient<IPlanetRepository, PlanetRepository>();
            services.AddTransient<IStarshipRepository, StarshipRepository>();
            #endregion

            #region Services
            services.AddTransient<IPlanetSynchronize, PlanetSynchronize>();
            services.AddTransient<IHttpRequest, HttpRequest>();
            services.AddTransient<IStarshipSynchronize, StarshipSynchronize>();
            #endregion
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "StarWars.API", Version = "v1"});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWars.API v1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}