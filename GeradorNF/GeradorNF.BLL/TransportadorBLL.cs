using GeradorNF.DAO;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.BLL
{
    public class TransportadorBLL
    {
        public static async Task<List<Transportador>> GetTransportadorBLL()
        {
            return await TransportadorDAO.GetTransportadorDAO();
        }

        public static async Task<HttpResponseMessage> AdicionarTransportadorBLL(Transportador transportador)
        {
            if (transportador.NomeRazao == string.Empty)
                throw new Exception("Nome do transportador é obrigatório!");

            if (transportador.CPF_CNPJ == string.Empty)
                throw new Exception("CNPJ/CPF do transportador é obrigatório!");

            transportador.CPF_CNPJ = transportador.CPF_CNPJ.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            transportador.CEP = transportador.CEP.Replace("-", string.Empty);

            return await TransportadorDAO.AdicionarTransportadorDAO(transportador);
        }

        public static async Task<HttpResponseMessage> DeletarTransportadorBLL(int id)
        {
            if (id < 1)
                throw new Exception("O Transportador não pode ser zero ou negativo. Verifique");

            return await TransportadorDAO.DeletarTransportadorDAO(id);

        }

        public static async Task<HttpResponseMessage> AtualizarTransportadorBLL(Transportador transportador)
        {
            if (transportador.NomeRazao == string.Empty)
                throw new Exception("Nome do transportador é obrigatório!");

            if (transportador.CPF_CNPJ == string.Empty)
                throw new Exception("CNPJ/CNPJ do transportador é obrigatório!");

            return await TransportadorDAO.AtualizarTransportadorDAO(transportador);
        }
    }
}