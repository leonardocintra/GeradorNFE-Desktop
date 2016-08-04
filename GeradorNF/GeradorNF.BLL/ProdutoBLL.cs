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
        public static async Task<HttpResponseMessage> AdicionarProdutoBLL(Produto produto)
        {
            if (produto.Descricao == string.Empty)
                throw new Exception("Nome do produto é obrigatório!");

            return await ProdutoDAO.AdicionarProdutoDAO(produto);
        }
    }
}
