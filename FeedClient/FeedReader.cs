﻿using FeedClient.Model;
using FeedClient.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient
{
    public class FeedReader
    {
        private XmlFetcher fetcher = new XmlFetcher();
        private FeedParserFacade parser = new FeedParserFacade();

        public List<NewsItem> GetNews(Feed feed) => parser.GetNews(feed, fetcher.Fetch(feed.Url));

        public string GetName(string feedUrl) => parser.GetName(fetcher.Fetch(feedUrl));
    }
}
