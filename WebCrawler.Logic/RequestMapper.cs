using WebCrawler.Logic.Models;
using WebCrawlerDataBase.Models;

namespace WebCrawlerLogic
{
    public class RequestMapper
    {

        public IEnumerable<RequestInfoModel> MapRequestInfoModelList(IEnumerable<RequestInfo> requestInfos)
        {
            return requestInfos.Select(x => new RequestInfoModel
            {
                WebsiteName = x.WebsiteName,
                RequestTime = x.RequestTime,
                Id = x.Id,
            });
        }

        public IEnumerable<RequestResultModel> MapRequestResultModelList(RequestInfo requestInfo)
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

        public RequestInfo MapRequestInfo(RequestInfoModel requestInfos)
        {
            return new RequestInfo
            {
                WebsiteName = requestInfos.WebsiteName,
                RequestTime = requestInfos.RequestTime,
                Id = requestInfos.Id,
            };
        }

        public IEnumerable<RequestInfo> MapRequestInfoList(IEnumerable<RequestInfoModel> requestInfos)
        {
            return requestInfos.Select(x => new RequestInfo
            {
                WebsiteName = x.WebsiteName,
                RequestTime = x.RequestTime,
                Id = x.Id,
            });
        }

        public IEnumerable<RequestResult> MapRequestResult(RequestInfoModel requestInfo)
        {
            return requestInfo.Results.Select(x => new RequestResult
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
