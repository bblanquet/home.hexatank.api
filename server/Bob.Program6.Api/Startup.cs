using AspNetCoreRateLimit;
using Bob.Program6.Api.Core;
using Bob.Program6.Api.Core.Dao;
using Bob.Program6.Api.Core.Services;
using Bob.Program6.Api.Dao;
using Bob.Program6.Api.Middleware;
using Bob.Program6.Dao.Core;
using Bob.Program6.Security.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Bob.Program6.Api
{
    public class Startup
    {
        readonly string customOrigins = "customOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ITokenRetriever, TokenRetriever>();
            
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<IExceptionService, ExceptionService>();

            services.AddScoped<IPlayerDao, PlayerDao>();
            services.AddScoped<IRecordDao, RecordDao>();
            services.AddScoped<IExceptionDao, ExceptionDao>();

            services.AddScoped<IDataAccess, DataAccess>();

            //what is that?
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();

            // Add framework services.
            services.AddMvc();

            services.AddSwaggerGen();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: customOrigins, builder => {
                    builder.WithOrigins("http://localhost:8080");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
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

            app.UseMiddleware<JwtMiddleware>();
            app.UseIpRateLimiting();
            app.UseRouting();
            app.UseCors(customOrigins);
            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{Environment.GetEnvironmentVariable("SUBPATH")}/swagger/v1/swagger.json", "program6 API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
