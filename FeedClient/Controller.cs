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
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        public List<NewsItem> FindUserNews()
        {
            // FIXME meter try-catch
            return newsDAO.FindAllByUser(user);
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
            catch (Exception)
            {
                // Si se produce un error, dejamos la noticia como estaba
                newsItem.Unread = !unread;
                // FIXME mostrar mensaje de error
            }
        }

        public void MarkAsFavorite(NewsItem newsItem, bool favorite)
        {
            if (newsItem.Favorite == favorite)
            {
                return;
            }

            newsItem.Unread = favorite;
            try
            {
                newsDAO.MarkAsRead(newsItem);
            }
            catch (Exception)
            {
                // Si se produce un error, dejamos la noticia como estaba
                newsItem.Unread = !favorite;
                // FIXME mostrar mensaje de error
            }
        }

    }
}
