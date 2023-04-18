using WebCrawlerLogic;

namespace WebCrawlerConsole
{

    public class App
    {
        private readonly PageCrawler _pageCrawler;
        private readonly SitemapLoader _sitemapLoader;
        private readonly TimingLinks _timingLinks;
        private readonly Printer _printer;
        private readonly CrawlerService _crawlerService;

        public App(PageCrawler pageCrawler, SitemapLoader sitemapLoader, TimingLinks timingLinks,
                   Printer printer, CrawlerService crawlerService)
        {
            _pageCrawler = pageCrawler;
            _sitemapLoader = sitemapLoader;
            _timingLinks = timingLinks;
            _printer = printer;
            _crawlerService = crawlerService;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Press any key to start, press Esc to exit");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Enter website url :");
                var url = Console.ReadLine();
                Console.WriteLine($"Entered urls is : {url}");

                var performanceResult = await _crawlerService.TestPerformanceAsync(url);

                _printer.PrintPerformanceResult(performanceResult);

                await _crawlerService.SaveRequestInfo(url, performanceResult.CrawledUrls, performanceResult.SitemapUrls, performanceResult.TimingResult);

                Console.WriteLine("Press Esc to exit, enter new url to continue");
            }
        }
    }
}
