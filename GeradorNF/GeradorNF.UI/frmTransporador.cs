using GeradorNF.BLL;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorNF.UI
{
    public partial class frmTransporador : Form
    {
        public frmTransporador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkCpfCnpj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkCpfCnpj.Text.Equals("Usar CPF"))
            {
                txtCNPJ.Clear();
                txtCNPJ.Mask = "000.000.000-00";
                lblCnpjCpf.Text = "CPF:";
                linkCpfCnpj.Text = "Usar CNPJ";
                txtCNPJ.Focus();
            }
            else
            {
                txtCNPJ.Clear();
                txtCNPJ.Mask = "000.000.000/0000-0";
                lblCnpjCpf.Text = "CNPJ:";
                linkCpfCnpj.Text = "Usar CPF";
                txtCNPJ.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            txtNomeRazao.Focus();
        }

        #region methods privates
        private void LimpaCampos()
        {
            txtIdTransportador.Clear();
            txtCEP.Clear();
            txtCidade.Clear();
            txtCodigoCidade.Clear();
            txtCNPJ.Clear();
            txtEndereco.Clear();
            txtEstado.Clear();
            txtFiltro.Clear();
            txtNomeRazao.Clear();
            txtNumero.Clear();
            txtEndereco.Clear();
            txtInscricaoEstadual.Clear();
        }

        private void DesbloquearCamposEndereco(bool tipoBloqueio)
        {
            txtCEP.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
            txtNumero.Enabled = tipoBloqueio;
            btnSalvar.Enabled = tipoBloqueio;
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            DesbloquearCamposEndereco(tipoBloqueio);
            txtCNPJ.Enabled = tipoBloqueio;
            txtNomeRazao.Enabled = tipoBloqueio;
            txtInscricaoEstadual.Enabled = tipoBloqueio;
            txtCEP.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DesbloquearCampos(false);
            btnEditar.Enabled = true;

            txtIdTransportador.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            cbxFretePorConta.Checked = dataGridView1[1, dataGridView1.CurrentRow.Index].Value != null ? true : false;
            txtCNPJ.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            txtInscricaoEstadual.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            txtNomeRazao.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            txtEndereco.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            txtCodigoCidade.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
            txtCidade.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
            txtEstado.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
            txtCEP.Text = dataGridView1[18, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void linkPesquisaCEP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Endereco endereco = new Endereco();
            EnderecoBLL enderecoBLL = new EnderecoBLL();

            linkPesquisaCEP.Text = "Aguarde ...";
            DesbloquearCamposEndereco(false);

            try
            {
                endereco = enderecoBLL.BuscarDadosCEP(txtCEP.Text);

                txtEndereco.Text = endereco.Logradouro;
                txtCidade.Text = endereco.Localidade;
                txtEstado.Text = endereco.UF;
                txtCodigoCidade.Text = endereco.IBGE;

                if (endereco.CEP == null)
                {
                    MessageBox.Show("CEP não encontrado ou inválido! Tente novamente", "CEP não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCEP.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP! \nErro: " + ex.Message, "Erro CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DesbloquearCamposEndereco(true);
                linkPesquisaCEP.Text = "Pesquisar";
                txtCEP.Focus();
            }
        }
    }
}
