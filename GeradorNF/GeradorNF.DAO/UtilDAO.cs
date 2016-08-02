using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNF.DAO
{
    public class UtilDAO
    {
        public static string UrlApi()
        {
            return "https://geradornf-prod.herokuapp.com";
            //return "http://localhost:8000/";
        }
    }
}
