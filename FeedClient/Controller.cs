using FeedClient.DB;
using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedClient
{
    public class Controller
    {

        private readonly FeedReader feedReader = new FeedReader();
        private readonly UserDAO userDAO = new UserDAO();
        private readonly FeedDAO feedDAO = new FeedDAO();
        private readonly NewsDAO newsDAO = new NewsDAO();
        private readonly FilterDAO filterDAO = new FilterDAO();

        private User user;

        public User User { get => user; }

        public bool Login(string username, string password)
        {
            try
            {
                user = userDAO.Login(username, password);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña no válidos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckUsernameExists(string username)
        {
            return userDAO.CheckUsernameExists(username);
        }

        public void RegisterUser(string name, string username, string password)
        {
            User user = new User()
            {
                Name = name,
                Username = username
            };

            userDAO.Add(user, password);
        }

        public List<Feed> FindUserFeeds()
        {
            try
            {
                return feedDAO.FindAllByUser(user);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error consultando las fuentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Feed>();
            }
        }

        public string GetFeedName(string feedUrl)
        {
            return feedReader.GetName(feedUrl);
        }

        public void ReadNewsFromFeeds()
        {
            List<Feed> feeds = feedDAO.FindAllByUser(user);

            if(feeds.Count == 0)
            {
                return;
            }

            List<Feed> errorFeeds = new List<Feed>();

            List<NewsItem> newsItems = feeds.SelectMany(feed =>
            {
                try
                {
                    return feedReader.GetNews(feed);
                } catch(Exception)
                {
                    errorFeeds.Add(feed);
                    return new List<NewsItem>();
                }
            }).ToList();

            if(errorFeeds.Count > 0)
            {
                string feedNames = string.Join(", ", errorFeeds.Select(feed => feed.Name));
                MessageBox.Show("Ha ocurrido un error leyendo las noticias de las siguientes fuentes: " + feedNames, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(newsItems.Count == 0)
            {
                return;
            }

            Dictionary<long, HashSet<string>> newsItemGuidsByFeed = newsDAO.FindExistingNewsItemGuidsGroupedByFeed(user);

            foreach (NewsItem newsItem in newsItems)
            {

                long feedId = newsItem.Feed.Id.Value;
                string guid = newsItem.Guid;

                // Si no hay noticias de este feed, o bien las hay pero esta no se encuentra entre ellas,
                // insertamos dicha noticia en base de datos (es una noticia nueva).
                if (!newsItemGuidsByFeed.ContainsKey(feedId) || !newsItemGuidsByFeed[feedId].Contains(guid))
                {
                    newsDAO.Add(newsItem);
                }
            }
        }

        public List<NewsItem> FindUserNews()
        {
            return newsDAO.FindAllByUser(user);
        }

        public List<NewsItem> FindUserNewsByFeed(Feed feed)
        {
            return newsDAO.FindAllByUserAndFeed(user, feed);
        }

        public List<NewsItem> FindUserNewsByFilter(Filter filter)
        {
            return newsDAO.FindAllByUserAndFilter(user, filter);
        }

        public void MarkAsUnread(NewsItem newsItem, bool unread)
        {
            if (newsItem.Unread == unread)
            {
                return;
            }

            newsItem.Unread = unread;
            try
            {
                newsDAO.MarkAsRead(newsItem);
            }
            catch (Exception e)
            {
                // Si se produce un error, dejamos la noticia como estaba
                newsItem.Unread = !unread;
                throw e;
            }
        }

        public void MarkAsFavorite(NewsItem newsItem, bool favorite)
        {
            if (newsItem.Favorite == favorite)
            {
                return;
            }

            newsItem.Favorite = favorite;
            try
            {
                newsDAO.MarkAsFavorite(newsItem);
            }
            catch (Exception e)
            {
                // Si se produce un error, dejamos la noticia como estaba
                newsItem.Favorite = !favorite;
                throw e;
            }
        }

        public void DeleteNewsItem(NewsItem newsItem)
        {
            newsDAO.Delete(newsItem);
        }

        public Feed AddFeed(string name, string url)
        {
            Feed feed = new Feed
            {
                Name = name,
                Url = url,
                User = user
            };

            feedDAO.Add(feed);

            return feed;
        }

        public void UpdateFeed(Feed feed)
        {
            feedDAO.Update(feed);
        }

        public void DeleteFeeds(List<Feed> feeds)
        {
            feedDAO.Delete(feeds);
        }

        public List<Filter> FindUserFilters()
        {
            return filterDAO.FindAllByUser(user);
        }

        public Filter AddFilter(string name, string text, List<Feed> feeds)
        {
            Filter filter = new Filter
            {
                Name = name,
                Text = text,
                Feeds = feeds,
                User = user
            };

            filterDAO.Add(filter);

            return filter;
        }

        public void UpdateFilter(Filter filter)
        {
            filterDAO.Update(filter);
        }

        public void DeleteFilters(List<Filter> filters)
        {
            filterDAO.Delete(filters);
        }

    }
}
