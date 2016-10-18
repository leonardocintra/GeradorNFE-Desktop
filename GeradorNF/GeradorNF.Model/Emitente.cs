using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GeradorNF.Model
{
    public class Emitente : INotifyPropertyChanged
    {
        private string _razaoSocial;
        private string _logradouro;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("inscricao_estadual")]
        public string InscricaoEstadual { get; set; }

        [JsonProperty("nome_razao")]
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set
            {
                if (_razaoSocial != value)
                {
                    _razaoSocial = value;
                    RaiseProperyChanged("RazaoSocial");
                }
            }
        }

        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("fone")]
        public string Fone { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro
        {
            get { return _logradouro; }
            set
            {
                if (_logradouro != value)
                {
                    _logradouro = value;
                    RaiseProperyChanged("Logradouro");
                }
            }
        }

        [JsonProperty("numero_casa")]
        public string NumeroCasa { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cidade_codigo")]
        public int? CidadeCodigo { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("im")]
        public string IM { get; set; }

        [JsonProperty("cnae")]
        public string CNAE { get; set; }

        [JsonProperty("pais_codigo")]
        public int PaisCodigo { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
