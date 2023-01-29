using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Test_app
{
    public class PageCrawler
    {
        private readonly IConfiguration _config;
        private string? _rootUrl;
        private List<string>? _visitedPages;

        public PageCrawler()
        {
            _config = Configuration.Default.WithDefaultLoader();
        }

        public async Task<List<string>> GetCrawlLinks(string url)
        {
            _visitedPages = new List<string>();
            _rootUrl = url;
            return await CrawlAsync(url);
        }

        public async Task<List<string>> CrawlAsync(string url)
        {
            //var crawledUrls = new List<string>();
            var pagesList = await GetUrlsAsync(url);

            foreach (var page in pagesList)
            {
                if (!_visitedPages.Contains(page))
                {
                    _visitedPages.Add(page);
                    await CrawlAsync(page);
                }
            }

            return _visitedPages;
        }

        private async Task<List<string>> GetUrlsAsync(string currentUrl)
        {
            using var context = BrowsingContext.New(_config);
            using var doc = await context.OpenAsync(currentUrl);

            var foundedUrls = doc.QuerySelectorAll<IHtmlAnchorElement>("a")
            .Select(a =>
            {
                var currentLink = a.Attributes["href"]?.Value;

                if (currentLink == null) return String.Empty;

                if (IsLinkValid(currentLink))
                {
                    return String.Empty;
                }

                if (!currentLink.EndsWith("/"))
                {
                    currentLink += "/";
                }

                if (!currentLink.StartsWith("http"))
                {
                    currentLink = currentLink.StartsWith("/") ?
                    _rootUrl + currentLink.Substring(1, currentLink.Length - 1) :
                    _rootUrl + currentLink;
                }

                return currentLink;
            }).Where(a => (a.Contains(_rootUrl) && (!string.IsNullOrWhiteSpace(a))))
            .Distinct().ToList();

            return foundedUrls;
        }

        private bool IsLinkValid(string link)
        {
            var Extensions = new List<string>
            {
                ".dox",".docx",".png",".bmp",
                ".jpg",".jpeg",".pdf",".xls",
                ".xlsx",".txt",".webp",".gif",
                ".mp4",".xml",".aif",".mp3",
                ".ogg",".wav","pkg",".rar",
                ".zip",".ico","#","?",":"," "
            };

            if (Extensions.FirstOrDefault(x => link.Contains(x)) != null)
            {
                return true;
            }

            return false;
        }
    }
}
