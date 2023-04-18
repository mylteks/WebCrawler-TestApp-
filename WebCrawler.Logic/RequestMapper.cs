using WebCrawler.Logic.Models;
using WebCrawlerDataBase.Models;

namespace WebCrawlerLogic
{
    public class RequestMapper
    {
        public RequestInfoModel MapRequestInfo(RequestInfo requestInfo)
        {
            return new RequestInfoModel
            {
                WebsiteName = requestInfo.WebsiteName,
                RequestTime = requestInfo.RequestTime,
                Results = MapRequestResultList(requestInfo.Results)
            };
        }

        public IEnumerable<RequestInfoModel> MapRequestInfoList(IEnumerable<RequestInfo> requestInfos)
        {
            return requestInfos.Select(x => new RequestInfoModel
            {
                WebsiteName = x.WebsiteName,
                RequestTime = x.RequestTime,
                Id = x.Id,
            });
        }

        public IEnumerable<RequestInfo> MapRequestInfoModelList(IEnumerable<RequestInfoModel> requestInfos)
        {
            return requestInfos.Select(x => new RequestInfo
            {
                WebsiteName = x.WebsiteName,
                RequestTime = x.RequestTime,
                Id = x.Id,
            });
        }

        public RequestInfo MapRequestInfoModel(RequestInfoModel requestInfo)
        {
            return new RequestInfo
            {
                WebsiteName = requestInfo.WebsiteName,
                RequestTime = requestInfo.RequestTime,
                Results = MapRequestResultModelList(requestInfo.Results).ToList()
            };
        }

        public IEnumerable<RequestResultModel> MapRequestResultList(IEnumerable<RequestResult> requestInfo)
        {
            return requestInfo.Select(x => new RequestResultModel
            {
                Id = x.Id,
                IsCrawl = x.IsCrawl,
                IsSitemap = x.IsSitemap,
                Timing = x.Timing,
                RequestInfoId = x.RequestInfoId,
                Url = x.Url,
            });
        }
        public IEnumerable<RequestResult> MapRequestResultModelList(IEnumerable<RequestResultModel> requestInfo)
        {
            return requestInfo.Select(x => new RequestResult
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
