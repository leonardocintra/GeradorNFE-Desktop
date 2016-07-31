using GeradorNF.BLL;
using GeradorNF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorNF.UI
{
    public partial class frmEmitente : Form
    {
        public frmEmitente()
        {
            InitializeComponent();
        }

        private void frmEmitente_Load(object sender, EventArgs e)
        {
            GetEmitente();
        }

        private async void GetEmitente()
        {
            dataGridEmitente.DataSource = await EmitenteBLL.GetEmitenteBLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}