namespace GeradorNFE.UI
{
    partial class frmGeradorArquivo
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
            this.cbxEmitente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDestinatario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.gridProduto = new System.Windows.Forms.DataGridView();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValorTotalNfe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxEmitente
            // 
            this.cbxEmitente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmitente.FormattingEnabled = true;
            this.cbxEmitente.Location = new System.Drawing.Point(181, 24);
            this.cbxEmitente.Name = "cbxEmitente";
            this.cbxEmitente.Size = new System.Drawing.Size(323, 21);
            this.cbxEmitente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emitente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destinatário:";
            // 
            // cbxDestinatario
            // 
            this.cbxDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDestinatario.FormattingEnabled = true;
            this.cbxDestinatario.Location = new System.Drawing.Point(181, 60);
            this.cbxDestinatario.Name = "cbxDestinatario";
            this.cbxDestinatario.Size = new System.Drawing.Size(323, 21);
            this.cbxDestinatario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Produto:";
            // 
            // cbxProduto
            // 
            this.cbxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Location = new System.Drawing.Point(181, 132);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(249, 21);
            this.cbxProduto.TabIndex = 4;
            this.cbxProduto.SelectedIndexChanged += new System.EventHandler(this.cbxProduto_SelectedIndexChanged);
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(119, 133);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(56, 20);
            this.txtCodigoProduto.TabIndex = 6;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(436, 133);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(51, 20);
            this.txtQuantidade.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descrição";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quantidade:";
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(493, 130);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarProduto.TabIndex = 11;
            this.btnAdicionarProduto.Text = "Adicionar";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // gridProduto
            // 
            this.gridProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProduto.Location = new System.Drawing.Point(65, 159);
            this.gridProduto.Name = "gridProduto";
            this.gridProduto.Size = new System.Drawing.Size(503, 195);
            this.gridProduto.TabIndex = 12;
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.Location = new System.Drawing.Point(458, 371);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(110, 47);
            this.btnGerarArquivo.TabIndex = 13;
            this.btnGerarArquivo.Text = "Gerar Arquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Click += new System.EventHandler(this.btnGerarArquivo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 42);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total:";
            // 
            // lblValorTotalNfe
            // 
            this.lblValorTotalNfe.AutoSize = true;
            this.lblValorTotalNfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalNfe.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblValorTotalNfe.Location = new System.Drawing.Point(234, 376);
            this.lblValorTotalNfe.Name = "lblValorTotalNfe";
            this.lblValorTotalNfe.Size = new System.Drawing.Size(39, 42);
            this.lblValorTotalNfe.TabIndex = 15;
            this.lblValorTotalNfe.Text = "0";
            // 
            // frmGeradorArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 442);
            this.Controls.Add(this.lblValorTotalNfe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGerarArquivo);
            this.Controls.Add(this.gridProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtCodigoProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDestinatario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxEmitente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeradorArquivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador do Arquivo";
            this.Load += new System.EventHandler(this.frmGeradorArquivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEmitente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDestinatario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.DataGridView gridProduto;
        private System.Windows.Forms.Button btnGerarArquivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValorTotalNfe;
    }
}