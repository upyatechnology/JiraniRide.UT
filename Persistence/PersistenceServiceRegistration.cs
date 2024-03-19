using Application.Contracts.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JiraniDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JiraniRideConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IRiderRouteRepository, RouteRepository>();
           // services.AddScoped<IDriverRouteRepository, RideRequestRepository>();
            services.AddScoped<IDriverRouteRepository, InMemoryDriverRouteRepository>();
            services.AddScoped<IRiderRouteRepository, InMemoryRiderRouteRepository>();


            return services;
        }
    }


}
