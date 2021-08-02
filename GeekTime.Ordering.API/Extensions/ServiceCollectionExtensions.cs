using GeekTime.Infrastructure;
using GeekTime.Ordering.API.IntegrationEvents;
using GeekTime.Ordering.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeekTime.Ordering.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(OrderingDomainContextTransactionBehavior<,>));

            services.AddMediatR(typeof(Startup).Assembly);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }

        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<OrderingDomainContext>(optionsAction);
        }

        public static IServiceCollection AddMysqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISubscriberService, SubscriberService>();

            services.AddCap(o =>
            {
                o.UseEntityFramework<OrderingDomainContext>();

                o.UseRabbitMQ(o =>
                {
                    configuration.GetSection("RabbitMQ").Bind(o);
                });
            });

            return services;
        }
    }
}
