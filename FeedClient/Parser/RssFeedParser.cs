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
                var url = XmlParseUtils.FindFirstChildByTagName(item, "link").InnerText;
                var title = XmlParseUtils.FindFirstChildByTagName(item, "title").InnerText;
                var contents = XmlParseUtils.FindFirstChildByTagName(item, "description").InnerText;

                // Como la etiqueta <guid> es opcional en la especificación RSS 2.0, utilizamos
                // la URL de la noticia como identificador en caso de que el GUID no venga indicado
                var guidElement = XmlParseUtils.FindFirstChildByTagName(item, "guid");
                var guid = guidElement != null ? guidElement.InnerText : url;

                var datetimeElement = XmlParseUtils.FindFirstChildByTagName(item, "pubDate");
                var datetime = datetimeElement != null ? ParseDateTimeString(datetimeElement.InnerText) : (DateTime?)null;

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

        private DateTime ParseDateTimeString(string input)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-EN");
            try
            {
                return DateTime.ParseExact(input, "ddd, dd MMM yyyy HH:mm:ss zzz", cultureInfo);
            }
            catch (Exception)
            {
                return DateTime.ParseExact(input, "ddd, dd MMM yyyy HH:mm:ss Z", cultureInfo);
            }
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
