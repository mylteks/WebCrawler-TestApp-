using Microsoft.EntityFrameworkCore;
using WebCrawlerDataBase.Models;

namespace WebCrawlerDataBase
{
    public class CrawlerDB
    {
        CrawlerContext _context;

        public CrawlerDB(CrawlerContext context)
        {
            _context = context;
        }

        public async void AddCrawlingResultAsync(RequestInfo model)
        {
            _context.RequestInfo.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task<RequestInfo> GetRequestInfoByIdAsync(int id)
        {
            return await _context.RequestInfo.Include(x => x.Results).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<RequestInfo> GetWebsitesList()
        {
            return _context.RequestInfo;
        }
    }
}
