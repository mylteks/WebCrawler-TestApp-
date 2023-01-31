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

        public async void AddCrawlingResult(RequestInfo model)
        {
            _context.RequestInfo.Add(model);

            await _context.SaveChangesAsync();
        }
    }
}
