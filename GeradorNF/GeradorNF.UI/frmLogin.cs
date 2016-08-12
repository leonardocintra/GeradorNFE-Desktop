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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FazerLogin();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                FazerLogin();                
        }

        private void FazerLogin()
        {
            if (txtSenha.Text.Equals("teste") && txtSenha.Text.Equals("teste"))
            {
                frmPrincipal frmPrincipal = new frmPrincipal();
                frmLogin frmLogin = new UI.frmLogin();
                frmLogin.Hide();
                frmPrincipal.Show();
            }
            // else if para login com conta normal
            else
            {
                MessageBox.Show("Usuario ou senha inválidos", "Erro login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsuario.Focus();
            }
        }
    }
}
