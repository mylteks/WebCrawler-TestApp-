using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebCrawlerConsole;
using WebCrawlerDataBase;
using WebCrawlerLogic;

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
        services.AddScoped<App>();
        services.AddScoped<Printer>();

    }).ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));



