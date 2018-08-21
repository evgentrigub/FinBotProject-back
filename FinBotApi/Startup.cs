using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinBotApi
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;  // если true, то передча токена будет по https
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,                          // укзывает, будет ли валидироваться издатель при валидации токена
                    ValidIssuer = AuthOptions.ISSUER,                // строка, представляющая издателя
                    ValidateAudience = true,                        // будет ли валидироваться потребитель токена
                    ValidAudience = AuthOptions.AUDIENCE,            // установка потребителя токена
                    ValidateLifetime = true,                                    // будет ли валидироваться время существования
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),    // установка ключа безопасности
                    ValidateIssuerSigningKey = true,                             // валидация ключа безопасности
                }; 
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
