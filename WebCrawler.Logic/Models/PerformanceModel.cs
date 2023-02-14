using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Logic.Models
{
    public class PerformanceModel
    {
        public IEnumerable<string> CrawledUrls { get; set; }
        public IEnumerable<string> SitemapUrls { get; set; }
        public Dictionary<string, double> TimingResult { get; set; }
    }
}
