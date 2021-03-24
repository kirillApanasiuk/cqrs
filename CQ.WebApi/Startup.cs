using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CQ.ApplicationServices.Implementation;
using CQ.ApplicationServices.Interfaces;
using CQ.CqrsFramework;
using CQ.DataAccess.MsSql;
using CQ.Infrastructure.Interfaces;
using CQ.UseCases.Order.Commands.CreateOrder;
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "CQ.WebApi", Version = "v1"}); });
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<ICurrentUserService, UserService>();
            services.AddScoped<IStatisticService, StatisticService>();

            services.Scan(selector => selector.FromAssemblyOf<GetOrderByIdQuery>()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            services.Scan(selector => selector.FromAssemblyOf<CreateOrderCommand>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQ.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
