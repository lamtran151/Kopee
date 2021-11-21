using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Myrmica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions
{
    public static class AdminServicesExtensions
    {
        public static IServiceCollection AddAdminServices<TNopObjectContext>(this IServiceCollection services)
            where TNopObjectContext : NopObjectContext, IDbContext
        {
            //Repositories
            services.AddScoped(typeof(IDbContext), typeof(NopObjectContext));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddTransient<IClientRepository, ClientRepository<TConfigurationDbContext>>();

            //Services
            //services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
