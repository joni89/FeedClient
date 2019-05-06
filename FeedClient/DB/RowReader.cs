using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using FeedClient.Model;

namespace FeedClient.DB
{
    public class RowReader
    {
        public static Feed ReadFeed(SQLiteDataReader reader, User user, string prefix)
        {
            return new Feed()
            {
                Id = Convert.ToInt64(reader[prefix + "id"]),
                Name = reader[prefix + "name"].ToString(),
                Url = reader[prefix + "url"].ToString(),
                User = user
            };
        }

        public static NewsItem ReadNewsItem(SQLiteDataReader reader, User user, string prefix)
        {
            return new NewsItem()
            {
                Id = Convert.ToInt64(reader[prefix + "id"]),
                Guid = reader[prefix + "guid"].ToString(),
                Title = reader[prefix + "title"].ToString(),
                Contents = reader[prefix + "contents"].ToString(),
                Datetime = Convert.ToDateTime(reader[prefix + "datetime"]),
                Url = reader[prefix + "url"].ToString(),
                Feed = ReadFeed(reader, user, prefix + "feed_"),
                Favorite = Convert.ToBoolean(reader[prefix + "favorite"]),
                Unread = Convert.ToBoolean(reader[prefix + "unread"])
            };
        }

        public static Filter ReadFilter(SQLiteDataReader reader, User user, string prefix)
        {
            return new Filter()
            {
                Id = Convert.ToInt64(reader[prefix + "id"]),
                Name = reader[prefix + "name"].ToString(),
                Text = reader[prefix + "text"].ToString(),
                User = user,
                Feeds = new List<Feed>()
            };
        }
    }
}
