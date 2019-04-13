using FeedClient.Feed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient.Feed.Parser
{
    interface IFeedParser
    {

        bool IsCompatible(XmlDocument document);

        string GetTitle(XmlDocument document);

        List<NewsItem> GetNews(XmlDocument document);

    }
}
