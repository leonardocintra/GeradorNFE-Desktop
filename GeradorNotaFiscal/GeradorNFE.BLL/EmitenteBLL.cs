using GeradorNFE.DAO;
using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.BLL
{
    public class EmitenteBLL
    {

        public static void ExcluirEmitente(Emitente emitente)
        {
            if (emitente.EmitenteId > 0)
                EmitenteDAO.DeleteEmitente(emitente);
            else
                throw new Exception("ID do emitente inválido para exclusão");
        }

        public static void CadastrarEmitente(Emitente emitente)
        {
            ValidaInformacoesEmitente(emitente);
            EmitenteDAO.SetEmitente(emitente);
        }

        public static void AtualizarEmitente(Emitente emitente)
        {
            ValidaInformacoesEmitente(emitente);
            EmitenteDAO.UpdateEmitente(emitente);
        }

        public static List<Emitente> BuscarEmitente()
        {
            return EmitenteDAO.GetEmitente();
        }

        public static Emitente BuscarEmitenteById(int id)
        {
            if (id > 0)
                return EmitenteDAO.GetEmitenteById(id);
            else
                return null;
        }

        public static List<Emitente> BuscarEmitenteComParametro(string parametro)
        {
            if (parametro != string.Empty)
                return EmitenteDAO.GetEmitenteByParameter(parametro);
            else
                return EmitenteDAO.GetEmitente();
        }

        private static void ValidaInformacoesEmitente(Emitente emitente)
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
