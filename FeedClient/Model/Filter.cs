using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.Model
{
    public class Filter
    {
        private long? id;
        private string name;
        private string text;
        private User user;
        private List<Feed> feeds;

        public long? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Text { get => text; set => text = value; }
        public User User { get => user; set => user = value; }
        public List<Feed> Feeds { get => feeds; set => feeds = value; }
    }
}
