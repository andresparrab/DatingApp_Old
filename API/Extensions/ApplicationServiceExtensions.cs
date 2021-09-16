using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    // When creating extensions methods the class need to be static
    // static means that we no need to make a new instace of the class
    // before we use it
    public static class ApplicationServiceExtensions
    {
                //                                   You write "this" to extend the type of IserviceCollection
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, Services.TokenService>();
            
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;            
        }
    }
}