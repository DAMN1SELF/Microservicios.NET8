//using Microsoft.ApplicationInsights.AspNetCore.Extensions;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using INCHE.Producto.Application.External.ApplicationInsights;
//using INCHE.Producto.Application.External.GetTokenJwt;
//using INCHE.Producto.Application.External.SendGridEmail;
//using INCHE.Producto.External.ApplicationInsights;
//using INCHE.Producto.External.GetTokenJwt;
//using INCHE.Producto.External.SendGridEmail;

namespace INCHE.Producto.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            //services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"])),
            //        ValidIssuer = configuration["IssuerJwt"],
            //        ValidAudience = configuration["AudienceJwt"]
            //    };
            //});

            //services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            //{
            //    ConnectionString = configuration["ApplicationInsightsConnectionString"]
            //});

            //services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();

            return services;
        }
    }
}
