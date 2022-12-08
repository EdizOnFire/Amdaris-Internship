using AudioEditor.Application.Abstract;
using AudioEditor.Application.Commands;
using AudioEditor.Application.Services;
using AudioEditor.Infrastructure;
using AudioEditor.Infrastructure.Repository;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IStorageService, StorageService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAudioFileRepository, AudioFileRepository>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(typeof(CreateAudioFile));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Audio Editor", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Audio Editor v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();