using Microsoft.Extensions.DependencyInjection;
using WebCrawlerDataBase;

namespace WebCrawlerLogic
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddScoped(this IServiceCollection collection)
        {
            collection.AddScoped<PageCrawler>()
                      .AddScoped<SitemapLoader>()
                      .AddScoped<TimingLinks>()
                      .AddScoped<ModelCreator>()
                      .AddScoped<CrawlerDB>();

            return collection;
        }
    }
}
