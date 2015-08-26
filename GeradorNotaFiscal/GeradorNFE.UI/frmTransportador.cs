using GeradorNFE.BLL;
using GeradorNFE.Model;
using GeradorNFE.UI.ClassForm;
using System;
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
    public partial class frmTransportador : Form
    {
        public frmTransportador()
        {
            InitializeComponent();
        }

        private void frmTransportador_Load(object sender, EventArgs e)
        {
            txtNomeRazao.Focus();
            PreencherGrid();
        }

        #region Privates
        private  void SomaValorImposto()
        {
            decimal valorAliquota = string.IsNullOrEmpty(txtAliquota.Text) ? 0 : Convert.ToDecimal(txtAliquota.Text.Replace(".", ","));
            decimal valorServico = string.IsNullOrEmpty(txtValorServico.Text) ? 0 : Convert.ToDecimal(txtValorServico.Text.Replace(".", ","));
            decimal valorBase = string.IsNullOrEmpty(txtValorBase.Text) ? 0 : Convert.ToDecimal(txtValorBase.Text.Replace(".", ","));

            decimal total = valorAliquota + valorServico + valorBase;
            txtValorTotal.Text = total.ToString();
        }

        private static void ValidaValorDecinal(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1 || (sender as TextBox).Text == string.Empty)
                    e.Handled = true;
            }

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
                return;
            }
        }

        private void DesbloquearCamposEndereco(bool tipoBloqueio)
        {
            txtCEP.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
            txtNumero.Enabled = tipoBloqueio;
            //txtCidade.Enabled = tipoBloqueio;
            //txtEstado.Enabled = tipoBloqueio;
            btnSalvar.Enabled = tipoBloqueio;
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            DesbloquearCamposEndereco(tipoBloqueio);
            txtCNPJ.Enabled = tipoBloqueio;
            txtNomeRazao.Enabled = tipoBloqueio;
            txtInscricaoEstadual.Enabled = tipoBloqueio;
            txtAliquota.Enabled = tipoBloqueio;
            txtCEP.Enabled = tipoBloqueio;
            txtCEPPlaca.Enabled = tipoBloqueio;
            txtCFOP.Enabled = tipoBloqueio;
            txtCodigoCidadePlaca.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
            txtPlaca.Enabled = tipoBloqueio;
            txtRNTC.Enabled = tipoBloqueio;
            txtUFPlaca.Enabled = tipoBloqueio;
            txtValorBase.Enabled = tipoBloqueio;
            txtValorServico.Enabled = tipoBloqueio;
            txtValorTotal.Enabled = tipoBloqueio;

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
            txtAliquota.Clear();
            txtCEPPlaca.Clear();
            txtCFOP.Clear();
            txtCodigoCidadePlaca.Clear();
            txtEndereco.Clear();
            txtInscricaoEstadual.Clear();
            txtPlaca.Clear();
            txtRNTC.Clear();
            txtUFPlaca.Clear();
            txtValorBase.Clear();
            txtValorServico.Clear();
            txtValorTotal.Clear();
        }

        private void PreencherGrid()
        {
            dataGridView1.DataSource = TransportadorBLL.BuscarTransportador();
        }

        private void SetTranportadora(Enuns.TipoCrud tipoCrud)
        {
            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);
            string mensagemCrud = Utilidade.GetMensagemParaCrud(tipoCrud);

            try
            {
                Transportador transportador = new Transportador();

                #region set parameters
                transportador.CFOP = txtCFOP.Text;
                transportador.Cidade = txtCidade.Text;
                transportador.CNPJCPF = txtCNPJ.Text
                    .Replace(".", string.Empty)
                    .Replace(",", string.Empty)
                    .Replace("/", string.Empty)
                    .Replace("-", string.Empty)
                    .Trim();
                transportador.CodigoCidade = Convert.ToInt32(txtCodigoCidade.Text);
                transportador.CodigoCidadePlaca = Convert.ToInt32(txtCodigoCidadePlaca.Text);
                transportador.Endereco = txtEndereco.Text;
                transportador.FretePorConta = cbxFretePorConta.Checked;
                transportador.InscricaoEstadual = txtInscricaoEstadual.Text;
                transportador.NomeRazao = txtNomeRazao.Text;
                transportador.Placa = txtPlaca.Text;
                transportador.RNTC = txtRNTC.Text;
                transportador.UF = txtEstado.Text;
                transportador.UFPlaca = txtUFPlaca.Text;
                transportador.CEP = txtCEP.Text.Replace("-", string.Empty);
                transportador.CEPPlaca = txtCEPPlaca.Text.Replace("-", string.Empty);

                // VERIFICAR SE O CALCULO ESTA CORRETO.
                transportador.Aliquota = string.IsNullOrEmpty(txtAliquota.Text) ? 0 : Convert.ToDecimal(txtAliquota.Text);
                transportador.ValorBase = string.IsNullOrEmpty(txtValorBase.Text) ? 0 : Convert.ToDecimal(txtValorBase.Text);
                transportador.ValorServico = string.IsNullOrEmpty(txtValorServico.Text) ? 0 : Convert.ToDecimal(txtValorServico.Text);
                transportador.Valor = transportador.ValorBase + transportador.ValorServico + transportador.Aliquota;
                
                #endregion

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    TransportadorBLL.CadastrarTransportador(transportador);
                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    transportador.TransportadorId = int.Parse(txtIdTransportador.Text);
                    TransportadorBLL.AtualizarTransportador(transportador);
                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    transportador.TransportadorId = int.Parse(txtIdTransportador.Text);
                    TransportadorBLL.ExcluirTransportador(transportador);
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Emitente");
                    PreencherGrid();
                    return;
                }                

                MessageBox.Show("Transportador " + mensagemCrud + " com sucesso!", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpaCampos();
                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o transportador! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region botoes do formulario
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            txtNomeRazao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblAcao.Text.Equals("Editar"))
                SetTranportadora(Enuns.TipoCrud.update);
            else
                SetTranportadora(Enuns.TipoCrud.novo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            DesbloquearCampos(true);
            lblAcao.Text = "Editar";
            txtNomeRazao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir esse transportador?", "Exluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetTranportadora(Enuns.TipoCrud.delete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = TransportadorBLL.BuscarTransportadorComParametro(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnPesquisarCodigoPlaca_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            EnderecoBLL enderecoBLL = new EnderecoBLL();

            try
            {
                endereco = enderecoBLL.BuscarDadosCEP(txtCEPPlaca.Text);
                txtCodigoCidadePlaca.Text = endereco.IBGE;
                txtUFPlaca.Text = endereco.UF;

                if (endereco.CEP == null)
                {
                    MessageBox.Show("CEP não encontrado ou inválido! Tente novamente", "CEP não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCEPPlaca.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP! \nErro: " + ex.Message, "Erro CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtCEPPlaca.Focus();
            }
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

        #endregion

        #region Calculo de valores
        private void txtValorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecinal(sender, e);
        }

        private void txtValorBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecinal(sender, e);
        }

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecinal(sender, e);
        }

        private void txtValorServico_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }

        private void txtValorBase_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }

        private void txtAliquota_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DesbloquearCampos(false);
            btnEditar.Enabled = true;
            try
            {
                txtIdTransportador.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                cbxFretePorConta.Checked = dataGridView1[1, dataGridView1.CurrentRow.Index].Value != null ? true : false;
                txtCNPJ.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                txtInscricaoEstadual.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                txtNomeRazao.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                txtEndereco.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCodigoCidade.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCidade.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
                txtEstado.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                txtValorServico.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                txtValorBase.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                txtAliquota.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                txtValorTotal.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCFOP.Text = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCodigoCidadePlaca.Text = dataGridView1[14, dataGridView1.CurrentRow.Index].Value.ToString();
                txtPlaca.Text = dataGridView1[15, dataGridView1.CurrentRow.Index].Value.ToString();
                txtUFPlaca.Text = dataGridView1[16, dataGridView1.CurrentRow.Index].Value.ToString();
                txtRNTC.Text = dataGridView1[17, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCEP.Text = dataGridView1[18, dataGridView1.CurrentRow.Index].Value.ToString();
                txtCEPPlaca.Text = dataGridView1[19, dataGridView1.CurrentRow.Index].Value.ToString();

            }
            catch
            {
                Transportador transportador = new Transportador();
                List<Transportador> listEmitente = new List<Transportador>();
                int idTransportador = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                transportador = TransportadorBLL.BuscarTransportadorById(idTransportador);
                listEmitente.Add(transportador);

                dataGridView1.DataSource = listEmitente;
                PreencherGrid();
            }
        }
    }
}
