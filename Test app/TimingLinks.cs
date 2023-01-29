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
    }
}
