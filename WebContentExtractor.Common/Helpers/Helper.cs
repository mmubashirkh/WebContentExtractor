using HtmlAgilityPack;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebContentExtractor.Common
{
    public static class Helper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static HtmlDocument GetDocument(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                return doc;
            }
            catch(Exception ex)
            {
                logger.Error(ex.InnerException);
                throw new Exception(ex.Message);
            }
        }

        public static List<string> GetImageUrls(string html)
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                List<string> imageUrl = new List<string>();

                foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img"))
                {
                    string url = img.GetAttributeValue("src", null);
                    if (!string.IsNullOrEmpty(url) && url.StartsWith("https"))
                    {
                        imageUrl.Add(url);
                    }
                }

                return imageUrl;
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw new Exception("Data Not Found");
            }
        }

        public static int CountWords(string html)
        {
            string[] words = html.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static List<KeyValuePair<string, int>> GetTopWords(string html, int count)
        {
            string[] words = html.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
            return wordCounts.OrderByDescending(x => x.Value).Take(count).ToList();
        }

        public static string DataWithoutHtmlTags(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var words = new List<string>();

            foreach (var item in doc.DocumentNode.DescendantsAndSelf())
            {
                if (item.NodeType == HtmlNodeType.Text && Convert.ToString(item.ParentNode.Name) != "script" && Convert.ToString(item.ParentNode.Name) != "style")
                {
                    if (item.InnerText.Trim() != "")
                    {
                        words.Add(item.InnerText.Trim());
                    }
                }
            }
            var wordString = String.Join(" ", words);
            wordString = Regex.Replace(wordString, @"[^a-zA-Z\._']", " ");
            return wordString;
        }
    }
}
