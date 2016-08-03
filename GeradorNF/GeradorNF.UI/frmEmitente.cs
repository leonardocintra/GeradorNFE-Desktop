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
            try
            {
                dataGridEmitente.DataSource = await EmitenteBLL.GetEmitenteBLL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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

        private async void SetEmitente(Enuns.TipoCrud tipoCrud)
        {
            Emitente emitente = new Emitente();

            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);
            string mensagemCrud = Utilidade.GetMensagemParaCrud(tipoCrud);

            try
            {
                #region set parameters
                emitente.RazaoSocial = txtNomeRazao.Text;
                emitente.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                emitente.NomeFantasia = txtNomeFantasia.Text;
                emitente.Bairro = txtBairro.Text;
                emitente.CEP = txtCEP.Text.Replace("-", string.Empty);
                emitente.Cidade = txtCidade.Text;
                emitente.CNAE = txtCNAE.Text;
                emitente.CidadeCodigo = int.Parse(txtCodigoCidade.Text);
                emitente.Complemento = txtComplemento.Text;
                emitente.Fone = txtTelefone.Text;
                emitente.InscricaoEstadual = txtInscricaoEstatudal.Text;
                emitente.IM = txtIM.Text;
                emitente.Logradouro = txtEndereco.Text;
                emitente.NumeroCasa = txtNumero.Text;
                emitente.UF = txtEstado.Text;
                #endregion

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await EmitenteBLL.AdicionarEmitenteBLL(emitente);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Emitente " + mensagemCrud + " com sucesso!", "Emitente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o emitente! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                //else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                //{
                //    emitente.EmitenteId = int.Parse(txtIdEmitente.Text);
                //    EmitenteBLL.AtualizarEmitente(emitente);

                //}
                //else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                //{
                //    emitente.EmitenteId = int.Parse(txtIdEmitente.Text);
                //    EmitenteBLL.ExcluirEmitente(emitente);
                //}
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Emitente");
                }

                LimpaCampos();
                GetEmitente();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o emitente! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SetEmitente(Enuns.TipoCrud.novo);
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
                txtComplemento.Text = endereco.Complemento;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Localidade;
                txtEstado.Text = endereco.UF;
                txtCodigoCidade.Text = endereco.IBGE;

                if (endereco.CEP == null)
                {
                    MessageBox.Show("CEP não encontrado ou inválido! Tente novamente", "CEP não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCEP.Clear();
                }
                else
                {
                    if (txtEndereco.Text != string.Empty)
                        txtNumero.Focus();
                    else
                        txtEndereco.Focus();
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