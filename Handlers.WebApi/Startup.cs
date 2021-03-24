using Handlers.ApplicationServices.Implementation;
using Handlers.ApplicationServices.Interfaces;
using Handlers.CqrsFramework;
using Handlers.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Handlers.UseCases.Order.Dto;
using Handlers.UseCases.Order.Queries.GetOrderById;
using Microsoft.EntityFrameworkCore;
using Handlers.DataAccess.MsSql;
using Handlers.UseCases.Order.Commands.CreateOrder;
using Handlers.UseCases.Order.Commands.UpdateOrder;
using Handlers.UseCases.Order.Utils;
using Handlers.WebApi.Services;

namespace Handlers.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Handlers.WebApi", Version = "v1" });
            });
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<ICurrentUserService,UserService>();
            services.AddScoped<IStatisticService,StatisticService>();

            services.Scan(selector => selector.FromAssemblyOf<GetOrderByIdQuery>()
                .AddClasses(classes=>classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            //services.AddScoped<IRequestHandler<GetOrderByIdQuery, OrderDto>,GetOrderByIdHandler>();
            //services.AddScoped<IRequestHandler<CreateOrderCommand, int>, CreateOrderHandler>();
            //services.AddScoped<IRequestHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();



            services.AddDbContext<IDbContext, AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddDbContext<IReadOnlyDbContext, ReadOnlyAppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Handlers.WebApi v1"));
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
