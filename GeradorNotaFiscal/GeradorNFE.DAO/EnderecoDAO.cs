using GeradorNFE.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public class EnderecoDAO
    {
        public static Endereco GetDadosCEP(string cep)
        {
            Endereco endereco = new Endereco();

            cep = cep.Replace("-", string.Empty);
            try
            {
                HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create(String.Format("http://viacep.com.br/ws/{0}/json/", cep));
                HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
                int cont;
                byte[] buffer = new byte[1000];
                StringBuilder sb = new StringBuilder();
                string temp;
                Stream stream = resposta.GetResponseStream();
                do
                {
                    cont = stream.Read(buffer, 0, buffer.Length);
                    temp = Encoding.Default.GetString(buffer, 0, cont).Trim();
                    sb.Append(temp);
                } while (cont > 0);

                string retornoUTF8 = sb.ToString();
                byte[] bytes = Encoding.Default.GetBytes(retornoUTF8);
                retornoUTF8 = Encoding.UTF8.GetString(bytes);

                endereco = JsonConvert.DeserializeObject<Endereco>(retornoUTF8);
                return endereco;
            }
            catch (JsonException ex)
            {
                throw new Exception("Ocorreu erro no JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao buscar CEP: " + ex.Message);
            }

        }
    }
}
