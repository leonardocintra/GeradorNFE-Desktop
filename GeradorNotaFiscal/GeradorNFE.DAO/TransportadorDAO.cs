using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public class TransportadorDAO
    {

        public static void DeleteTransportador(Transportador transportador)
        {
            try
            {
                AbstractCrud.Delete(transportador);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir transportador. Erro: " + ex.Message);
            }
        }

        public static void UpdateTransportador(Transportador transportador)
        {
            try
            {
                AbstractCrud.Update(transportador);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o transportador: " + ex.Message);
            }
        }

        public static void SetTransportador(Transportador transportador)
        {
            try
            {
                AbstractCrud.Add(transportador);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadatrar o Transportador: " + ex.Message);
            }
        }

        public static List<Transportador> GetTransportador()
        {
            List<Transportador> _return = new List<Transportador>();

            using (GeradorEntities context = new GeradorEntities())
            {
                return _return = context.Transportador.ToList();
            }
        }

        public static Transportador GetTransportadorById(int id)
        {
            try
            {
                Transportador transportador = new Transportador();
                GeradorEntities db = new GeradorEntities();

                transportador = db.Transportador.Where(e => e.TransportadorId.Equals(id)).FirstOrDefault();

                return transportador;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar transportador. \nErro: " + ex.Message);
            }
        }

        public static List<Transportador> GetTransportadorByParameter(string parameter)
        {
            try
            {
                List<Transportador> listTransportador = new List<Transportador>();
                GeradorEntities db = new GeradorEntities();

                listTransportador = db.Transportador.Where(e => e.NomeRazao.Contains(parameter)).ToList();
                return listTransportador;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Transportador. \nErro: " + ex.Message);
            }

        }
    }
}
