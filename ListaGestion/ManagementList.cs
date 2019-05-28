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

        [Category("Action")]
        [Description("Evento de cambio sobre una propiedad del componente")]
        [DisplayName("Property Changed")]
        public event EventHandler<PropertyChangeEventArgs> PropertyChangeEvent;

        private Color listColor = Color.Black;

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

        [Category("Behavior")]
        [Description("Indica si la lista está habilitada")]
        public bool ListEnabled
        {
            set
            {
                bool oldValue = listItems.Enabled;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("ListEnabled", oldValue, value);
                    listItems.Enabled = value;
                }
            }
            get => listItems.Enabled;
        }

        [Category("Appearance")]
        [Description("Color de los elementos de la lista")]
        public Color ListColor
        {
            set
            {
                if (listColor != value)
                {
                    InvokePropertyChangeEvent("ListColor", listColor, value);
                    listColor = value;
                }
            }
            get => listColor;
        }

        [Category("Behavior")]
        [Description("Indica si el botón Añadir está habilitado")]
        public bool AddButtonEnabled
        {
            set
            {
                bool oldValue = btnAdd.Enabled;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("AddButtonEnabled", oldValue, value);
                    btnAdd.Enabled = value;
                }
            }
            get => btnAdd.Enabled;
        }

        [Category("Behavior")]
        [Description("Indica si el botón Eliminar está habilitado")]
        public bool DeleteButtonEnabled
        {
            set
            {
                bool oldValue = btnDelete.Enabled;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("DeleteButtonEnabled", oldValue, value);
                    btnDelete.Enabled = value;
                }
            }
            get => btnDelete.Enabled;
        }

        [Category("Behavior")]
        [Description("Indica si el botón Editar está habilitado")]
        public bool EditButtonEnabled
        {
            set
            {
                bool oldValue = btnEdit.Enabled;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("EditButtonEnabled", oldValue, value);
                    btnEdit.Enabled = value;
                }
            }
            get => btnEdit.Enabled;
        }

        [Category("Appearance")]
        [Description("Texto asociado al botón Añadir")]
        public string AddButtonText
        {
            set
            {
                string oldValue = btnAdd.Text;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("AddButtonText", oldValue, value);
                    btnAdd.Text = value;
                }
            }
            get
            {
                return btnAdd.Text;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado al botón Eliminar")]
        public string DeleteButtonText
        {
            set
            {
                string oldValue = btnDelete.Text;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("DeleteButtonText", oldValue, value);
                    btnDelete.Text = value;
                }
            }
            get
            {
                return btnDelete.Text;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado al botón Editar")]
        public string EditButtonText
        {
            set
            {
                string oldValue = btnEdit.Text;

                if (oldValue != value)
                {
                    InvokePropertyChangeEvent("EditButtonText", oldValue, value);
                    btnEdit.Text = value;
                }
            }
            get
            {
                return btnEdit.Text;
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

        private void InvokePropertyChangeEvent(string propertyName, object oldValue, object newValue)
        {
            if (PropertyChangeEvent != null)
            {
                PropertyChangeEvent(this, new PropertyChangeEventArgs(propertyName, oldValue, newValue));
            }
        }

        private void ListItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            object item = listItems.Items[e.Index];
            string strItem = item == null ? "" : item.ToString();

            Brush brush = new SolidBrush(listColor);

            e.DrawBackground();

            e.Graphics.DrawString(strItem, listItems.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
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

    public class PropertyChangeEventArgs : EventArgs
    {
        private readonly string propertyName;
        private readonly object oldValue;
        private readonly object newValue;

        public PropertyChangeEventArgs(string propertyName, object oldValue, object newValue)
        {
            this.propertyName = propertyName;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public string PropertyName => propertyName;

        public object OldValue => oldValue;

        public object NewValue => newValue;
    }
}
