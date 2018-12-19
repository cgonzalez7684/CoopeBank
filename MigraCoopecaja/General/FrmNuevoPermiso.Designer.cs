namespace AppEscritorio.General
{
    partial class FrmNuevoPermiso
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
            this.CmbModulo = new System.Windows.Forms.ComboBox();
            this.ChkVisible = new System.Windows.Forms.CheckBox();
            this.ChkEscritura = new System.Windows.Forms.CheckBox();
            this.ChkLectura = new System.Windows.Forms.CheckBox();
            this.ChkBorrado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.CmbPan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CmbModulo
            // 
            this.CmbModulo.DisplayMember = "DesModulo";
            this.CmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbModulo.FormattingEnabled = true;
            this.CmbModulo.Location = new System.Drawing.Point(71, 27);
            this.CmbModulo.Name = "CmbModulo";
            this.CmbModulo.Size = new System.Drawing.Size(121, 21);
            this.CmbModulo.TabIndex = 0;
            this.CmbModulo.ValueMember = "IdModulo";
            this.CmbModulo.SelectedIndexChanged += new System.EventHandler(this.CmbModulo_SelectedIndexChanged);
            this.CmbModulo.SelectedValueChanged += new System.EventHandler(this.CmbModulo_SelectedValueChanged);
            // 
            // ChkVisible
            // 
            this.ChkVisible.AutoSize = true;
            this.ChkVisible.Checked = true;
            this.ChkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkVisible.Location = new System.Drawing.Point(18, 85);
            this.ChkVisible.Name = "ChkVisible";
            this.ChkVisible.Size = new System.Drawing.Size(56, 17);
            this.ChkVisible.TabIndex = 2;
            this.ChkVisible.Text = "Visible";
            this.ChkVisible.UseVisualStyleBackColor = true;
            // 
            // ChkEscritura
            // 
            this.ChkEscritura.AutoSize = true;
            this.ChkEscritura.Checked = true;
            this.ChkEscritura.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEscritura.Location = new System.Drawing.Point(125, 85);
            this.ChkEscritura.Name = "ChkEscritura";
            this.ChkEscritura.Size = new System.Drawing.Size(67, 17);
            this.ChkEscritura.TabIndex = 3;
            this.ChkEscritura.Text = "Escritura";
            this.ChkEscritura.UseVisualStyleBackColor = true;
            // 
            // ChkLectura
            // 
            this.ChkLectura.AutoSize = true;
            this.ChkLectura.Checked = true;
            this.ChkLectura.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkLectura.Location = new System.Drawing.Point(239, 85);
            this.ChkLectura.Name = "ChkLectura";
            this.ChkLectura.Size = new System.Drawing.Size(62, 17);
            this.ChkLectura.TabIndex = 4;
            this.ChkLectura.Text = "Lectura";
            this.ChkLectura.UseVisualStyleBackColor = true;
            // 
            // ChkBorrado
            // 
            this.ChkBorrado.AutoSize = true;
            this.ChkBorrado.Checked = true;
            this.ChkBorrado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBorrado.Location = new System.Drawing.Point(351, 85);
            this.ChkBorrado.Name = "ChkBorrado";
            this.ChkBorrado.Size = new System.Drawing.Size(63, 17);
            this.ChkBorrado.TabIndex = 5;
            this.ChkBorrado.Text = "Borrado";
            this.ChkBorrado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Modulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pantalla";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(157, 129);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // CmbPan
            // 
            this.CmbPan.DisplayMember = "NomBoton";
            this.CmbPan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPan.FormattingEnabled = true;
            this.CmbPan.Location = new System.Drawing.Point(293, 27);
            this.CmbPan.Name = "CmbPan";
            this.CmbPan.Size = new System.Drawing.Size(121, 21);
            this.CmbPan.TabIndex = 9;
            this.CmbPan.ValueMember = "IdPantalla";
            // 
            // FrmNuevoPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 176);
            this.Controls.Add(this.CmbPan);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkBorrado);
            this.Controls.Add(this.ChkLectura);
            this.Controls.Add(this.ChkEscritura);
            this.Controls.Add(this.ChkVisible);
            this.Controls.Add(this.CmbModulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmNuevoPermiso";
            this.Text = "Nuevo permiso";
            this.Load += new System.EventHandler(this.FrmNuevoPermiso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbModulo;
        private System.Windows.Forms.CheckBox ChkVisible;
        private System.Windows.Forms.CheckBox ChkEscritura;
        private System.Windows.Forms.CheckBox ChkLectura;
        private System.Windows.Forms.CheckBox ChkBorrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ComboBox CmbPan;
    }
}