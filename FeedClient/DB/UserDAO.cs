using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    class UserDAO
    {

        public void Add(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = "INSERT INTO users(username, password, name) VALUES (:username, :password, :name)";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("username", user.Username));
                command.Parameters.Add(new SQLiteParameter("password", user.Password));
                command.Parameters.Add(new SQLiteParameter("name", user.Name));

                command.ExecuteNonQuery();

                user.Id = connection.LastInsertRowId;
            }
        }

        public void Update(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE users SET username = :username, password = :password, name = :name WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", user.Id));
                command.Parameters.Add(new SQLiteParameter("username", user.Username));
                command.Parameters.Add(new SQLiteParameter("password", user.Password));
                command.Parameters.Add(new SQLiteParameter("name", user.Name));

                command.ExecuteNonQuery();

                user.Id = connection.LastInsertRowId;
            }
        }

        public void Delete(User user)
        {
            Delete(user.Id.Value);
        }

        public void Delete(long id)
        {
            var connection = DataBase.GetConnection();

            string sql = "DELETE FROM users WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", id));

                command.ExecuteNonQuery();
            }
        }

        public User Login(string username, string password)
        {
            var connection = DataBase.GetConnection();

            string sql = "SELECT id, name FROM users WHERE username = :username AND password = :password";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("username", username));
                command.Parameters.Add(new SQLiteParameter("password", password));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Username = username,
                            Password = password,
                            Name = reader["name"].ToString()
                        };
                    }
                }
            }

            return null;
        }

    }
}
