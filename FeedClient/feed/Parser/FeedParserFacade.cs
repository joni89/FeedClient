using FeedClient.Feed.Model;
using FeedClient.Feed.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient.Feed.Parser
{
    class FeedParserFacade
    {
        private IFeedParser[] parsers = {
            new RssFeedParser(),
            new AtomFeedParser()
        };

        public List<NewsItem> GetNews(XmlDocument document)
        {
            return GetCompatibleReader(document).GetNews(document);
        }

        public string GetTitle(XmlDocument document)
        {
            return GetCompatibleReader(document).GetTitle(document);
        }

        private IFeedParser GetCompatibleReader(XmlDocument document)
        {
            foreach (var parser in parsers)
            {
                if (parser.IsCompatible(document))
                {
                    return parser;
                }
            }

            // TODO buscar una excepción mejor
            throw new Exception("No se ha encontrado un lector compatible con la fuente de noticias");
        }
    }
}
