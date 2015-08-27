using GeradorNFE.BLL;
using GeradorNFE.Model;
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
    public partial class frmGeradorArquivo : Form
    {
        List<MontaProduto> listMontaProduto = new List<MontaProduto>();

        public frmGeradorArquivo()
        {
            InitializeComponent();
        }

        private void frmGeradorArquivo_Load(object sender, EventArgs e)
        {
            PreencherComboDestinatario();
            PreencherComboEmitente();
            PreencherComboProduto();
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto = ProdutoBLL.BuscarProdutoById(Convert.ToInt32(txtCodigoProduto.Text));

            if (Convert.ToInt32(txtQuantidade.Text) <= 0)
                txtQuantidade.Text = "0";

            
            MontaProduto montaProduto = new MontaProduto();
            montaProduto.CodigoProduto = produto.ProdutoId;
            montaProduto.DescricaoProduto = produto.Descricao;
            montaProduto.ValorUnitarioProduto = produto.ValorUnitario;
            montaProduto.ValorTotalProduto = Convert.ToInt32(txtQuantidade.Text) * produto.ValorUnitario;
            listMontaProduto.Add(montaProduto);

            decimal valorTotal = Convert.ToDecimal(lblValorTotalNfe.Text.Replace("R$", string.Empty).Trim()) + montaProduto.ValorTotalProduto;
            lblValorTotalNfe.Text = valorTotal.ToString("C");

            var bindingList = new BindingList<MontaProduto>(listMontaProduto);
            var souce = new BindingSource(bindingList, null);

            gridProduto.DataSource = souce;
        }


        #region Preenchimento Combobox
        private void PreencherComboDestinatario()
        {
            cbxDestinatario.DataSource = DestinatarioBLL.BuscarDestinatario();
            cbxDestinatario.ValueMember = "DestinatarioId";
            cbxDestinatario.DisplayMember = "NomeRazao";
        }

        private void PreencherComboEmitente()
        {
            cbxEmitente.DataSource = EmitenteBLL.BuscarEmitente();
            cbxEmitente.ValueMember = "EmitenteId";
            cbxEmitente.DisplayMember = "NomeRazao";
        }

        private void PreencherComboProduto()
        {
            cbxProduto.DataSource = ProdutoBLL.BuscarProduto();
            cbxProduto.ValueMember = "ProdutoId";
            cbxProduto.DisplayMember = "Descricao";
        }

        #endregion

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {

        }

        private void cbxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoProduto.Text = cbxProduto.SelectedValue.ToString();
        }

        private void gridProduto_DoubleClick(object sender, EventArgs e)
        {
            // TO DO: remove linha
            MessageBox.Show("A função de remover o produto com 2 cliques ainda não foi implementada");
        }
    }

    class MontaProduto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorUnitarioProduto { get; set; }
        public decimal ValorTotalProduto { get; set; }
    }
}
