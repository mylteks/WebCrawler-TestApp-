using AngleSharp;
using AngleSharp.Dom;

namespace WebCrawlerLogic
{
    public class PageLoader
    {
        public async Task<IDocument> LoadPage(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var doc = await context.OpenAsync(url);

            return doc;
        }
    }
}
