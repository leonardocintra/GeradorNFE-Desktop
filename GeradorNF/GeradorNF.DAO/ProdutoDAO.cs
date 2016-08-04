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
    }
}
