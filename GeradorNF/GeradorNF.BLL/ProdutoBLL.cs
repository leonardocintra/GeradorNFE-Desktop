using GeradorNF.DAO;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.BLL
{
    public class ProdutoBLL
    {
        public static async Task<List<Produto>> GetProdutoBLL()
        {
            return await ProdutoDAO.GetProdutoDAO();
        }

        public static async Task<HttpResponseMessage> AdicionarProdutoBLL(Produto produto)
        {
            if (produto.Descricao == string.Empty)
                throw new Exception("Nome do produto é obrigatório!");

            return await ProdutoDAO.AdicionarProdutoDAO(produto);
        }

        public static async Task<HttpResponseMessage> DeletarProdutoBLL(int id)
        {
            if (id < 1)
                throw new Exception("O Produto não pode ser zero ou negativo. Verifique");

            return await ProdutoDAO.DeletarProdutoDAO(id);

        }

        public static async Task<HttpResponseMessage> AtualizarProdutoBLL(Produto produto)
        {
            if (produto.Descricao == string.Empty)
                throw new Exception("Nome do produto é obrigatório!");

            return await ProdutoDAO.AtualizarProdutoDAO(produto);
        }
    }
}
