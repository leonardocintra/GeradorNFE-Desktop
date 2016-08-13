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
    public partial class frmDestinatario : Form
    {
        public frmDestinatario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDestinatario_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }

        #region methos privates
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
                destinatario.NumeroCasa = txtNumero.Text;
                destinatario.UF = txtEstado.Text;
                destinatario.Pais = "BRASIL";
                destinatario.PaisCodigo = 1058;
                //destinatario.Email = txtEmail.Text;
                #endregion

                //if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                //{
                //    DestinatarioBLL.CadastrarDestinatario(destinatario);

                //}
                //else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                //{
                //    destinatario.DestinatarioId = int.Parse(txtIdDestinatario.Text);
                //    DestinatarioBLL.AtualizarDestinatario(destinatario);

                //}
                //else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                //{
                //    destinatario.DestinatarioId = int.Parse(txtIdDestinatario.Text);
                //    DestinatarioBLL.ExcluirDestinatario(destinatario);
                //}
                //else
                //{
                //    MessageBox.Show("Erro ao fazer operação no Destinatario");
                //}

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
            txtEmail.Clear();
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            DesbloquearCamposEndereco(tipoBloqueio);
            txtComplemento.Enabled = tipoBloqueio;
            txtCNPJ.Enabled = tipoBloqueio;
            txtInscricaoEstatudal.Enabled = tipoBloqueio;
            txtNomeRazao.Enabled = tipoBloqueio;
            txtTelefone.Enabled = tipoBloqueio;
            txtEmail.Enabled = tipoBloqueio;
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

        private async void PreencherGrid()
        {
            dataGridDestinatario.DataSource = await DestinatarioBLL.GetDestinatarioBLL();
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
    }
}
