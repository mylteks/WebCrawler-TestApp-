using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Logic.Models
{
    public class RequestInfoModel
    {
        public int Id { get; set; }
        public DateTime RequestTime { get; set; }
        public string WebsiteName { get; set; }
        public IEnumerable<RequestResultModel> Results { get; set; }
    }
}
