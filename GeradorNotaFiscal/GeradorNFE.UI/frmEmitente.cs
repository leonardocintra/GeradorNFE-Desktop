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
    public partial class frmEmitente : Form
    {
        public frmEmitente()
        {
            InitializeComponent();
        }

        private void frmEmitente_Load_1(object sender, EventArgs e)
        {
            PreencherGrid();
            VerificaSePrimeiroRegistro();
        }

        #region Metodos Privados
        private void SetEmitente(Enuns.TipoCrud tipoCrud)
        {
            Emitente emitente = new Emitente();

            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);

            try
            {
                #region set parameters
                emitente.NomeRazao = txtNomeRazao.Text;
                emitente.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                emitente.NomeFantasia = txtNomeFantasia.Text;
                emitente.Bairro = txtBairro.Text;
                emitente.CEP = int.Parse(txtCEP.Text.Replace("-", string.Empty));
                emitente.Cidade = txtCidade.Text;
                emitente.CNAE = txtCNAE.Text;
                emitente.CodigoCidade = int.Parse(txtCodigoCidade.Text);
                emitente.Complemento = txtComplemento.Text;
                emitente.Fone = txtTelefone.Text;
                emitente.IE = txtInscricaoEstatudal.Text;
                emitente.IM = txtIM.Text;
                emitente.Logradouro = txtEndereco.Text;
                emitente.NumeroRua = string.IsNullOrEmpty(txtNumero.Text) ? emitente.NumeroRua.GetValueOrDefault() : int.Parse(txtNumero.Text);
                emitente.UF = txtEstado.Text;
                emitente.Pais = "BRASIL";
                emitente.CodigoPais = 1058;
                #endregion

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    EmitenteBLL.CadastrarEmitente(emitente);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    emitente.EmitenteId = int.Parse(txtIdEmitente.Text);
                    EmitenteBLL.AtualizarEmitente(emitente);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    emitente.EmitenteId = int.Parse(txtIdEmitente.Text);
                    EmitenteBLL.ExcluirEmitente(emitente);
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Emitente");
                }

                MessageBox.Show("Emitente " + mensagemException + " com sucesso!", "Emitente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpaCampos();
                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o emitente! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void PreencherGrid()
        {
            dataGridEmitente.DataSource = EmitenteBLL.BuscarEmitente();
        }

        private void VerificaSePrimeiroRegistro()
        {
            if (dataGridEmitente.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhum emitente cadastrado ainda! \n Faça o primeiro cadastro!", "Emitente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeRazao.Focus();
            }
        }

        private bool VerificarCamposObrigatorios()
        {
            bool _return;

            string cep = txtCEP.Text.Replace("-", string.Empty).Trim();
            string cnpj = txtCNPJ.Text.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty).Trim();

            if (cep.Length == 0 || cep == string.Empty)
            {
                _return = false;
                MessageBox.Show("Informe corretamente o CEP");
            }
            else if (cnpj.Length == 0 || cnpj == string.Empty)
            {
                _return = false;
                MessageBox.Show("CNPJ é Obrigatório!");
            }
            else if (txtNomeRazao.TextLength < 3)
            {
                _return = false;
                MessageBox.Show("Nome razão é obrigatório ou é menor que 3 caracteres!");
            }
            else
            {
                _return = true;
            }

            return _return;
        }
        #endregion

        #region Botoes
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposObrigatorios())
            {
                if (lblAcao.Text.Equals("Editar"))
                    SetEmitente(Enuns.TipoCrud.update);
                else
                    SetEmitente(Enuns.TipoCrud.novo);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            txtNomeRazao.Focus();
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
                if (MessageBox.Show("Deseja excluir esse Emitente?", "Exluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetEmitente(Enuns.TipoCrud.delete);
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
                dataGridEmitente.DataSource = EmitenteBLL.BuscarEmitenteComParametro(txtFiltro.Text);
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

        private void dataGridEmitente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DesbloquearCampos(false);
            btnEditar.Enabled = true;
            try
            {
                txtIdEmitente.Text = dataGridEmitente[0, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtCNPJ.Text = dataGridEmitente[1, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtInscricaoEstatudal.Text = dataGridEmitente[2, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtNomeRazao.Text = dataGridEmitente[3, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtNomeFantasia.Text = dataGridEmitente[4, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtTelefone.Text = dataGridEmitente[5, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtCEP.Text = dataGridEmitente[6, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtEndereco.Text = dataGridEmitente[7, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtNumero.Text = dataGridEmitente[8, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtComplemento.Text = dataGridEmitente[9, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtBairro.Text = dataGridEmitente[10, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtCodigoCidade.Text = dataGridEmitente[11, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtCidade.Text = dataGridEmitente[12, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtEstado.Text = dataGridEmitente[13, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtIM.Text = dataGridEmitente[14, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtCNAE.Text = dataGridEmitente[15, dataGridEmitente.CurrentRow.Index].Value.ToString();
                txtPais.Text = dataGridEmitente[17, dataGridEmitente.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                Emitente emitente = new Emitente();
                List<Emitente> listEmitente = new List<Emitente>();
                int idEmiente = Convert.ToInt32(dataGridEmitente[0, dataGridEmitente.CurrentRow.Index].Value.ToString());

                emitente = EmitenteBLL.BuscarEmitenteById(idEmiente);
                listEmitente.Add(emitente);

                dataGridEmitente.DataSource = listEmitente;
                PreencherGrid();

            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTelefone.TextLength > 15)
                txtTelefone.Mask = "(999) 00000-0000";
            else
                txtTelefone.Mask = "(999) 0000-0000";
        }

    }
}
