using GeradorNF.DAO;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.BLL
{
    public class EnderecoBLL
    {
        public Endereco BuscarDadosCEP(string cep)
        {
            cep = cep.Replace("-", string.Empty);

            if (cep.Length.Equals(8))
                return EnderecoDAO.GetDadosCEP(cep);
            else
                throw new Exception("CEP Inválido! Verifique e tente novamente");
        }
    }
}
