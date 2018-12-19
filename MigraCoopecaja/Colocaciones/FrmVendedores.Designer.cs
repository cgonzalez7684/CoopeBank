namespace AppEscritorio.Colocaciones
{
    partial class FrmVendedores
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
            this.TxtCodVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombreVendedor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbOrigen = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbFPago = new System.Windows.Forms.ComboBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMtoSeg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMtoCred = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtMtoCap = new System.Windows.Forms.TextBox();
            this.DgVendedores = new System.Windows.Forms.DataGridView();
            this.DgCOD_COMPANIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgIND_ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgNOMBRE_VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMTO_META_CAPTACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMTO_META_CREDITO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMTO_META_SEGURO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgIND_ORIGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgTELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgFAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgIND_FORMA_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TxtFax = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodVendedor
            // 
            this.TxtCodVendedor.Enabled = false;
            this.TxtCodVendedor.Location = new System.Drawing.Point(162, 12);
            this.TxtCodVendedor.Name = "TxtCodVendedor";
            this.TxtCodVendedor.Size = new System.Drawing.Size(120, 20);
            this.TxtCodVendedor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // TxtCodUsuario
            // 
            this.TxtCodUsuario.Enabled = false;
            this.TxtCodUsuario.Location = new System.Drawing.Point(466, 12);
            this.TxtCodUsuario.Name = "TxtCodUsuario";
            this.TxtCodUsuario.Size = new System.Drawing.Size(121, 20);
            this.TxtCodUsuario.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre";
            // 
            // TxtNombreVendedor
            // 
            this.TxtNombreVendedor.Enabled = false;
            this.TxtNombreVendedor.Location = new System.Drawing.Point(162, 49);
            this.TxtNombreVendedor.Name = "TxtNombreVendedor";
            this.TxtNombreVendedor.Size = new System.Drawing.Size(425, 20);
            this.TxtNombreVendedor.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CmbOrigen);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CmbFPago);
            this.groupBox1.Controls.Add(this.CmbEstado);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtMtoSeg);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtMtoCred);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtMtoCap);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 160);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Origen";
            // 
            // CmbOrigen
            // 
            this.CmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrigen.Enabled = false;
            this.CmbOrigen.FormattingEnabled = true;
            this.CmbOrigen.Items.AddRange(new object[] {
            "Interno",
            "Externo"});
            this.CmbOrigen.Location = new System.Drawing.Point(454, 107);
            this.CmbOrigen.Name = "CmbOrigen";
            this.CmbOrigen.Size = new System.Drawing.Size(121, 21);
            this.CmbOrigen.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Forma de pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Estado";
            // 
            // CmbFPago
            // 
            this.CmbFPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFPago.Enabled = false;
            this.CmbFPago.FormattingEnabled = true;
            this.CmbFPago.Items.AddRange(new object[] {
            "C",
            "P",
            "N/A"});
            this.CmbFPago.Location = new System.Drawing.Point(454, 61);
            this.CmbFPago.Name = "CmbFPago";
            this.CmbFPago.Size = new System.Drawing.Size(121, 21);
            this.CmbFPago.TabIndex = 4;
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.Enabled = false;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.CmbEstado.Location = new System.Drawing.Point(454, 18);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(121, 21);
            this.CmbEstado.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Meta Seguro";
            // 
            // TxtMtoSeg
            // 
            this.TxtMtoSeg.Enabled = false;
            this.TxtMtoSeg.Location = new System.Drawing.Point(150, 108);
            this.TxtMtoSeg.Name = "TxtMtoSeg";
            this.TxtMtoSeg.Size = new System.Drawing.Size(120, 20);
            this.TxtMtoSeg.TabIndex = 2;
            this.TxtMtoSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMtoSeg.Enter += new System.EventHandler(this.TxtMtoSeg_Enter);
            this.TxtMtoSeg.Leave += new System.EventHandler(this.TxtMtoSeg_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Meta Credito";
            // 
            // TxtMtoCred
            // 
            this.TxtMtoCred.Enabled = false;
            this.TxtMtoCred.Location = new System.Drawing.Point(150, 62);
            this.TxtMtoCred.Name = "TxtMtoCred";
            this.TxtMtoCred.Size = new System.Drawing.Size(120, 20);
            this.TxtMtoCred.TabIndex = 1;
            this.TxtMtoCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMtoCred.Enter += new System.EventHandler(this.TxtMtoCred_Enter);
            this.TxtMtoCred.Leave += new System.EventHandler(this.TxtMtoCred_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Meta Captación";
            // 
            // TxtMtoCap
            // 
            this.TxtMtoCap.Enabled = false;
            this.TxtMtoCap.Location = new System.Drawing.Point(150, 19);
            this.TxtMtoCap.Name = "TxtMtoCap";
            this.TxtMtoCap.Size = new System.Drawing.Size(120, 20);
            this.TxtMtoCap.TabIndex = 0;
            this.TxtMtoCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMtoCap.Enter += new System.EventHandler(this.TxtMtoCap_Enter);
            this.TxtMtoCap.Leave += new System.EventHandler(this.TxtMtoCap_Leave);
            // 
            // DgVendedores
            // 
            this.DgVendedores.AllowUserToAddRows = false;
            this.DgVendedores.AllowUserToDeleteRows = false;
            this.DgVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgVendedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgCOD_COMPANIA,
            this.DgCOD_VENDEDOR,
            this.DgCOD_USUARIO,
            this.DgIND_ESTADO,
            this.DgNOMBRE_VENDEDOR,
            this.DgMTO_META_CAPTACION,
            this.DgMTO_META_CREDITO,
            this.DgMTO_META_SEGURO,
            this.DgIND_ORIGEN,
            this.DgTELEFONO,
            this.DgFAX,
            this.DgIND_FORMA_PAGO});
            this.DgVendedores.Location = new System.Drawing.Point(12, 341);
            this.DgVendedores.Name = "DgVendedores";
            this.DgVendedores.ReadOnly = true;
            this.DgVendedores.RowHeadersVisible = false;
            this.DgVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgVendedores.Size = new System.Drawing.Size(628, 128);
            this.DgVendedores.TabIndex = 19;
            this.DgVendedores.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgVendedores_CellEnter);
            // 
            // DgCOD_COMPANIA
            // 
            this.DgCOD_COMPANIA.DataPropertyName = "COD_COMPANIA";
            this.DgCOD_COMPANIA.HeaderText = "Compañia";
            this.DgCOD_COMPANIA.Name = "DgCOD_COMPANIA";
            this.DgCOD_COMPANIA.ReadOnly = true;
            this.DgCOD_COMPANIA.Visible = false;
            // 
            // DgCOD_VENDEDOR
            // 
            this.DgCOD_VENDEDOR.DataPropertyName = "COD_VENDEDOR";
            this.DgCOD_VENDEDOR.HeaderText = "Vendedor";
            this.DgCOD_VENDEDOR.Name = "DgCOD_VENDEDOR";
            this.DgCOD_VENDEDOR.ReadOnly = true;
            // 
            // DgCOD_USUARIO
            // 
            this.DgCOD_USUARIO.DataPropertyName = "COD_USUARIO";
            this.DgCOD_USUARIO.HeaderText = "Usuario";
            this.DgCOD_USUARIO.Name = "DgCOD_USUARIO";
            this.DgCOD_USUARIO.ReadOnly = true;
            // 
            // DgIND_ESTADO
            // 
            this.DgIND_ESTADO.DataPropertyName = "IND_ESTADO";
            this.DgIND_ESTADO.FalseValue = "0";
            this.DgIND_ESTADO.HeaderText = "Estado";
            this.DgIND_ESTADO.IndeterminateValue = "0";
            this.DgIND_ESTADO.Name = "DgIND_ESTADO";
            this.DgIND_ESTADO.ReadOnly = true;
            this.DgIND_ESTADO.TrueValue = "1";
            // 
            // DgNOMBRE_VENDEDOR
            // 
            this.DgNOMBRE_VENDEDOR.DataPropertyName = "NOMBRE_VENDEDOR";
            this.DgNOMBRE_VENDEDOR.HeaderText = "Nombre";
            this.DgNOMBRE_VENDEDOR.Name = "DgNOMBRE_VENDEDOR";
            this.DgNOMBRE_VENDEDOR.ReadOnly = true;
            // 
            // DgMTO_META_CAPTACION
            // 
            this.DgMTO_META_CAPTACION.DataPropertyName = "MTO_META_CAPTACION";
            this.DgMTO_META_CAPTACION.HeaderText = "MetaCaptacion";
            this.DgMTO_META_CAPTACION.Name = "DgMTO_META_CAPTACION";
            this.DgMTO_META_CAPTACION.ReadOnly = true;
            // 
            // DgMTO_META_CREDITO
            // 
            this.DgMTO_META_CREDITO.DataPropertyName = "MTO_META_CREDITO";
            this.DgMTO_META_CREDITO.HeaderText = "MetaCredito";
            this.DgMTO_META_CREDITO.Name = "DgMTO_META_CREDITO";
            this.DgMTO_META_CREDITO.ReadOnly = true;
            // 
            // DgMTO_META_SEGURO
            // 
            this.DgMTO_META_SEGURO.DataPropertyName = "MTO_META_SEGURO";
            this.DgMTO_META_SEGURO.HeaderText = "MetaSeguro";
            this.DgMTO_META_SEGURO.Name = "DgMTO_META_SEGURO";
            this.DgMTO_META_SEGURO.ReadOnly = true;
            // 
            // DgIND_ORIGEN
            // 
            this.DgIND_ORIGEN.DataPropertyName = "IND_ORIGEN";
            this.DgIND_ORIGEN.HeaderText = "Origen";
            this.DgIND_ORIGEN.Name = "DgIND_ORIGEN";
            this.DgIND_ORIGEN.ReadOnly = true;
            // 
            // DgTELEFONO
            // 
            this.DgTELEFONO.DataPropertyName = "TELEFONO";
            this.DgTELEFONO.HeaderText = "Telefono";
            this.DgTELEFONO.Name = "DgTELEFONO";
            this.DgTELEFONO.ReadOnly = true;
            this.DgTELEFONO.Visible = false;
            // 
            // DgFAX
            // 
            this.DgFAX.DataPropertyName = "FAX";
            this.DgFAX.HeaderText = "Fax";
            this.DgFAX.Name = "DgFAX";
            this.DgFAX.ReadOnly = true;
            this.DgFAX.Visible = false;
            // 
            // DgIND_FORMA_PAGO
            // 
            this.DgIND_FORMA_PAGO.DataPropertyName = "IND_FORMA_PAGO";
            this.DgIND_FORMA_PAGO.HeaderText = "Pago";
            this.DgIND_FORMA_PAGO.Name = "DgIND_FORMA_PAGO";
            this.DgIND_FORMA_PAGO.ReadOnly = true;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(186, 298);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 4;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(292, 298);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 21;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(403, 298);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 22;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Enabled = false;
            this.TxtTelefono.Location = new System.Drawing.Point(162, 84);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(120, 20);
            this.TxtTelefono.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Telefono";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(466, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 3;
            // 
            // TxtFax
            // 
            this.TxtFax.AutoSize = true;
            this.TxtFax.Location = new System.Drawing.Point(350, 91);
            this.TxtFax.Name = "TxtFax";
            this.TxtFax.Size = new System.Drawing.Size(24, 13);
            this.TxtFax.TabIndex = 26;
            this.TxtFax.Text = "Fax";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtFax);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.DgVendedores);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNombreVendedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCodUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCodVendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmVendedores";
            this.Text = "Gestión de vendedores";
            this.Load += new System.EventHandler(this.FrmVendedores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCodVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNombreVendedor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbOrigen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbFPago;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMtoSeg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMtoCred;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtMtoCap;
        private System.Windows.Forms.DataGridView DgVendedores;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_COMPANIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_USUARIO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgIND_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgNOMBRE_VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMTO_META_CAPTACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMTO_META_CREDITO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMTO_META_SEGURO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgIND_ORIGEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgTELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgFAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgIND_FORMA_PAGO;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label TxtFax;
        private System.Windows.Forms.Button button1;
    }
}