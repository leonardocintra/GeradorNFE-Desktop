using GeradorNF.BLL;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
        private async void SetTranportadora(Enuns.TipoCrud tipoCrud)
        {
            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);
            string mensagemCrud = Utilidade.GetMensagemParaCrud(tipoCrud);

            try
            {
                Transportador transportador = new Transportador();

                #region set parameters
                transportador.Cidade = txtCidade.Text;
                transportador.CidadeCodigo = Convert.ToInt32(txtCodigoCidade.Text);
                transportador.CPF_CNPJ = txtCNPJ.Text;
                transportador.Endereco = txtEndereco.Text;
                transportador.FretePorConta = cbxFretePorConta.Checked;
                transportador.InscricaoEstadual = txtInscricaoEstadual.Text;
                transportador.NomeRazao = txtNomeRazao.Text;
                transportador.UF = txtEstado.Text;
                transportador.CEP = txtCEP.Text;
                transportador.Cliente = MyGlobals.Cliente;

                #endregion

                HttpResponseMessage response = new HttpResponseMessage();

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    response = await TransportadorBLL.AdicionarTransportadorBLL(transportador);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tranportador " + mensagemCrud + " com sucesso!", "Tranportador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o transportador! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    response = await TransportadorBLL.AtualizarTransportadorBLL(transportador);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tranportador " + mensagemCrud + " com sucesso!", "Tranportador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o transportador! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    transportador.Id = Convert.ToInt32(txtIdTransportador.Text);
                    response = await TransportadorBLL.DeletarTransportadorBLL(transportador.Id);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tranportador " + mensagemCrud + " com sucesso!", "Tranportador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o transportador! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Tranportador");
                    return;
                }

                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o transportador! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherGrid()
        {
            GetTransportador();
        }

        private async void GetTransportador()
        {
            try
            {
                dataGridView1.DataSource = await TransportadorBLL.GetTransportadorBLL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            txtCEP.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblAcao.Text.Equals("Editar"))
                SetTranportadora(Enuns.TipoCrud.update);
            else
                SetTranportadora(Enuns.TipoCrud.novo);
        }

        private void linkPesquisaCEP_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void frmTransporador_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }
    }
}
