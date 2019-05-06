using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using FeedClient.Model;

namespace FeedClient.Parser
{
    public class AtomFeedParser : IFeedParser
    {
        public bool IsCompatible(XmlDocument document)
        {
            var root = XmlParseUtils.GetRootNode(document);

            string rootName = root.Name;
            string xmlNamespace = root.Attributes.GetNamedItem("xmlns")?.Value;

            return rootName == "feed" && xmlNamespace == "http://www.w3.org/2005/Atom";
        }

        public List<NewsItem> GetNews(Feed feed, XmlDocument document)
        {
            var root = XmlParseUtils.GetRootNode(document);
            var entries = XmlParseUtils.FindChildrenByTagName(root, "entry");

            var newsItems = new List<NewsItem>();

            foreach (var entry in entries)
            {
                var id = XmlParseUtils.FindFirstChildByTagName(entry, "id").InnerText;
                var title = XmlParseUtils.FindFirstChildByTagName(entry, "title").InnerText;
                var contents = XmlParseUtils.FindFirstChildByTagName(entry, "summary").InnerText;
                var datetime = DateTime.ParseExact(XmlParseUtils.FindFirstChildByTagName(entry, "updated").InnerText, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.GetCultureInfo("en-EN"));
                var url = XmlParseUtils.FindFirstChildByTagName(entry, "link").Attributes.GetNamedItem("href").Value;

                var newsItem = new NewsItem
                {
                    Guid = id,
                    Title = title,
                    Contents = contents,
                    Datetime = datetime,
                    Url = url,
                    Feed = feed,
                    Favorite = false,
                    Unread = true
                };

                newsItems.Add(newsItem);
            }

            return newsItems;
        }

        public string GetName(XmlDocument document)
        {
            var root = XmlParseUtils.GetRootNode(document);
            var title = XmlParseUtils.FindFirstChildByTagName(root, "title");

            return title.InnerText;
        }
    }
}
