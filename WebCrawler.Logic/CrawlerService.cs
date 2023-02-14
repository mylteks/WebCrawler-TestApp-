using WebCrawlerDataBase;
using WebCrawler.Logic.Models;

namespace WebCrawlerLogic
{
    public class CrawlerService
    {
        private readonly CrawlerDB _dbContext;
        private readonly RequestMapper _requestMapper;

        public CrawlerService(CrawlerDB dbContext, RequestMapper requestMapper)
        {
            _requestMapper = requestMapper;
            _dbContext = dbContext;
        }

        public IEnumerable<RequestInfoModel> GetSavedWebsites()
        {
            return _requestMapper.MapRequestInfo(_dbContext.GetWebsitesList());
        }

        public async Task<IEnumerable<RequestResultModel>> GetRequestResultById(int id)
        {
            return _requestMapper.MapRequestResultById(await _dbContext.GetRequestInfoByIdAsync(id));
        }

        public void SaveRequestInfo(string url, IEnumerable<string> crawledUrls, IEnumerable<string> sitemapUrls,
            Dictionary<string, double> timingResult)
        {
            _dbContext.AddCrawlingResultAsync(_requestMapper.GenerateRequestInfo(url, crawledUrls, sitemapUrls, timingResult));
        }
    }
}
