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
    public class EmitenteBLL
    {
        public static async Task<List<Emitente>> GetEmitenteBLL()
        {
            return await EmitenteDAO.GetEmitenteDAO();
        }

        public static async Task<HttpResponseMessage> AdicionarEmitenteBLL(Emitente emitente)
        {
            if (emitente.NomeFantasia == string.Empty)
                throw new Exception("Nome do emitente é obrigatório!");

            if (emitente.CNPJ == string.Empty)
                throw new Exception("CNPJ do emitente é obrigatório!");

            emitente.Pais = "BRASIL";
            emitente.PaisCodigo = 1058;

            return await EmitenteDAO.AdicionarEmitenteDAO(emitente);
        }
    }
}
