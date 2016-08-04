using GeradorNF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.DAO
{
    public class ProdutoDAO
    {
        /// <summary>
        /// Buscar/Listar todos os produtos
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Produto>> GetProdutoDAO()
        {
            try
            {
                return await AbstractCrud.GetAll<Produto>("produto");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel buscar os Produtos. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel buscar os Produtos. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel buscar os Produtos. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Cadatrar um novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AdicionarProdutoDAO(Produto produto)
        {
            try
            {
                return await AbstractCrud.Add(produto, "produto");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel salvar esse produto. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel salvar esse produto.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel salvar esse produto. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletar um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletarProdutoDAO(int id)
        {
            try
            {
                return await AbstractCrud.Delete(id, "produto");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel deletar esse produto. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel deletar esse produto.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel deletar esse produto. Erro: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Atualizar/Editar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AtualizarProdutoDAO(Produto produto)
        {
            try
            {
                return await AbstractCrud.Update(produto, "produto", produto.Id);
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel atualizar esse produto. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi atualizar deletar esse produto.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel atualizar esse produto. Erro: " + ex.Message);
            }
        }
    }
}
