using Microsoft.EntityFrameworkCore;
using WebCrawlerDataBase.Models;

namespace WebCrawlerDataBase
{
    public class CrawlerContext : DbContext
    {

        public CrawlerContext(DbContextOptions<CrawlerContext> options)
             : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<RequestInfo> RequestInfo { get; set; }
        public virtual DbSet<RequestResult> RequestResult { get; set; }
    }
}
