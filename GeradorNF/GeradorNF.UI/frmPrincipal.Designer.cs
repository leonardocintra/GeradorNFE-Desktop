namespace GeradorNF.UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinatarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.gerarArquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(101, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitenteToolStripMenuItem,
            this.transportadoraToolStripMenuItem,
            this.destinatarioToolStripMenuItem,
            this.produtoToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // emitenteToolStripMenuItem
            // 
            this.emitenteToolStripMenuItem.Name = "emitenteToolStripMenuItem";
            this.emitenteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.emitenteToolStripMenuItem.Text = "&Emitente";
            this.emitenteToolStripMenuItem.Click += new System.EventHandler(this.emitenteToolStripMenuItem_Click);
            // 
            // transportadoraToolStripMenuItem
            // 
            this.transportadoraToolStripMenuItem.Name = "transportadoraToolStripMenuItem";
            this.transportadoraToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.transportadoraToolStripMenuItem.Text = "&Transportadora";
            this.transportadoraToolStripMenuItem.Click += new System.EventHandler(this.transportadoraToolStripMenuItem_Click);
            // 
            // destinatarioToolStripMenuItem
            // 
            this.destinatarioToolStripMenuItem.Name = "destinatarioToolStripMenuItem";
            this.destinatarioToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.destinatarioToolStripMenuItem.Text = "&Destinatario";
            this.destinatarioToolStripMenuItem.Click += new System.EventHandler(this.destinatarioToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.produtoToolStripMenuItem.Text = "&Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // gerarArquivoToolStripMenuItem
            // 
            this.gerarArquivoToolStripMenuItem.Name = "gerarArquivoToolStripMenuItem";
            this.gerarArquivoToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.gerarArquivoToolStripMenuItem.Text = "&Gerar Arquivo!";
            this.gerarArquivoToolStripMenuItem.Click += new System.EventHandler(this.gerarArquivoToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 527);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Gerador de NF-e Simples";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportadoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinatarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarArquivoToolStripMenuItem;
    }
}