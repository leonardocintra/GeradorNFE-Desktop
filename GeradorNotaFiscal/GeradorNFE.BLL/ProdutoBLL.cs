using GeradorNFE.DAO;
using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.BLL
{
    public class ProdutoBLL
    {
        public static void ExcluirProduto(Produto produto)
        {
            if (produto.ProdutoId > 0)
                ProdutoDAO.DeleteProduto(produto);
            else
                throw new Exception("ID do produto inválido para exclusão");
        }

        public static void CadastrarProduto(Produto produto)
        {
            ValidaInformacoesProduto(produto);
            ProdutoDAO.SetProduto(produto);
        }

        public static void AtualizarProduto(Produto produto)
        {
            ValidaInformacoesProduto(produto);
            ProdutoDAO.UpdateProduto(produto);
        }

        public static List<Produto> BuscarProduto()
        {
            return ProdutoDAO.GetProduto();
        }

        public static Produto BuscarProdutoById(int id)
        {
            if (id > 0)
                return ProdutoDAO.GetProdutoById(id);
            else
                return null;
        }

        public static List<Produto> BuscarProdutoComParametro(string parametro)
        {
            if (parametro != string.Empty)
                return ProdutoDAO.GetProdutoByParameter(parametro);
            else
                return ProdutoDAO.GetProduto();
        }

        private static void ValidaInformacoesProduto(Produto produto)
        {

        }
    }
}
