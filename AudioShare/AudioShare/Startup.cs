using AudioShare.Application.Abstract;
using AudioShare.Application.Commands;
using AudioShare.Application.Services;
using AudioShare.Infrastructure.Repository;
using AudioShare.Infrastructure;
using MediatR;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AudioShare.Application.Queries;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace AudioShare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddControllers();

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration.GetSection("Storage:ConnectionString").Value);
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CORSPolicy", policy =>
                {
                    policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
                });
            });

            services.AddTransient<IStorageService, StorageService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAudioFileRepository, AudioFileRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            var connectionString = Configuration.GetConnectionString("DefaultString");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddMediatR(typeof(GetAllAudioFiles));
            services.AddAutoMapper(typeof(Program));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web App", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Oauth2.0 which uses AuthorizationCode flow",
                    Name = "oauth2.0",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(Configuration["SwaggerAzureAD:AuthorizationUrl"]),
                            TokenUrl = new Uri(Configuration["SwaggerAzureAD:TokenUrl"]),
                            Scopes = new Dictionary<string, string>
                            {
                                {Configuration["SwaggerAzureAD:Scope"],"Access API as User" }
                            }
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="oauth2"}
                        },
                        new []{Configuration["SwaggerAzureAD:Scope"]}
                    }
                });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = WebApplication.CreateBuilder();
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);
                    c.OAuthUsePkce();
                });
            }

            app.UseRouting();
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
