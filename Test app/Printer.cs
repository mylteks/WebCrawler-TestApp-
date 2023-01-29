﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app
{
    internal class Printer
    {
        public void PrintFoundedLinks(List<string> crawlUrls, List<string> sitemapUrls)
        {
            var sitemapExcept = sitemapUrls.Except(crawlUrls).ToList();

            Console.WriteLine("\nUrls FOUNDED IN SITEMAP.XML but not founded after crawling : \n");

            if (sitemapExcept.Count == 0)
            {
                Console.WriteLine("No links founded");
                return;
            }

            for (int i = 0; i < sitemapExcept.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {sitemapExcept[i]}");
            }

            Console.WriteLine("\nFounded by crawling\n");

            var crawlExcept = crawlUrls.Except(sitemapUrls).ToList();

            if (crawlExcept.Count == 0)
            {
                Console.WriteLine("No links founded");
                return;
            }

            for (int i = 0; i < crawlExcept.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {crawlExcept[i]}");
            }
        }

        public void PrintTimingRes(int crawlCount,int sitemapCount,Dictionary<string,double> linksTiming)
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