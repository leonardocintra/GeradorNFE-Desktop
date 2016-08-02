using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.Model
{
    public class TransportadorContrato
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("valor_servico")]
        public decimal ValorServico { get; set; }

        [JsonProperty("valor_base")]
        public decimal ValorBase { get; set; }

        [JsonProperty("aliquota")]
        public decimal Aliquota { get; set; }

        [JsonProperty("valor_total")]
        public decimal ValorTotal { get; set; }

        [JsonProperty("CFOP")]
        public string CFOP { get; set; }

        [JsonProperty("cidade_codigo_placa")]
        public int CidadeCodigoPlaca { get; set; }

        [JsonProperty("RNTC")]
        public string RNTC { get; set; }


        [JsonProperty("transportador_id")]
        public Transportador Transportador { get; set; }
    }
}
