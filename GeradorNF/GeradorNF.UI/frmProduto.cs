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
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            DesbloquearCampos(true);
            lblAcao.Text = "Novo";
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            txtDescricao.Focus();
        }

        #region private methods
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
            txtNCM.Enabled = tipoBloqueio;
            txtUnidade.Enabled = tipoBloqueio;
            txtValorUnitario.Enabled = tipoBloqueio;
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
            else if (Convert.ToDecimal(txtValorUnitario.Text) <= 0)
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

        private async void SetProduto(Enuns.TipoCrud tipoCrud)
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
                produto.NCM = Convert.ToInt32(txtNCM.Text);
                produto.Unidade = txtUnidade.Text;
                produto.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);

                #endregion

                HttpResponseMessage response = new HttpResponseMessage();

                if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                {
                    response = await ProdutoBLL.AdicionarProdutoBLL(produto);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Produto " + mensagemCrud + " com sucesso!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o produto! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                //else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                //{
                //    produto.ProdutoId = int.Parse(txtIdProduto.Text);
                //    ProdutoBLL.AtualizarProduto(produto);

                //}
                //else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                //{
                //    produto.ProdutoId = int.Parse(txtIdProduto.Text);
                //    ProdutoBLL.ExcluirProduto(produto);
                //}
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


        private void PreencherGrid()
        {
            //dataGridProduto.DataSource = ProdutoBLL.BuscarProduto();
        }
        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposObrigatorios())
            {
                if (lblAcao.Text.Equals("Editar"))
                    SetProduto(Enuns.TipoCrud.update);
                else
                    SetProduto(Enuns.TipoCrud.novo);
            }
            btnSalvar.Enabled = true;
        }
    }
}
