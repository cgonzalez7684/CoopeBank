namespace AppEscritorio.Captacion
{
    partial class FrmAhorros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMontoD = new System.Windows.Forms.TextBox();
            this.txtMontoB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAhorro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.tbcOpciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmbAhorros = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnExcel = new System.Windows.Forms.Button();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.chkMarcar = new System.Windows.Forms.CheckBox();
            this.Dgahorros = new System.Windows.Forms.DataGridView();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbAhorroP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.colcodcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInom_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnum_contrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmon_saldo_real = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfec_vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbcOpciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgahorros)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(189, 220);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 60;
            this.BtnModificar.Text = "Trasladar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(251, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Monto Disponible";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Monto Bloqueado";
            // 
            // txtMontoD
            // 
            this.txtMontoD.Location = new System.Drawing.Point(249, 153);
            this.txtMontoD.Name = "txtMontoD";
            this.txtMontoD.Size = new System.Drawing.Size(157, 20);
            this.txtMontoD.TabIndex = 57;
            this.txtMontoD.Validating += new System.ComponentModel.CancelEventHandler(this.txtMontoD_Validating);
            // 
            // txtMontoB
            // 
            this.txtMontoB.Location = new System.Drawing.Point(51, 153);
            this.txtMontoB.Name = "txtMontoB";
            this.txtMontoB.Size = new System.Drawing.Size(157, 20);
            this.txtMontoB.TabIndex = 56;
            this.txtMontoB.TextChanged += new System.EventHandler(this.txtMontoB_TextChanged);
            this.txtMontoB.Validating += new System.ComponentModel.CancelEventHandler(this.txtMontoB_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Seleccionar Ahorro";
            // 
            // cmbAhorro
            // 
            this.cmbAhorro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAhorro.FormattingEnabled = true;
            this.cmbAhorro.Location = new System.Drawing.Point(6, 86);
            this.cmbAhorro.Name = "cmbAhorro";
            this.cmbAhorro.Size = new System.Drawing.Size(457, 21);
            this.cmbAhorro.TabIndex = 54;
            this.cmbAhorro.SelectedIndexChanged += new System.EventHandler(this.cmbAhorro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Nombre Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Código de Cliente";
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomCliente.Location = new System.Drawing.Point(128, 29);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.ReadOnly = true;
            this.txtNomCliente.Size = new System.Drawing.Size(335, 20);
            this.txtNomCliente.TabIndex = 51;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(6, 29);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodCliente.TabIndex = 50;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCliente_Validating);
            // 
            // tbcOpciones
            // 
            this.tbcOpciones.Controls.Add(this.tabPage1);
            this.tbcOpciones.Controls.Add(this.tabPage2);
            this.tbcOpciones.Controls.Add(this.tabPage3);
            this.tbcOpciones.Location = new System.Drawing.Point(3, 12);
            this.tbcOpciones.Name = "tbcOpciones";
            this.tbcOpciones.SelectedIndex = 0;
            this.tbcOpciones.Size = new System.Drawing.Size(611, 431);
            this.tbcOpciones.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.cmbAhorros);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Traslado de saldo masivo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(184, 70);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(181, 17);
            this.radioButton2.TabIndex = 55;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Trasladar  saldo a Desbloqueado";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "Trasladar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 70);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(160, 17);
            this.radioButton1.TabIndex = 54;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Trasladar saldo a Bloqueado";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cmbAhorros
            // 
            this.cmbAhorros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAhorros.FormattingEnabled = true;
            this.cmbAhorros.Location = new System.Drawing.Point(14, 31);
            this.cmbAhorros.Name = "cmbAhorros";
            this.cmbAhorros.Size = new System.Drawing.Size(351, 21);
            this.cmbAhorros.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Seleccionar Ahorro:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnModificar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtCodCliente);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtNomCliente);
            this.tabPage2.Controls.Add(this.txtMontoD);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtMontoB);
            this.tabPage2.Controls.Add(this.cmbAhorro);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Traslado de saldo individual";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.dtFecha2);
            this.tabPage3.Controls.Add(this.btnExcel);
            this.tabPage3.Controls.Add(this.rdb3);
            this.tabPage3.Controls.Add(this.rdb1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.chkMarcar);
            this.tabPage3.Controls.Add(this.Dgahorros);
            this.tabPage3.Controls.Add(this.dtFecha);
            this.tabPage3.Controls.Add(this.cmbAhorroP);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(603, 405);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Traslado de saldo por fecha Liquidacion";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::AppEscritorio.Properties.Resources.Excel2;
            this.btnExcel.Location = new System.Drawing.Point(553, 327);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 27);
            this.btnExcel.TabIndex = 65;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(343, 340);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(108, 17);
            this.rdb3.TabIndex = 64;
            this.rdb3.Text = "Solo mover fecha";
            this.rdb3.UseVisualStyleBackColor = true;
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Location = new System.Drawing.Point(115, 340);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(167, 17);
            this.rdb1.TabIndex = 62;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "Trasladar saldo y mover fecha";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "Ejecutar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkMarcar
            // 
            this.chkMarcar.AutoSize = true;
            this.chkMarcar.Location = new System.Drawing.Point(498, 63);
            this.chkMarcar.Name = "chkMarcar";
            this.chkMarcar.Size = new System.Drawing.Size(92, 17);
            this.chkMarcar.TabIndex = 60;
            this.chkMarcar.Text = "Marcar Todos";
            this.chkMarcar.UseVisualStyleBackColor = true;
            this.chkMarcar.CheckedChanged += new System.EventHandler(this.chkMarcar_CheckedChanged);
            // 
            // Dgahorros
            // 
            this.Dgahorros.AllowUserToAddRows = false;
            this.Dgahorros.AllowUserToDeleteRows = false;
            this.Dgahorros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgahorros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colcodcliente,
            this.colInom_cliente,
            this.colnum_contrato,
            this.colmon_saldo_real,
            this.colfec_vencimiento,
            this.colVisi});
            this.Dgahorros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Dgahorros.Location = new System.Drawing.Point(6, 84);
            this.Dgahorros.Name = "Dgahorros";
            this.Dgahorros.RowHeadersVisible = false;
            this.Dgahorros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgahorros.Size = new System.Drawing.Size(588, 240);
            this.Dgahorros.TabIndex = 59;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(346, 26);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(117, 20);
            this.dtFecha.TabIndex = 58;
            this.dtFecha.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbAhorroP
            // 
            this.cmbAhorroP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAhorroP.FormattingEnabled = true;
            this.cmbAhorroP.Location = new System.Drawing.Point(6, 25);
            this.cmbAhorroP.Name = "cmbAhorroP";
            this.cmbAhorroP.Size = new System.Drawing.Size(318, 21);
            this.cmbAhorroP.TabIndex = 56;
            this.cmbAhorroP.SelectedIndexChanged += new System.EventHandler(this.cmbAhorroP_SelectedIndexChanged);
            this.cmbAhorroP.SelectedValueChanged += new System.EventHandler(this.cmbAhorroP_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Seleccionar Ahorro";
            // 
            // dtFecha2
            // 
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(485, 26);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Size = new System.Drawing.Size(109, 20);
            this.dtFecha2.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(343, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Fecha Inicial";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(482, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "Fecha Final";
            // 
            // colcodcliente
            // 
            this.colcodcliente.DataPropertyName = "COD_CLIENTE";
            this.colcodcliente.HeaderText = "Código";
            this.colcodcliente.Name = "colcodcliente";
            this.colcodcliente.ReadOnly = true;
            this.colcodcliente.Width = 50;
            // 
            // colInom_cliente
            // 
            this.colInom_cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colInom_cliente.DataPropertyName = "NOM_CLIENTE";
            this.colInom_cliente.HeaderText = "Nombre";
            this.colInom_cliente.MinimumWidth = 200;
            this.colInom_cliente.Name = "colInom_cliente";
            this.colInom_cliente.ReadOnly = true;
            this.colInom_cliente.Width = 200;
            // 
            // colnum_contrato
            // 
            this.colnum_contrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colnum_contrato.DataPropertyName = "NUM_CONTRATO";
            this.colnum_contrato.HeaderText = "Contrato";
            this.colnum_contrato.MinimumWidth = 50;
            this.colnum_contrato.Name = "colnum_contrato";
            this.colnum_contrato.ReadOnly = true;
            // 
            // colmon_saldo_real
            // 
            this.colmon_saldo_real.DataPropertyName = "MON_SALDO_REAL";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colmon_saldo_real.DefaultCellStyle = dataGridViewCellStyle1;
            this.colmon_saldo_real.HeaderText = "Saldo";
            this.colmon_saldo_real.Name = "colmon_saldo_real";
            // 
            // colfec_vencimiento
            // 
            this.colfec_vencimiento.DataPropertyName = "fec_vencimiento";
            this.colfec_vencimiento.HeaderText = "Vencimiento";
            this.colfec_vencimiento.Name = "colfec_vencimiento";
            this.colfec_vencimiento.Width = 80;
            // 
            // colVisi
            // 
            this.colVisi.DataPropertyName = "seleccionado";
            this.colVisi.FalseValue = "0";
            this.colVisi.HeaderText = "Aplicar";
            this.colVisi.IndeterminateValue = "0";
            this.colVisi.Name = "colVisi";
            this.colVisi.TrueValue = "1";
            this.colVisi.Width = 50;
            // 
            // FrmAhorros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 444);
            this.Controls.Add(this.tbcOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAhorros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traslado Saldo Ahorros";
            this.Load += new System.EventHandler(this.FrmAhorros_Load);
            this.tbcOpciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgahorros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoD;
        private System.Windows.Forms.TextBox txtMontoB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAhorro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TabControl tbcOpciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton radioButton2;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmbAhorros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.ComboBox cmbAhorroP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Dgahorros;
        private System.Windows.Forms.CheckBox chkMarcar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcodcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInom_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnum_contrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmon_saldo_real;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfec_vencimiento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisi;

    }
}