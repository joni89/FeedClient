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
    public partial class FrmCustomFilters : Form
    {

        private Controller controller;
        private List<Filter> filters;

        public Filter appliedFilter;

        public FrmCustomFilters(Controller controller, Filter appliedFilter)
        {
            this.controller = controller;

            InitializeComponent();

            filters = controller.FindUserFilters();

            if (appliedFilter != null)
            {
                this.appliedFilter = filters.Find(filter => filter.Id.Value == appliedFilter.Id.Value);
            }

            UpdateListItems();
        }

        private void ManagementList_ButtonClickEvent(object sender, ManagementList.ButtonClickEventArgs e)
        {
            switch (e.Button)
            {
                case ManagementList.ActionButton.ADD:
                    AddFilter();
                    break;
                case ManagementList.ActionButton.EDIT:
                    EditFilter(e.SelectedIndex);
                    break;
                case ManagementList.ActionButton.DELETE:
                    DeleteFilters(e.SelectedIndices);
                    break;
            }
        }

        private void UpdateListItems()
        {
            managementList.Items = filters.Select(f => f.Name).ToList<object>();
        }

        private void AddFilter()
        {
            FrmNewFilter frmNewFilter = new FrmNewFilter(controller);
            var answer = frmNewFilter.ShowDialog();

            if (answer == DialogResult.OK)
            {
                filters.Add(frmNewFilter.filter);
                UpdateListItems();
            }
        }

        private void EditFilter(int selectedIndex)
        {
            Filter selectedFilter = filters[selectedIndex];

            var frmNewFilter = new FrmNewFilter(controller, selectedFilter);
            var answer = frmNewFilter.ShowDialog();

            if (answer == DialogResult.OK)
            {
                UpdateListItems();
            }
        }

        private void DeleteFilters(int[] selectedIndices)
        {
            List<Filter> selectedFilters = selectedIndices.Select(i => filters[i]).ToList();

            try
            {
                controller.DeleteFilters(selectedFilters);

                foreach (var filter in selectedFilters)
                {
                    filters.Remove(filter);

                    if (filter == appliedFilter)
                    {
                        appliedFilter = null;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error eliminando las fuentes.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Fuentes eliminadas satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateListItems();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            int[] selectedIndices = managementList.GetSelectedIndices();

            if (selectedIndices.Length == 0)
            {
                MessageBox.Show("Debe seleccionar algún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedIndices.Length > 1)
            {
                MessageBox.Show("Debe seleccionar un único elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                appliedFilter = filters[selectedIndices[0]];
            }
        }
    }
}
