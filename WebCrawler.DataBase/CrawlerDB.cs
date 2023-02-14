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

        public async Task AddCrawlingResultAsync(RequestInfo model)
        {
            await _context.RequestInfo.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task<RequestInfo> GetRequestInfoByIdAsync(int id)
        {
            return await _context.RequestInfo.Include(x => x.Results).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyCollection<RequestInfo>> GetWebsitesListAsync()
        {
            return await _context.RequestInfo.ToListAsync();
        }
    }
}
