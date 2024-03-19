using Application.Contracts.Infrastructure;
using Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IKafkaRideRequestProducer, KafkaRideRequestProducer>();
            //services.AddSingleton<IKafkaRouteConsumer, KafkaRouteConsumer>();
            //services.AddSingleton<IKafkaRouteConsumer, KafkaRouteConsumer>();

            //services.AddTransient<IEmailService, EmailService>();
            //services.AddTransient<IRedisRouteMatch, RedisRouteMatch>();
            //services.AddTransient<IDriverMatchingService, DriverMatchingService>();
            //services.AddTransient<IRedisDriverMatchingService, RedisDriverMatchingService>();
            // services.AddScoped<IKafkaProducerService, KafkaProducerService>();
            return services;
        }
    }
}
