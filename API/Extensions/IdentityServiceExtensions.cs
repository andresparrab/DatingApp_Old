using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    // When creating extensions methods the class need to be static
    // static means that we no need to make a new instace of the class
    // before we use it
    public static class IdentityServiceExtensions
    {
        //                                        You write "this" to extend the type of IserviceCollection
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,  // the Issuer is the api server
                                ValidateAudience = false, // the Audience is the Angular client

                            };
                });

            return services;
        }
    }
}