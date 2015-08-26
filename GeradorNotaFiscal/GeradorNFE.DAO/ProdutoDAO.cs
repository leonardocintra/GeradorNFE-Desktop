using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public class ProdutoDAO
    {

        public static void DeleteProduto(Produto produto)
        {
            try
            {
                AbstractCrud.Delete(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto. Erro: " + ex.Message);
            }
        }

        public static void UpdateProduto(Produto produto)
        {
            try
            {
                AbstractCrud.Update(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o produto: " + ex.Message);
            }
        }

        public static void SetProduto(Produto produto)
        {
            try
            {
                AbstractCrud.Add(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadatrar o Produto: " + ex.Message);
            }
        }

        public static List<Produto> GetProduto()
        {
            List<Produto> _return = new List<Produto>();

            using (GeradorEntities context = new GeradorEntities())
            {
                return _return = context.Produto.ToList();
            }
        }

        public static Produto GetProdutoById(int id)
        {
            try
            {
                Produto produto = new Produto();
                GeradorEntities db = new GeradorEntities();

                produto = db.Produto.Where(e => e.ProdutoId.Equals(id)).FirstOrDefault();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar produto. \nErro: " + ex.Message);
            }
        }

        public static List<Produto> GetProdutoByParameter(string parameter)
        {
            try
            {
                List<Produto> listProduto = new List<Produto>();
                GeradorEntities db = new GeradorEntities();

                listProduto = db.Produto.Where(e => e.Descricao.Contains(parameter)).ToList();
                return listProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Produto. \nErro: " + ex.Message);
            }

        }
    }
}
