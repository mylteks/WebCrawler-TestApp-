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
            return _requestMapper.MapRequestResultList(await _dbContext.GetRequestInfoByIdAsync(id));
        }

        public async Task SaveRequestInfo(RequestInfoModel requestInfo)
        {
           await _dbContext.AddCrawlingResultAsync(_requestMapper.MapRequestInfo(requestInfo));
        }

        public async Task<RequestInfoModel> GetPerformanceAsync(string url)
        {
            var crawledLinks = await _pageCrawler.GetCrawlLinksAsync(url);
            var sitemapLinks = _sitemapLoader.LoadXmlUrls(url);
            var timings = await _timingLinks.LinksTiming(crawledLinks, sitemapLinks);

            return new RequestInfoModel
            {
                WebsiteName = url,
                RequestTime = DateTime.UtcNow,
                Results = timings.Select(timingsPair => new RequestResultModel
                {
                    Timing = timingsPair.Value,
                    Url = timingsPair.Key,
                    IsCrawl = crawledLinks.Contains(timingsPair.Key),
                    IsSitemap = sitemapLinks.Contains(timingsPair.Key)
                })
            };
        }
    }
}
