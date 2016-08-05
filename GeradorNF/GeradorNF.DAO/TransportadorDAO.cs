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
    public class TransportadorDAO
    {
        /// <summary>
        /// GetTransportador - Buscar/Listar TODOS os Transportadors
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Transportador>> GetTransportadorDAO()
        {
            try
            {
                return await AbstractCrud.GetAll<Transportador>("transportador");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel buscar os Transportadors. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel buscar os Transportadors. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel buscar os Transportadors. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// AdicionarEmiente - Adicionar/Cadastra um novo Transportador
        /// </summary>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AdicionarTransportadorDAO(Transportador transportador)
        {
            try
            {
                return await AbstractCrud.Add(transportador, "transportador");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel salvar esse transportador. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel salvar esse transportador.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel salvar esse transportador. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// DeltarTransportador - Excluir um transportador
        /// </summary>
        /// <param name="id">id do Transportador</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletarTransportadorDAO(int id)
        {
            try
            {
                return await AbstractCrud.Delete(id, "transportador");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel deletar esse transportador. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel deletar esse transportador.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel deletar esse transportador. Erro: " + ex.Message);
            }
        }

        public static async Task<HttpResponseMessage> AtualizarTransportadorDAO(Transportador transportador)
        {
            try
            {
                return await AbstractCrud.Update(transportador, "transportador", transportador.Id);
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel atualizar esse transportador. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi atualizar deletar esse transportador.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel atualizar esse transportador. Erro: " + ex.Message);
            }
        }
    }
}
