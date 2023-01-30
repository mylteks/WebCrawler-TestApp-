using Microsoft.EntityFrameworkCore;
using Test_app_DB.Models;

namespace Test_app_DB
{
    public class CrawlerContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.\\SQLEXPRESS;Initial Catalog=CrawlerDb;Trusted_Connection=True;Encrypt=False");
        }

        public virtual DbSet<RequestInfo> RequestInfo { get; set; }
        public virtual DbSet<RequestResult> RequestResult { get; set; }
    }
}
