using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Test_app
{
    public class PageCrawler
    {
        IConfiguration config;
        public List<string> urls { get; set; }
        public List<string> foundedUrls;
        string rootUrl;

        public PageCrawler()
        {
            config = Configuration.Default.WithDefaultLoader();
        }

        public PageCrawler(string mainUrl)
        {
            config = Configuration.Default.WithDefaultLoader();
            foundedUrls = new List<string>();
            urls = new List<string>();
            rootUrl = mainUrl;
        }



        async public Task<List<string>> GetUrlsAsync(string currentUrl)
        {
           
            using var context = BrowsingContext.New(config);
            using var doc = await context.OpenAsync(currentUrl);
            foundedUrls=doc.QuerySelectorAll<IHtmlAnchorElement>("a")
            .Select(a =>
            {
                var currentLink = a.Attributes["href"]?.Value;
                if (currentLink == null) return "";
                if (IsLinkValid(currentLink))
                {
                    return "";
                }
                if (!currentLink.EndsWith("/"))
                {
                    currentLink += "/";
                }
                if (!currentLink.StartsWith("http"))
                {
                    currentLink = currentLink.StartsWith("/") ?
                    rootUrl + currentLink.Substring(1, currentLink.Length - 1) :
                    rootUrl + currentLink;
                }
                
                return currentLink;
            }).Where(a => (a.Contains(rootUrl) && (!string.IsNullOrWhiteSpace(a))))
            .Distinct().ToList();
            return foundedUrls;
        }
        async public Task CrawlAsync(string url)
        {
            var pagesList = await GetUrlsAsync(url);
            foreach (var page in pagesList)
            {
                if (!urls.Contains(page))
                {
                    urls.Add(page);
                    await CrawlAsync(page);
                }
            }
        }

        public void Print(List<string> sitemapUrls)
        {
            Console.WriteLine("\nFounded by crawling\n");

            var ListsDistinct = urls.Except(sitemapUrls).ToList();

            Console.WriteLine(urls.Count);
            if(ListsDistinct.Count == 0)
            {
                Console.WriteLine("No links founded");
            }
            else
            {
                for (int i = 0; i < ListsDistinct.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {ListsDistinct[i]}");
                }
            }
            
        }

        public bool IsLinkValid(string link)
        {
            var Extensions = new List<string>
            {
                ".dox",".docx",".png",".bmp",
                ".jpg",".jpeg",".pdf",".xls",
                ".xlsx",".txt",".webp",".gif",
                ".mp4",".xml",".aif",".mp3",
                ".ogg",".wav","pkg",".rar",
                ".zip",".ico","#","?",":"
            };
            if(Extensions.FirstOrDefault(x=>link.Contains(x))!=null)
            {
                return true;
            }
            return false;
        }
    }
}
