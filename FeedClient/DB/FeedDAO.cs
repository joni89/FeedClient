using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    class FeedDAO
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

        public Feed FindAllByUser(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = "SELECT id, name, url FROM feeds WHERE user_id = :user_id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("user_id", user.Id.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Feed()
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Name = reader["name"].ToString(),
                            Url = reader["url"].ToString(),
                            User = user
                        };
                    }
                }
            }

            return null;
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
    }
}
