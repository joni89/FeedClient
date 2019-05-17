using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    public class NewsDAO
    {

        public void Add(NewsItem newsItem)
        {
            var connection = DataBase.GetConnection();

            string sql = "INSERT INTO news(guid, title, contents, datetime, url, feed, favorite, unread) VALUES (:guid, :title, :contents, :datetime, :url, :feed, :favorite, :unread)";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("guid", newsItem.Guid));
                command.Parameters.Add(new SQLiteParameter("title", newsItem.Title));
                command.Parameters.Add(new SQLiteParameter("contents", newsItem.Contents));
                command.Parameters.Add(new SQLiteParameter("datetime", newsItem.Datetime));
                command.Parameters.Add(new SQLiteParameter("url", newsItem.Url));
                command.Parameters.Add(new SQLiteParameter("feed_id", newsItem.Feed.Id));
                command.Parameters.Add(new SQLiteParameter("favorite", newsItem.Favorite));
                command.Parameters.Add(new SQLiteParameter("unread", newsItem.Unread));

                command.ExecuteNonQuery();

                newsItem.Id = connection.LastInsertRowId;
            }
        }

        public List<NewsItem> FindAllByUser(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = @"
                SELECT
                    news.id, news.guid, news.title, news.contents, news.datetime,
                    news.url, news.feed_id, news.favorite, news.unread,
                    feeds.name AS feed_name, feeds.url AS feed_url
                FROM
                    news
                    INNER JOIN feeds
                        ON news.feed_id = feeds.id
                WHERE
                    feeds.user_id = :user_id
                ORDER BY
                    news.datetime DESC
            ";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("user_id", user.Id.Value));

                using (var reader = command.ExecuteReader())
                {
                    var results = new List<NewsItem>();

                    while (reader.Read())
                    {
                        results.Add(RowReader.ReadNewsItem(reader, user, ""));
                    }

                    return results;
                }
            }
        }

        public List<NewsItem> FindAllByUserAndFilter(User user, Filter filter)
        {
            var connection = DataBase.GetConnection();

            var sql = @"
                SELECT
                    news.id, news.guid, news.title, news.contents, news.datetime,
                    news.url, news.feed_id, news.favorite, news.unread,
                    feeds.name AS feed_name, feeds.url AS feed_url
                FROM
                    news
                    INNER JOIN feeds
                        ON news.feed_id = feeds.i
                WHERE
                    feeds.user_id = :user_id
                    AND (
                        news.title LIKE :filterText
                        OR news.contents LIKE :filterText
                    )
                    AND news.feed_id IN (
            ";

            sql += string.Join(",", filter.Feeds.Select((feed, index) => ":feed_id_" + index));

            sql += @"
                    )
                ORDER BY
                    news.datetime DESC
            ";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("user_id", user.Id.Value));

                // TODO mejorar el filtro para que busque las palabras en cualquier orden
                command.Parameters.Add(new SQLiteParameter("filterText", "%" + filter.Text.Replace(' ', '%') + "%"));

                for (int i = 0; i < filter.Feeds.Count; ++i)
                {
                    command.Parameters.Add(new SQLiteParameter("feed_id_" + i, filter.Feeds[i].Id));
                }

                using (var reader = command.ExecuteReader())
                {
                    var results = new List<NewsItem>();

                    while (reader.Read())
                    {
                        results.Add(RowReader.ReadNewsItem(reader, user, ""));
                    }

                    return results;
                }
            }
        }

        public void MarkAsRead(NewsItem newsItem)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE news SET unread = :unread WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", newsItem.Id));
                command.Parameters.Add(new SQLiteParameter("unread", newsItem.Unread));

                command.ExecuteNonQuery();
            }
        }

        public void MarkAsFavorite(NewsItem newsItem)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE news SET favorite = :favorite WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", newsItem.Id));
                command.Parameters.Add(new SQLiteParameter("favorite", newsItem.Favorite));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(NewsItem newsItem)
        {
            Delete(newsItem.Id.Value);
        }

        public void Delete(long id)
        {
            var connection = DataBase.GetConnection();

            string sql = "DELETE FROM news WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", id));

                command.ExecuteNonQuery();
            }
        }
    }
}
