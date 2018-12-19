namespace AppEscritorio.Colocaciones
{
    partial class FrmEspeciales
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtOperacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rdbApunto = new System.Windows.Forms.RadioButton();
            this.rdbEspecial = new System.Windows.Forms.RadioButton();
            this.rdbNoEspecial = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Nombre Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Código de Cliente";
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomCliente.Location = new System.Drawing.Point(134, 95);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.ReadOnly = true;
            this.txtNomCliente.Size = new System.Drawing.Size(335, 20);
            this.txtNomCliente.TabIndex = 55;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCodCliente.Location = new System.Drawing.Point(12, 95);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodCliente.TabIndex = 54;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Location = new System.Drawing.Point(12, 42);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(100, 20);
            this.txtOperacion.TabIndex = 58;
            this.txtOperacion.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Operación";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdbApunto
            // 
            this.rdbApunto.AutoSize = true;
            this.rdbApunto.Checked = true;
            this.rdbApunto.Location = new System.Drawing.Point(12, 131);
            this.rdbApunto.Name = "rdbApunto";
            this.rdbApunto.Size = new System.Drawing.Size(190, 17);
            this.rdbApunto.TabIndex = 61;
            this.rdbApunto.TabStop = true;
            this.rdbApunto.Text = "Eliminar de Apunto de Ser Especial";
            this.rdbApunto.UseVisualStyleBackColor = true;
            // 
            // rdbEspecial
            // 
            this.rdbEspecial.AutoSize = true;
            this.rdbEspecial.Location = new System.Drawing.Point(12, 151);
            this.rdbEspecial.Name = "rdbEspecial";
            this.rdbEspecial.Size = new System.Drawing.Size(184, 17);
            this.rdbEspecial.TabIndex = 62;
            this.rdbEspecial.Text = "Asignar como Operación Especial";
            this.rdbEspecial.UseVisualStyleBackColor = true;
            // 
            // rdbNoEspecial
            // 
            this.rdbNoEspecial.AutoSize = true;
            this.rdbNoEspecial.Location = new System.Drawing.Point(12, 174);
            this.rdbNoEspecial.Name = "rdbNoEspecial";
            this.rdbNoEspecial.Size = new System.Drawing.Size(147, 17);
            this.rdbNoEspecial.TabIndex = 63;
            this.rdbNoEspecial.Text = "Asignar como no Especial";
            this.rdbNoEspecial.UseVisualStyleBackColor = true;
            // 
            // FrmEspeciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 246);
            this.Controls.Add(this.rdbNoEspecial);
            this.Controls.Add(this.rdbEspecial);
            this.Controls.Add(this.rdbApunto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOperacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomCliente);
            this.Controls.Add(this.txtCodCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEspeciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operaciones especiales";
            this.Load += new System.EventHandler(this.FrmEspeciales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtOperacion;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdbApunto;
        private System.Windows.Forms.RadioButton rdbEspecial;
        private System.Windows.Forms.RadioButton rdbNoEspecial;
    }
}