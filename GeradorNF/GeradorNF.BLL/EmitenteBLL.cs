using GeradorNF.DAO;
using GeradorNF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
