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

        public User Login(string username, string password)
        {
            try
            {
                var user = userDAO.Login(username, password);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña no válidos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return user;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
