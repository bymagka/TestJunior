using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.MyDataInitializer;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using BLL.Services;

namespace MyWebAPI
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

            services.AddDbContext<MyContext>(opt => opt.UseInMemoryDatabase("MyBase"));
            services.AddScoped<MyDataInitializer>();

            //repositories
            services.AddScoped<IProductsRepo, ProductsRepo>();
            services.AddScoped<IBuyersRepo, BuyersRepo>();
            services.AddScoped<ISalesPointsRepo, SalesPointRepo>();
            services.AddScoped<ISalesRepo, SalesRepo>();

            //services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<ISalesPointService, SalesPointService>();
            services.AddScoped<ISaleService, SaleService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebAPI", Version = "v1" });
            });
        }

  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebAPI v1"));
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
