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
    public class ClienteDAO
    {
        /// <summary>
        /// GetCliente - Buscar/Listar TODOS os Emitentes
        /// </summary>
        /// <returns></returns>
        public static async Task<Cliente> GetClienteByIdDAO(string nomeUsuario)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UtilDAO.UrlApi());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("cliente/" + nomeUsuario);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Cliente>(json);
                    }
                    else
                        throw new Exception(response.RequestMessage.ToString());
                }
            }
            catch (JsonException ex)
            {
                throw new Exception("JsonException - Não foi possivel buscar o cliente. Erro: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HttpRequestException - Não foi possivel buscar o cliente. Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception - Não foi possivel buscar os Emitentes. Erro: " + ex.Message);
            }
        }
    }
}
