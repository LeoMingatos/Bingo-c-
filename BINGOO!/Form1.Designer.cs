namespace BINGOO_
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnBingo = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnSortear = new System.Windows.Forms.Button();
            this.txtPremio = new System.Windows.Forms.TextBox();
            this.lblSorteado = new System.Windows.Forms.Label();
            this.lblUltimo = new System.Windows.Forms.Label();
            this.panelBingo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prémio";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NUMERO SORTEADO";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ULTIMO NUMERO SORTEADO";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Green;
            this.btnIniciar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIniciar.Location = new System.Drawing.Point(3, 44);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(227, 36);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar Bingo";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnBingo
            // 
            this.btnBingo.BackColor = System.Drawing.Color.Gold;
            this.btnBingo.ForeColor = System.Drawing.Color.Red;
            this.btnBingo.Location = new System.Drawing.Point(220, 44);
            this.btnBingo.Name = "btnBingo";
            this.btnBingo.Size = new System.Drawing.Size(348, 36);
            this.btnBingo.TabIndex = 6;
            this.btnBingo.Text = "BINGO!";
            this.btnBingo.UseVisualStyleBackColor = false;
            this.btnBingo.Click += new System.EventHandler(this.btnBingo_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Crimson;
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnFinalizar.Location = new System.Drawing.Point(564, 44);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(278, 36);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "Finalizar Bingo";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnSortear
            // 
            this.btnSortear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortear.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSortear.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSortear.Location = new System.Drawing.Point(837, 44);
            this.btnSortear.Name = "btnSortear";
            this.btnSortear.Size = new System.Drawing.Size(149, 36);
            this.btnSortear.TabIndex = 8;
            this.btnSortear.Text = "Sortear Número";
            this.btnSortear.UseVisualStyleBackColor = false;
            this.btnSortear.Click += new System.EventHandler(this.btnSortear_Click);
            // 
            // txtPremio
            // 
            this.txtPremio.Location = new System.Drawing.Point(3, 17);
            this.txtPremio.Name = "txtPremio";
            this.txtPremio.Size = new System.Drawing.Size(212, 20);
            this.txtPremio.TabIndex = 9;
            // 
            // lblSorteado
            // 
            this.lblSorteado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSorteado.Location = new System.Drawing.Point(3, 96);
            this.lblSorteado.Name = "lblSorteado";
            this.lblSorteado.Size = new System.Drawing.Size(993, 52);
            this.lblSorteado.TabIndex = 10;
            // 
            // lblUltimo
            // 
            this.lblUltimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimo.Location = new System.Drawing.Point(4, 161);
            this.lblUltimo.Name = "lblUltimo";
            this.lblUltimo.Size = new System.Drawing.Size(993, 52);
            this.lblUltimo.TabIndex = 11;
            // 
            // panelBingo
            // 
            this.panelBingo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBingo.BackgroundImage = global::BINGOO_.Properties.Resources.blue_and_purple_background_qzpfve3ir237isr52;
            this.panelBingo.Location = new System.Drawing.Point(8, 229);
            this.panelBingo.Name = "panelBingo";
            this.panelBingo.Size = new System.Drawing.Size(959, 322);
            this.panelBingo.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::BINGOO_.Properties.Resources._21948784_bingo_loteria_bolas_e_bilhetes_fundo_vetor;
            this.ClientSize = new System.Drawing.Size(986, 553);
            this.Controls.Add(this.panelBingo);
            this.Controls.Add(this.lblUltimo);
            this.Controls.Add(this.lblSorteado);
            this.Controls.Add(this.txtPremio);
            this.Controls.Add(this.btnSortear);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnBingo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "\'";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnBingo;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnSortear;
        private System.Windows.Forms.TextBox txtPremio;
        private System.Windows.Forms.Label lblSorteado;
        private System.Windows.Forms.Label lblUltimo;
        private System.Windows.Forms.Panel panelBingo;
    }
}

