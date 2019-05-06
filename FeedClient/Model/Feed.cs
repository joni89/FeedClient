using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.Model
{
    public class Feed
    {

        private long? id;
        private string name;
        private string url;
        private User user;

        public long? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Url { get => url; set => url = value; }
        internal User User { get => user; set => user = value; }
    }
}
