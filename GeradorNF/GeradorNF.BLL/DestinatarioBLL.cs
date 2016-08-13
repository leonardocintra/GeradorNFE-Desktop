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
    public class DestinatarioBLL
    {
        public static async Task<List<Destinatario>> GetDestinatarioBLL()
        {
            return await DestinatarioDAO.GetDestinatarioDAO();
        }

        public static async Task<HttpResponseMessage> AdicionarDestinatarioBLL(Destinatario destinatario)
        {
            if (destinatario.NomeRazao == string.Empty)
                throw new Exception("Nome do destinatario é obrigatório!");

            if (destinatario.CNPJ == string.Empty)
                throw new Exception("CNPJ do destinatario é obrigatório!");

            destinatario.Pais = "BRASIL";
            destinatario.PaisCodigo = 1058;

            return await DestinatarioDAO.AdicionarDestinatarioDAO(destinatario);
        }

        public static async Task<HttpResponseMessage> DeletarDestinatarioBLL(int id)
        {
            if (id < 1)
                throw new Exception("O Destinatario não pode ser zero ou negativo. Verifique");

            return await DestinatarioDAO.DeletarDestinatarioDAO(id);

        }

        public static async Task<HttpResponseMessage> AtualizarDestinatarioBLL(Destinatario destinatario)
        {
            if (destinatario.NomeRazao == string.Empty)
                throw new Exception("Nome do destinatario é obrigatório!");

            if (destinatario.CNPJ == string.Empty)
                throw new Exception("CNPJ do destinatario é obrigatório!");

            destinatario.Pais = "BRASIL";
            destinatario.PaisCodigo = 1058;

            return await DestinatarioDAO.AtualizarDestinatarioDAO(destinatario);
        }
    }
}
