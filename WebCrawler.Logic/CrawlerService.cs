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
            return _requestMapper.MapRequestInfoList(await _dbContext.GetWebsitesListAsync());
        }

        public async Task<IEnumerable<RequestResultModel>> GetRequestResultByIdAsync(int id)
        {
            var requestResults = await _dbContext.GetRequestInfoByIdAsync(id);
            return _requestMapper.MapRequestResultList(requestResults.Results);
        }

        public async Task SaveRequestInfo(RequestInfoModel requestInfo)
        {
           await _dbContext.AddCrawlingResultAsync(_requestMapper.MapRequestInfoModel(requestInfo));
        }

        public async Task<RequestInfoModel> TestPerformanceAsync(string url)
        {
            var crawledLinks = await _pageCrawler.GetCrawlLinksAsync(url);
            var sitemapLinks = _sitemapLoader.LoadXmlUrls(url);
            var timingResult = await _timingLinks.LinksTiming(crawledLinks, sitemapLinks);

            var requestResult = new List<RequestResultModel>();

            foreach (var pair in timingResult)
            {
                requestResult.Add(new RequestResultModel
                {
                    Timing = pair.Value,
                    Url = pair.Key,
                    IsCrawl = crawledLinks.Contains(pair.Key),
                    IsSitemap = sitemapLinks.Contains(pair.Key)
                });
            }

            var requestInfoResult = new RequestInfoModel
            {
                RequestTime = DateTime.Now,
                WebsiteName = url,
                Results = requestResult
            };

            return requestInfoResult;
        }
    }
}
