using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCrawler.Logic;
using WebCrawler.Logic.Models;
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
            var performanceResult = await _crawlerService.GetPerformanceAsync(url);

            await _crawlerService.SaveRequestInfo(url, performanceResult.CrawledUrls, performanceResult.SitemapUrls, performanceResult.TimingResult);

            PerformanceModel model = new PerformanceModel
            {
                TimingResult = performanceResult.TimingResult,
                CrawledUrls = performanceResult.CrawledUrls,
                SitemapUrls = performanceResult.SitemapUrls
            };

            return  View(model);
        }

        public async Task<IActionResult> ShowResults()
        {
            var savedWebsites = _crawlerService.GetSavedWebsitesAsync();

            return View("ShowSavedData", savedWebsites);
        }

        public async Task<IActionResult> ShowUrlReport(int id)
        {
            var requestResult = await _crawlerService.GetRequestResultByIdAsync(id);

            return View("ShowUrlReport", requestResult);
        }
    }
}