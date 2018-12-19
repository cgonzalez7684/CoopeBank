namespace AppEscritorio.Colocaciones
{
    partial class FrmAvaluos
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
            this.CmbTipoBien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtOperacion = new System.Windows.Forms.TextBox();
            this.DgAvaluos = new System.Windows.Forms.DataGridView();
            this.DgCompania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgGarantiaPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgGarantiaSIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgFechaAvaluo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgNum_Perito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPerito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMntAvaluo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMntTerreno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMntConstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMntVehi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgGenReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgTipoBien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgAdjudicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtGaranPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtGaranSIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtFeAvaluo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMntTerreno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtMntAvaluo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtMntConst = new System.Windows.Forms.TextBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.CmbGene = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbBinAdj = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CmbProfesional = new System.Windows.Forms.ComboBox();
            this.BtnBusOpe = new System.Windows.Forms.Button();
            this.TxtBusqOpe = new System.Windows.Forms.TextBox();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgAvaluos)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbTipoBien
            // 
            this.CmbTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoBien.FormattingEnabled = true;
            this.CmbTipoBien.Location = new System.Drawing.Point(149, 130);
            this.CmbTipoBien.Name = "CmbTipoBien";
            this.CmbTipoBien.Size = new System.Drawing.Size(163, 21);
            this.CmbTipoBien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Bien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operación";
            // 
            // TxtOperacion
            // 
            this.TxtOperacion.Enabled = false;
            this.TxtOperacion.Location = new System.Drawing.Point(149, 34);
            this.TxtOperacion.Name = "TxtOperacion";
            this.TxtOperacion.ReadOnly = true;
            this.TxtOperacion.Size = new System.Drawing.Size(163, 20);
            this.TxtOperacion.TabIndex = 1;
            this.TxtOperacion.TextChanged += new System.EventHandler(this.TxtOperacion_TextChanged);
            this.TxtOperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOperacion_KeyPress);
            // 
            // DgAvaluos
            // 
            this.DgAvaluos.AllowUserToAddRows = false;
            this.DgAvaluos.AllowUserToDeleteRows = false;
            this.DgAvaluos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgAvaluos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgCompania,
            this.DgOperacion,
            this.DgGarantiaPS,
            this.DgGarantiaSIC,
            this.DgFechaAvaluo,
            this.DgNum_Perito,
            this.DgPerito,
            this.DgProfesional,
            this.DgMntAvaluo,
            this.DgMntTerreno,
            this.DgMntConstr,
            this.DgMntVehi,
            this.DgEstado,
            this.DgGenReg,
            this.DgTipoBien,
            this.DgAdjudicado});
            this.DgAvaluos.Location = new System.Drawing.Point(12, 287);
            this.DgAvaluos.Name = "DgAvaluos";
            this.DgAvaluos.ReadOnly = true;
            this.DgAvaluos.RowHeadersVisible = false;
            this.DgAvaluos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgAvaluos.Size = new System.Drawing.Size(1110, 173);
            this.DgAvaluos.TabIndex = 0;
            this.DgAvaluos.DataSourceChanged += new System.EventHandler(this.DgAvaluos_DataSourceChanged);
            this.DgAvaluos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgAvaluos_CellEnter);
            this.DgAvaluos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgAvaluos_DataBindingComplete);
            this.DgAvaluos.Validated += new System.EventHandler(this.DgAvaluos_Validated);
            // 
            // DgCompania
            // 
            this.DgCompania.DataPropertyName = "COD_COMPANIA";
            this.DgCompania.HeaderText = "Compañia";
            this.DgCompania.Name = "DgCompania";
            this.DgCompania.ReadOnly = true;
            // 
            // DgOperacion
            // 
            this.DgOperacion.DataPropertyName = "NUM_OPERACION";
            this.DgOperacion.HeaderText = "Operación";
            this.DgOperacion.Name = "DgOperacion";
            this.DgOperacion.ReadOnly = true;
            // 
            // DgGarantiaPS
            // 
            this.DgGarantiaPS.DataPropertyName = "NUM_GARANTIA_MADRE";
            this.DgGarantiaPS.HeaderText = "GarantiaPS";
            this.DgGarantiaPS.Name = "DgGarantiaPS";
            this.DgGarantiaPS.ReadOnly = true;
            // 
            // DgGarantiaSIC
            // 
            this.DgGarantiaSIC.DataPropertyName = "CNUMEDOCUM";
            this.DgGarantiaSIC.HeaderText = "GarantiaSIC";
            this.DgGarantiaSIC.Name = "DgGarantiaSIC";
            this.DgGarantiaSIC.ReadOnly = true;
            // 
            // DgFechaAvaluo
            // 
            this.DgFechaAvaluo.DataPropertyName = "FEC_AVALUO";
            this.DgFechaAvaluo.HeaderText = "FechaAvaluo";
            this.DgFechaAvaluo.Name = "DgFechaAvaluo";
            this.DgFechaAvaluo.ReadOnly = true;
            // 
            // DgNum_Perito
            // 
            this.DgNum_Perito.DataPropertyName = "NUM_PERITO";
            this.DgNum_Perito.HeaderText = "Num_Perito";
            this.DgNum_Perito.Name = "DgNum_Perito";
            this.DgNum_Perito.ReadOnly = true;
            this.DgNum_Perito.Visible = false;
            // 
            // DgPerito
            // 
            this.DgPerito.DataPropertyName = "NUM_PERITO";
            this.DgPerito.HeaderText = "Perito";
            this.DgPerito.Name = "DgPerito";
            this.DgPerito.ReadOnly = true;
            this.DgPerito.Visible = false;
            // 
            // DgProfesional
            // 
            this.DgProfesional.DataPropertyName = "NOM_PROFESIONAL";
            this.DgProfesional.HeaderText = "Profesional";
            this.DgProfesional.Name = "DgProfesional";
            this.DgProfesional.ReadOnly = true;
            // 
            // DgMntAvaluo
            // 
            this.DgMntAvaluo.DataPropertyName = "MON_AVALUO";
            this.DgMntAvaluo.HeaderText = "MntAvaluo";
            this.DgMntAvaluo.Name = "DgMntAvaluo";
            this.DgMntAvaluo.ReadOnly = true;
            // 
            // DgMntTerreno
            // 
            this.DgMntTerreno.DataPropertyName = "MON_TERRENO";
            this.DgMntTerreno.HeaderText = "MntTerreno";
            this.DgMntTerreno.Name = "DgMntTerreno";
            this.DgMntTerreno.ReadOnly = true;
            // 
            // DgMntConstr
            // 
            this.DgMntConstr.DataPropertyName = "MON_CONSTRUCCION";
            this.DgMntConstr.HeaderText = "MntConstr";
            this.DgMntConstr.Name = "DgMntConstr";
            this.DgMntConstr.ReadOnly = true;
            // 
            // DgMntVehi
            // 
            this.DgMntVehi.DataPropertyName = "MON_VEHICULO";
            this.DgMntVehi.HeaderText = "MntVehi";
            this.DgMntVehi.Name = "DgMntVehi";
            this.DgMntVehi.ReadOnly = true;
            this.DgMntVehi.Visible = false;
            // 
            // DgEstado
            // 
            this.DgEstado.DataPropertyName = "ESTADO";
            this.DgEstado.HeaderText = "Estado";
            this.DgEstado.Name = "DgEstado";
            this.DgEstado.ReadOnly = true;
            // 
            // DgGenReg
            // 
            this.DgGenReg.DataPropertyName = "GENREG";
            this.DgGenReg.HeaderText = "GenReg";
            this.DgGenReg.Name = "DgGenReg";
            this.DgGenReg.ReadOnly = true;
            // 
            // DgTipoBien
            // 
            this.DgTipoBien.DataPropertyName = "COD_TIPOBIEN";
            this.DgTipoBien.HeaderText = "TipoBien";
            this.DgTipoBien.Name = "DgTipoBien";
            this.DgTipoBien.ReadOnly = true;
            // 
            // DgAdjudicado
            // 
            this.DgAdjudicado.DataPropertyName = "IND_BIENADJUDICADO";
            this.DgAdjudicado.HeaderText = "Adjudicado";
            this.DgAdjudicado.Name = "DgAdjudicado";
            this.DgAdjudicado.ReadOnly = true;
            // 
            // TxtGaranPS
            // 
            this.TxtGaranPS.Location = new System.Drawing.Point(149, 66);
            this.TxtGaranPS.Name = "TxtGaranPS";
            this.TxtGaranPS.ReadOnly = true;
            this.TxtGaranPS.Size = new System.Drawing.Size(163, 20);
            this.TxtGaranPS.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Garantia PSBANK";
            // 
            // TxtGaranSIC
            // 
            this.TxtGaranSIC.Location = new System.Drawing.Point(149, 98);
            this.TxtGaranSIC.Name = "TxtGaranSIC";
            this.TxtGaranSIC.ReadOnly = true;
            this.TxtGaranSIC.Size = new System.Drawing.Size(163, 20);
            this.TxtGaranSIC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Doc SIC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Facha Avaluo";
            // 
            // DtFeAvaluo
            // 
            this.DtFeAvaluo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFeAvaluo.Location = new System.Drawing.Point(149, 163);
            this.DtFeAvaluo.Name = "DtFeAvaluo";
            this.DtFeAvaluo.Size = new System.Drawing.Size(163, 20);
            this.DtFeAvaluo.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Estado";
            // 
            // TxtMntTerreno
            // 
            this.TxtMntTerreno.Location = new System.Drawing.Point(510, 98);
            this.TxtMntTerreno.Name = "TxtMntTerreno";
            this.TxtMntTerreno.Size = new System.Drawing.Size(163, 20);
            this.TxtMntTerreno.TabIndex = 4;
            this.TxtMntTerreno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Monto terreno";
            // 
            // TxtMntAvaluo
            // 
            this.TxtMntAvaluo.Location = new System.Drawing.Point(510, 66);
            this.TxtMntAvaluo.Name = "TxtMntAvaluo";
            this.TxtMntAvaluo.Size = new System.Drawing.Size(163, 20);
            this.TxtMntAvaluo.TabIndex = 3;
            this.TxtMntAvaluo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Monto avaluo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Profesional";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(385, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Monto construcción";
            // 
            // TxtMntConst
            // 
            this.TxtMntConst.Location = new System.Drawing.Point(510, 131);
            this.TxtMntConst.Name = "TxtMntConst";
            this.TxtMntConst.Size = new System.Drawing.Size(163, 20);
            this.TxtMntConst.TabIndex = 5;
            this.TxtMntConst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Reservado"});
            this.CmbEstado.Location = new System.Drawing.Point(510, 161);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(163, 21);
            this.CmbEstado.TabIndex = 6;
            // 
            // CmbGene
            // 
            this.CmbGene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGene.FormattingEnabled = true;
            this.CmbGene.Items.AddRange(new object[] {
            "Manual",
            "Automatico (Revalución/Depreciación)"});
            this.CmbGene.Location = new System.Drawing.Point(842, 31);
            this.CmbGene.Name = "CmbGene";
            this.CmbGene.Size = new System.Drawing.Size(163, 21);
            this.CmbGene.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(717, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Generación registro";
            // 
            // CmbBinAdj
            // 
            this.CmbBinAdj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBinAdj.FormattingEnabled = true;
            this.CmbBinAdj.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.CmbBinAdj.Location = new System.Drawing.Point(842, 65);
            this.CmbBinAdj.Name = "CmbBinAdj";
            this.CmbBinAdj.Size = new System.Drawing.Size(163, 21);
            this.CmbBinAdj.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(717, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Bien adjudicado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 38);
            this.button2.TabIndex = 27;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(661, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 38);
            this.button3.TabIndex = 28;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CmbProfesional
            // 
            this.CmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProfesional.Enabled = false;
            this.CmbProfesional.FormattingEnabled = true;
            this.CmbProfesional.Location = new System.Drawing.Point(510, 30);
            this.CmbProfesional.Name = "CmbProfesional";
            this.CmbProfesional.Size = new System.Drawing.Size(163, 21);
            this.CmbProfesional.TabIndex = 2;
            // 
            // BtnBusOpe
            // 
            this.BtnBusOpe.Image = global::AppEscritorio.Properties.Resources.buscar;
            this.BtnBusOpe.Location = new System.Drawing.Point(319, 30);
            this.BtnBusOpe.Name = "BtnBusOpe";
            this.BtnBusOpe.Size = new System.Drawing.Size(35, 24);
            this.BtnBusOpe.TabIndex = 30;
            this.BtnBusOpe.UseVisualStyleBackColor = true;
            this.BtnBusOpe.Visible = false;
            this.BtnBusOpe.Click += new System.EventHandler(this.BtnBusOpe_Click);
            // 
            // TxtBusqOpe
            // 
            this.TxtBusqOpe.Location = new System.Drawing.Point(96, 254);
            this.TxtBusqOpe.Name = "TxtBusqOpe";
            this.TxtBusqOpe.Size = new System.Drawing.Size(168, 20);
            this.TxtBusqOpe.TabIndex = 31;
            this.TxtBusqOpe.TextChanged += new System.EventHandler(this.TxtBusqOpe_TextChanged);
            this.TxtBusqOpe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBusqOpe_KeyPress);
            // 
            // LblRegistros
            // 
            this.LblRegistros.AutoSize = true;
            this.LblRegistros.Location = new System.Drawing.Point(1080, 268);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(13, 13);
            this.LblRegistros.TabIndex = 32;
            this.LblRegistros.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(990, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Registros:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Buscar";
            // 
            // FrmAvaluos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 472);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LblRegistros);
            this.Controls.Add(this.TxtBusqOpe);
            this.Controls.Add(this.BtnBusOpe);
            this.Controls.Add(this.CmbProfesional);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbBinAdj);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CmbGene);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.TxtMntConst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtMntTerreno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtMntAvaluo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DtFeAvaluo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtGaranSIC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtGaranPS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DgAvaluos);
            this.Controls.Add(this.TxtOperacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbTipoBien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAvaluos";
            this.Text = "Gestor de avaluos";
            this.Load += new System.EventHandler(this.FrmAvaluos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgAvaluos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbTipoBien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtOperacion;
        private System.Windows.Forms.DataGridView DgAvaluos;
        private System.Windows.Forms.TextBox TxtGaranPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtGaranSIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtFeAvaluo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMntTerreno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtMntAvaluo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtMntConst;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.ComboBox CmbGene;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CmbBinAdj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox CmbProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCompania;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgGarantiaPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgGarantiaSIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgFechaAvaluo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgNum_Perito;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgPerito;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMntAvaluo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMntTerreno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMntConstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgMntVehi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgGenReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgTipoBien;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgAdjudicado;
        private System.Windows.Forms.Button BtnBusOpe;
        private System.Windows.Forms.TextBox TxtBusqOpe;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}