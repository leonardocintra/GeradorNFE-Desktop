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
using System.IO;

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
            StreamWriter writer = new StreamWriter(@"C:\GitHub\GeradorNF-e\ArquivosGerados\arquivo1.txt");

            writer.WriteLine("NFe.CriarEnviarNFe([Identificacao]");
            writer.WriteLine("NaturezaOperacao=VENDA MERC. ADQ. NO ESTADO");
            writer.WriteLine("Modelo=55");
            writer.WriteLine("Serie=01");
            writer.WriteLine("Codigo=220724");
            writer.WriteLine("Numero=7915");
            writer.WriteLine("Emissao=08/08/2015");
            writer.WriteLine("Saida=08/08/2015");
            writer.WriteLine("Tipo=1");
            writer.WriteLine("FormaPag=0");
            writer.WriteLine("idDest =1");
            writer.WriteLine("[Emitente]");
            writer.WriteLine("CNPJ=07686218000271");
            writer.WriteLine("IE=2973957160144");
            writer.WriteLine("Razao=R. R. RIBEIRO INSUMOS AGRICOLAS LTDA");
            writer.WriteLine("Fantasia=CASA DO AGRICULTOR - FILIAL CASSIA");
            writer.WriteLine("Fone=(35)3541-2769");
            writer.WriteLine("CEP=37980000");
            writer.WriteLine("Logradouro=AVENIDA SANTA RITA");
            writer.WriteLine("Numero=720");
            writer.WriteLine("Complemento=");
            writer.WriteLine("Bairro=CENTRO");
            writer.WriteLine("CidadeCod=3115102");
            writer.WriteLine("Cidade=CASSIA");
            writer.WriteLine("UF=MG");
            writer.WriteLine("IM = ");
            writer.WriteLine("CNAE = 4683400");
            writer.WriteLine("PaisCod=1058");
            writer.WriteLine("Pais=BRASIL");
            writer.WriteLine("[Destinatario]");
            writer.WriteLine("CNPJ=72654376672");
            writer.WriteLine("indIEDest=1");
            writer.WriteLine("IE=ISENTO");
            writer.WriteLine("ISUF=");
            writer.WriteLine("NomeRazao=RODRIGO DIAS DA SILVEIRA");
            writer.WriteLine("Fone=3591780910");
            writer.WriteLine("CEP=37990000");
            writer.WriteLine("Logradouro=BARÃO DO RIO BRANCO");
            writer.WriteLine("Numero=400");
            writer.WriteLine("Complemento=");
            writer.WriteLine("Bairro=CENTRO");
            writer.WriteLine("CidadeCod=");
            writer.WriteLine("Cidade=IBIRACI");
            writer.WriteLine("UF=MG");
            writer.WriteLine("PaisCod=1058");
            writer.WriteLine("Pais=BRASIL");
            writer.WriteLine("[Produto001]");
            writer.WriteLine("CFOP=5102");
            writer.WriteLine("Codigo=110");
            writer.WriteLine("EAN=");
            writer.WriteLine("NCM=31052000");
            writer.WriteLine("Descricao=ADUBO 08.20.10 YARA");
            writer.WriteLine("Unidade=TN");
            writer.WriteLine("Quantidade=0,10");
            writer.WriteLine("ValorUnitario=1400,00");
            writer.WriteLine("ValorTotal=140,00");
            writer.WriteLine("[ICMS001]");
            writer.WriteLine("CST=40");
            writer.WriteLine("Origem=0");
            writer.WriteLine("ValorBase=0,00");
            writer.WriteLine("Aliquota=0,00");
            writer.WriteLine("Valor=0,00");
            writer.WriteLine("[PIS001]");
            writer.WriteLine("CST=06");
            writer.WriteLine("ValorBase= 0");
            writer.WriteLine("Aliquota= 0");
            writer.WriteLine("Valor= 0");
            writer.WriteLine("Quantidade= 0");
            writer.WriteLine("ValorAliquota= 0");
            writer.WriteLine("[COFINS001]");
            writer.WriteLine("CST=06");
            writer.WriteLine("Valor= 0");
            writer.WriteLine("Aliquota= 0");
            writer.WriteLine("Quantidade= 0");
            writer.WriteLine("ValorAliquota= 0");
            writer.WriteLine("ValorBase= 0");
            writer.WriteLine("[Total]");
            writer.WriteLine("BaseICMS=0,00");
            writer.WriteLine("ValorICMS=0,00");
            writer.WriteLine("ValorProduto=140,00");
            writer.WriteLine("ValorServicos=0");
            writer.WriteLine("ValorBaseISS=0");
            writer.WriteLine("ValorISSQN=0");
            writer.WriteLine("ValorNota=140,00");
            writer.WriteLine("[Transportador]");
            writer.WriteLine("FretePorConta=1");
            writer.WriteLine("CnpjCpf=");
            writer.WriteLine("IE=");
            writer.WriteLine("NomeRazao=RODRIGO DIAS DA SILVEIRA");
            writer.WriteLine("Endereco=");
            writer.WriteLine("CidadeCod=");
            writer.WriteLine("Cidade=CASSIA");
            writer.WriteLine("UF=MG");
            writer.WriteLine("ValorServico=");
            writer.WriteLine("ValorBase=");
            writer.WriteLine("Aliquota=");
            writer.WriteLine("Valor=");
            writer.WriteLine("CFOP=");
            writer.WriteLine("CidadeCod=");
            writer.WriteLine("Placa=");
            writer.WriteLine("UFPlaca=");
            writer.WriteLine("RNTC=");
            writer.WriteLine("[Volume001]");
            writer.WriteLine("Quantidade=");
            writer.WriteLine("Especie=");
            writer.WriteLine("Marca=");
            writer.WriteLine("Numeracao=");
            writer.WriteLine("PesoLiquido=");
            writer.WriteLine("PesoBruto=");
            writer.WriteLine("[Fatura]");
            writer.WriteLine("Numero= 007915");
            writer.WriteLine("ValorOriginal=140,00");
            writer.WriteLine("ValorDesconto=");
            writer.WriteLine("ValorLiquido=140,00");
            writer.WriteLine("[Duplicata001]");
            writer.WriteLine("Numero=007915-1");
            writer.WriteLine("DataVencimento=08/08/2015");
            writer.WriteLine("Valor=140,00");
            writer.WriteLine("[DadosAdicionais]");
            writer.WriteLine("Complemento=CODIGO INTERNO 36366. -; ICMS DIFERIDO CONF ART 8, ANEXO II, ITEM 25 RICMS; **");
            writer.WriteLine(",1,1)");


            writer.Close();
            writer.Dispose();
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
