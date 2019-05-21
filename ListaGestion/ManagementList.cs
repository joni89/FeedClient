using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementList
{
    [
        DefaultProperty("Items"),
        DefaultEvent("Load")
    ]
    public partial class ManagementList : UserControl
    {
        [Category("Action")]
        [Description("Evento de click sobre alguno de los botones (Añadir, Editar o Eliminar)")]
        [DisplayName("Button Clicked")]
        public event EventHandler<ButtonClickEventArgs> ButtonClickEvent;

        public ManagementList()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [Description("Elementos que se mostrarán en la lista")]
        public List<object> Items
        {
            set
            {
                listItems.Items.Clear();
                listItems.Items.AddRange(value.ToArray());
            }
            get
            {
                List<object> items = new List<object>(listItems.Items.Count);

                foreach (var item in listItems.Items)
                {
                    items.Add(item);
                }

                return items;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InvokeButtonClickEvent(ActionButton.ADD);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            int selectedItemsCount = listItems.SelectedIndices.Count;

            if (selectedItemsCount == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar " + (selectedItemsCount > 1 ? "los elementos seleccionados" : "el elemento seleccionado") + "?"
                    , "Salir"
                    , MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    InvokeButtonClickEvent(ActionButton.DELETE);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (listItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Debe seleccionar algún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listItems.SelectedIndices.Count > 1)
            {
                MessageBox.Show("Debe seleccionar un único elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InvokeButtonClickEvent(ActionButton.EDIT);
            }
        }

        public int[] GetSelectedIndices()
        {
            List<int> selectedIndices = new List<int>();

            foreach (int index in listItems.SelectedIndices)
            {
                selectedIndices.Add(index);
            }

            return selectedIndices.ToArray();
        }

        private void InvokeButtonClickEvent(ActionButton button)
        {
            if (ButtonClickEvent != null)
            {
                ButtonClickEvent(this, new ButtonClickEventArgs(button, GetSelectedIndices()));
            }
        }
    }

    public enum ActionButton
    {
        ADD,
        EDIT,
        DELETE
    }

    public class ButtonClickEventArgs : EventArgs
    {
        private readonly ActionButton button;
        private readonly int[] selectedIndices;

        public ButtonClickEventArgs(ActionButton button, int[] selectedIndices)
        {
            this.button = button;
            this.selectedIndices = selectedIndices;
        }

        public ActionButton Button => button;

        public int SelectedIndex => selectedIndices[0];

        public int[] SelectedIndices => selectedIndices;
    }
}
