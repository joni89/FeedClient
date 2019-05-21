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
    public partial class FrmNewFilter : Form
    {

        private Controller controller;
        private List<Feed> feeds;

        public Filter filter;

        public FrmNewFilter(Controller controller): this(controller, null)
        {
        }

        public FrmNewFilter(Controller controller, Filter filter)
        {
            this.controller = controller;
            InitializeComponent();

            feeds = controller.FindUserFeeds();
            clbFeeds.Items.AddRange(feeds.Select(feed => feed.Name).ToArray());

            this.filter = filter;

            if(filter != null)
            {
                txtName.Text = filter.Name;
                txtText.Text = filter.Text;

                HashSet<long> feedIds = filter.Feeds.Select(feed => feed.Id.Value).ToHashSet();

                for (int i = 0; i < feeds.Count; ++i)
                {
                    if (feedIds.Contains(feeds[i].Id.Value))
                    {
                        clbFeeds.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAcept_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            List<Feed> selectedFeeds = clbFeeds.CheckedIndices.Cast<int>().Select(i => feeds[i]).ToList();
            string text = txtText.Text.Trim();

            if (name.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre para el filtro.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (text.Length == 0)
            {
                MessageBox.Show("Debe introducir al menos una palabra.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (filter == null)
                {
                    filter = controller.AddFilter(name, text, selectedFeeds);

                    MessageBox.Show("Filtro guardado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    filter.Name = name;
                    filter.Text = text;
                    filter.Feeds = selectedFeeds;

                    controller.UpdateFilter(filter);

                    MessageBox.Show("Filtro modificado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error guardando el filtro.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
