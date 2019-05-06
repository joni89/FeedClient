using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeedClient
{
    public class XmlParseUtils
    {

        public static XmlNode GetRootNode(XmlDocument document)
        {

            int childrenCount = document.ChildNodes.Count;

            foreach (XmlNode childNode in document.ChildNodes)
            {
                if (childNode.GetType() == typeof(XmlElement))
                {
                    return childNode;
                }
            }

            throw new Exception("No se ha encontrado el nodo raíz del documento");
        }

        public static List<XmlNode> FindChildrenByTagName(XmlNode node, string tagName)
        {

            int childrenCount = node.ChildNodes.Count;
            List<XmlNode> result = new List<XmlNode>();

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == tagName)
                {
                    result.Add(childNode);
                }
            }

            return result;
        }

        public static XmlNode FindFirstChildByTagName(XmlNode node, string tagName)
        {

            int childrenCount = node.ChildNodes.Count;

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == tagName)
                {
                    return childNode;
                }
            }

            return null;
        }
    }
}
