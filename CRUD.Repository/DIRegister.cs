using CRUD.Repository.ProdukRepo;
using CRUD.Repository.CartRepo;
using CRUD.Repository.UserRepo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public static class DIRegister
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IProdukRepository,ProdukRepository>();
            services.AddScoped<ICartRepository,CartRepository>();
            return services;
        }
    }
}
