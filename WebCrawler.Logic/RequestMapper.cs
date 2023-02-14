using WebCrawler.Logic.Models;
using WebCrawlerDataBase.Models;

namespace WebCrawlerLogic
{
    public class RequestMapper
    {
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

        public IEnumerable<RequestInfoModel> MapRequestInfo(IEnumerable<RequestInfo> requestInfos)
        {
            return requestInfos.Select(x => new RequestInfoModel
            {
                WebsiteName = x.WebsiteName,
                RequestTime = x.RequestTime,
                Id = x.Id,
            });
        }

        public IEnumerable<RequestResultModel> MapRequestResultById(RequestInfo requestInfo)
        {
            return requestInfo.Results.Select(x => new RequestResultModel
            {
                Id = x.Id,
                IsCrawl = x.IsCrawl,
                IsSitemap = x.IsSitemap,
                Timing = x.Timing,
                RequestInfoId = x.RequestInfoId,
                Url = x.Url,
            });
        }

    }
}
