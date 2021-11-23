using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Myrmica.Data;
using Myrmica.Repository;
using Myrmica.Repository.Interfaces;
using Myrmica.Service;
using Myrmica.Service.Interface;
using System;

namespace Myrmica.Ext
{
    public static class AdminServicesExtensions
    {
        public static IServiceCollection AddAdminServices<TNopObjectContext>(this IServiceCollection services, IConfiguration configuration)
            where TNopObjectContext : NopObjectContext, IDbContext
        {
            //Repositories
            services.AddScoped(typeof(IDbContext), typeof(NopObjectContext));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientSettingRepository, ClientSettingRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<ISettingTypeRepository, SettingTypeRepository>();
            //services.AddTransient<IClientRepository, ClientRepository<TConfigurationDbContext>>();

            //Services
            //services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<IClientService, ClientService>();
            //services.AddTransient<IClientSettingService, ClientSettingService>();
            //services.AddTransient<IContactService, ContactService>();
            //services.AddTransient<IMenuService, MenuService>();
            //services.AddTransient<INewsService, NewsService>();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IServiceTypeService, ServiceTypeService>();
            //services.AddTransient<ISettingTypeService, SettingTypeService>();
            var fileApi = configuration.GetSection("FileStorageApi").Value;
            services.AddHttpClient<ICategoryService, CategoryService>(client => {
                client.BaseAddress = new Uri(fileApi);
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5));
            return services;
        }
    }
}
