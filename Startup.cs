using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing
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
            SqlAuthenticationContext.SqlAuthenticationDataContext C = new SqlAuthenticationContext.SqlAuthenticationDataContext("data source=DESKTOP-BVHJ40C;initial catalog=SqlAuthentication;integrated security=True;persist security info=True;License Key=qHnH5wx/L422kFN4WQussVkqbelF0xGMaZi+DGL6lhFu+VTasW/ZRA22+dVoDbuQ64trDZsBMziLDE9kumHeTDKlcRSCvsotqn7rHn9VHFXS3Jmh/rFBVSxav6UlKmT4POdU+hnX8ACaigXhFdBiZ4NeHNVRNTqJ4fUTou0czKt8ATWxOB2MjUrprbYTV2ECFJOo2uLgwGzqeEpv1gGPLKR3p5DOKdeMu61FRAak23fmjt8PPQpz50o1E0r0FFdoQrJIYKkMxqRiD2IhVxlcVCvpIqR31rWwKJ1sNquGBMU=;");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Testing", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Testing v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
