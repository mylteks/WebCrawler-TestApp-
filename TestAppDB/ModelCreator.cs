using TestAppDB.Models;

namespace TestAppDB
{
    public class ModelCreator
    {
        public RequestInfo GenerateRequestInfo(string url, List<string> crawledUrls, List<string> sitemapUrls, Dictionary<string, double> timingResult)
        {
            var results = GenerateRequestResult(crawledUrls, sitemapUrls, timingResult);

            return new RequestInfo
            {
                RequestTime = DateTime.Now,
                WebsiteName = url,
                Results = results
            };
        }

        public List<RequestResult> GenerateRequestResult(List<string> crawledUrls, List<string> sitemapUrls, Dictionary<string, double> timingResult)
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

    }
}
