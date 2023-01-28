
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Diagnostics;
using System.Net;
using System.Xml;
using Test_app;

Console.WriteLine("Press any key to start, press Esc to exit");
while (Console.ReadKey().Key!=ConsoleKey.Escape)
{
    Console.WriteLine("Enter website url :");
    var url = Console.ReadLine();
    Console.WriteLine($"Entered urls is : {url}");
    PageCrawler pageCrawler = new PageCrawler(url);
    SitemapLoader sitemapLoader = new SitemapLoader(url);
    TimingLinks timingLinks = new TimingLinks();
    await pageCrawler.CrawlAsync(url);
    sitemapLoader.LoadXmlUrls(pageCrawler.urls);
    pageCrawler.Print(sitemapLoader.SitemapUrls);
    sitemapLoader.Print(pageCrawler.urls);
    timingLinks.LinksTiming(pageCrawler.urls, sitemapLoader.SitemapUrls);
    timingLinks.PrintTiming(pageCrawler.urls.Count, sitemapLoader.SitemapUrls.Count);
    Console.WriteLine("Press Esc to exit, enter new url to continue");
}



//var tmp3 = xmlFile.Union(visitedPages).ToList();

//Dictionary<string, double> dict = new Dictionary<string, double>();

//foreach (string link in tmp3)
//{
//    WebRequest request = WebRequest.Create(link);
//    Stopwatch sw = Stopwatch.StartNew();
//    try
//    {
//        WebResponse response = request.GetResponse();
//        sw.Stop();
//    }
//    catch (Exception ex)
//    {

//    }
//    finally
//    {
//        dict.Add(link, sw.ElapsedMilliseconds);
//    }

//}

//var tmp4 = dict.OrderBy(x => x.Value);

//Console.WriteLine("\nTiming report :");
//var c = 0;
//foreach (var item in tmp4)
//{
//    Console.WriteLine($"[{++c}]" + item.Key + "  " + item.Value + "ms.");
//}
//Console.WriteLine($"\nLinks founded in sitemap.xml : {xmlFile.Count}");
//Console.WriteLine($"Links founded by crawling : {visitedPages.Count}");