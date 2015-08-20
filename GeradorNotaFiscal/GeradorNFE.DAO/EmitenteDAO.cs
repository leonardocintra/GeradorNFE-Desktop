using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public class EmitenteDAO
    {
        public static void DeleteEmitente(Emitente emitente)
        {
            try
            {
                AbstractCrud.Delete(emitente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir emitente. Erro: " + ex.Message);
            }
        }

        public static void UpdateEmitente(Emitente emitente)
        {
            try
            {
                AbstractCrud.Update(emitente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o emitente: " + ex.Message);
            }
        }

        public static void SetEmitente(Emitente emitente)
        {
            try
            {
                AbstractCrud.Add(emitente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadatrar o Emitente: " + ex.Message);
            }
        }

        public static List<Emitente> GetEmitente()
        {
            List<Emitente> _return = new List<Emitente>();

            using (GeradorEntities context = new GeradorEntities())
            {
                return _return = context.Emitente.ToList();
            }
        }

        public static Emitente GetEmitenteById(int id)
        {
            try
            {
                Emitente emitente = new Emitente();
                GeradorEntities db = new GeradorEntities();

                emitente = db.Emitente.Where(e => e.EmitenteId.Equals(id)).FirstOrDefault();

                return emitente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar emitente. \nErro: " + ex.Message);
            }
        }

        public static List<Emitente> GetEmitenteByParameter(string parameter)
        {
            try
            {
                List<Emitente> listEmitente = new List<Emitente>();
                GeradorEntities db = new GeradorEntities();

                listEmitente = db.Emitente.Where(e => e.NomeFantasia.Contains(parameter) || e.NomeRazao.Contains(parameter)).ToList();
                return listEmitente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Emitente. \nErro: " + ex.Message);
            }

        }
    }
}
