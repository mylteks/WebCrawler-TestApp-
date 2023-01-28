using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test_app
{
    internal class TimingLinks
    {
        List<string> linksUnion;
        Dictionary<string,double> linksTiming;
        public TimingLinks()
        {
            linksUnion = new List<string>();
            linksTiming = new Dictionary<string, double>();
        }

        public void LinksTiming(List<string> crawlLinks,List<string> sitemap)
        {
            linksUnion = crawlLinks.Union(sitemap).ToList();
            foreach (string link in linksUnion)
            {
                WebRequest request = WebRequest.Create(link);
                Stopwatch sw = Stopwatch.StartNew();
                try
                {
                    WebResponse response = request.GetResponse();
                    sw.Stop();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    linksTiming.Add(link, sw.ElapsedMilliseconds);
                }
            }
        }

       public void PrintTiming(int crawlCount,int sitemapCount)
        {
            var sortedLinks = linksTiming.OrderBy(x => x.Value);
            Console.WriteLine("\nTiming report :");
            for (int i = 0; i < sortedLinks.Count(); i++)
            {
                Console.WriteLine($"[{i}]" + sortedLinks.ElementAt(i).Key + "  " + sortedLinks.ElementAt(i).Value + "ms.");
            }
            Console.WriteLine($"\nLinks founded in sitemap.xml : {sitemapCount}");
            Console.WriteLine($"Links founded by crawling : {crawlCount}");
        }
    }
}
