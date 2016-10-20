using GeradorNF.BLL;
using GeradroNF.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GeradroNF.WPF.UI
{
    /// <summary>
    /// Interaction logic for Emitente.xaml
    /// </summary>
    public partial class Emitente : Window
    {
        public Emitente()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmitenteViewModel emitenteViewModel = new EmitenteViewModel();
            emitenteViewModel.LoadEmitente();
            EmitenteView.DataContext = emitenteViewModel;
        }
    }
}
