using GeradorNFE.DAO;
using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.BLL
{
    public class DestinatarioBLL
    {
        public static void ExcluirDestinatario(Destinatario emitente)
        {
            if (emitente.DestinatarioId > 0)
                DestinatarioDAO.DeleteDestinatario(emitente);
            else
                throw new Exception("ID do emitente inválido para exclusão");
        }

        public static void CadastrarDestinatario(Destinatario emitente)
        {
            ValidaInformacoesDestinatario(emitente);
            DestinatarioDAO.SetDestinatario(emitente);
        }

        public static void AtualizarDestinatario(Destinatario emitente)
        {
            ValidaInformacoesDestinatario(emitente);
            DestinatarioDAO.UpdateDestinatario(emitente);
        }

        public static List<Destinatario> BuscarDestinatario()
        {
            return DestinatarioDAO.GetDestinatario();
        }

        public static Destinatario BuscarDestinatarioById(int id)
        {
            if (id > 0)
                return DestinatarioDAO.GetDestinatarioById(id);
            else
                return null;
        }

        public static List<Destinatario> BuscarDestinatarioComParametro(string parametro)
        {
            if (parametro != string.Empty)
                return DestinatarioDAO.GetDestinatarioByParameter(parametro);
            else
                return DestinatarioDAO.GetDestinatario();
        }

        private static void ValidaInformacoesDestinatario(Destinatario emitente)
        {
            if (!Util.ValidaCNPJ.IsCnpj(emitente.CNPJ.ToString()))
                throw new Exception("CNPJ inválido! Verifique e tente novamente");

            if (emitente.NomeRazao == string.Empty)
                throw new Exception("Nome Razão é obrigatório");

            if (emitente.Logradouro == string.Empty)
                throw new Exception("Endereço/Logradouro é obrigatório!");

            if (emitente.Cidade == string.Empty)
                throw new Exception("Nome da cidade é obrigatório");
        }
    }
}
