using FeedClient.Model;
using FeedClient.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient.Parser
{
    public class FeedParserFacade
    {
        private IFeedParser[] parsers = {
            new RssFeedParser(),
            new AtomFeedParser()
        };

        public List<NewsItem> GetNews(Feed feed, XmlDocument document)
        {
            return GetCompatibleReader(document).GetNews(feed, document);
        }

        public string GetName(XmlDocument document)
        {
            return GetCompatibleReader(document).GetName(document);
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
