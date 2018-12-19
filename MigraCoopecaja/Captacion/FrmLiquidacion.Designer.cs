namespace AppEscritorio.Captacion
{
    partial class FrmLiquidacion
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
            this.oFdBuscarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.DgProdCarga = new System.Windows.Forms.DataGridView();
            this.DgCOD_COMPANIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgDES_IDENTIFICACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMON_APLICADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_CUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_INVERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_USUARIO_CARGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgFEC_CARGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgFEC_LIQUIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCOD_USUARIO_LIQUIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtBuscar1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtMontCarga = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCantCargArchivo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbNUM_CUENTA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCompania = new System.Windows.Forms.ComboBox();
            this.CmbProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtFecCarga = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DgProdLiq = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTotPerLiq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtSumaLiq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnCarga = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtBuscar2 = new System.Windows.Forms.TextBox();
            this.LstNoEncontrados = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnCopiar = new System.Windows.Forms.Button();
            this.LblCant = new System.Windows.Forms.Label();
            this.LstNoLiquidados = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgProdCarga)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProdLiq)).BeginInit();
            this.SuspendLayout();
            // 
            // oFdBuscarArchivo
            // 
            this.oFdBuscarArchivo.FileName = "openFileDialog1";
            // 
            // DgProdCarga
            // 
            this.DgProdCarga.AllowUserToAddRows = false;
            this.DgProdCarga.AllowUserToDeleteRows = false;
            this.DgProdCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProdCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgCOD_COMPANIA,
            this.DgDES_IDENTIFICACION,
            this.DgMON_APLICADO,
            this.DgCOD_CUENTA,
            this.DgCOD_INVERSION,
            this.DgCOD_USUARIO_CARGA,
            this.DgFEC_CARGA,
            this.DgFEC_LIQUIDA,
            this.DgCOD_USUARIO_LIQUIDA,
            this.Column1,
            this.Column2});
            this.DgProdCarga.Location = new System.Drawing.Point(12, 205);
            this.DgProdCarga.MultiSelect = false;
            this.DgProdCarga.Name = "DgProdCarga";
            this.DgProdCarga.RowHeadersVisible = false;
            this.DgProdCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgProdCarga.Size = new System.Drawing.Size(956, 137);
            this.DgProdCarga.TabIndex = 25;
            this.DgProdCarga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgProdCarga_CellContentClick);
            // 
            // DgCOD_COMPANIA
            // 
            this.DgCOD_COMPANIA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgCOD_COMPANIA.DataPropertyName = "COD_COMPANIA";
            this.DgCOD_COMPANIA.HeaderText = "Compañia";
            this.DgCOD_COMPANIA.Name = "DgCOD_COMPANIA";
            this.DgCOD_COMPANIA.ReadOnly = true;
            this.DgCOD_COMPANIA.Width = 79;
            // 
            // DgDES_IDENTIFICACION
            // 
            this.DgDES_IDENTIFICACION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgDES_IDENTIFICACION.DataPropertyName = "DES_IDENTIFICACION";
            this.DgDES_IDENTIFICACION.HeaderText = "Identificación";
            this.DgDES_IDENTIFICACION.Name = "DgDES_IDENTIFICACION";
            this.DgDES_IDENTIFICACION.ReadOnly = true;
            this.DgDES_IDENTIFICACION.Width = 95;
            // 
            // DgMON_APLICADO
            // 
            this.DgMON_APLICADO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgMON_APLICADO.DataPropertyName = "MON_APLICADO";
            this.DgMON_APLICADO.HeaderText = "Aplicar";
            this.DgMON_APLICADO.Name = "DgMON_APLICADO";
            this.DgMON_APLICADO.Width = 64;
            // 
            // DgCOD_CUENTA
            // 
            this.DgCOD_CUENTA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgCOD_CUENTA.DataPropertyName = "COD_CUENTA";
            this.DgCOD_CUENTA.HeaderText = "Banco";
            this.DgCOD_CUENTA.Name = "DgCOD_CUENTA";
            this.DgCOD_CUENTA.ReadOnly = true;
            this.DgCOD_CUENTA.Width = 63;
            // 
            // DgCOD_INVERSION
            // 
            this.DgCOD_INVERSION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgCOD_INVERSION.DataPropertyName = "COD_INVERSION";
            this.DgCOD_INVERSION.HeaderText = "Producto";
            this.DgCOD_INVERSION.Name = "DgCOD_INVERSION";
            this.DgCOD_INVERSION.ReadOnly = true;
            this.DgCOD_INVERSION.Width = 75;
            // 
            // DgCOD_USUARIO_CARGA
            // 
            this.DgCOD_USUARIO_CARGA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgCOD_USUARIO_CARGA.DataPropertyName = "COD_USUARIO_CARGA";
            this.DgCOD_USUARIO_CARGA.HeaderText = "UsuarioCarga";
            this.DgCOD_USUARIO_CARGA.Name = "DgCOD_USUARIO_CARGA";
            this.DgCOD_USUARIO_CARGA.ReadOnly = true;
            // 
            // DgFEC_CARGA
            // 
            this.DgFEC_CARGA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgFEC_CARGA.DataPropertyName = "FEC_CARGA";
            this.DgFEC_CARGA.HeaderText = "FechaCarga";
            this.DgFEC_CARGA.Name = "DgFEC_CARGA";
            this.DgFEC_CARGA.ReadOnly = true;
            this.DgFEC_CARGA.Width = 90;
            // 
            // DgFEC_LIQUIDA
            // 
            this.DgFEC_LIQUIDA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgFEC_LIQUIDA.DataPropertyName = "FEC_LIQUIDA";
            this.DgFEC_LIQUIDA.HeaderText = "FechaLiquida";
            this.DgFEC_LIQUIDA.Name = "DgFEC_LIQUIDA";
            this.DgFEC_LIQUIDA.ReadOnly = true;
            this.DgFEC_LIQUIDA.Width = 96;
            // 
            // DgCOD_USUARIO_LIQUIDA
            // 
            this.DgCOD_USUARIO_LIQUIDA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgCOD_USUARIO_LIQUIDA.DataPropertyName = "COD_USUARIO_LIQUIDA";
            this.DgCOD_USUARIO_LIQUIDA.HeaderText = "UsuarioLiquida";
            this.DgCOD_USUARIO_LIQUIDA.Name = "DgCOD_USUARIO_LIQUIDA";
            this.DgCOD_USUARIO_LIQUIDA.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "COD_CLIENTE";
            this.Column1.HeaderText = "COD_CLIENTE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NUM_CONTRATO";
            this.Column2.HeaderText = "NUM_CONTRATO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // TxtBuscar1
            // 
            this.TxtBuscar1.Location = new System.Drawing.Point(116, 172);
            this.TxtBuscar1.Name = "TxtBuscar1";
            this.TxtBuscar1.Size = new System.Drawing.Size(100, 20);
            this.TxtBuscar1.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Buscar persona";
            // 
            // TxtMontCarga
            // 
            this.TxtMontCarga.Location = new System.Drawing.Point(800, 351);
            this.TxtMontCarga.Name = "TxtMontCarga";
            this.TxtMontCarga.Size = new System.Drawing.Size(168, 20);
            this.TxtMontCarga.TabIndex = 28;
            this.TxtMontCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Monto liquidar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(672, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Total personas";
            // 
            // TxtCantCargArchivo
            // 
            this.TxtCantCargArchivo.Location = new System.Drawing.Point(800, 377);
            this.TxtCantCargArchivo.Name = "TxtCantCargArchivo";
            this.TxtCantCargArchivo.Size = new System.Drawing.Size(168, 20);
            this.TxtCantCargArchivo.TabIndex = 30;
            this.TxtCantCargArchivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 676);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 39);
            this.button1.TabIndex = 32;
            this.button1.Text = "Ejecutar liquidación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbNUM_CUENTA
            // 
            this.CmbNUM_CUENTA.DisplayMember = "NOM_CUENTA";
            this.CmbNUM_CUENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNUM_CUENTA.FormattingEnabled = true;
            this.CmbNUM_CUENTA.Location = new System.Drawing.Point(161, 67);
            this.CmbNUM_CUENTA.Name = "CmbNUM_CUENTA";
            this.CmbNUM_CUENTA.Size = new System.Drawing.Size(245, 21);
            this.CmbNUM_CUENTA.TabIndex = 24;
            this.CmbNUM_CUENTA.ValueMember = "COD_CUENTA";
            this.CmbNUM_CUENTA.SelectedIndexChanged += new System.EventHandler(this.CmbNUM_CUENTA_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Banco liquidar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Compañia";
            // 
            // cmbCompania
            // 
            this.cmbCompania.DisplayMember = "NOM_CUENTA";
            this.cmbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompania.FormattingEnabled = true;
            this.cmbCompania.Items.AddRange(new object[] {
            "Coopecaja",
            "Cesantia"});
            this.cmbCompania.Location = new System.Drawing.Point(161, 28);
            this.cmbCompania.Name = "cmbCompania";
            this.cmbCompania.Size = new System.Drawing.Size(245, 21);
            this.cmbCompania.TabIndex = 27;
            this.cmbCompania.ValueMember = "COD_CUENTA";
            this.cmbCompania.SelectedIndexChanged += new System.EventHandler(this.cmbCompania_SelectedIndexChanged);
            // 
            // CmbProducto
            // 
            this.CmbProducto.DisplayMember = "DES_INVERSION";
            this.CmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducto.FormattingEnabled = true;
            this.CmbProducto.Location = new System.Drawing.Point(635, 64);
            this.CmbProducto.Name = "CmbProducto";
            this.CmbProducto.Size = new System.Drawing.Size(245, 21);
            this.CmbProducto.TabIndex = 28;
            this.CmbProducto.ValueMember = "COD_INVERSION";
            this.CmbProducto.SelectedIndexChanged += new System.EventHandler(this.CmbProducto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Producto liquidar";
            // 
            // DtFecCarga
            // 
            this.DtFecCarga.CalendarForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.DtFecCarga.CalendarTitleForeColor = System.Drawing.SystemColors.Desktop;
            this.DtFecCarga.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFecCarga.Location = new System.Drawing.Point(635, 28);
            this.DtFecCarga.Name = "DtFecCarga";
            this.DtFecCarga.Size = new System.Drawing.Size(245, 20);
            this.DtFecCarga.TabIndex = 32;
            this.DtFecCarga.ValueChanged += new System.EventHandler(this.DtFecCarga_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Fecha carga";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DtFecCarga);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbProducto);
            this.groupBox1.Controls.Add(this.cmbCompania);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbNUM_CUENTA);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 153);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de carga";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnBuscar.Location = new System.Drawing.Point(6, 109);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(944, 25);
            this.BtnBuscar.TabIndex = 35;
            this.BtnBuscar.Text = "CARGAR ARCHIVO";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(293, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "REGISTROS CONTENIDOS EN EL ARCHIVO";
            // 
            // DgProdLiq
            // 
            this.DgProdLiq.AllowUserToAddRows = false;
            this.DgProdLiq.AllowUserToDeleteRows = false;
            this.DgProdLiq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProdLiq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column3,
            this.Column4});
            this.DgProdLiq.Location = new System.Drawing.Point(14, 487);
            this.DgProdLiq.Name = "DgProdLiq";
            this.DgProdLiq.ReadOnly = true;
            this.DgProdLiq.RowHeadersVisible = false;
            this.DgProdLiq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProdLiq.Size = new System.Drawing.Size(956, 153);
            this.DgProdLiq.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "COD_COMPANIA";
            this.dataGridViewTextBoxColumn1.HeaderText = "Compañia";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 79;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DES_IDENTIFICACION";
            this.dataGridViewTextBoxColumn2.HeaderText = "Identificación";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 95;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MON_APLICADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "Aplicar";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 64;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "COD_CUENTA";
            this.dataGridViewTextBoxColumn4.HeaderText = "Banco";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 63;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "COD_INVERSION";
            this.dataGridViewTextBoxColumn5.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "COD_USUARIO_CARGA";
            this.dataGridViewTextBoxColumn6.HeaderText = "UsuarioCarga";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FEC_CARGA";
            this.dataGridViewTextBoxColumn7.HeaderText = "FechaCarga";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FEC_LIQUIDA";
            this.dataGridViewTextBoxColumn8.HeaderText = "FechaLiquida";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 96;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "COD_USUARIO_LIQUIDA";
            this.dataGridViewTextBoxColumn9.HeaderText = "UsuarioLiquida";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "COD_CLIENTE";
            this.Column3.HeaderText = "COD_CLIENTE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NUM_CONTRATO";
            this.Column4.HeaderText = "NUM_CONTRATO";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(674, 683);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Total personas";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // TxtTotPerLiq
            // 
            this.TxtTotPerLiq.Location = new System.Drawing.Point(802, 676);
            this.TxtTotPerLiq.Name = "TxtTotPerLiq";
            this.TxtTotPerLiq.Size = new System.Drawing.Size(168, 20);
            this.TxtTotPerLiq.TabIndex = 37;
            this.TxtTotPerLiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTotPerLiq.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(674, 657);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Monto liquidar";
            // 
            // TxtSumaLiq
            // 
            this.TxtSumaLiq.Location = new System.Drawing.Point(802, 650);
            this.TxtSumaLiq.Name = "TxtSumaLiq";
            this.TxtSumaLiq.Size = new System.Drawing.Size(168, 20);
            this.TxtSumaLiq.TabIndex = 35;
            this.TxtSumaLiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(365, 453);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(228, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "GESTION DE REGISTROS";
            // 
            // BtnCarga
            // 
            this.BtnCarga.Location = new System.Drawing.Point(420, 358);
            this.BtnCarga.Name = "BtnCarga";
            this.BtnCarga.Size = new System.Drawing.Size(122, 39);
            this.BtnCarga.TabIndex = 40;
            this.BtnCarga.Text = "Ejecutar Carga";
            this.BtnCarga.UseVisualStyleBackColor = true;
            this.BtnCarga.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Buscar persona";
            // 
            // TxtBuscar2
            // 
            this.TxtBuscar2.Location = new System.Drawing.Point(118, 453);
            this.TxtBuscar2.Name = "TxtBuscar2";
            this.TxtBuscar2.Size = new System.Drawing.Size(100, 20);
            this.TxtBuscar2.TabIndex = 41;
            // 
            // LstNoEncontrados
            // 
            this.LstNoEncontrados.FormattingEnabled = true;
            this.LstNoEncontrados.Location = new System.Drawing.Point(13, 358);
            this.LstNoEncontrados.Name = "LstNoEncontrados";
            this.LstNoEncontrados.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstNoEncontrados.Size = new System.Drawing.Size(363, 43);
            this.LstNoEncontrados.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.MediumBlue;
            this.label13.Location = new System.Drawing.Point(149, 404);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(227, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "* Asociados No encontrados en base de datos";
            // 
            // BtnCopiar
            // 
            this.BtnCopiar.Location = new System.Drawing.Point(13, 407);
            this.BtnCopiar.Name = "BtnCopiar";
            this.BtnCopiar.Size = new System.Drawing.Size(75, 23);
            this.BtnCopiar.TabIndex = 45;
            this.BtnCopiar.Text = "Copiar";
            this.BtnCopiar.UseVisualStyleBackColor = true;
            this.BtnCopiar.Click += new System.EventHandler(this.BtnCopiar_Click);
            // 
            // LblCant
            // 
            this.LblCant.AutoSize = true;
            this.LblCant.Location = new System.Drawing.Point(674, 460);
            this.LblCant.Name = "LblCant";
            this.LblCant.Size = new System.Drawing.Size(151, 13);
            this.LblCant.TabIndex = 46;
            this.LblCant.Text = "Cantidad registros por liquidar: ";
            // 
            // LstNoLiquidados
            // 
            this.LstNoLiquidados.FormattingEnabled = true;
            this.LstNoLiquidados.Location = new System.Drawing.Point(14, 653);
            this.LstNoLiquidados.Name = "LstNoLiquidados";
            this.LstNoLiquidados.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstNoLiquidados.Size = new System.Drawing.Size(363, 43);
            this.LstNoLiquidados.TabIndex = 47;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 702);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "Copiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // FrmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 739);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LstNoLiquidados);
            this.Controls.Add(this.LblCant);
            this.Controls.Add(this.BtnCopiar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LstNoEncontrados);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtBuscar2);
            this.Controls.Add(this.BtnCarga);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtTotPerLiq);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtSumaLiq);
            this.Controls.Add(this.DgProdLiq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtCantCargArchivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtMontCarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtBuscar1);
            this.Controls.Add(this.DgProdCarga);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLiquidacion";
            this.Text = "Gestor de liquidación de productos";
            this.Load += new System.EventHandler(this.FrmLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgProdCarga)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProdLiq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog oFdBuscarArchivo;
        private System.Windows.Forms.DataGridView DgProdCarga;
        private System.Windows.Forms.TextBox TxtBuscar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtMontCarga;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCantCargArchivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbNUM_CUENTA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCompania;
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtFecCarga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgProdLiq;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtTotPerLiq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtSumaLiq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnCarga;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtBuscar2;
        private System.Windows.Forms.ListBox LstNoEncontrados;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_COMPANIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgDES_IDENTIFICACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMON_APLICADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_CUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_INVERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_USUARIO_CARGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgFEC_CARGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgFEC_LIQUIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCOD_USUARIO_LIQUIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button BtnCopiar;
        private System.Windows.Forms.Label LblCant;
        private System.Windows.Forms.ListBox LstNoLiquidados;
        private System.Windows.Forms.Button button2;
    }
}