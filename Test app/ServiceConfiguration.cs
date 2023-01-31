using Microsoft.Extensions.DependencyInjection;
using TestAppDB;

namespace Test_app
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddScoped(this IServiceCollection collection)
        {
            collection.AddScoped<PageCrawler>()
                      .AddScoped<SitemapLoader>()
                      .AddScoped<TimingLinks>()
                      .AddScoped<Printer>()
                      .AddScoped<ModelCreator>()
                      .AddScoped<App>()
                      .AddScoped<CrawlerDB>();

            return collection;
        }
    }
}
