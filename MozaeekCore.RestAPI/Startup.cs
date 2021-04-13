using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.LogManagement;
using MozaeekCore.Persistense.EF;
using MozaeekCore.RestAPI.Bootstrap;
using MozaeekCore.RestAPI.Utility;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace MozaeekCore.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // if (CurrentEnvironment.EnvironmentName == "IntegrationTest")
            // {
            //     services.AddControllers(config =>
            //     {
            //         config.Filters.Add(new ActionFilter());
            //     });
            //  
            //     return;
            // }

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                    .WithExposedHeaders("Token-Expired");
            }));

            services.AddScoped<IErrorHandling, SailorLogErrorHandle>(sp =>
            {
                var path = Configuration.GetValue<String>("SailorLogPath");
                
                Log.Logger = (Serilog.ILogger)new LoggerConfiguration()
                    .WriteTo
                    .File($"{path}log-.txt", LogEventLevel.Verbose, "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", (IFormatProvider)null, new long?(1073741824L), (LoggingLevelSwitch)null, false, false, new TimeSpan?(), RollingInterval.Day, false, new int?(31), (Encoding)null)
                    .MinimumLevel.Information().CreateLogger();
                return new SailorLogErrorHandle();
            });

            services.AddDbContext<CoreDomainContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(this.Configuration.GetConnectionString("CoreDomainContext"));
            });



            services.AddFrameworkServices();
            services.AddCommandHandlerServices();
            services.AddQueryHandlerServices();
            
            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<CurrentUser>(provider =>
            {
                var claims = provider.GetService<IHttpContextAccessor>().HttpContext.User.Claims;
                var userIdClaim = claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string userId = "";
                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;
                }
                var userNameClaim = claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
                string userName = "";
                if (userNameClaim != null)
                {
                    userName = userNameClaim.Value;
                }
                var currentUser = new CurrentUser();
                currentUser.UserId = userId;
                currentUser.UserName = userName;
                return currentUser;
            });


            services.AddControllers(config =>
            {
                config.Filters.Add(new ActionFilter());
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MozaeekCore.RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName== "IntegrationTest")
            {
                app.UseExceptionHandler("/error");
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
                return;
            }
            app.UseCors("ApiCorsPolicy");
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MozaeekCore.RestAPI v1"));
            // }
            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
