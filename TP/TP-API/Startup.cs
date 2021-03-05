using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_API.Helper;
using TP_DAL.Contrats;
using TP_DAL.Models;
using TP_DAL.Providers;
using TP_DAL.Services;
using TP_DAL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TP_DAL.Email;

namespace TP_API
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);

                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
                options.AddPolicy("RequireAdminRole",
                    policy => policy.RequireRole("Admin"));
            });

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.Configure<AppSettingsModel>(Configuration.GetSection("ConnectionStrings"));

            services.AddControllers();

            services.AddTransient<IRepositoryArticle, DataProvidersArticle>();
            services.AddTransient<IServiceArticle, ServiceArticle>();

            services.AddTransient<IRepositoryCommande, DataProvidersCommande>();
            services.AddTransient<IServiceCommande, ServiceCommande>();

            services.AddTransient<IRepositoryCreneau, DataProvidersCreneau>();
            services.AddTransient<IServiceCreneau, ServiceCreneau>();

            services.AddTransient<IRepositoryMagasin, DataProvidersMagasin>();
            services.AddTransient<IServiceMagasin, ServiceMagasin>();

            services.AddTransient<IRepositoryMessage, DataProvidersMessage>();
            services.AddTransient<IServiceMessage, ServiceMessage>();

            services.AddTransient<IRepositoryReservation, DataProvidersReservation>();
            services.AddTransient<IServiceReservation, ServiceReservation>();

            services.AddTransient<IRepositoryStock, DataProvidersStock>();
            services.AddTransient<IServiceStock, ServiceStock>();

            services.AddTransient<IRepositoryUtilisateur, DataProvidersUtilisateur>();
            services.AddTransient<IServiceUtilisateur, ServiceUtilisateur>();

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddCors(options =>
            {
                options.AddPolicy("Policy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44380")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddOptions();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default", new CacheProfile()
                {
                    Duration = 60
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
