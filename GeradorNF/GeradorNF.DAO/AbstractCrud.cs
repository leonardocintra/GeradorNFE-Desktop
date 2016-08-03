using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.DAO
{
    public static class AbstractCrud
    {
        public static async Task<List<E>> GetAll<E>(string entityURL) where E: class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UtilDAO.UrlApi());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/" + entityURL);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<E>>(json).ToList();
                }
                else
                    return null;
            }
        }


        public static async Task<HttpResponseMessage> Add<E>(E entity, string entityURL) where E : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UtilDAO.UrlApi());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlEndPoint = client.BaseAddress.AbsoluteUri + entityURL + "/";

                HttpResponseMessage response = await client.PostAsJsonAsync(urlEndPoint, entity);
                return response;
            }
        }

        public static async Task<HttpResponseMessage> Update<E>(E entity, string entityURL, int id) where E: class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UtilDAO.UrlApi());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlEndPoint = client.BaseAddress.AbsoluteUri + entityURL + "/" + id.ToString() + "/";

                HttpResponseMessage response = await client.PutAsJsonAsync(urlEndPoint, entity);
                return response;
            }
        }

        public static async Task<HttpResponseMessage> Delete(int id, string entityURL)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UtilDAO.UrlApi());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlEndPoint = client.BaseAddress.AbsoluteUri + entityURL + "/" + id.ToString();

                HttpResponseMessage response = await client.DeleteAsync(urlEndPoint);
                return response;
            }
        }
    }
}
