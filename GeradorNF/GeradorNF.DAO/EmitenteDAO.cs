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
