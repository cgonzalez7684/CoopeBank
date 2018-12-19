namespace AppEscritorio.Cobros
{
    partial class FrmCancCreditos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnTodas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCanSaldo = new System.Windows.Forms.Button();
            this.DgCreditosInco = new System.Windows.Forms.DataGridView();
            this.dgIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgAsociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgUltimoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCancelar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCreditosInco)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 456);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnTodas);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BtnCanSaldo);
            this.tabPage1.Controls.Add(this.DgCreditosInco);
            this.tabPage1.Controls.Add(this.TxtBusqueda);
            this.tabPage1.Controls.Add(this.BtnConsultar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gestión";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnTodas
            // 
            this.BtnTodas.Location = new System.Drawing.Point(868, 111);
            this.BtnTodas.Name = "BtnTodas";
            this.BtnTodas.Size = new System.Drawing.Size(75, 23);
            this.BtnTodas.TabIndex = 5;
            this.BtnTodas.Text = "Todas";
            this.BtnTodas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "busqueda por coincidencia";
            // 
            // BtnCanSaldo
            // 
            this.BtnCanSaldo.Location = new System.Drawing.Point(326, 390);
            this.BtnCanSaldo.Name = "BtnCanSaldo";
            this.BtnCanSaldo.Size = new System.Drawing.Size(280, 23);
            this.BtnCanSaldo.TabIndex = 3;
            this.BtnCanSaldo.Text = "Cancelar Saldo de Operaciones marcadas";
            this.BtnCanSaldo.UseVisualStyleBackColor = true;
            this.BtnCanSaldo.Click += new System.EventHandler(this.BtnCanSaldo_Click);
            // 
            // DgCreditosInco
            // 
            this.DgCreditosInco.AllowUserToAddRows = false;
            this.DgCreditosInco.AllowUserToDeleteRows = false;
            this.DgCreditosInco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCreditosInco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgIdentificacion,
            this.DgCodCliente,
            this.DgAsociado,
            this.DgOperacion,
            this.DgUltimoPago,
            this.DgSaldo,
            this.DgCancelar});
            this.DgCreditosInco.Location = new System.Drawing.Point(8, 140);
            this.DgCreditosInco.Name = "DgCreditosInco";
            this.DgCreditosInco.RowHeadersVisible = false;
            this.DgCreditosInco.Size = new System.Drawing.Size(950, 233);
            this.DgCreditosInco.TabIndex = 2;
            // 
            // dgIdentificacion
            // 
            this.dgIdentificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgIdentificacion.DataPropertyName = "DES_IDENTIFICACION";
            this.dgIdentificacion.HeaderText = "Identificación";
            this.dgIdentificacion.Name = "dgIdentificacion";
            this.dgIdentificacion.ReadOnly = true;
            this.dgIdentificacion.Width = 95;
            // 
            // DgCodCliente
            // 
            this.DgCodCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgCodCliente.DataPropertyName = "COD_CLIENTE";
            this.DgCodCliente.HeaderText = "CodCliente";
            this.DgCodCliente.Name = "DgCodCliente";
            this.DgCodCliente.ReadOnly = true;
            this.DgCodCliente.Width = 83;
            // 
            // DgAsociado
            // 
            this.DgAsociado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgAsociado.DataPropertyName = "NOM_CLIENTE";
            this.DgAsociado.HeaderText = "Asociado";
            this.DgAsociado.Name = "DgAsociado";
            this.DgAsociado.ReadOnly = true;
            // 
            // DgOperacion
            // 
            this.DgOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgOperacion.DataPropertyName = "NUM_OPERACION";
            this.DgOperacion.HeaderText = "Operación";
            this.DgOperacion.Name = "DgOperacion";
            this.DgOperacion.ReadOnly = true;
            this.DgOperacion.Width = 81;
            // 
            // DgUltimoPago
            // 
            this.DgUltimoPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgUltimoPago.DataPropertyName = "FEC_ULTPINT";
            this.DgUltimoPago.HeaderText = "UltimoPago";
            this.DgUltimoPago.Name = "DgUltimoPago";
            this.DgUltimoPago.ReadOnly = true;
            this.DgUltimoPago.Width = 86;
            // 
            // DgSaldo
            // 
            this.DgSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgSaldo.DataPropertyName = "Saldo";
            this.DgSaldo.HeaderText = "Saldo";
            this.DgSaldo.Name = "DgSaldo";
            this.DgSaldo.ReadOnly = true;
            this.DgSaldo.Width = 59;
            // 
            // DgCancelar
            // 
            this.DgCancelar.DataPropertyName = "CancelarSaldo";
            this.DgCancelar.FalseValue = "0";
            this.DgCancelar.HeaderText = "CancelarSaldo";
            this.DgCancelar.IndeterminateValue = "1";
            this.DgCancelar.Name = "DgCancelar";
            this.DgCancelar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgCancelar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DgCancelar.TrueValue = "1";
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(8, 111);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(145, 20);
            this.TxtBusqueda.TabIndex = 1;
            this.TxtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBusqueda_KeyPress);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(326, 49);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(280, 23);
            this.BtnConsultar.TabIndex = 0;
            this.BtnConsultar.Text = "Consultar operaciones en estado incobrable PSBANK";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(966, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bitacora";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmCancCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 456);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCancCreditos";
            this.Text = "Cancelación de creditos incobrables";
            this.Load += new System.EventHandler(this.FrmCancCreditos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCreditosInco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BtnTodas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCanSaldo;
        private System.Windows.Forms.DataGridView DgCreditosInco;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgAsociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgUltimoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgSaldo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgCancelar;
    }
}