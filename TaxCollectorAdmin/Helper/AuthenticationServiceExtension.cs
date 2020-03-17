using IdentityModel;
using IdentityModel.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCollectorAdmin.Helper
{
    public static class AuthenticationServiceExtension
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var idpSettings = Startup.StaticConfig.GetSection("APPCONSTANTS");

            var apiUrl = idpSettings["ApiUrl"];
            var authority = idpSettings["Authority"];
            var clientSecret = idpSettings["ClientSecret"];
            var clientId = idpSettings["ClientId"];
            bool requireHttpsMetadata = bool.Parse(idpSettings["RequireHttpsMetadata"]);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.Name = "mvcHybridTaxAdmin";
            })
            .AddAutomaticTokenManagement()
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = requireHttpsMetadata;
                options.ClientSecret = clientSecret;
                options.ClientId = clientId;
                options.CallbackPath = "/signin-oidc";
                options.ResponseType = "code";
                options.UseTokenLifetime = true;
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("collectorapi");
                options.Scope.Add("offline_access");

                options.ClaimActions.MapAllExcept("iss", "nbf", "exp", "aud", "nonce", "iat", "c_hash");

                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,
                };
            });

            return services;
        }
    }
}
