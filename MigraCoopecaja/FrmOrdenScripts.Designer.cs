namespace AppEscritorio
{
    partial class FrmOrdenScripts
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
            this.chkAplicaM = new System.Windows.Forms.CheckBox();
            this.IndiceBorrado = new System.Windows.Forms.NumericUpDown();
            this.Label9 = new System.Windows.Forms.Label();
            this.CbxTipoBorrado = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.LblCambio = new System.Windows.Forms.Label();
            this.TxtCambio = new System.Windows.Forms.TextBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.TxtScript = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtIdScript = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.colIdScript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreScript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IndiceBorrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAplicaM
            // 
            this.chkAplicaM.AutoSize = true;
            this.chkAplicaM.Location = new System.Drawing.Point(439, 378);
            this.chkAplicaM.Name = "chkAplicaM";
            this.chkAplicaM.Size = new System.Drawing.Size(104, 17);
            this.chkAplicaM.TabIndex = 48;
            this.chkAplicaM.Text = "Aplica Migración";
            this.chkAplicaM.UseVisualStyleBackColor = true;
            // 
            // IndiceBorrado
            // 
            this.IndiceBorrado.Enabled = false;
            this.IndiceBorrado.Location = new System.Drawing.Point(123, 526);
            this.IndiceBorrado.Name = "IndiceBorrado";
            this.IndiceBorrado.Size = new System.Drawing.Size(120, 20);
            this.IndiceBorrado.TabIndex = 46;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(8, 526);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(76, 13);
            this.Label9.TabIndex = 45;
            this.Label9.Text = "Orden Borrado";
            // 
            // CbxTipoBorrado
            // 
            this.CbxTipoBorrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxTipoBorrado.Enabled = false;
            this.CbxTipoBorrado.FormattingEnabled = true;
            this.CbxTipoBorrado.Items.AddRange(new object[] {
            "Delete",
            "Truncate",
            "No aplica"});
            this.CbxTipoBorrado.Location = new System.Drawing.Point(123, 479);
            this.CbxTipoBorrado.Name = "CbxTipoBorrado";
            this.CbxTipoBorrado.Size = new System.Drawing.Size(121, 21);
            this.CbxTipoBorrado.TabIndex = 44;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(5, 479);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(65, 13);
            this.Label8.TabIndex = 43;
            this.Label8.Text = "TipoBorrado";
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Location = new System.Drawing.Point(336, 343);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(97, 17);
            this.CheckBox2.TabIndex = 42;
            this.CheckBox2.Text = "Reubicar script";
            this.CheckBox2.UseVisualStyleBackColor = true;
            this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged_1);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(242, 581);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 41;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click_1);
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.Enabled = false;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "SQL",
            "ORC"});
            this.ComboBox1.Location = new System.Drawing.Point(123, 431);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(121, 21);
            this.ComboBox1.TabIndex = 40;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(5, 440);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(34, 13);
            this.Label7.TabIndex = 39;
            this.Label7.Text = "Motor";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(12, 41);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(130, 24);
            this.Label6.TabIndex = 38;
            this.Label6.Text = "Switch Script";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(12, 9);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(165, 24);
            this.Label5.TabIndex = 37;
            this.Label5.Text = "Incorporar Script";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(183, 49);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(408, 13);
            this.Label4.TabIndex = 36;
            this.Label4.Text = "Realiza un cambio en los indice del script seleccionado con el indicado por el us" +
    "uario";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(183, 17);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(519, 13);
            this.Label3.TabIndex = 35;
            this.Label3.Text = "Ingresa un nuevo script en el indice de script indicado, desplazando para un indi" +
    "ce posterior todos los demas";
            // 
            // LblCambio
            // 
            this.LblCambio.AutoSize = true;
            this.LblCambio.Location = new System.Drawing.Point(449, 343);
            this.LblCambio.Name = "LblCambio";
            this.LblCambio.Size = new System.Drawing.Size(115, 13);
            this.LblCambio.TabIndex = 34;
            this.LblCambio.Text = "Indice Script a cambiar";
            this.LblCambio.Visible = false;
            // 
            // TxtCambio
            // 
            this.TxtCambio.Location = new System.Drawing.Point(585, 340);
            this.TxtCambio.Name = "TxtCambio";
            this.TxtCambio.Size = new System.Drawing.Size(100, 20);
            this.TxtCambio.TabIndex = 33;
            this.TxtCambio.Visible = false;
            this.TxtCambio.WordWrap = false;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(256, 343);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(58, 17);
            this.CheckBox1.TabIndex = 32;
            this.CheckBox1.Text = "Switch";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged_1);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(415, 581);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 31;
            this.BtnNuevo.Text = "Incorporar";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click_1);
            // 
            // TxtScript
            // 
            this.TxtScript.Enabled = false;
            this.TxtScript.Location = new System.Drawing.Point(123, 376);
            this.TxtScript.Name = "TxtScript";
            this.TxtScript.Size = new System.Drawing.Size(310, 20);
            this.TxtScript.TabIndex = 30;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(9, 383);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "Script";
            // 
            // TxtIdScript
            // 
            this.TxtIdScript.Enabled = false;
            this.TxtIdScript.Location = new System.Drawing.Point(123, 341);
            this.TxtIdScript.Name = "TxtIdScript";
            this.TxtIdScript.Size = new System.Drawing.Size(100, 20);
            this.TxtIdScript.TabIndex = 28;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 344);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "IdScript";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToResizeColumns = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdScript,
            this.colNombreScript,
            this.Motor});
            this.DataGridView1.Location = new System.Drawing.Point(8, 87);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(733, 235);
            this.DataGridView1.TabIndex = 26;
            this.DataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // colIdScript
            // 
            this.colIdScript.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colIdScript.DataPropertyName = "IdScript";
            this.colIdScript.HeaderText = "IdScript";
            this.colIdScript.Name = "colIdScript";
            this.colIdScript.ReadOnly = true;
            this.colIdScript.Width = 68;
            // 
            // colNombreScript
            // 
            this.colNombreScript.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreScript.DataPropertyName = "NombreScripts";
            this.colNombreScript.HeaderText = "NombreScript";
            this.colNombreScript.Name = "colNombreScript";
            this.colNombreScript.ReadOnly = true;
            // 
            // Motor
            // 
            this.Motor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Motor.DataPropertyName = "Motor";
            this.Motor.HeaderText = "Motor";
            this.Motor.Name = "Motor";
            this.Motor.ReadOnly = true;
            this.Motor.Width = 59;
            // 
            // FrmOrdenScripts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 618);
            this.Controls.Add(this.chkAplicaM);
            this.Controls.Add(this.IndiceBorrado);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.CbxTipoBorrado);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.LblCambio);
            this.Controls.Add(this.TxtCambio);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.TxtScript);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtIdScript);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.DataGridView1);
            this.Name = "FrmOrdenScripts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Orden De Scripts";
            this.Load += new System.EventHandler(this.FrmOrdenScripts_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.IndiceBorrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkAplicaM;
        internal System.Windows.Forms.NumericUpDown IndiceBorrado;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.ComboBox CbxTipoBorrado;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.Button BtnModificar;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label LblCambio;
        internal System.Windows.Forms.TextBox TxtCambio;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Button BtnNuevo;
        internal System.Windows.Forms.TextBox TxtScript;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtIdScript;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colIdScript;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colNombreScript;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Motor;
    }
}