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
    class XmlFetcher
    {

        public XmlDocument Fetch(string url)
        {
            HttpWebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;

            try
            {
                WebRequest request = WebRequest.Create(url);

                response = (HttpWebResponse)request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);

                string contents = reader.ReadToEnd();

                XmlDocument document = new XmlDocument();
                document.LoadXml(contents);

                return document;
            }
            finally
            {
                reader?.Close();
                dataStream?.Close();
                response?.Close();
            }
        }

    }
}
