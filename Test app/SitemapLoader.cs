using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test_app
{
    internal class SitemapLoader
    {
        public List<string> SitemapUrls { get; set; }
        string url;
        public SitemapLoader()
        {
            SitemapUrls = new List<string>();
        }

        public SitemapLoader(string url)
        {
            SitemapUrls = new List<string>();
            this.url = url;
        }

        public List<string> LoadXmlUrls(List<string> crawlUrls)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url + "sitemap.xml");
            XmlElement? root = doc.DocumentElement;

            foreach (XmlElement el in root)
            {
                XmlNodeList nodes = el.ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    if (node.Name == "loc")
                    {
                        var value = node.InnerText.Contains(url) ?
                        node.InnerText :
                        url.Substring(0, url.Length - 1) + node.InnerText;
                        SitemapUrls.Add(value);
                    }
                }
            }
            return SitemapUrls;

        }
        public void Print(List<string> crawlUrls)
        {
            var SitemapExcept = SitemapUrls.Except(crawlUrls).ToList();

            Console.WriteLine("\nUrls FOUNDED IN SITEMAP.XML but not founded after crawling : \n");

            for (int i = 0; i < SitemapExcept.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {SitemapExcept[i]}");
            }
        }
    }
}
