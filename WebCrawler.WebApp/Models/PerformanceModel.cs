namespace WebCrawler.WebApp.Models
{
    public class PerformanceModel
    {
        public List<string> CrawledUrls { get; set; }
        public List<string> SitemapUrls { get; set; }
        public Dictionary<string,double> PerformanceResult { get; set; }
    }
}
