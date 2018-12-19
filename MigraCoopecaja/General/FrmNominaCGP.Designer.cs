namespace AppEscritorio.General
{
    partial class FrmNominaCGP
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoNomina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
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
            this.chkDesmarcar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.dtFechaPago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTipoNomina);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(639, 25);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(107, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtFechaPago
            // 
            this.dtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaPago.Location = new System.Drawing.Point(370, 27);
            this.dtFechaPago.Name = "dtFechaPago";
            this.dtFechaPago.Size = new System.Drawing.Size(200, 20);
            this.dtFechaPago.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Pago";
            // 
            // cmbTipoNomina
            // 
            this.cmbTipoNomina.FormattingEnabled = true;
            this.cmbTipoNomina.Location = new System.Drawing.Point(101, 27);
            this.cmbTipoNomina.Name = "cmbTipoNomina";
            this.cmbTipoNomina.Size = new System.Drawing.Size(147, 21);
            this.cmbTipoNomina.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de nómina";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtDatos);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dtDatos
            // 
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatos.Location = new System.Drawing.Point(11, 19);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.ReadOnly = true;
            this.dtDatos.Size = new System.Drawing.Size(783, 249);
            this.dtDatos.TabIndex = 0;
            this.dtDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDatos_CellClick);
            this.dtDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDatos_CellContentClick);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(355, 487);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(107, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar Archivo";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox3
            // 
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
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 95);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos archivo";
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Enabled = false;
            this.txtConsecutivo.Location = new System.Drawing.Point(629, 64);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Size = new System.Drawing.Size(117, 20);
            this.txtConsecutivo.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Consecutivo envío";
            // 
            // txtNumEnvio
            // 
            this.txtNumEnvio.Enabled = false;
            this.txtNumEnvio.Location = new System.Drawing.Point(368, 65);
            this.txtNumEnvio.Name = "txtNumEnvio";
            this.txtNumEnvio.Size = new System.Drawing.Size(117, 20);
            this.txtNumEnvio.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 69);
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
            this.txtCodEntidad.Size = new System.Drawing.Size(147, 20);
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
            // chkDesmarcar
            // 
            this.chkDesmarcar.AutoSize = true;
            this.chkDesmarcar.Location = new System.Drawing.Point(694, 194);
            this.chkDesmarcar.Name = "chkDesmarcar";
            this.chkDesmarcar.Size = new System.Drawing.Size(115, 17);
            this.chkDesmarcar.TabIndex = 4;
            this.chkDesmarcar.Text = "Marcar/Desmarcar";
            this.chkDesmarcar.UseVisualStyleBackColor = true;
            this.chkDesmarcar.CheckedChanged += new System.EventHandler(this.chkDesmarcar_CheckedChanged);
            // 
            // FrmNominaCGP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 531);
            this.Controls.Add(this.chkDesmarcar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmNominaCGP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de archivos de pago CGP";
            this.Load += new System.EventHandler(this.FrmNominaCGP_Load);
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
        private System.Windows.Forms.ComboBox cmbTipoNomina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtDatos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.DateTimePicker dtFechaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbTiposServSinpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetallePago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumEnvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodEntidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDesmarcar;
    }
}