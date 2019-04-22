using System;
using System.Collections.Generic;
using System.Xml;
using FeedClient.Feed.Model;

namespace FeedClient.Feed.Parser
{
    class AtomFeedParser : IFeedParser
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
