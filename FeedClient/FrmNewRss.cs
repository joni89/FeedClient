using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedClient
{
    public partial class FrmNewRss : Form
    {

        private Controller controller;
        private bool urlChanged = false;
        public Feed feed;

        public FrmNewRss(Controller controller) : this(controller, null)
        {
        }

        public FrmNewRss(Controller controller, Feed feed)
        {
            this.controller = controller;
            InitializeComponent();

            this.feed = feed;

            if (feed != null)
            {
                txtUrl.Text = feed.Url;
                txtName.Text = feed.Name;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAcept_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            string name = txtName.Text.Trim();

            if (url.Length == 0)
            {
                MessageBox.Show("Debe introducir una URL.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ValidationUtils.IsValidUrl(url))
            {
                MessageBox.Show("La URL introducida no es válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (name.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (feed == null)
                {
                    feed = controller.AddFeed(name, url);

                    MessageBox.Show("Fuente añadida satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    feed.Name = name;
                    feed.Url = url;
                    controller.UpdateFeed(feed);

                    MessageBox.Show("Fuente modificada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error guardando la fuente.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtUrl_Leave(object sender, EventArgs e)
        {
            if(!urlChanged)
            {
                return;
            }

            urlChanged = false;

            string url = txtUrl.Text.Trim();

            if (!ValidationUtils.IsValidUrl(url))
            {
                return;
            }

            if(txtName.Text.Trim().Length > 0)
            {
                return;
            }

            txtName.Enabled = false;
            try
            {
                txtName.Text = controller.GetFeedName(url);
            }
            catch(Exception)
            {
                MessageBox.Show("No ha sido posible obtener el nombre de la fuente.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtName.Enabled = true;
            }
        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {
            urlChanged = true;
        }
    }
}
