using Microsoft.EntityFrameworkCore;
using Test_app_DB.Models;

namespace Test_app_DB
{
    public class CrawlerContext : DbContext
    {
        public CrawlerContext()
        {
            Database.Migrate();
        }

        public CrawlerContext(DbContextOptions<CrawlerContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("data source=.\\SQLEXPRESS;initial catalog=CrawlerDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        public virtual DbSet<RequestInfo> RequestInfo { get; set; }
        public virtual DbSet<RequestResult> RequestResult { get; set; }
    }
}
