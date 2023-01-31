using Test_app_DB;
using Test_app_DB.Models;

namespace TestAppDB
{
    public class CrawlerDB
    {
        CrawlerContext _context;

        public CrawlerDB()
        {
            _context = new CrawlerContext();
        }

        public async void AddCrawlingResult(RequestInfo model)
        {
            _context.RequestInfo.Add(model);

            await _context.SaveChangesAsync();
        }
    }
}
