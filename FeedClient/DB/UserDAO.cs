using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    public class UserDAO
    {

        public void Add(User user, string password)
        {
            var connection = DataBase.GetConnection();

            string sql = "INSERT INTO users(username, password, name) VALUES (:username, :password, :name)";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("username", user.Username));
                command.Parameters.Add(new SQLiteParameter("password", HashUtils.ComputeHash(password)));
                command.Parameters.Add(new SQLiteParameter("name", user.Name));

                command.ExecuteNonQuery();

                user.Id = connection.LastInsertRowId;
            }
        }

        public void Update(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE users SET username = :username, name = :name WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", user.Id));
                command.Parameters.Add(new SQLiteParameter("username", user.Username));
                command.Parameters.Add(new SQLiteParameter("name", user.Name));

                command.ExecuteNonQuery();

                user.Id = connection.LastInsertRowId;
            }
        }

        public void UpdatePassword(User user, string password)
        {
            var connection = DataBase.GetConnection();

            string sql = "UPDATE users SET password = :password WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", user.Id));
                command.Parameters.Add(new SQLiteParameter("password", HashUtils.ComputeHash(password)));

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
                command.Parameters.Add(new SQLiteParameter("password", HashUtils.ComputeHash(password)));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Username = username,
                            Name = reader["name"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public bool CheckUsernameExists(string username)
        {
            var connection = DataBase.GetConnection();

            string sql = "SELECT id FROM users WHERE username = :username";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("username", username));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
