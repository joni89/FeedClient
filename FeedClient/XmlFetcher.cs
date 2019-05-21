using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient
{
    public class XmlFetcher
    {

        public XmlDocument Fetch(string url)
        {
            WebRequest request = WebRequest.Create(url);

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream, Encoding.GetEncoding(response.CharacterSet)))
                    {
                        string contents = reader.ReadToEnd();

                        XmlDocument document = new XmlDocument();
                        document.LoadXml(contents);

                        return document;
                    }
                }
            }
        }
    }
}
