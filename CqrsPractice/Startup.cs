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
using ApplicationServices.Implementation;
using ApplicationServices.Implementation.Order;
using ApplicationServices.Implementation.Product;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Common;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Product;
using DataAccess.Mssql;
using Infrastructure.Interfaces;
using Layers.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace CqrsPractice
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CqrsPractice", Version = "v1" });
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReadOnlyOrderService, ReadOnlyOrderService>(); 

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReadOnlyProductService, ReadOnlyProductService>();

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IStatisticService, StatisticService>();

            services.AddDbContext<IDbContext, AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddDbContext<IReadOnlyDbContext, ReadOnlyAppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<ICurrentUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CqrsPractice v1"));
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
