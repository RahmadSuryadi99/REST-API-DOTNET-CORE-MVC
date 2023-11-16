using CRUD.Provider.CartProv;
using CRUD.Provider.ProdukProvd;
using CRUD.Provider.UserProv;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider
{
    public static class DIRegister
    {
        public static IServiceCollection AddProvider(this IServiceCollection services)
        {
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IProdukProvider, ProdukProvider>();
            services.AddScoped<ICartProvider, CartProvider>();
            return services;
        }
    }
}
