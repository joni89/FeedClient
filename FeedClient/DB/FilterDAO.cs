using FeedClient.DB;
using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    public class FilterDAO
    {

        public void Add(Filter filter)
        {
            var connection = DataBase.GetConnection();

            string sql = "INSERT INTO filters(name, text, user_id) VALUES (:name, :text, :user_id)";

            var transaction = connection.BeginTransaction();

            try
            {

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("name", filter.Name));
                    command.Parameters.Add(new SQLiteParameter("text", filter.Text));
                    command.Parameters.Add(new SQLiteParameter("user_id", filter.User.Id));

                    command.ExecuteNonQuery();

                    filter.Id = connection.LastInsertRowId;
                }

                InsertFeedFilterRelationships(connection, filter);

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        private static void InsertFeedFilterRelationships(SQLiteConnection connection, Filter filter)
        {
            string sql = "INSERT INTO feed_filters(feed_id, filter_id) VALUES (:feed_id, :filter_id)";

            foreach (var feed in filter.Feeds)
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("feed_id", feed.Id));
                    command.Parameters.Add(new SQLiteParameter("filter_id", filter.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Filter> FindAllByUser(User user)
        {
            var connection = DataBase.GetConnection();

            string sql = @"
                SELECT
	                filters.id,
	                filters.name,
	                filters.text,
	                feeds.id AS feed_id,
	                feeds.name AS feed_name,
	                feeds.url AS feed_url
                FROM
	                filters
	                LEFT JOIN feed_filters
		                ON filters.id = feed_filters.filter_id
	                LEFT JOIN feeds
		                ON feed_filters.feed_id = feeds.id
                WHERE
	                filters.user_id = :user_id
                ORDER BY
	                filters.name,
	                filters.id
            ";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("user_id", user.Id.Value));

                using (var reader = command.ExecuteReader())
                {
                    var results = new List<Filter>();
                    var resultsById = new Dictionary<long, Filter>();

                    while (reader.Read())
                    {
                        var filterId = Convert.ToInt64(reader["id"]);
                        Filter filter;

                        if(resultsById.ContainsKey(filterId))
                        {
                            filter = resultsById[filterId];
                        } else
                        {
                            filter = RowReader.ReadFilter(reader, user, "");
                            results.Add(filter);
                            resultsById.Add(filterId, filter);
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("feed_id")))
                        {
                            filter.Feeds.Add(RowReader.ReadFeed(reader, user, "feed_"));
                        }
                    }

                    return results;
                }
            }
        }

        public void Update(Filter filter)
        {
            var connection = DataBase.GetConnection();

            string sqlInsert = "UPDATE filters SET name = :name, text = :text, user_id = :user_id WHERE id = :id";

            var transaction = connection.BeginTransaction();

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(sqlInsert, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("id", filter.Id));
                    command.Parameters.Add(new SQLiteParameter("name", filter.Name));
                    command.Parameters.Add(new SQLiteParameter("text", filter.Text));
                    command.Parameters.Add(new SQLiteParameter("user_id", filter.User.Id));

                    command.ExecuteNonQuery();
                }

                // Eliminamos las relaciones con los feeds y las insertamos de nuevo

                string sqlDeleteRelationships = "DELETE FROM feed_filters WHERE filter_id = :filter_id";

                using (SQLiteCommand command = new SQLiteCommand(sqlDeleteRelationships, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("filter_id", filter.Id));

                    command.ExecuteNonQuery();
                }

                InsertFeedFilterRelationships(connection, filter);

                transaction.Commit();

            } catch(Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        public void Delete(Filter filter)
        {
            Delete(filter.Id.Value);
        }

        public void Delete(long id)
        {
            var connection = DataBase.GetConnection();

            string sql = "DELETE FROM filters WHERE id = :id";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.Add(new SQLiteParameter("id", id));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(List<Filter> filters)
        {
            Delete(filters.Select(filter => filter.Id.Value).ToList());
        }

        public void Delete(List<long> ids)
        {
            var connection = DataBase.GetConnection();

            string parameterNames = string.Join(",", ids.Select((filter, index) => ":filter_id_" + index));

            string sql = "DELETE FROM filters WHERE id IN (" + parameterNames + ")";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                for (int i = 0; i < ids.Count; ++i)
                {
                    command.Parameters.Add(new SQLiteParameter("filter_id_" + i, ids[i]));
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
