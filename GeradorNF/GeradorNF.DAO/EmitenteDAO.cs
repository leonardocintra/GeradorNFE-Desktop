using GeradorNF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.DAO
{
    public class EmitenteDAO
    {
        /// <summary>
        /// GetEmitente - Buscar/Listar TODOS os Emitentes
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Emitente>> GetEmitenteDAO()
        {
            try
            {
                List<Emitente> _return = new List<Emitente>();
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UtilDAO.UrlApi());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/emitente");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        _return = JsonConvert.DeserializeObject<List<Emitente>>(json).ToList();
                    }
                    else
                    {
                        throw new Exception("Erro ao buscar os Emitentes. Erro:" + response.RequestMessage);
                    }
                }

                return _return;
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel buscar os Emitentes. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel buscar os Emitentes. Erro: " + ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Exception - Não foi possivel buscar os Emitentes. Erro: " + ex.Message);
            }

        }

        /// <summary>
        /// AdicionarEmiente - Adicionar/Cadastra um novo Emitente
        /// </summary>
        /// <param name="emitente"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AdicionarEmitenteDAO(Emitente emitente)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UtilDAO.UrlApi());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress.AbsolutePath + "emitente/" , emitente);
                    return response;
                }
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel salvar esse emitente. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel salvar esse emitente.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel salvar esse emitente. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// DeltarEmitente - Excluir um emitente
        /// </summary>
        /// <param name="id">id do Emitente</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletarEmitenteDAO(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UtilDAO.UrlApi());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress.AbsolutePath + String.Format("emitente/{0}", id));
                    return response;
                }
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel deletar esse emitente. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel deletar esse emitente.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel deletar esse emitente. Erro: " + ex.Message);
            }
        }

        public static async Task<HttpResponseMessage> AtualizarEmitenteDAO(Emitente emitente)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UtilDAO.UrlApi());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress.AbsolutePath + String.Format("emitente/{0}/", emitente.Id), emitente);
                    return response;
                }
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel atualizar esse emitente. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi atualizar deletar esse emitente.. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel atualizar esse emitente. Erro: " + ex.Message);
            }
        }
    }
}
