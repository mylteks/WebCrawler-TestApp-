﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawlerDataBase.Models;

namespace WebCrawler.Logic.Models
{
    public class RequestResultModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public double Timing { get; set; }
        public bool IsSitemap { get; set; }
        public bool IsCrawl { get; set; }
        public int RequestInfoId { get; set; }
    }
}
