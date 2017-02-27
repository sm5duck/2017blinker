﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlinkBlink_EyeJoah.Chart.ConstantChange;

namespace BlinkBlink_EyeJoah
{
    public partial class Control1_Home : UserControl
    {
        ConstantChange con;
        public Control1_Home()
        {
            InitializeComponent();

            con = new ConstantChange();
            con.BackColor = Color.Beige;
            con.TopLevel = false;
            con.AutoScroll = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.Controls.Add(con);
            con.Show();
        }

        public ConstantChange getConstantChange
        {
            get { return con; }
            set { con = value; }
        }

    }
}
