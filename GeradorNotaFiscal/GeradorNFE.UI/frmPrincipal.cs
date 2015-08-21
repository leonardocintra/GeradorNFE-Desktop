﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorNFE.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void emitenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmitente frm = new frmEmitente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void transportadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransportador frm = new frmTransportador();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
