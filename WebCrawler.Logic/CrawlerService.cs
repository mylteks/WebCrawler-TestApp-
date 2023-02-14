using WebCrawlerDataBase;
using WebCrawler.Logic.Models;
using WebCrawlerDataBase.Models;

namespace WebCrawlerLogic
{
    public class CrawlerService
    {
        private readonly CrawlerDB _dbContext;
        private readonly RequestMapper _requestMapper;
        private readonly PageCrawler _pageCrawler;
        private readonly SitemapLoader _sitemapLoader;
        private readonly TimingLinks _timingLinks;

        public CrawlerService(CrawlerDB dbContext, RequestMapper requestMapper, PageCrawler pageCrawler,
            SitemapLoader sitemapLoader, TimingLinks timingLinks)
        {
            _requestMapper = requestMapper;
            _dbContext = dbContext;
            _pageCrawler = pageCrawler;
            _sitemapLoader = sitemapLoader;
            _timingLinks = timingLinks;
        }

        public async Task<IEnumerable<RequestInfoModel>> GetSavedWebsitesAsync()
        {
            return _requestMapper.MapRequestInfo(await _dbContext.GetWebsitesListAsync());
        }

        public async Task<IEnumerable<RequestResultModel>> GetRequestResultByIdAsync(int id)
        {
            return _requestMapper.MapRequestResultById(await _dbContext.GetRequestInfoByIdAsync(id));
        }

        public async Task SaveRequestInfo(string url, IEnumerable<string> crawledUrls, IEnumerable<string> sitemapUrls,
            Dictionary<string, double> timingResult)
        {
           await _dbContext.AddCrawlingResultAsync(GenerateRequestInfo(url, crawledUrls, sitemapUrls, timingResult));
        }

        public RequestInfo GenerateRequestInfo(string url, IEnumerable<string> crawledUrls, IEnumerable<string> sitemapUrls, Dictionary<string, double> timingResult)
        {
            return new RequestInfo
            {
                RequestTime = DateTime.Now,
                WebsiteName = url,
                Results = GenerateRequestResult(crawledUrls, sitemapUrls, timingResult).ToList()
            };
        }

        public IEnumerable<RequestResult> GenerateRequestResult(IEnumerable<string> crawledUrls, IEnumerable<string> sitemapUrls, Dictionary<string, double> timingResult)
        {
            var result = new List<RequestResult>();

            foreach (var pair in timingResult)
            {
                result.Add(new RequestResult
                {
                    Timing = pair.Value,
                    Url = pair.Key,
                    IsCrawl = crawledUrls.Contains(pair.Key),
                    IsSitemap = sitemapUrls.Contains(pair.Key)
                });
            }
            return result;
        }

        public async Task<PerformanceModel> GetPerformanceAsync(string url)
        {
            var crawledLinks = await _pageCrawler.GetCrawlLinksAsync(url);
            var sitemapLinks = _sitemapLoader.LoadXmlUrls(url);

            return new PerformanceModel
            {
                CrawledUrls = crawledLinks,
                SitemapUrls = sitemapLinks,
                TimingResult = await _timingLinks.LinksTiming(crawledLinks, sitemapLinks)
            };
        }
    }
}
