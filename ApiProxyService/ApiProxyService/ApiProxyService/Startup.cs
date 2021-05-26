using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiProxyService
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
            services.AddHttpClient("ShareService", c =>
            {
                c.BaseAddress = new Uri(AppSettings.Get<string>("ShareService"));
            });
            services.AddHttpClient("TraderService", c =>
            {
                c.BaseAddress = new Uri(AppSettings.Get<string>("TraderService"));
            });
            services.AddHttpClient("RequesterService", c =>
            {
                c.BaseAddress = new Uri(AppSettings.Get<string>("RequesterService"));
            });
            services.AddHttpClient("ProviderService", c =>
            {
                c.BaseAddress = new Uri(AppSettings.Get<string>("ProviderService"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProxyService", Version = "v1" });
            });
        }      
        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIProxyService v1"));
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
