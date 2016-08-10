namespace GeradorNF.UI
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
            this.txtQuantidade = new System.Windows.Forms.MaskedTextBox();
            this.lblValorTotalNfe = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.gridProduto = new System.Windows.Forms.DataGridView();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDestinatario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEmitente = new System.Windows.Forms.ComboBox();
            this.cbxTransportador = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPesquisarCodigoPlaca = new System.Windows.Forms.Button();
            this.txtCEPPlaca = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.txtRNTC = new System.Windows.Forms.TextBox();
            this.txtUFPlaca = new System.Windows.Forms.TextBox();
            this.lblAcao = new System.Windows.Forms.Label();
            this.txtCodigoCidadePlaca = new System.Windows.Forms.TextBox();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtAliquota = new System.Windows.Forms.TextBox();
            this.txtValorBase = new System.Windows.Forms.TextBox();
            this.txtValorServico = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduto)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(770, 123);
            this.txtQuantidade.Mask = "00000";
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(39, 20);
            this.txtQuantidade.TabIndex = 32;
            this.txtQuantidade.ValidatingType = typeof(int);
            // 
            // lblValorTotalNfe
            // 
            this.lblValorTotalNfe.AutoSize = true;
            this.lblValorTotalNfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalNfe.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblValorTotalNfe.Location = new System.Drawing.Point(567, 367);
            this.lblValorTotalNfe.Name = "lblValorTotalNfe";
            this.lblValorTotalNfe.Size = new System.Drawing.Size(39, 42);
            this.lblValorTotalNfe.TabIndex = 31;
            this.lblValorTotalNfe.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(389, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 42);
            this.label7.TabIndex = 30;
            this.label7.Text = "Total:";
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.Location = new System.Drawing.Point(834, 367);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(110, 47);
            this.btnGerarArquivo.TabIndex = 29;
            this.btnGerarArquivo.Text = "Gerar Arquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            // 
            // gridProduto
            // 
            this.gridProduto.AllowUserToAddRows = false;
            this.gridProduto.AllowUserToResizeRows = false;
            this.gridProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProduto.Location = new System.Drawing.Point(381, 150);
            this.gridProduto.Name = "gridProduto";
            this.gridProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProduto.Size = new System.Drawing.Size(576, 197);
            this.gridProduto.TabIndex = 28;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(815, 121);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarProduto.TabIndex = 27;
            this.btnAdicionarProduto.Text = "Adicionar";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(761, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Quantidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Código";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(452, 124);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(56, 20);
            this.txtCodigoProduto.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Produto:";
            // 
            // cbxProduto
            // 
            this.cbxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Location = new System.Drawing.Point(514, 123);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(249, 21);
            this.cbxProduto.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Destinatário:";
            // 
            // cbxDestinatario
            // 
            this.cbxDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDestinatario.FormattingEnabled = true;
            this.cbxDestinatario.Location = new System.Drawing.Point(532, 60);
            this.cbxDestinatario.Name = "cbxDestinatario";
            this.cbxDestinatario.Size = new System.Drawing.Size(323, 21);
            this.cbxDestinatario.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Emitente:";
            // 
            // cbxEmitente
            // 
            this.cbxEmitente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmitente.FormattingEnabled = true;
            this.cbxEmitente.Location = new System.Drawing.Point(532, 24);
            this.cbxEmitente.Name = "cbxEmitente";
            this.cbxEmitente.Size = new System.Drawing.Size(323, 21);
            this.cbxEmitente.TabIndex = 17;
            // 
            // cbxTransportador
            // 
            this.cbxTransportador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransportador.FormattingEnabled = true;
            this.cbxTransportador.Location = new System.Drawing.Point(86, 27);
            this.cbxTransportador.Name = "cbxTransportador";
            this.cbxTransportador.Size = new System.Drawing.Size(323, 21);
            this.cbxTransportador.TabIndex = 82;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 81;
            this.label17.Text = "Transportador:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Khaki;
            this.groupBox3.Controls.Add(this.btnPesquisarCodigoPlaca);
            this.groupBox3.Controls.Add(this.txtCEPPlaca);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtPlaca);
            this.groupBox3.Controls.Add(this.txtRNTC);
            this.groupBox3.Controls.Add(this.txtUFPlaca);
            this.groupBox3.Controls.Add(this.lblAcao);
            this.groupBox3.Controls.Add(this.txtCodigoCidadePlaca);
            this.groupBox3.Controls.Add(this.txtCFOP);
            this.groupBox3.Controls.Add(this.txtValorTotal);
            this.groupBox3.Controls.Add(this.txtAliquota);
            this.groupBox3.Controls.Add(this.txtValorBase);
            this.groupBox3.Controls.Add(this.txtValorServico);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(67, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 302);
            this.groupBox3.TabIndex = 80;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados do Transporte";
            // 
            // btnPesquisarCodigoPlaca
            // 
            this.btnPesquisarCodigoPlaca.Image = global::GeradorNF.UI.Properties.Resources.searchIco;
            this.btnPesquisarCodigoPlaca.Location = new System.Drawing.Point(208, 138);
            this.btnPesquisarCodigoPlaca.Name = "btnPesquisarCodigoPlaca";
            this.btnPesquisarCodigoPlaca.Size = new System.Drawing.Size(29, 23);
            this.btnPesquisarCodigoPlaca.TabIndex = 15;
            this.btnPesquisarCodigoPlaca.UseVisualStyleBackColor = true;
            // 
            // txtCEPPlaca
            // 
            this.txtCEPPlaca.Location = new System.Drawing.Point(133, 141);
            this.txtCEPPlaca.Mask = "00000-000";
            this.txtCEPPlaca.Name = "txtCEPPlaca";
            this.txtCEPPlaca.Size = new System.Drawing.Size(69, 20);
            this.txtCEPPlaca.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 170);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 13);
            this.label19.TabIndex = 51;
            this.label19.Text = "Codigo Cidade Placa:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(132, 193);
            this.txtPlaca.Mask = ">LLL-0000";
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(81, 20);
            this.txtPlaca.TabIndex = 17;
            // 
            // txtRNTC
            // 
            this.txtRNTC.Location = new System.Drawing.Point(133, 245);
            this.txtRNTC.Name = "txtRNTC";
            this.txtRNTC.Size = new System.Drawing.Size(80, 20);
            this.txtRNTC.TabIndex = 19;
            // 
            // txtUFPlaca
            // 
            this.txtUFPlaca.Enabled = false;
            this.txtUFPlaca.Location = new System.Drawing.Point(133, 219);
            this.txtUFPlaca.Name = "txtUFPlaca";
            this.txtUFPlaca.Size = new System.Drawing.Size(37, 20);
            this.txtUFPlaca.TabIndex = 18;
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.ForeColor = System.Drawing.Color.Green;
            this.lblAcao.Location = new System.Drawing.Point(6, 286);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(54, 13);
            this.lblAcao.TabIndex = 50;
            this.lblAcao.Text = "labelAcao";
            this.lblAcao.Visible = false;
            // 
            // txtCodigoCidadePlaca
            // 
            this.txtCodigoCidadePlaca.Enabled = false;
            this.txtCodigoCidadePlaca.Location = new System.Drawing.Point(133, 167);
            this.txtCodigoCidadePlaca.Name = "txtCodigoCidadePlaca";
            this.txtCodigoCidadePlaca.Size = new System.Drawing.Size(80, 20);
            this.txtCodigoCidadePlaca.TabIndex = 16;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(132, 271);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(80, 20);
            this.txtCFOP.TabIndex = 20;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Location = new System.Drawing.Point(133, 101);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(80, 20);
            this.txtValorTotal.TabIndex = 13;
            // 
            // txtAliquota
            // 
            this.txtAliquota.Location = new System.Drawing.Point(133, 75);
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(80, 20);
            this.txtAliquota.TabIndex = 12;
            // 
            // txtValorBase
            // 
            this.txtValorBase.Location = new System.Drawing.Point(133, 49);
            this.txtValorBase.Name = "txtValorBase";
            this.txtValorBase.Size = new System.Drawing.Size(80, 20);
            this.txtValorBase.TabIndex = 11;
            // 
            // txtValorServico
            // 
            this.txtValorServico.Location = new System.Drawing.Point(133, 23);
            this.txtValorServico.Name = "txtValorServico";
            this.txtValorServico.Size = new System.Drawing.Size(80, 20);
            this.txtValorServico.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(87, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "RNTC:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "UF Placa:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Placa:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "CEP Placa:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "CFOP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Valor:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(79, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Aliquota:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(66, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Valor Base:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Valor serviço:";
            // 
            // frmGeradorArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 437);
            this.Controls.Add(this.cbxTransportador);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblValorTotalNfe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGerarArquivo);
            this.Controls.Add(this.gridProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            this.Text = "Gerar arquivo para a Receita Federal";
            ((System.ComponentModel.ISupportInitialize)(this.gridProduto)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtQuantidade;
        private System.Windows.Forms.Label lblValorTotalNfe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGerarArquivo;
        private System.Windows.Forms.DataGridView gridProduto;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDestinatario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxEmitente;
        private System.Windows.Forms.ComboBox cbxTransportador;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPesquisarCodigoPlaca;
        private System.Windows.Forms.MaskedTextBox txtCEPPlaca;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox txtPlaca;
        private System.Windows.Forms.TextBox txtRNTC;
        private System.Windows.Forms.TextBox txtUFPlaca;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.TextBox txtCodigoCidadePlaca;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtAliquota;
        private System.Windows.Forms.TextBox txtValorBase;
        private System.Windows.Forms.TextBox txtValorServico;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}