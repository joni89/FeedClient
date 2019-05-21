using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    public class FeedDAO
    {

        public void Add(Feed feed)
        {
            var connection = DataBase.GetConnection();

            string sql = "INSERT INTO feeds(name, url, user_id) VALUES (:name, :url, :user_id)";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("name", feed.Name));
                command.Parameters.Add(new SQLiteParameter("url", feed.Url));
                command.Parameters.Add(new SQLiteParameter("user_id", feed.User.Id));

                command.ExecuteNonQuery();

                feed.Id = connection.LastInsertRowId;
            }
        }

        public List<Feed> FindAllByUser(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = "SELECT id, name, url FROM feeds WHERE user_id = :user_id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("user_id", user.Id.Value));

                using (var reader = command.ExecuteReader())
                {
                    var results = new List<Feed>();

                    while (reader.Read())
                    {
                        results.Add(RowReader.ReadFeed(reader, user, ""));
                    }

                    return results;
                }
            }
        }

        public void Update(Feed feed)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE feeds SET name = :name, url = :url, user_id = :user_id WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", feed.Id));
                command.Parameters.Add(new SQLiteParameter("name", feed.Name));
                command.Parameters.Add(new SQLiteParameter("url", feed.Url));
                command.Parameters.Add(new SQLiteParameter("user_id", feed.User.Id));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Feed feed)
        {
            Delete(feed.Id.Value);
        }

        public void Delete(long id)
        {
            var connection = DataBase.GetConnection();

            string sql = "DELETE FROM feeds WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", id));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(List<Feed> feeds)
        {
            Delete(feeds.Select(feed => feed.Id.Value).ToList());
        }

        public void Delete(List<long> ids)
        {
            var connection = DataBase.GetConnection();

            string parameterNames = string.Join(",", ids.Select((feed, index) => ":feed_id_" + index));

            string sql = "DELETE FROM feeds WHERE id IN (" + parameterNames  + ")";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                for (int i = 0; i < ids.Count; ++i)
                {
                    command.Parameters.Add(new SQLiteParameter("feed_id_" + i, ids[i]));
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
