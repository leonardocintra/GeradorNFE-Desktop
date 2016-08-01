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
        public static async Task<List<Emitente>> GetEmitenteDAO()
        {
            try
            {
                List<Emitente> _return = new List<Emitente>();
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:8000");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/emitente");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        _return = JsonConvert.DeserializeObject<List<Emitente>>(json).ToList();
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

        public static async void AdicionarEmitente(Emitente emitente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("/emitente", emitente);
            }
        }
    }
}
