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
    public partial class FrmLogin : Form
    {
        private Controller controller;

        public FrmLogin(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var answer = new FrmRegister(controller).ShowDialog();
            Console.WriteLine("Answer: " + answer);
        }
    }
}
