using WebCrawler.Logic.Models;
using WebCrawlerDataBase.Models;

namespace WebCrawlerLogic
{
    public class RequestMapper
    {

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
