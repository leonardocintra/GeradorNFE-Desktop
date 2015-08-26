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
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        #region botoes
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            txtDescricao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposObrigatorios())
            {
                if (lblAcao.Text.Equals("Editar"))
                    SetProduto(Enuns.TipoCrud.update);
                else
                    SetProduto(Enuns.TipoCrud.novo);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            DesbloquearCampos(true);
            lblAcao.Text = "Editar";
            txtDescricao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir esse Produto?", "Exluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetProduto(Enuns.TipoCrud.delete);
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
                dataGridProduto.DataSource = ProdutoBLL.BuscarProdutoComParametro(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ValidaValorDecinal(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1 || (sender as TextBox).Text == string.Empty)
                    e.Handled = true;
            }

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region Metodos Privados
        private void SetProduto(Enuns.TipoCrud tipoCrud)
        {
            Produto produto = new Produto();

            string mensagemException = Utilidade.GetMensagemParaException(tipoCrud);
            string mensagemCrud = Utilidade.GetMensagemParaCrud(tipoCrud);

            try
            {
                #region set parameters
                produto.Descricao = txtDescricao.Text;
                produto.CFOP = Convert.ToInt32(txtCFOP.Text);
                produto.EAN = txtEAN.Text;
                produto.NCM = Convert.ToInt64(txtNCM.Text);
                produto.Unidade = txtUnidade.Text;
                produto.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);

                #endregion

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    ProdutoBLL.CadastrarProduto(produto);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    produto.ProdutoId = int.Parse(txtIdProduto.Text);
                    ProdutoBLL.AtualizarProduto(produto);

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    produto.ProdutoId = int.Parse(txtIdProduto.Text);
                    ProdutoBLL.ExcluirProduto(produto);
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Produto");
                }

                MessageBox.Show("Produto " + mensagemCrud + " com sucesso!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpaCampos();
                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o produto! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpaCampos()
        {
            txtCFOP.Clear();
            txtDescricao.Clear();
            txtEAN.Clear();
            txtFiltro.Clear();
            txtIdProduto.Clear();
            txtNCM.Clear();
            txtUnidade.Clear();
            txtValorUnitario.Clear();
        }

        private void DesbloquearCampos(bool tipoBloqueio)
        {
            txtCFOP.Enabled = tipoBloqueio;
            txtDescricao.Enabled = tipoBloqueio;
            txtEAN.Enabled = tipoBloqueio;
            txtFiltro.Enabled = tipoBloqueio;
            txtIdProduto.Enabled = tipoBloqueio;
            txtNCM.Enabled = tipoBloqueio;
            txtUnidade.Enabled = tipoBloqueio;
            txtValorUnitario.Enabled = tipoBloqueio;
        }

        private void PreencherGrid()
        {
            dataGridProduto.DataSource = ProdutoBLL.BuscarProduto();
        }

        private void VerificaSePrimeiroRegistro()
        {
            if (dataGridProduto.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhum produto cadastrado ainda! \n Faça o primeiro cadastro!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
            }
        }

        private bool VerificarCamposObrigatorios()
        {
            bool _return;

            if (string.IsNullOrEmpty(txtValorUnitario.Text))
            {
                txtValorUnitario.Text = "0";
            }

            if (txtDescricao.TextLength < 3)
            {
                _return = false;
                MessageBox.Show("Decrição do produto é obrigatório ou é menor que 3 caracteres!");
            }
            else if(Convert.ToDecimal(txtValorUnitario.Text) <= 0)
            {
                _return = false;
                MessageBox.Show("Valor unitário não pode ser zero ou negativo.");
            }
            else
            {
                _return = true;
            }

            return _return;
        }
        #endregion

        private void frmProduto_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }

        private void dataGridProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DesbloquearCampos(false);
            btnEditar.Enabled = true;
            try
            {
                txtIdProduto.Text = dataGridProduto[0, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtCFOP.Text = dataGridProduto[1, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtEAN.Text = dataGridProduto[2, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtNCM.Text = dataGridProduto[3, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtDescricao.Text = dataGridProduto[4, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtUnidade.Text = dataGridProduto[5, dataGridProduto.CurrentRow.Index].Value.ToString();
                txtValorUnitario.Text = dataGridProduto[6, dataGridProduto.CurrentRow.Index].Value.ToString();
            }
            catch
            {
            }
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecinal(sender, e);
        }
    }
}
