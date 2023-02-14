using Microsoft.Extensions.DependencyInjection;
using WebCrawlerDataBase;

namespace WebCrawlerLogic
{
    public static class CrawlerServiceConfiguration
    {
        public static IServiceCollection AddScoped(this IServiceCollection collection)
        {
            collection.AddScoped<CrawlerDB>()
                      .AddScoped<PageCrawler>()
                      .AddScoped<SitemapLoader>()
                      .AddScoped<TimingLinks>()
                      .AddScoped<CrawlerService>()
                      .AddScoped<RequestMapper>();

            return collection;
        }
    }
}
