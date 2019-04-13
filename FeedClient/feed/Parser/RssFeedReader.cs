using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FeedClient.Feed.Model;

namespace FeedClient.Feed.Parser
{
    class RssFeedParser : IFeedParser
    {
        public bool IsCompatible(XmlDocument document)
        {
            return false;
        }

        public List<NewsItem> GetNews(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(XmlDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
