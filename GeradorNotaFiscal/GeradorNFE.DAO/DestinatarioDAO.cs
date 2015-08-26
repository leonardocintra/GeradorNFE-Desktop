using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public class DestinatarioDAO
    {

        public static void DeleteDestinatario(Destinatario destinatario)
        {
            try
            {
                AbstractCrud.Delete(destinatario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir destinatario. Erro: " + ex.Message);
            }
        }

        public static void UpdateDestinatario(Destinatario destinatario)
        {
            try
            {
                AbstractCrud.Update(destinatario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o destinatario: " + ex.Message);
            }
        }

        public static void SetDestinatario(Destinatario destinatario)
        {
            try
            {
                AbstractCrud.Add(destinatario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadatrar o Destinatario: " + ex.Message);
            }
        }

        public static List<Destinatario> GetDestinatario()
        {
            List<Destinatario> _return = new List<Destinatario>();

            using (GeradorEntities context = new GeradorEntities())
            {
                return _return = context.Destinatario.ToList();
            }
        }

        public static Destinatario GetDestinatarioById(int id)
        {
            try
            {
                Destinatario destinatario = new Destinatario();
                GeradorEntities db = new GeradorEntities();

                destinatario = db.Destinatario.Where(e => e.DestinatarioId.Equals(id)).FirstOrDefault();

                return destinatario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar destinatario. \nErro: " + ex.Message);
            }
        }

        public static List<Destinatario> GetDestinatarioByParameter(string parameter)
        {
            try
            {
                List<Destinatario> listDestinatario = new List<Destinatario>();
                GeradorEntities db = new GeradorEntities();

                listDestinatario = db.Destinatario.Where(e => e.NomeRazao.Contains(parameter) || e.NomeRazao.Contains(parameter)).ToList();
                return listDestinatario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Destinatario. \nErro: " + ex.Message);
            }

        }
    }
}
