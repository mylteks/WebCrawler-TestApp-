using System.Diagnostics;

namespace Test_app
{
    internal class TimingLinks
    {
        public async Task<Dictionary<string, double>> LinksTiming(List<string> crawlLinks, List<string> sitemap)
        {
            var linksTiming = new Dictionary<string, double>();
            var linksUnion = crawlLinks.Union(sitemap).ToList();
            var loader = new PageLoader();

            foreach (string link in linksUnion)
            {
                var sw = Stopwatch.StartNew();
                await loader.LoadPage(link);
                sw.Stop();

                linksTiming.Add(link, sw.ElapsedMilliseconds);
            }

            return linksTiming;
        }
    }
}
