using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorNF.Model;
using GeradorNF.BLL;

namespace GeradroNF.WPF.ViewModel
{
    class EmitenteViewModel
    {
        public ObservableCollection<Emitente> Emitentes { get; set; }

        public EmitenteViewModel()
        {
            Emitentes = new ObservableCollection<Emitente>();
        }
              

        public async void LoadEmitente()
        {
            //ObservableCollection<Emitente> emitentes = new ObservableCollection<Emitente>();
            List<Emitente> emitenteList = new List<Emitente>();
            if (IsInDesignMode)
            {
                Emitentes.Add(new Emitente { RazaoSocial = "Eficaz Contabilidae", Logradouro = "Rua Sete de setembro" });
                Emitentes.Add(new Emitente { RazaoSocial = "Eficaz Contabilidae 2", Logradouro = "Rua Sete de setembro" });
            }
            else
            {
                emitenteList = await EmitenteBLL.GetEmitenteBLL();

                foreach (var item in emitenteList)
                {
                    Emitentes.Add(new Emitente { RazaoSocial = item.RazaoSocial, Logradouro = item.Logradouro });
                }
            }

            //Emitentes = emitentes;

        }

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
