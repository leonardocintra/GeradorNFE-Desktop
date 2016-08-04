using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.Model
{
    public class Produto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("CFOP")]
        public int CFOP { get; set; }

        [JsonProperty("EAN")]
        public string EAN { get; set; }

        [JsonProperty("NCM")]
        public int NCM { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("valor_unitario")]
        public decimal ValorUnitario { get; set; }

        [JsonProperty("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
