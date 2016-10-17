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
            bool _return = true;

            if (string.IsNullOrEmpty(txtValorUnitario.Text))
            {
                txtValorUnitario.Text = "0";
            }

            if (txtDescricao.TextLength < 3)
            {
                _return = false;
                MessageBox.Show("Decrição do produto é obrigatório ou é menor que 3 caracteres!");
            }
            else if (txtValorUnitario.Text != string.Empty)
            {
                try
                {
                    decimal valorUnitario = Convert.ToDecimal(txtValorUnitario.Text);

                    if (valorUnitario <= 0)
                    {
                        MessageBox.Show("Valor unitário não pode ser zero ou negativo.");
                        _return = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Verifique se digitou numeros válidos no campo Valor Unitario!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorUnitario.Focus();
                    _return = false;
                }
                catch(Exception ex)
                {
                    _return = false;
                    MessageBox.Show("Erro: " + ex.Message);
                }                
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
                produto.Cliente = MyGlobals.Cliente;

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
                else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                {
                    
                    produto.Id = int.Parse(txtIdProduto.Text);
                    response = await ProdutoBLL.AtualizarProdutoBLL(produto);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Produto " + mensagemCrud + " com sucesso!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o produto! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                {
                    produto.Id = int.Parse(txtIdProduto.Text);
                    response = await ProdutoBLL.DeletarProdutoBLL(produto.Id);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Produto " + mensagemCrud + " com sucesso!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o produto! \nErro: " + response.RequestMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao fazer operação no Produto");
                }

                LimpaCampos();
                PreencherGrid();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao " + mensagemException + " o produto! \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void PreencherGrid()
        {
            dataGridProduto.DataSource = await ProdutoBLL.GetProdutoBLL();
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

        private void frmProduto_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            DesbloquearCampos(true);
            lblAcao.Text = "Editar";
            txtDescricao.Focus();
        }

        private void dataGridProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtIdProduto.Text = dataGridProduto[0, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtCFOP.Text = dataGridProduto[1, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtEAN.Text = dataGridProduto[2, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtNCM.Text = dataGridProduto[3, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtDescricao.Text = dataGridProduto[4, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtUnidade.Text = dataGridProduto[5, dataGridProduto.CurrentRow.Index].Value.ToString();
            txtValorUnitario.Text = dataGridProduto[6, dataGridProduto.CurrentRow.Index].Value.ToString();

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            DesbloquearCampos(false);
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
    }
}
