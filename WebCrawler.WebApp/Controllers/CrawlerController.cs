using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCrawler.Logic;
using WebCrawler.WebApp.Models;
using WebCrawlerLogic;

namespace WebCrawler.WebApp.Controllers
{
    public class CrawlerController : Controller
    {
        private readonly SitemapLoader _sitemap;
        private readonly PageCrawler _crawler;
        private readonly TimingLinks _timingLinks;
        private readonly CrawlerService _crawlerService;

        public CrawlerController(SitemapLoader sitemap, PageCrawler crawler, TimingLinks timingLinks, CrawlerService service)
        {
            _sitemap = sitemap;
            _crawler = crawler;
            _timingLinks = timingLinks;
            _crawlerService = service;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public  async Task<IActionResult> ShowPerformace(string url)
        {
            var sitemapLinks = _sitemap.LoadXmlUrls(url);
            var crawledLinks = await _crawler.GetCrawlLinks(url);
            var timingReport = await _timingLinks.LinksTiming(crawledLinks, sitemapLinks);

            _crawlerService.SaveRequestInfo(url, crawledLinks, sitemapLinks, timingReport);

            PerformanceModel model = new PerformanceModel
            {
                PerformanceResult = timingReport,
                CrawledUrls = crawledLinks,
                SitemapUrls = sitemapLinks
            };

            return  View(model);
        }

        public async Task<IActionResult> PrintDatabase()
        {
            return View("ShowSavedData",_crawlerService.GetSavedWebsites());
        }

        public async Task<IActionResult> ShowUrlReport(int id)
        {
            return View("ShowUrlReport",await _crawlerService.GetRequestResultById(id));
        }
    }
}