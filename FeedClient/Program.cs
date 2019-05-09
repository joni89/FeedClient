using FeedClient;
using FeedClient.DB;
using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedClient
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controller controller = new Controller();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal(controller));

            //TestFeeds();

            TestDAOs();
        }

        private static void TestFeeds()
        {
            Feed feed = new Feed()
            {
                Name = "Test",
                Url = "http://localhost:8080/feeds/genbeta.xml"
                //Url = "http://localhost:8080/feeds/the-register.xml"
            };

            FeedReader reader = new FeedReader();

            var title = reader.GetName(feed.Url);
            Console.WriteLine("Nombre del Feed: " + title);

            var news = reader.GetNews(feed);
            Console.WriteLine("Número de noticias: " + news.Count);
            Console.WriteLine("Título de la primera noticia: " + news[0].Title);
            Console.WriteLine("GUID de la primera noticia: " + news[0].Guid);
            Console.WriteLine("URL de la primera noticia: " + news[0].Url);
            Console.WriteLine("Fecha de la primera noticia: " + news[0].Datetime);
        }

        private static void TestDAOs()
        {
            UserDAO userDAO = new UserDAO();

            //userDAO.Add(new User() {
            //    Username = "joni89",
            //    Name = "Jonatan 2"
            //}, "prueba");

            var user = userDAO.Login("jonifer", "abc123.");
            Console.WriteLine(user?.Name);

            FeedDAO feedDAO = new FeedDAO();
            var feeds = feedDAO.FindAllByUser(user);
            foreach (var feed in feeds)
            {
                Console.WriteLine("Feed[id={0}, name={1}, url={2}]", feed.Id, feed.Name, feed.Url);
            }

            FilterDAO filterDAO = new FilterDAO();
            var filter = new Filter()
            {
                Name = "Filtro de prueba",
                Text = "prueba",
                User = user,
                Feeds = feeds
            };
            filterDAO.Add(filter);
            Console.WriteLine("=== Se ha insertado el filtro {0} ===", filter.Id);

            var filters = filterDAO.FindAllByUser(user);

            foreach (var filterAux in filters)
            {
                Console.WriteLine("Filter[id={0}, name={1}, text={2}]", filterAux.Id, filterAux.Name, filterAux.Text);
                foreach (var feed in filterAux.Feeds)
                {
                    Console.WriteLine("Feed[id={0}, name={1}, url={2}]", feed.Id, feed.Name, feed.Url);
                }
            }
        }
    }
}
