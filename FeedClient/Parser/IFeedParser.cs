using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient.Parser
{
    public interface IFeedParser
    {

        bool IsCompatible(XmlDocument document);

        string GetName(XmlDocument document);

        List<NewsItem> GetNews(Feed feed, XmlDocument document);

    }
}
