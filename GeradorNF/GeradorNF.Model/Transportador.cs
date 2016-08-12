using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.Model
{
    public class Transportador
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("frete_por_conta")]
        public bool FretePorConta { get; set; }

        [JsonProperty("cpf_cnpj")]
        public string CPF_CNPJ { get; set; }

        [JsonProperty("inscricao_estadual")]
        public string InscricaoEstadual { get; set; }

        [JsonProperty("nome_razao")]
        public string NomeRazao { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("cidade_codigo")]
        public int? CidadeCodigo { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("cliente_id")]
        public Cliente Cliente { get; set; }
    }
}
