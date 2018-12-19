namespace AppEscritorio.Captacion
{
    partial class FrmCertiCredito
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
            this.dtgCerti = new System.Windows.Forms.DataGridView();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asociado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOperacion = new System.Windows.Forms.TextBox();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCerti = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCerti)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCerti
            // 
            this.dtgCerti.AllowUserToAddRows = false;
            this.dtgCerti.AllowUserToDeleteRows = false;
            this.dtgCerti.AllowUserToResizeColumns = false;
            this.dtgCerti.AllowUserToResizeRows = false;
            this.dtgCerti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCerti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Operacion,
            this.Linea,
            this.Asociado,
            this.Asociado1,
            this.Titulo,
            this.id});
            this.dtgCerti.Location = new System.Drawing.Point(12, 163);
            this.dtgCerti.Name = "dtgCerti";
            this.dtgCerti.ReadOnly = true;
            this.dtgCerti.RowHeadersVisible = false;
            this.dtgCerti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCerti.Size = new System.Drawing.Size(733, 235);
            this.dtgCerti.TabIndex = 15;
            this.dtgCerti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCerti_CellContentClick);
            this.dtgCerti.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgCerti_ColumnHeaderMouseClick);
            this.dtgCerti.SelectionChanged += new System.EventHandler(this.dtgCerti_SelectionChanged);
            // 
            // Operacion
            // 
            this.Operacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "Operación";
            this.Operacion.Name = "Operacion";
            this.Operacion.ReadOnly = true;
            this.Operacion.Width = 81;
            // 
            // Linea
            // 
            this.Linea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Linea.DataPropertyName = "Linea";
            this.Linea.HeaderText = "Línea";
            this.Linea.MinimumWidth = 150;
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            this.Linea.Width = 250;
            // 
            // Asociado
            // 
            this.Asociado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Asociado.DataPropertyName = "Asociado";
            this.Asociado.HeaderText = "Asociado";
            this.Asociado.Name = "Asociado";
            this.Asociado.ReadOnly = true;
            // 
            // Asociado1
            // 
            this.Asociado1.DataPropertyName = "Asociado1";
            this.Asociado1.HeaderText = "Nombre";
            this.Asociado1.Name = "Asociado1";
            this.Asociado1.ReadOnly = true;
            this.Asociado1.Width = 200;
            // 
            // Titulo
            // 
            this.Titulo.DataPropertyName = "Titulo";
            this.Titulo.HeaderText = "Título";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Location = new System.Drawing.Point(24, 82);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(100, 20);
            this.txtOperacion.TabIndex = 16;
            this.txtOperacion.Validating += new System.ComponentModel.CancelEventHandler(this.txtOperacion_Validating);
            // 
            // txtLinea
            // 
            this.txtLinea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLinea.Enabled = false;
            this.txtLinea.Location = new System.Drawing.Point(141, 82);
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.ReadOnly = true;
            this.txtLinea.Size = new System.Drawing.Size(337, 20);
            this.txtLinea.TabIndex = 17;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(141, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(337, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // txtAsociado
            // 
            this.txtAsociado.Location = new System.Drawing.Point(24, 36);
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.Size = new System.Drawing.Size(100, 20);
            this.txtAsociado.TabIndex = 18;
            this.txtAsociado.TextChanged += new System.EventHandler(this.txtAsociado_TextChanged);
            this.txtAsociado.Validated += new System.EventHandler(this.txtAsociado_Validated);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(24, 128);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 20;
            this.txtTitulo.Text = "0";
            this.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTitulo.TextChanged += new System.EventHandler(this.txtTitulo_TextChanged);
            this.txtTitulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitulo_KeyPress);
            this.txtTitulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitulo_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(498, 117);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 40);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Nuevo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(667, 117);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 40);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(582, 117);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 40);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Actualizar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Crédito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Línea de Crédito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Asociado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Título";
            // 
            // txtCerti
            // 
            this.txtCerti.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCerti.Enabled = false;
            this.txtCerti.Location = new System.Drawing.Point(141, 128);
            this.txtCerti.Name = "txtCerti";
            this.txtCerti.ReadOnly = true;
            this.txtCerti.Size = new System.Drawing.Size(337, 20);
            this.txtCerti.TabIndex = 29;
            this.txtCerti.Visible = false;
            // 
            // FrmCertiCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 431);
            this.Controls.Add(this.txtCerti);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.txtLinea);
            this.Controls.Add(this.txtOperacion);
            this.Controls.Add(this.dtgCerti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCertiCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificados en garantía de Crédito";
            this.Load += new System.EventHandler(this.FrmCertiCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCerti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dtgCerti;
        private System.Windows.Forms.TextBox txtOperacion;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asociado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.TextBox txtCerti;
    }
}