namespace AppEscritorio.General
{
    partial class FrmCargarPagosCGP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDolares = new System.Windows.Forms.RadioButton();
            this.rbColones = new System.Windows.Forms.RadioButton();
            this.txtCargaArc = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.pbAvance = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbContador = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtConsecutivo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumEnvio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodEntidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetallePago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTiposServSinpe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.rbDolares);
            this.groupBox1.Controls.Add(this.rbColones);
            this.groupBox1.Controls.Add(this.txtCargaArc);
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rbDolares
            // 
            this.rbDolares.AutoSize = true;
            this.rbDolares.Location = new System.Drawing.Point(501, 30);
            this.rbDolares.Name = "rbDolares";
            this.rbDolares.Size = new System.Drawing.Size(61, 17);
            this.rbDolares.TabIndex = 6;
            this.rbDolares.TabStop = true;
            this.rbDolares.Text = "Dólares";
            this.rbDolares.UseVisualStyleBackColor = true;
            // 
            // rbColones
            // 
            this.rbColones.AutoSize = true;
            this.rbColones.Location = new System.Drawing.Point(432, 30);
            this.rbColones.Name = "rbColones";
            this.rbColones.Size = new System.Drawing.Size(63, 17);
            this.rbColones.TabIndex = 5;
            this.rbColones.TabStop = true;
            this.rbColones.Text = "Colones";
            this.rbColones.UseVisualStyleBackColor = true;
            // 
            // txtCargaArc
            // 
            this.txtCargaArc.Enabled = false;
            this.txtCargaArc.Location = new System.Drawing.Point(113, 27);
            this.txtCargaArc.Name = "txtCargaArc";
            this.txtCargaArc.Size = new System.Drawing.Size(305, 20);
            this.txtCargaArc.TabIndex = 4;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(642, 24);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(107, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar archivo";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccionar archivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dtDatos);
            this.groupBox2.Location = new System.Drawing.Point(12, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 274);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dtDatos
            // 
            this.dtDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatos.Location = new System.Drawing.Point(11, 19);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.ReadOnly = true;
            this.dtDatos.Size = new System.Drawing.Size(735, 249);
            this.dtDatos.TabIndex = 0;
            this.dtDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDatos_CellClick);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(297, 495);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(107, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar Archivo";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // pbAvance
            // 
            this.pbAvance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAvance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbAvance.Location = new System.Drawing.Point(554, 511);
            this.pbAvance.Maximum = 2000;
            this.pbAvance.Name = "pbAvance";
            this.pbAvance.Size = new System.Drawing.Size(213, 23);
            this.pbAvance.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total registros cargados:";
            // 
            // lbContador
            // 
            this.lbContador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContador.AutoSize = true;
            this.lbContador.Location = new System.Drawing.Point(678, 495);
            this.lbContador.Name = "lbContador";
            this.lbContador.Size = new System.Drawing.Size(19, 13);
            this.lbContador.TabIndex = 6;
            this.lbContador.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtConsecutivo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNumEnvio);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCodEntidad);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDetallePago);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbTiposServSinpe);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(755, 95);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos archivo";
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Enabled = false;
            this.txtConsecutivo.Location = new System.Drawing.Point(432, 64);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Size = new System.Drawing.Size(56, 20);
            this.txtConsecutivo.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Consecutivo envío";
            // 
            // txtNumEnvio
            // 
            this.txtNumEnvio.Enabled = false;
            this.txtNumEnvio.Location = new System.Drawing.Point(249, 65);
            this.txtNumEnvio.Name = "txtNumEnvio";
            this.txtNumEnvio.Size = new System.Drawing.Size(50, 20);
            this.txtNumEnvio.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Número envío";
            // 
            // txtCodEntidad
            // 
            this.txtCodEntidad.Enabled = false;
            this.txtCodEntidad.Location = new System.Drawing.Point(101, 66);
            this.txtCodEntidad.Name = "txtCodEntidad";
            this.txtCodEntidad.Size = new System.Drawing.Size(55, 20);
            this.txtCodEntidad.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Código Entidad";
            // 
            // txtDetallePago
            // 
            this.txtDetallePago.Location = new System.Drawing.Point(370, 24);
            this.txtDetallePago.Name = "txtDetallePago";
            this.txtDetallePago.Size = new System.Drawing.Size(376, 20);
            this.txtDetallePago.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Descripción Pago";
            // 
            // cmbTiposServSinpe
            // 
            this.cmbTiposServSinpe.Enabled = false;
            this.cmbTiposServSinpe.FormattingEnabled = true;
            this.cmbTiposServSinpe.Location = new System.Drawing.Point(101, 24);
            this.cmbTiposServSinpe.Name = "cmbTiposServSinpe";
            this.cmbTiposServSinpe.Size = new System.Drawing.Size(147, 21);
            this.cmbTiposServSinpe.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo de Servicio";
            // 
            // FrmCargarPagosCGP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbContador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbAvance);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCargarPagosCGP";
            this.Text = "FrmCargarPagosCGP";
            this.Load += new System.EventHandler(this.FrmCargarPagosCGP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCargaArc;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtDatos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ProgressBar pbAvance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbContador;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumEnvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodEntidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDetallePago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTiposServSinpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.RadioButton rbDolares;
        private System.Windows.Forms.RadioButton rbColones;
    }
}