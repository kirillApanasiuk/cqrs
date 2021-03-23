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
using CQ.CqrsFramework;
using CQ.Infrastructure.Interfaces;
using CQ.UseCases.Order.Commands.CreateOrder;
using CQ.UseCases.Order.Commands.UpdateOrder;
using CQ.UseCases.Order.Dto;
using CQ.UseCases.Order.Queries.GetOrderById;
using CQ.UseCases.Order.Utils;
using CQ.WebApi.Services;
using Handlers.DataAccess.MsSql;
using Microsoft.EntityFrameworkCore;

namespace CQ.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQ.WebApi", Version = "v1" });
            });
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<ICurrentUserService, UserService>();

            services.AddScoped<IQueryHandler<GetOrderByIdQuery, OrderDto>, GetOrderByIdHandler>();
            services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderHandler>();
            services.AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();

            services.AddDbContext<IDbContext,AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQ.WebApi v1"));
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
