using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatSystem
{
    public partial class FormName : Form
    {
        public FormName()
        {
            InitializeComponent();
        }

        public string name;

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Hide();
                Form1 form = new Form1();
                form.name = textBox1.Text;
                form.FormClosed += (s, args) => this.Close();
                form.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
