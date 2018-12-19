namespace AppEscritorio.Colocaciones
{
    partial class FrmBuscarOperacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.dgOperaciones = new System.Windows.Forms.DataGridView();
            this.dgCOD_COMPANIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDes_Identificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCod_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNom_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNum_Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFec_Constitucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFec_Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMon_Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNum_Garantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGarantiaSIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(95, 34);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(206, 20);
            this.TxtBuscar.TabIndex = 1;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            this.TxtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBuscar_KeyPress);
            // 
            // dgOperaciones
            // 
            this.dgOperaciones.AllowUserToAddRows = false;
            this.dgOperaciones.AllowUserToDeleteRows = false;
            this.dgOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOperaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgCOD_COMPANIA,
            this.dgDes_Identificacion,
            this.dgCod_Cliente,
            this.dgNom_Cliente,
            this.dgNum_Operacion,
            this.dgFec_Constitucion,
            this.dgFec_Vencimiento,
            this.dgMon_Original,
            this.dgSaldo,
            this.dgNum_Garantia,
            this.dgGarantiaSIC,
            this.dgEstado});
            this.dgOperaciones.Location = new System.Drawing.Point(12, 67);
            this.dgOperaciones.Name = "dgOperaciones";
            this.dgOperaciones.ReadOnly = true;
            this.dgOperaciones.RowHeadersVisible = false;
            this.dgOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOperaciones.Size = new System.Drawing.Size(666, 198);
            this.dgOperaciones.TabIndex = 2;
            this.dgOperaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOperaciones_CellContentClick);
            this.dgOperaciones.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgOperaciones_CellMouseDoubleClick);
            // 
            // dgCOD_COMPANIA
            // 
            this.dgCOD_COMPANIA.DataPropertyName = "COD_COMPANIA";
            this.dgCOD_COMPANIA.HeaderText = "Compania";
            this.dgCOD_COMPANIA.Name = "dgCOD_COMPANIA";
            this.dgCOD_COMPANIA.ReadOnly = true;
            this.dgCOD_COMPANIA.Visible = false;
            // 
            // dgDes_Identificacion
            // 
            this.dgDes_Identificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgDes_Identificacion.DataPropertyName = "DES_IDENTIFICACION";
            this.dgDes_Identificacion.HeaderText = "IdAsociado";
            this.dgDes_Identificacion.Name = "dgDes_Identificacion";
            this.dgDes_Identificacion.ReadOnly = true;
            this.dgDes_Identificacion.Width = 85;
            // 
            // dgCod_Cliente
            // 
            this.dgCod_Cliente.DataPropertyName = "COD_CLIENTE";
            this.dgCod_Cliente.HeaderText = "ClientePS";
            this.dgCod_Cliente.Name = "dgCod_Cliente";
            this.dgCod_Cliente.ReadOnly = true;
            this.dgCod_Cliente.Visible = false;
            // 
            // dgNom_Cliente
            // 
            this.dgNom_Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgNom_Cliente.DataPropertyName = "NOM_CLIENTE";
            this.dgNom_Cliente.FillWeight = 200F;
            this.dgNom_Cliente.HeaderText = "Nombre";
            this.dgNom_Cliente.Name = "dgNom_Cliente";
            this.dgNom_Cliente.ReadOnly = true;
            // 
            // dgNum_Operacion
            // 
            this.dgNum_Operacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgNum_Operacion.DataPropertyName = "NUM_OPERACION";
            this.dgNum_Operacion.HeaderText = "Operacion";
            this.dgNum_Operacion.Name = "dgNum_Operacion";
            this.dgNum_Operacion.ReadOnly = true;
            this.dgNum_Operacion.Width = 81;
            // 
            // dgFec_Constitucion
            // 
            this.dgFec_Constitucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgFec_Constitucion.DataPropertyName = "FEC_CONSTITUCION";
            this.dgFec_Constitucion.HeaderText = "Formalizacion";
            this.dgFec_Constitucion.Name = "dgFec_Constitucion";
            this.dgFec_Constitucion.ReadOnly = true;
            this.dgFec_Constitucion.Width = 96;
            // 
            // dgFec_Vencimiento
            // 
            this.dgFec_Vencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgFec_Vencimiento.DataPropertyName = "FEC_VENCIMIENTO";
            this.dgFec_Vencimiento.HeaderText = "Vencimiento";
            this.dgFec_Vencimiento.Name = "dgFec_Vencimiento";
            this.dgFec_Vencimiento.ReadOnly = true;
            this.dgFec_Vencimiento.Visible = false;
            // 
            // dgMon_Original
            // 
            this.dgMon_Original.DataPropertyName = "MON_ORIGINAL";
            this.dgMon_Original.HeaderText = "Original";
            this.dgMon_Original.Name = "dgMon_Original";
            this.dgMon_Original.ReadOnly = true;
            this.dgMon_Original.Visible = false;
            // 
            // dgSaldo
            // 
            this.dgSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgSaldo.DataPropertyName = "SALDO";
            this.dgSaldo.HeaderText = "Saldo";
            this.dgSaldo.Name = "dgSaldo";
            this.dgSaldo.ReadOnly = true;
            this.dgSaldo.Width = 59;
            // 
            // dgNum_Garantia
            // 
            this.dgNum_Garantia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgNum_Garantia.DataPropertyName = "NUM_GARANTIA";
            this.dgNum_Garantia.HeaderText = "GarantiaPS";
            this.dgNum_Garantia.Name = "dgNum_Garantia";
            this.dgNum_Garantia.ReadOnly = true;
            this.dgNum_Garantia.Width = 86;
            // 
            // dgGarantiaSIC
            // 
            this.dgGarantiaSIC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgGarantiaSIC.DataPropertyName = "GARANTIASIC";
            this.dgGarantiaSIC.HeaderText = "GarantiaSIC";
            this.dgGarantiaSIC.Name = "dgGarantiaSIC";
            this.dgGarantiaSIC.ReadOnly = true;
            this.dgGarantiaSIC.Width = 89;
            // 
            // dgEstado
            // 
            this.dgEstado.DataPropertyName = "ESTADO";
            this.dgEstado.HeaderText = "Estado";
            this.dgEstado.Name = "dgEstado";
            this.dgEstado.ReadOnly = true;
            this.dgEstado.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Esta pantalla solo muestra aquellas operaciones cuyas garantias ya no se encuentr" +
    "en registradas.";
            // 
            // FrmBuscarOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 276);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgOperaciones);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarOperacion";
            this.Text = "Operaciones crediticias";
            this.Load += new System.EventHandler(this.FrmBuscarOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView dgOperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOD_COMPANIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDes_Identificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCod_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNom_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNum_Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFec_Constitucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFec_Vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMon_Original;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNum_Garantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGarantiaSIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEstado;
        private System.Windows.Forms.Label label2;
    }
}