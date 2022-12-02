using AudioEditor.API;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });