using FeedClient.Feed.Model;
using FeedClient.Feed.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient.Feed
{
    class FeedParser
    {
        private FeedFetcher fetcher = new FeedFetcher();
        private FeedParserFacade parser = new FeedParserFacade();

        public List<NewsItem> GetNews(string url)
        {
            return parser.GetNews(fetcher.Fetch(url));
        }

        public string GetTitle(string url)
        {
            return parser.GetTitle(fetcher.Fetch(url));
        }
    }
}
