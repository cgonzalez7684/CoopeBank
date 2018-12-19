namespace AppEscritorio.Colocaciones
{
    partial class FrmBuscarUsuariosPs
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
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.DgUsuariosPs = new System.Windows.Forms.DataGridView();
            this.DgCod_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgDES_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuariosPs)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(109, 23);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(117, 20);
            this.TxtBuscar.TabIndex = 0;
            // 
            // DgUsuariosPs
            // 
            this.DgUsuariosPs.AllowUserToAddRows = false;
            this.DgUsuariosPs.AllowUserToDeleteRows = false;
            this.DgUsuariosPs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgUsuariosPs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgCod_Usuario,
            this.DgDES_NOMBRE});
            this.DgUsuariosPs.Location = new System.Drawing.Point(12, 60);
            this.DgUsuariosPs.Name = "DgUsuariosPs";
            this.DgUsuariosPs.ReadOnly = true;
            this.DgUsuariosPs.RowHeadersVisible = false;
            this.DgUsuariosPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgUsuariosPs.Size = new System.Drawing.Size(387, 150);
            this.DgUsuariosPs.TabIndex = 1;
            this.DgUsuariosPs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgUsuariosPs_CellContentDoubleClick);
            this.DgUsuariosPs.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgUsuariosPs_CellEnter);
            // 
            // DgCod_Usuario
            // 
            this.DgCod_Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DgCod_Usuario.DataPropertyName = "COD_USUARIO";
            this.DgCod_Usuario.HeaderText = "Usuario";
            this.DgCod_Usuario.Name = "DgCod_Usuario";
            this.DgCod_Usuario.ReadOnly = true;
            this.DgCod_Usuario.Width = 68;
            // 
            // DgDES_NOMBRE
            // 
            this.DgDES_NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgDES_NOMBRE.DataPropertyName = "DES_NOMBRE";
            this.DgDES_NOMBRE.HeaderText = "Nombre";
            this.DgDES_NOMBRE.Name = "DgDES_NOMBRE";
            this.DgDES_NOMBRE.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar";
            // 
            // FrmBuscarUsuariosPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 221);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgUsuariosPs);
            this.Controls.Add(this.TxtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarUsuariosPs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios PSBANK";
            this.Load += new System.EventHandler(this.FrmBuscarUsuariosPs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuariosPs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView DgUsuariosPs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgCod_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgDES_NOMBRE;
    }
}