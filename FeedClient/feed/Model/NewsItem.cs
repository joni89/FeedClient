using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.Feed.Model
{
    class NewsItem
    {

        private long id;
        private string title;
        private string contents;
        private DateTime datetime;
        private string url;
        private Feed feed;
        private bool favorite;
        private bool unread;

        public long Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Contents { get => contents; set => contents = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }
        public string Url { get => url; set => url = value; }
        public bool Favorite { get => favorite; set => favorite = value; }
        public bool Unread { get => unread; set => unread = value; }
        internal Feed Feed { get => feed; set => feed = value; }
    }
}
