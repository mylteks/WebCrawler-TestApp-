using System.Xml;

namespace Test_app
{
    internal class SitemapLoader
    {
        public List<string> LoadXmlUrls(string url)
        {
            var urls = new List<string>();

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

                        urls.Add(value);
                    }
                }
            }

            return urls;
        }
    }
}
