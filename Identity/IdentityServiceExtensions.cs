using Application.Contracts.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

            //services.AddAuthorizationBuilder();

            //services.AddDbContext<GloboTicketIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("JiraniRideIdentityConnectionString")));

            //services.AddIdentityCore<ApplicationUser>()
            //    .AddEntityFrameworkStores<JiraniRideDbContext>()
            //    .AddApiEndpoints();
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
