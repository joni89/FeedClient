using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FeedClient.Model;

namespace FeedClient.Parser
{
    public class RssFeedParser : IFeedParser
    {
        public bool IsCompatible(XmlDocument document)
        {
            var root = XmlParseUtils.GetRootNode(document);

            string rootName = root.Name;
            string version = root.Attributes.GetNamedItem("version")?.Value;

            return rootName == "rss" && version == "2.0";
        }

        public List<NewsItem> GetNews(Feed feed, XmlDocument document)
        {
            var root = XmlParseUtils.GetRootNode(document);
            var channel = XmlParseUtils.FindFirstChildByTagName(root, "channel");
            var items = XmlParseUtils.FindChildrenByTagName(channel, "item");

            var newsItems = new List<NewsItem>();

            foreach(var item in items)
            {
                var guid = XmlParseUtils.FindFirstChildByTagName(item, "guid").InnerText;
                var title = XmlParseUtils.FindFirstChildByTagName(item, "title").InnerText;
                var contents = XmlParseUtils.FindFirstChildByTagName(item, "description").InnerText;
                var datetime = DateTime.ParseExact(XmlParseUtils.FindFirstChildByTagName(item, "pubDate").InnerText, "ddd, dd MMM yyyy HH:mm:ss zzz", CultureInfo.GetCultureInfo("en-EN"));
                var url = XmlParseUtils.FindFirstChildByTagName(item, "link").InnerText;

                var newsItem = new NewsItem
                {
                    Guid = guid,
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
            var channel = XmlParseUtils.FindFirstChildByTagName(root, "channel");
            var title = XmlParseUtils.FindFirstChildByTagName(channel, "title");

            return title.InnerText;
        }
    }
}
