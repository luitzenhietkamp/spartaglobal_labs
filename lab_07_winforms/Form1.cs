﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_07_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int counter = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            label1.Text = "You clicked " + counter + " times";
        }
    }
}
