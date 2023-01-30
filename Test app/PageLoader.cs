using AngleSharp;
using AngleSharp.Dom;

namespace Test_app
{
    internal class PageLoader
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
