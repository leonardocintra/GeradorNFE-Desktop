using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradroNF.WPF
{
    public class UtilClass
    {
        public static bool IsInDesignMode
        {
            get
            {
                string app = System.Windows.Application.Current.ToString();
                if (app == "System.Windows.Application")
                {
                    return true;
                }
                else if (app == "Microsoft.Expression.Blend.BlendApplication")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
