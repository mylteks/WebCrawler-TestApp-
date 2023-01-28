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

    var crawledLinks = await pageCrawler.CrawlAsync(url);
    var sitemapLinks = sitemapLoader.LoadXmlUrls(url);

    // TO DO:
    // Create "Printer" class

    //pageCrawler.Print(sitemapLoader.SitemapUrls);
    //sitemapLoader.Print(pageCrawler.Urls);

    await timingLinks.LinksTiming(crawledLinks, sitemapLinks);
    //timingLinks.PrintTiming(crawledLinks.Count, sitemapLinks.Count);

    Console.WriteLine("Press Esc to exit, enter new url to continue");
}
