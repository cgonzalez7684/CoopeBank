namespace AppEscritorio.Colocaciones
{
    partial class FrmPlanillas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbPartida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TxtConteo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DgCargaTexto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCentro = new System.Windows.Forms.ComboBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.oFdBuscarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCargaTexto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmbPartida);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.TxtConteo);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TxtTotal);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DgCargaTexto);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.CmbCentro);
            this.tabPage2.Controls.Add(this.BtnBuscar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(573, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conteo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbPartida
            // 
            this.cmbPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartida.FormattingEnabled = true;
            this.cmbPartida.Location = new System.Drawing.Point(142, 299);
            this.cmbPartida.Name = "cmbPartida";
            this.cmbPartida.Size = new System.Drawing.Size(125, 21);
            this.cmbPartida.TabIndex = 13;
            this.cmbPartida.SelectedIndexChanged += new System.EventHandler(this.cmbPartida_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(18, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filtro por partida";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // TxtConteo
            // 
            this.TxtConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConteo.Location = new System.Drawing.Point(142, 382);
            this.TxtConteo.Name = "TxtConteo";
            this.TxtConteo.ReadOnly = true;
            this.TxtConteo.Size = new System.Drawing.Size(206, 26);
            this.TxtConteo.TabIndex = 10;
            this.TxtConteo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(18, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lineas en archivo";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(142, 338);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(206, 26);
            this.TxtTotal.TabIndex = 8;
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(18, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total sumatoria";
            // 
            // DgCargaTexto
            // 
            this.DgCargaTexto.AllowUserToAddRows = false;
            this.DgCargaTexto.AllowUserToDeleteRows = false;
            this.DgCargaTexto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCargaTexto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DgCargaTexto.Location = new System.Drawing.Point(21, 135);
            this.DgCargaTexto.Name = "DgCargaTexto";
            this.DgCargaTexto.ReadOnly = true;
            this.DgCargaTexto.RowHeadersVisible = false;
            this.DgCargaTexto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgCargaTexto.Size = new System.Drawing.Size(520, 126);
            this.DgCargaTexto.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Cedula";
            this.Column1.HeaderText = "Cedula";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Partida";
            this.Column2.HeaderText = "Partida";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Monto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Monto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Institución";
            // 
            // CmbCentro
            // 
            this.CmbCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCentro.FormattingEnabled = true;
            this.CmbCentro.Location = new System.Drawing.Point(116, 37);
            this.CmbCentro.Name = "CmbCentro";
            this.CmbCentro.Size = new System.Drawing.Size(257, 21);
            this.CmbCentro.TabIndex = 4;
            this.CmbCentro.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.CmbCentro.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CmbCentro_MouseClick);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Image = global::AppEscritorio.Properties.Resources.txtFile;
            this.BtnBuscar.Location = new System.Drawing.Point(412, 17);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(59, 41);
            this.BtnBuscar.TabIndex = 0;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // oFdBuscarArchivo
            // 
            this.oFdBuscarArchivo.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Buscar por cedula";
            // 
            // FrmPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 470);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmPlanillas";
            this.Text = "Gestión de planillas";
            this.Load += new System.EventHandler(this.FrmPlanillas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCargaTexto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog oFdBuscarArchivo;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.DataGridView DgCargaTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCentro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox TxtConteo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbPartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}