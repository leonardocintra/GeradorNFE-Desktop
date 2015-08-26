using GeradorNFE.BLL;
using GeradorNFE.Model;
using GeradorNFE.UI.ClassForm;
using System;
using System.Windows.Forms;

namespace GeradorNFE.UI
{
    public partial class frmDestinatario : Form
    {
        public frmDestinatario()
        {
            InitializeComponent();
        }

        #region botões da pagina
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            txtNomeRazao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposObrigatorios())
            {
                if (lblAcao.Text.Equals("Editar"))
                    SetDestinatario(Enuns.TipoCrud.update);
                else
                    SetDestinatario(Enuns.TipoCrud.novo);
            }
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
                if (MessageBox.Show("Deseja excluir esse Destinatario?", "Exluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetDestinatario(Enuns.TipoCrud.delete);
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
                dataGridDestinatario.DataSource = DestinatarioBLL.BuscarDestinatarioComParametro(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodos Privados
        private void SetDestinatario(Enuns.TipoCrud tipoCrud)
        {
            Destinatario destinatario = new Destinatario();

            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);
            string mensagemCrud = Utilidade.GetMensagemParaCrud(tipoCrud);

            try
            {
                #region set parameters
                destinatario.NomeRazao = txtNomeRazao.Text;
                destinatario.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                destinatario.InscricaoEstadual = txtInscricaoEstatudal.Text;
                destinatario.Bairro = txtBairro.Text;
                destinatario.CEP = txtCEP.Text.Replace("-", string.Empty);
                destinatario.Cidade = txtCidade.Text;
                destinatario.ISUF = txtIsUF.Text;
                destinatario.CidadeCodigo = int.Parse(txtCodigoCidade.Text);
                destinatario.Complemento = txtComplemento.Text;
                destinatario.Fone = txtTelefone.Text;
                destinatario.IndIEDest = 1;
                destinatario.Logradouro = txtEndereco.Text;
                destinatario.NumeroCasa = string.IsNullOrEmpty(txtNumero.Text) ? destinatario.NumeroCasa.GetValueOrDefault() : int.Parse(txtNumero.Text);
                destinatario.UF = txtEstado.Text;
                destinatario.Pais = "BRASIL";
                destinatario.PaisCodigo = 1058;
                #endregion

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    DestinatarioBLL.CadastrarDestinatario(destinatario);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    destinatario.DestinatarioId = int.Parse(txtIdDestinatario.Text);
                    DestinatarioBLL.AtualizarDestinatario(destinatario);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    destinatario.DestinatarioId = int.Parse(txtIdDestinatario.Text);
                    DestinatarioBLL.ExcluirDestinatario(destinatario);
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Destinatario");
                }

                MessageBox.Show("Destinatario " + mensagemCrud + " com sucesso!", "Destinatario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpaCampos();
                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o destinatario! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpaCampos()
        {
            txtIdDestinatario.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtCidade.Clear();
            txtIsUF.Clear();
            txtCodigoCidade.Clear();
            txtComplemento.Clear();
            txtCNPJ.Clear();
            txtEndereco.Clear();
            txtEstado.Clear();
            txtFiltro.Clear();
            txtInscricaoEstatudal.Clear();
            txtNomeRazao.Clear();
            txtNumero.Clear();
            txtPais.Clear();
            txtTelefone.Clear();
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            DesbloquearCamposEndereco(tipoBloqueio);
            txtComplemento.Enabled = tipoBloqueio;
            txtCNPJ.Enabled = tipoBloqueio;
            txtInscricaoEstatudal.Enabled = tipoBloqueio;
            txtNomeRazao.Enabled = tipoBloqueio;
            txtTelefone.Enabled = tipoBloqueio;
        }

        private void DesbloquearCamposEndereco(bool tipoBloqueio)
        {
            txtCEP.Enabled = tipoBloqueio;
            txtEndereco.Enabled = tipoBloqueio;
            txtBairro.Enabled = tipoBloqueio;
            txtComplemento.Enabled = tipoBloqueio;
            txtNumero.Enabled = tipoBloqueio;
            btnSalvar.Enabled = tipoBloqueio;
        }

        private void PreencherGrid()
        {
            dataGridDestinatario.DataSource = DestinatarioBLL.BuscarDestinatario();
        }

        private void VerificaSePrimeiroRegistro()
        {
            if (dataGridDestinatario.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhum destinatario cadastrado ainda! \n Faça o primeiro cadastro!", "Destinatario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridDestinatario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DesbloquearCampos(false);
            DesbloquearCamposEndereco(false);
            btnEditar.Enabled = true;
            try
            {
                txtIdDestinatario.Text = dataGridDestinatario[0, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtCNPJ.Text = dataGridDestinatario[1, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtInscricaoEstatudal.Text = dataGridDestinatario[3, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtIsUF.Text = dataGridDestinatario[4, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtNomeRazao.Text = dataGridDestinatario[5, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtTelefone.Text = dataGridDestinatario[6, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtCEP.Text = dataGridDestinatario[7, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtEndereco.Text = dataGridDestinatario[8, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtNumero.Text = dataGridDestinatario[9, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtComplemento.Text = dataGridDestinatario[10, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtBairro.Text = dataGridDestinatario[11, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtCodigoCidade.Text = dataGridDestinatario[12, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtCidade.Text = dataGridDestinatario[13, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtEstado.Text = dataGridDestinatario[14, dataGridDestinatario.CurrentRow.Index].Value.ToString();
                txtPais.Text = dataGridDestinatario[16, dataGridDestinatario.CurrentRow.Index].Value.ToString();
            }
            catch
            {
            }

        }

        private void frmDestinatario_Load(object sender, EventArgs e)
        {
            PreencherGrid();
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
    }
}
