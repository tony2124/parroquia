﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class acercade : Form
    {
        public acercade()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0,17, "www.simpus.com.mx");
            linkLabel2.Links.Add(0, 19, "www.simpus.com.mx/es/software/parroquia/terminos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
