using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.Model
{
    public class Emitente
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("nome_razao")]
        public string RazaoSocial { get; set; }

        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
