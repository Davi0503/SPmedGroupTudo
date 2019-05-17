using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Senai_Semestre2_Sprint2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })

            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Adiciona o Cors ao projeto
            //Veremos em breve
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Senai_Semestre_Sprint2", Version = "v1" });
            });

            //Implementa autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }
            ).AddJwtBearer("JwtBearer", options =>
            {
                //Define as opções 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Quem esta solicitando
                    ValidateIssuer = true,
                    //Quem esta validadando
                    ValidateAudience = true,
                    //Definindo o tempo de expiração
                    ValidateLifetime = true,
                    //Forma de criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SPmedgroup-chave-autenticacao")),
                    //Tempo de expiração do Token
                    ClockSkew = TimeSpan.FromMinutes(30),
                    //Nome da Issuer, de onde esta vindo
                    ValidIssuer = "Senai_Semestre_Sprint2",
                    //Nome da Audience, de onde esta vindo
                    ValidAudience = "Senai_Semestre_Sprint2"
                };
            });

        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai_Semestre_Sprint2");
            });

            app.UseAuthentication();

            app.UseCors("CorsPolicy");


            app.UseMvc();


            
        }
    }
}
