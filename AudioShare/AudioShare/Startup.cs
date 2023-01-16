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
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration.GetSection("Storage:ConnectionString").Value);
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CORSPolicy",
                                  policy =>
                                  {
                                      policy
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .WithOrigins("http://localhost:3000");
                                  });
            });
            services.AddTransient<IStorageService, StorageService>();

            services.AddControllers();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAudioFileRepository, AudioFileRepository>();

            var connectionString = Configuration.GetConnectionString("DefaultString");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddMediatR(typeof(GetAllAudioFiles));
            services.AddAutoMapper(typeof(Program));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Audio Editor", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Audio Editor v1"));
            }

            app.UseRouting();
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
