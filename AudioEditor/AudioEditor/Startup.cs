using AudioEditor.Application.Abstract;
using AudioEditor.Application.Commands;
using AudioEditor.Application.Services;
using AudioEditor.Infrastructure.Repository;
using AudioEditor.Infrastructure;
using MediatR;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;

namespace AudioEditor
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

            services.AddDbContext<AppDbContext>();
            services.AddMediatR(typeof(CreateAudioFile));
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
