using Test_app;

Console.WriteLine("Press any key to start, press Esc to exit");
while (Console.ReadKey().Key != ConsoleKey.Escape)
{
    Console.WriteLine("Enter website url :");
    var url = Console.ReadLine();
    Console.WriteLine($"Entered urls is : {url}");

    var pageCrawler = new PageCrawler();
    var sitemapLoader = new SitemapLoader();
    var timingLinks = new TimingLinks();
    var print = new Printer();

    var crawledLinks = await pageCrawler.GetCrawlLinks(url);
    var sitemapLinks = sitemapLoader.LoadXmlUrls(url);
    var timingResult = await timingLinks.LinksTiming(crawledLinks, sitemapLinks);
    
    print.PrintFoundedLinks(crawledLinks, sitemapLinks);
    print.PrintTimingRes(crawledLinks.Count,sitemapLinks.Count,timingResult);

    Console.WriteLine("Press Esc to exit, enter new url to continue");
}
