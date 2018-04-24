﻿using System;
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
    public partial class FormEmoji : Form
    {
        public Form1 form1_instance;

        public FormEmoji()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("images/exitbutton.png");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("images/exitbuttonred.png");
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            form1_instance.Send(name);
        }
    }
}
