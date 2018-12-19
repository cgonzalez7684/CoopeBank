namespace AppEscritorio.General
{
    partial class FrmPermisos
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
            this.DgUsuarios = new System.Windows.Forms.DataGridView();
            this.colIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPermisos = new System.Windows.Forms.DataGridView();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.codIdModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSubO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSubO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEscr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBorra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colaIdPantalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgUsuarios
            // 
            this.DgUsuarios.AllowUserToAddRows = false;
            this.DgUsuarios.AllowUserToDeleteRows = false;
            this.DgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdUsuario,
            this.colUsuario,
            this.colNombre});
            this.DgUsuarios.Location = new System.Drawing.Point(12, 12);
            this.DgUsuarios.Name = "DgUsuarios";
            this.DgUsuarios.ReadOnly = true;
            this.DgUsuarios.RowHeadersVisible = false;
            this.DgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgUsuarios.Size = new System.Drawing.Size(588, 150);
            this.DgUsuarios.TabIndex = 1;
            this.DgUsuarios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgUsuarios_CellEnter);
            // 
            // colIdUsuario
            // 
            this.colIdUsuario.DataPropertyName = "IdUsuario";
            this.colIdUsuario.HeaderText = "IdUsuario";
            this.colIdUsuario.Name = "colIdUsuario";
            this.colIdUsuario.ReadOnly = true;
            this.colIdUsuario.Visible = false;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.DataPropertyName = "NomUsu";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // DgPermisos
            // 
            this.DgPermisos.AllowUserToAddRows = false;
            this.DgPermisos.AllowUserToDeleteRows = false;
            this.DgPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codIdModulo,
            this.colNomMod,
            this.colIdSubO,
            this.colDsSubO,
            this.colVisi,
            this.colLect,
            this.colEscr,
            this.colBorra,
            this.Column1,
            this.colaIdPantalla});
            this.DgPermisos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgPermisos.Location = new System.Drawing.Point(12, 186);
            this.DgPermisos.Name = "DgPermisos";
            this.DgPermisos.RowHeadersVisible = false;
            this.DgPermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgPermisos.Size = new System.Drawing.Size(588, 150);
            this.DgPermisos.TabIndex = 2;
            this.DgPermisos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPermisos_CellEndEdit);
            this.DgPermisos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPermisos_CellValueChanged);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(234, 346);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(117, 23);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Modificar permisos";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(87, 346);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(117, 23);
            this.BtnNuevo.TabIndex = 4;
            this.BtnNuevo.Text = "Nuevo permiso";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Eliminar permisos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codIdModulo
            // 
            this.codIdModulo.DataPropertyName = "aIdModulo";
            this.codIdModulo.HeaderText = "IdModulo";
            this.codIdModulo.Name = "codIdModulo";
            this.codIdModulo.ReadOnly = true;
            this.codIdModulo.Visible = false;
            // 
            // colNomMod
            // 
            this.colNomMod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNomMod.DataPropertyName = "aDesModulo";
            this.colNomMod.HeaderText = "Modulo";
            this.colNomMod.Name = "colNomMod";
            this.colNomMod.ReadOnly = true;
            this.colNomMod.Width = 67;
            // 
            // colIdSubO
            // 
            this.colIdSubO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colIdSubO.DataPropertyName = "aIdSubOp";
            this.colIdSubO.HeaderText = "IdSubO";
            this.colIdSubO.Name = "colIdSubO";
            this.colIdSubO.ReadOnly = true;
            this.colIdSubO.Visible = false;
            this.colIdSubO.Width = 68;
            // 
            // colDsSubO
            // 
            this.colDsSubO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDsSubO.DataPropertyName = "aNomBoton";
            this.colDsSubO.HeaderText = "Pantalla";
            this.colDsSubO.Name = "colDsSubO";
            this.colDsSubO.ReadOnly = true;
            // 
            // colVisi
            // 
            this.colVisi.DataPropertyName = "aVisible";
            this.colVisi.FalseValue = "0";
            this.colVisi.HeaderText = "Visible";
            this.colVisi.IndeterminateValue = "0";
            this.colVisi.Name = "colVisi";
            this.colVisi.TrueValue = "1";
            // 
            // colLect
            // 
            this.colLect.DataPropertyName = "aLectura";
            this.colLect.FalseValue = "0";
            this.colLect.HeaderText = "Lectura";
            this.colLect.IndeterminateValue = "0";
            this.colLect.Name = "colLect";
            this.colLect.TrueValue = "1";
            // 
            // colEscr
            // 
            this.colEscr.DataPropertyName = "aEscritura";
            this.colEscr.FalseValue = "0";
            this.colEscr.HeaderText = "Escritura";
            this.colEscr.IndeterminateValue = "0";
            this.colEscr.Name = "colEscr";
            this.colEscr.TrueValue = "1";
            // 
            // colBorra
            // 
            this.colBorra.DataPropertyName = "aBorrado";
            this.colBorra.FalseValue = "0";
            this.colBorra.HeaderText = "Borrado";
            this.colBorra.IndeterminateValue = "0";
            this.colBorra.Name = "colBorra";
            this.colBorra.TrueValue = "1";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "aIdUsuario";
            this.Column1.HeaderText = "aIdUsuario";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // colaIdPantalla
            // 
            this.colaIdPantalla.DataPropertyName = "aIdPantalla";
            this.colaIdPantalla.HeaderText = "aIdPantalla";
            this.colaIdPantalla.Name = "colaIdPantalla";
            this.colaIdPantalla.ReadOnly = true;
            this.colaIdPantalla.Visible = false;
            // 
            // FrmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 381);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DgPermisos);
            this.Controls.Add(this.DgUsuarios);
            this.Name = "FrmPermisos";
            this.Text = "Gestión de permisos";
            this.Activated += new System.EventHandler(this.FrmPermisos_Activated);
            this.Load += new System.EventHandler(this.FrmPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridView DgPermisos;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codIdModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSubO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSubO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colLect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEscr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBorra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaIdPantalla;
    }
}