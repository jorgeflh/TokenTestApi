﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Interfaces.Services;
using TokenTestApi.Core.Domain.Services;
using TokenTestApi.Core.Infrastructure.Data;
using TokenTestApi.Core.Infrastructure.Repository;

namespace TokenTestApi
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
            var databaseName = Configuration["EntityFramework:DatabaseName"];

            services.AddDbContext<TokenTestApiContext>(options =>
                options.UseInMemoryDatabase(databaseName));

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
