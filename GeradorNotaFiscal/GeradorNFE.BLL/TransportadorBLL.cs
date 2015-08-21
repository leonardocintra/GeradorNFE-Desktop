using GeradorNFE.DAO;
using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.BLL
{
    public class TransportadorBLL
    {

        public static void ExcluirTransportador(Transportador transportador)
        {
            if (transportador.TransportadorId > 0)
                TransportadorDAO.DeleteTransportador(transportador);
            else
                throw new Exception("ID do transportador inválido para exclusão");
        }

        public static void CadastrarTransportador(Transportador transportador)
        {
            ValidaInformacoesTransportador(transportador);
            TransportadorDAO.SetTransportador(transportador);
        }

        public static void AtualizarTransportador(Transportador transportador)
        {
            ValidaInformacoesTransportador(transportador);
            TransportadorDAO.UpdateTransportador(transportador);
        }

        public static List<Transportador> BuscarTransportador()
        {
            return TransportadorDAO.GetTransportador();
        }

        public static Transportador BuscarTransportadorById(int id)
        {
            if (id > 0)
                return TransportadorDAO.GetTransportadorById(id);
            else
                return null;
        }

        public static List<Transportador> BuscarTransportadorComParametro(string parametro)
        {
            if (parametro != string.Empty)
                return TransportadorDAO.GetTransportadorByParameter(parametro);
            else
                return TransportadorDAO.GetTransportador();
        }

        private static void ValidaInformacoesTransportador(Transportador transportador)
        {
            string cnpjCpf = transportador.CNPJCPF.ToString()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)
                .Replace("/", string.Empty)
                .Trim();

            if (cnpjCpf.Length.Equals(11))
            {
                if (!Util.ValidaCPF.IsCpf(transportador.CNPJCPF.ToString()))
                    throw new Exception("CPF inválido! Verifique e tente novamente");
            }
            else if (cnpjCpf.Length.Equals(14))
            {
                if (!Util.ValidaCNPJ.IsCnpj(transportador.CNPJCPF.ToString()))
                    throw new Exception("CNPJ inválido! Verifique e tente novamente");
            }
            else
            {
                throw new Exception("CNPJ / CPF inválido! Verifique e tente novamente");
            }

            if (transportador.NomeRazao == string.Empty)
                throw new Exception("Nome Razão é obrigatório");

            if (transportador.Endereco == string.Empty)
                throw new Exception("Endereço/Logradouro é obrigatório!");

            if (transportador.Cidade == string.Empty)
                throw new Exception("Nome da cidade é obrigatório");

            if(transportador.Aliquota != 0 || transportador.ValorBase != 0 || transportador.ValorServico != 0 && transportador.Valor == 0)
                throw new Exception("Erro no calculo do valor da NF. Verifique.");

            if(transportador.Valor > 0)
                throw new Exception("Erro no calculo do valor da NF. \nAtualmente o sistema apenas gera um simples arquivo com os valores dos impostos = 0 (zero). \n Caso precise entre em contato com o desenvolvedor no email abaixo: \n leonardo.ncintra@outlook.com");
        }
    }
}
