using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorNF.UI
{
    public partial class frmGeradorArquivo : Form
    {
        public frmGeradorArquivo()
        {
            InitializeComponent();
        }

        #region private methods
        private static void ValidaValorDecimal(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1 || (sender as TextBox).Text == string.Empty)
                    e.Handled = true;
            }

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
                return;
            }
        }

        private void SomaValorImposto()
        {
            decimal valorAliquota = string.IsNullOrEmpty(txtAliquota.Text) ? 0 : Convert.ToDecimal(txtAliquota.Text.Replace(".", ","));
            decimal valorServico = string.IsNullOrEmpty(txtValorServico.Text) ? 0 : Convert.ToDecimal(txtValorServico.Text.Replace(".", ","));
            decimal valorBase = string.IsNullOrEmpty(txtValorBase.Text) ? 0 : Convert.ToDecimal(txtValorBase.Text.Replace(".", ","));

            decimal total = valorAliquota + valorServico + valorBase;
            txtValorTotal.Text = total.ToString();
        }

        #region Calculo de valores
        private void txtValorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecimal(sender, e);
        }

        private void txtValorBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecimal(sender, e);
        }

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaValorDecimal(sender, e);
        }

        private void txtValorServico_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }

        private void txtValorBase_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }

        private void txtAliquota_TextChanged(object sender, EventArgs e)
        {
            SomaValorImposto();
        }
        #endregion
        #endregion
    }
}
