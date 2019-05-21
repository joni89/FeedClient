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
    public partial class FrmRegister : Form
    {
        private Controller controller;

        public FrmRegister(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string name = txtName.Text.Trim();

            if (username.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre de usuario.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir una contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas introducidas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (controller.CheckUsernameExists(username))
            {
                MessageBox.Show("El nombre de usuario introducido ya existe en el sistema.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                controller.RegisterUser(name, username, txtPassword.Text);

                MessageBox.Show("Usuario registrado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al registrar el usuario.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
