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
    public class DestinatarioDAO
    {
        /// <summary>
        /// GetDestinatario - Buscar/Listar TODOS os Destinatarios
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Destinatario>> GetDestinatarioDAO()
        {
            try
            {
                return await AbstractCrud.GetAll<Destinatario>("destinatario");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel buscar os Destinatarios. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel buscar os Destinatarios. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel buscar os Destinatarios. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// AdicionarEmiente - Adicionar/Cadastra um novo Destinatario
        /// </summary>
        /// <param name="destinatario"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AdicionarDestinatarioDAO(Destinatario destinatario)
        {
            try
            {
                return await AbstractCrud.Add(destinatario, "destinatario");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel salvar esse destinatario. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel salvar esse destinatario.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel salvar esse destinatario. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// DeltarDestinatario - Excluir um destinatario
        /// </summary>
        /// <param name="id">id do Destinatario</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletarDestinatarioDAO(int id)
        {
            try
            {
                return await AbstractCrud.Delete(id, "destinatario");
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel deletar esse destinatario. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel deletar esse destinatario.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel deletar esse destinatario. Erro: " + ex.Message);
            }
        }

        public static async Task<HttpResponseMessage> AtualizarDestinatarioDAO(Destinatario destinatario)
        {
            try
            {
                return await AbstractCrud.Update(destinatario, "destinatario", destinatario.Id);
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel atualizar esse destinatario. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi atualizar deletar esse destinatario.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel atualizar esse destinatario. Erro: " + ex.Message);
            }
        }
    }
}
