using WebCrawlerDataBase;
using WebCrawlerLogic;

namespace WebCrawlerConsole
{

    public class App
    {
        private readonly PageCrawler _pageCrawler;
        private readonly SitemapLoader _sitemapLoader;
        private readonly TimingLinks _timingLinks;
        private readonly Printer _printer;
        private readonly ModelCreator _modelCreator;
        private readonly CrawlerDB _dbContext;

        public App(PageCrawler pageCrawler, SitemapLoader sitemapLoader, TimingLinks timingLinks,
                   Printer printer, ModelCreator creator, CrawlerDB dbContex)
        {
            _pageCrawler = pageCrawler;
            _sitemapLoader = sitemapLoader;
            _timingLinks = timingLinks;
            _printer = printer;
            _modelCreator = creator;
            _dbContext = dbContex;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Press any key to start, press Esc to exit");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Enter website url :");
                var url = Console.ReadLine();
                Console.WriteLine($"Entered urls is : {url}");

                var crawledLinks = await _pageCrawler.GetCrawlLinks(url);
                var sitemapLinks = _sitemapLoader.LoadXmlUrls(url);
                var timingResult = await _timingLinks.LinksTiming(crawledLinks, sitemapLinks);

                _printer.PrintFoundedLinks(crawledLinks, sitemapLinks);
                _printer.PrintTimingResult(timingResult);
                _printer.PrintFoundedCount(crawledLinks.Count, sitemapLinks.Count);

                _dbContext.AddCrawlingResult(_modelCreator.GenerateRequestInfo(url, crawledLinks, sitemapLinks, timingResult));

                Console.WriteLine("Press Esc to exit, enter new url to continue");
            }
        }
    }
}
