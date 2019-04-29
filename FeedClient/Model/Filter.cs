using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.Model
{
    class Filter
    {
        private long? id;
        private string name;
        private string text;
        private List<Feed> feeds;

        public long? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Text { get => text; set => text = value; }
        internal List<Feed> Feeds { get => feeds; set => feeds = value; }
    }
}
