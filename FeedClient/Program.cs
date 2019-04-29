using FeedClient;
using FeedClient.DB;
using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmPrincipal());

            //Feed feed = new Feed() {
            //    Name = "Test",
            //    Url = "http://localhost:8080/feeds/genbeta.xml"
            //    //Url = "http://localhost:8080/feeds/the-register.xml"
            //};

            //FeedReader reader = new FeedReader();

            //var title = reader.GetName(feed.Url);
            //Console.WriteLine("Nombre del Feed: " + title);

            //var news = reader.GetNews(feed);
            //Console.WriteLine("Número de noticias: " + news.Count);
            //Console.WriteLine("Título de la primera noticia: " + news[0].Title);
            //Console.WriteLine("GUID de la primera noticia: " + news[0].Guid);
            //Console.WriteLine("URL de la primera noticia: " + news[0].Url);
            //Console.WriteLine("Fecha de la primera noticia: " + news[0].Datetime);

            UserDAO userDAO = new UserDAO();
            //userDAO.CreateUser("pepe", "abc123.", "José");
            var user = userDAO.Login("pepe", "abc123.");
            Console.WriteLine(user?.Name);
        }
    }
}
