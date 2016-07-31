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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "novo";
            txtNomeRazao.Focus();
        }

        #region privates methods
        private void LimpaCampos()
        {
            txtIdEmitente.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtCidade.Clear();
            txtCNAE.Clear();
            txtCodigoCidade.Clear();
            txtComplemento.Clear();
            txtCNPJ.Clear();
            txtEndereco.Clear();
            txtEstado.Clear();
            txtFiltro.Clear();
            txtIM.Clear();
            txtInscricaoEstatudal.Clear();
            txtNomeFantasia.Clear();
            txtNomeRazao.Clear();
            txtNumero.Clear();
            txtPais.Clear();
            txtTelefone.Clear();
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            DesbloquearCamposEndereco(tipoBloqueio);
            txtCNAE.Enabled = tipoBloqueio;
            txtComplemento.Enabled = tipoBloqueio;
            txtCNPJ.Enabled = tipoBloqueio;
            txtIM.Enabled = tipoBloqueio;
            txtInscricaoEstatudal.Enabled = tipoBloqueio;
            txtNomeFantasia.Enabled = tipoBloqueio;
            txtNomeRazao.Enabled = tipoBloqueio;
            txtTelefone.Enabled = tipoBloqueio;
        }

        private void DesbloquearCamposEndereco(bool tipoBloqueio)
        {
            txtCEP.Enabled = tipoBloqueio;
            //txtCidade.Enabled = tipoBloqueio;
            //txtEstado.Enabled = tipoBloqueio;
            //txtCodigoCidade.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
            txtBairro.Enabled = tipoBloqueio;
            txtComplemento.Enabled = tipoBloqueio;
            txtNumero.Enabled = tipoBloqueio;
            btnSalvar.Enabled = tipoBloqueio;
        }
        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}