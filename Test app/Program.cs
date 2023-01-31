using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Test_app;
using TestAppDB;

using IHost host = CreateHostBuilder().Build();

var app = host.Services.GetService<App>();

await app.RunAsync();


static IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder().
    ConfigureServices((hostContext, services) =>
    {

        IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

        var conString = configuration.GetConnectionString("CrawlerDb");

        services.AddDbContext<CrawlerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CrawlerDb"))
        );

        services.AddScoped();

    }).ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));



