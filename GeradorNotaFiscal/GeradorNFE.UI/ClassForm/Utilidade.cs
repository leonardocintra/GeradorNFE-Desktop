using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.UI.ClassForm
{
    public class Utilidade
    {

        public static string GetMensagemParaException(Enuns.TipoCrud tipoCrud)
        {
            string mensagem = string.Empty;
            if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                mensagem = "cadastrar";
            else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                mensagem = "atualizar";
            else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                mensagem = "excluir";
            else
                mensagem = "executar alguma ação não informada";

            return mensagem;
        }

        public static string GetMensagemParaCrud(Enuns.TipoCrud tipoCrud)
        {
            string mensagem = string.Empty;
            if (tipoCrud.Equals(Enuns.TipoCrud.novo))
                mensagem = "cadastrado";
            else if (tipoCrud.Equals(Enuns.TipoCrud.update))
                mensagem = "atualizado";
            else if (tipoCrud.Equals(Enuns.TipoCrud.delete))
                mensagem = "excluído";
            else
                mensagem = "executar alguma ação não informada";

            return mensagem;
        }
    }
}
