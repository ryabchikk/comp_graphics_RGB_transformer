﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form2();
            frm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.ShowDialog();
        }
    }
}