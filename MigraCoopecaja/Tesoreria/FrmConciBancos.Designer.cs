namespace AppEscritorio.Tesoreria
{
    partial class FrmConciBancos
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
            this.CmbNUM_CUENTA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgMovimientos = new System.Windows.Forms.DataGridView();
            this.dgCOD_COMPANIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNUM_CUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTIP_MOVIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNUM_MOVIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFEC_MOVIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMON_MOVIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCOD_ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCOD_AJUSTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNUM_MOVIM_AJU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIND_INDIFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNOM_BENEFICIARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIND_ENVIO_NOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDOC_CONCILIAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbTIP_MOVIM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNUM_MOVIM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMON_MOVIM = new System.Windows.Forms.TextBox();
            this.DtFEC_MOVIM = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbCOD_ESTADO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDetalle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCompania = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBeneficiario = new System.Windows.Forms.TextBox();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbNUM_CUENTA
            // 
            this.CmbNUM_CUENTA.DisplayMember = "NOM_CUENTA";
            this.CmbNUM_CUENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNUM_CUENTA.Enabled = false;
            this.CmbNUM_CUENTA.FormattingEnabled = true;
            this.CmbNUM_CUENTA.Location = new System.Drawing.Point(83, 49);
            this.CmbNUM_CUENTA.Name = "CmbNUM_CUENTA";
            this.CmbNUM_CUENTA.Size = new System.Drawing.Size(245, 21);
            this.CmbNUM_CUENTA.TabIndex = 0;
            this.CmbNUM_CUENTA.ValueMember = "COD_CUENTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Banco";
            // 
            // DgMovimientos
            // 
            this.DgMovimientos.AllowUserToAddRows = false;
            this.DgMovimientos.AllowUserToDeleteRows = false;
            this.DgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgCOD_COMPANIA,
            this.dgNUM_CUENTA,
            this.dgTIP_MOVIM,
            this.dgNUM_MOVIM,
            this.dgDESCRIPCION,
            this.dgFEC_MOVIM,
            this.dgMON_MOVIM,
            this.dgCOD_ESTADO,
            this.dgCOD_AJUSTE,
            this.dgNUM_MOVIM_AJU,
            this.dgIND_INDIFERENCIA,
            this.dgNOM_BENEFICIARIO,
            this.dgIND_ENVIO_NOTA,
            this.dgDOC_CONCILIAR});
            this.DgMovimientos.Location = new System.Drawing.Point(12, 339);
            this.DgMovimientos.Name = "DgMovimientos";
            this.DgMovimientos.ReadOnly = true;
            this.DgMovimientos.RowHeadersVisible = false;
            this.DgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgMovimientos.Size = new System.Drawing.Size(761, 158);
            this.DgMovimientos.TabIndex = 2;
            this.DgMovimientos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgMovimientos_CellEnter);
            // 
            // dgCOD_COMPANIA
            // 
            this.dgCOD_COMPANIA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgCOD_COMPANIA.DataPropertyName = "COD_COMPANIA";
            this.dgCOD_COMPANIA.HeaderText = "Compania";
            this.dgCOD_COMPANIA.Name = "dgCOD_COMPANIA";
            this.dgCOD_COMPANIA.ReadOnly = true;
            this.dgCOD_COMPANIA.Visible = false;
            // 
            // dgNUM_CUENTA
            // 
            this.dgNUM_CUENTA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgNUM_CUENTA.DataPropertyName = "NUM_CUENTA";
            this.dgNUM_CUENTA.HeaderText = "Cuenta";
            this.dgNUM_CUENTA.Name = "dgNUM_CUENTA";
            this.dgNUM_CUENTA.ReadOnly = true;
            this.dgNUM_CUENTA.Width = 66;
            // 
            // dgTIP_MOVIM
            // 
            this.dgTIP_MOVIM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgTIP_MOVIM.DataPropertyName = "TIP_MOVIM";
            this.dgTIP_MOVIM.HeaderText = "Tipo";
            this.dgTIP_MOVIM.Name = "dgTIP_MOVIM";
            this.dgTIP_MOVIM.ReadOnly = true;
            this.dgTIP_MOVIM.Width = 53;
            // 
            // dgNUM_MOVIM
            // 
            this.dgNUM_MOVIM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgNUM_MOVIM.DataPropertyName = "NUM_MOVIM";
            this.dgNUM_MOVIM.HeaderText = "Referencia";
            this.dgNUM_MOVIM.Name = "dgNUM_MOVIM";
            this.dgNUM_MOVIM.ReadOnly = true;
            this.dgNUM_MOVIM.Width = 84;
            // 
            // dgDESCRIPCION
            // 
            this.dgDESCRIPCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgDESCRIPCION.DataPropertyName = "DESCRIPCION";
            this.dgDESCRIPCION.HeaderText = "Detalle";
            this.dgDESCRIPCION.Name = "dgDESCRIPCION";
            this.dgDESCRIPCION.ReadOnly = true;
            // 
            // dgFEC_MOVIM
            // 
            this.dgFEC_MOVIM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgFEC_MOVIM.DataPropertyName = "FEC_MOVIM";
            this.dgFEC_MOVIM.HeaderText = "Movimiento";
            this.dgFEC_MOVIM.Name = "dgFEC_MOVIM";
            this.dgFEC_MOVIM.ReadOnly = true;
            this.dgFEC_MOVIM.Width = 86;
            // 
            // dgMON_MOVIM
            // 
            this.dgMON_MOVIM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgMON_MOVIM.DataPropertyName = "MON_MOVIM";
            this.dgMON_MOVIM.HeaderText = "Monto";
            this.dgMON_MOVIM.Name = "dgMON_MOVIM";
            this.dgMON_MOVIM.ReadOnly = true;
            this.dgMON_MOVIM.Width = 62;
            // 
            // dgCOD_ESTADO
            // 
            this.dgCOD_ESTADO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgCOD_ESTADO.DataPropertyName = "COD_ESTADO";
            this.dgCOD_ESTADO.HeaderText = "Estado";
            this.dgCOD_ESTADO.Name = "dgCOD_ESTADO";
            this.dgCOD_ESTADO.ReadOnly = true;
            this.dgCOD_ESTADO.Width = 65;
            // 
            // dgCOD_AJUSTE
            // 
            this.dgCOD_AJUSTE.DataPropertyName = "COD_AJUSTE";
            this.dgCOD_AJUSTE.HeaderText = "Ajuste";
            this.dgCOD_AJUSTE.Name = "dgCOD_AJUSTE";
            this.dgCOD_AJUSTE.ReadOnly = true;
            this.dgCOD_AJUSTE.Visible = false;
            // 
            // dgNUM_MOVIM_AJU
            // 
            this.dgNUM_MOVIM_AJU.DataPropertyName = "NUM_MOVIM_AJU";
            this.dgNUM_MOVIM_AJU.HeaderText = "MovAju";
            this.dgNUM_MOVIM_AJU.Name = "dgNUM_MOVIM_AJU";
            this.dgNUM_MOVIM_AJU.ReadOnly = true;
            this.dgNUM_MOVIM_AJU.Visible = false;
            // 
            // dgIND_INDIFERENCIA
            // 
            this.dgIND_INDIFERENCIA.DataPropertyName = "IND_DIFERENCIA";
            this.dgIND_INDIFERENCIA.HeaderText = "Difere";
            this.dgIND_INDIFERENCIA.Name = "dgIND_INDIFERENCIA";
            this.dgIND_INDIFERENCIA.ReadOnly = true;
            this.dgIND_INDIFERENCIA.Visible = false;
            // 
            // dgNOM_BENEFICIARIO
            // 
            this.dgNOM_BENEFICIARIO.DataPropertyName = "NOM_BENEFICIARIO";
            this.dgNOM_BENEFICIARIO.HeaderText = "Beneficiario";
            this.dgNOM_BENEFICIARIO.Name = "dgNOM_BENEFICIARIO";
            this.dgNOM_BENEFICIARIO.ReadOnly = true;
            this.dgNOM_BENEFICIARIO.Visible = false;
            // 
            // dgIND_ENVIO_NOTA
            // 
            this.dgIND_ENVIO_NOTA.DataPropertyName = "IND_ENVIO_NOTA";
            this.dgIND_ENVIO_NOTA.HeaderText = "EnvioNota";
            this.dgIND_ENVIO_NOTA.Name = "dgIND_ENVIO_NOTA";
            this.dgIND_ENVIO_NOTA.ReadOnly = true;
            this.dgIND_ENVIO_NOTA.Visible = false;
            // 
            // dgDOC_CONCILIAR
            // 
            this.dgDOC_CONCILIAR.DataPropertyName = "DOC_CONCILIAR";
            this.dgDOC_CONCILIAR.HeaderText = "DocConci";
            this.dgDOC_CONCILIAR.Name = "dgDOC_CONCILIAR";
            this.dgDOC_CONCILIAR.ReadOnly = true;
            this.dgDOC_CONCILIAR.Visible = false;
            // 
            // CmbTIP_MOVIM
            // 
            this.CmbTIP_MOVIM.DisplayMember = "DES_TPMOV";
            this.CmbTIP_MOVIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTIP_MOVIM.Enabled = false;
            this.CmbTIP_MOVIM.FormattingEnabled = true;
            this.CmbTIP_MOVIM.Location = new System.Drawing.Point(83, 90);
            this.CmbTIP_MOVIM.Name = "CmbTIP_MOVIM";
            this.CmbTIP_MOVIM.Size = new System.Drawing.Size(245, 21);
            this.CmbTIP_MOVIM.TabIndex = 3;
            this.CmbTIP_MOVIM.ValueMember = "COD_TPMOV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo";
            // 
            // TxtNUM_MOVIM
            // 
            this.TxtNUM_MOVIM.Location = new System.Drawing.Point(83, 130);
            this.TxtNUM_MOVIM.Name = "TxtNUM_MOVIM";
            this.TxtNUM_MOVIM.ReadOnly = true;
            this.TxtNUM_MOVIM.Size = new System.Drawing.Size(196, 20);
            this.TxtNUM_MOVIM.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Referencia";
            // 
            // TxtMON_MOVIM
            // 
            this.TxtMON_MOVIM.Location = new System.Drawing.Point(514, 49);
            this.TxtMON_MOVIM.Name = "TxtMON_MOVIM";
            this.TxtMON_MOVIM.ReadOnly = true;
            this.TxtMON_MOVIM.Size = new System.Drawing.Size(196, 20);
            this.TxtMON_MOVIM.TabIndex = 7;
            // 
            // DtFEC_MOVIM
            // 
            this.DtFEC_MOVIM.Enabled = false;
            this.DtFEC_MOVIM.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFEC_MOVIM.Location = new System.Drawing.Point(514, 87);
            this.DtFEC_MOVIM.Name = "DtFEC_MOVIM";
            this.DtFEC_MOVIM.Size = new System.Drawing.Size(196, 20);
            this.DtFEC_MOVIM.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Monto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Movimiento";
            // 
            // CmbCOD_ESTADO
            // 
            this.CmbCOD_ESTADO.DisplayMember = "ESTADO";
            this.CmbCOD_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCOD_ESTADO.FormattingEnabled = true;
            this.CmbCOD_ESTADO.Location = new System.Drawing.Point(514, 125);
            this.CmbCOD_ESTADO.Name = "CmbCOD_ESTADO";
            this.CmbCOD_ESTADO.Size = new System.Drawing.Size(121, 21);
            this.CmbCOD_ESTADO.TabIndex = 11;
            this.CmbCOD_ESTADO.ValueMember = "Cod_Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Detalle";
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.Location = new System.Drawing.Point(83, 169);
            this.TxtDetalle.Multiline = true;
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.ReadOnly = true;
            this.TxtDetalle.Size = new System.Drawing.Size(627, 70);
            this.TxtDetalle.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(228, 262);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(368, 262);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 16;
            this.BtnModificar.Text = "&Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(514, 262);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 17;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Compañia";
            // 
            // cmbCompania
            // 
            this.cmbCompania.DisplayMember = "NOM_CUENTA";
            this.cmbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompania.Enabled = false;
            this.cmbCompania.FormattingEnabled = true;
            this.cmbCompania.Items.AddRange(new object[] {
            "Coopecaja",
            "Cesantia"});
            this.cmbCompania.Location = new System.Drawing.Point(83, 12);
            this.cmbCompania.Name = "cmbCompania";
            this.cmbCompania.Size = new System.Drawing.Size(245, 21);
            this.cmbCompania.TabIndex = 19;
            this.cmbCompania.ValueMember = "COD_CUENTA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(416, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Beneficiario";
            // 
            // TxtBeneficiario
            // 
            this.TxtBeneficiario.Location = new System.Drawing.Point(514, 12);
            this.TxtBeneficiario.Name = "TxtBeneficiario";
            this.TxtBeneficiario.ReadOnly = true;
            this.TxtBeneficiario.Size = new System.Drawing.Size(196, 20);
            this.TxtBeneficiario.TabIndex = 20;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(104, 313);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(100, 20);
            this.TxtBuscar.TabIndex = 22;
            this.TxtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBuscar_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Referencia";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(225, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "* digitar referencia y oprimir tecla enter";
            // 
            // FrmConciBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 509);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtBeneficiario);
            this.Controls.Add(this.cmbCompania);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtDetalle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbCOD_ESTADO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtFEC_MOVIM);
            this.Controls.Add(this.TxtMON_MOVIM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNUM_MOVIM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTIP_MOVIM);
            this.Controls.Add(this.DgMovimientos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbNUM_CUENTA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmConciBancos";
            this.Text = "Carga de movimientos bancarios";
            this.Load += new System.EventHandler(this.FrmConciBancos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbNUM_CUENTA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgMovimientos;
        private System.Windows.Forms.ComboBox CmbTIP_MOVIM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNUM_MOVIM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMON_MOVIM;
        private System.Windows.Forms.DateTimePicker DtFEC_MOVIM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbCOD_ESTADO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDetalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOD_COMPANIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNUM_CUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTIP_MOVIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNUM_MOVIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFEC_MOVIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMON_MOVIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOD_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOD_AJUSTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNUM_MOVIM_AJU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIND_INDIFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNOM_BENEFICIARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIND_ENVIO_NOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDOC_CONCILIAR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCompania;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtBeneficiario;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}