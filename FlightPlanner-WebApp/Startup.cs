using AutoMapper;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations.AirportValidations;
using FlightPlanner.Core.Validations.FlightValidations;
using FlightPlanner.Core.Validations.SearchFlightValidations;
using FlightPlanner.Services;
using FlightPLanner.Data.Data;
using FlightPlanner_WebApp.Data;
using FlightPlanner_WebApp.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightPlanner_WebApp
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightPlanner_WebApp", Version = "v1" });
            });

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddDbContext<FlightPlannerDbContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddScoped<IFlightPlannerDbContext, FlightPlannerDbContext>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Airport>, EntityService<Airport>>();
            services.AddScoped<IEntityService<Flight>, EntityService<Flight>>();
            services.AddScoped<IFlightService, AirporttService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IFlightValidator, FlightAirportValidator>();
            services.AddScoped<IFlightValidator, FlightCarrierValidator>();
            services.AddScoped<IFlightValidator, FlightTimeValidator>();
            services.AddScoped<IAirportValidator, AirportCityValidator>();
            services.AddScoped<IAirportValidator, AirportCountryValidator>();
            services.AddScoped<IAirportValidator, AirportNameValidator>();
            services.AddSingleton(MapperConfigcs.CreateMapper());
            services.AddScoped<ISearchFlightRequestValidator, SearchFlightRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightPlanner_WebApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
