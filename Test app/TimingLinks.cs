using System.Diagnostics;
using System.Net;

namespace Test_app
{
    internal class TimingLinks
    {
        public async Task<Dictionary<string, double>> LinksTiming(List<string> crawlLinks, List<string> sitemap)
        {
            var linksTiming = new Dictionary<string, double>();
            var linksUnion = crawlLinks.Union(sitemap).ToList();

            foreach (string link in linksUnion)
            {
                var request = WebRequest.Create(link);
                var sw = Stopwatch.StartNew();

                try
                {
                    WebResponse response = await request.GetResponseAsync();
                    sw.Stop();
                }
                catch (Exception ex) { }
                finally
                {
                    linksTiming.Add(link, sw.ElapsedMilliseconds);
                }
            }

            return linksTiming;
        }

        // TO DO:
        // Create "Printer" class

        //public void PrintTiming(int crawlCount, int sitemapCount)
        // {
        //     var sortedLinks = linksTiming.OrderBy(x => x.Value);
        //     Console.WriteLine("\nTiming report :");
        //     for (int i = 0; i < sortedLinks.Count(); i++)
        //     {
        //         Console.WriteLine($"[{i}]" + sortedLinks.ElementAt(i).Key + "  " + sortedLinks.ElementAt(i).Value + "ms.");
        //     }
        //     Console.WriteLine($"\nLinks founded in sitemap.xml : {sitemapCount}");
        //     Console.WriteLine($"Links founded by crawling : {crawlCount}");
        // }
    }
}
