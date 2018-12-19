namespace AppEscritorio.Colocaciones
{
    partial class FrmCambVend
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
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtSolicitud = new System.Windows.Forms.TextBox();
            this.txtNomAsesor = new System.Windows.Forms.TextBox();
            this.txtCodAsesor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomAsesorN = new System.Windows.Forms.TextBox();
            this.txtCodAsesorN = new System.Windows.Forms.TextBox();
            this.btnAsesor = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomCliente.Enabled = false;
            this.txtNomCliente.Location = new System.Drawing.Point(134, 96);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.ReadOnly = true;
            this.txtNomCliente.Size = new System.Drawing.Size(335, 20);
            this.txtNomCliente.TabIndex = 53;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.Location = new System.Drawing.Point(12, 96);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodCliente.TabIndex = 52;
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Location = new System.Drawing.Point(12, 51);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(100, 20);
            this.txtSolicitud.TabIndex = 1;
            this.txtSolicitud.Validating += new System.ComponentModel.CancelEventHandler(this.txtSolicitud_Validating);
            // 
            // txtNomAsesor
            // 
            this.txtNomAsesor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomAsesor.Enabled = false;
            this.txtNomAsesor.Location = new System.Drawing.Point(134, 143);
            this.txtNomAsesor.Name = "txtNomAsesor";
            this.txtNomAsesor.ReadOnly = true;
            this.txtNomAsesor.Size = new System.Drawing.Size(335, 20);
            this.txtNomAsesor.TabIndex = 56;
            // 
            // txtCodAsesor
            // 
            this.txtCodAsesor.Enabled = false;
            this.txtCodAsesor.Location = new System.Drawing.Point(12, 143);
            this.txtCodAsesor.Name = "txtCodAsesor";
            this.txtCodAsesor.Size = new System.Drawing.Size(100, 20);
            this.txtCodAsesor.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Solicitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Asesor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Nuevo Asesor";
            // 
            // txtNomAsesorN
            // 
            this.txtNomAsesorN.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomAsesorN.Enabled = false;
            this.txtNomAsesorN.Location = new System.Drawing.Point(134, 194);
            this.txtNomAsesorN.Name = "txtNomAsesorN";
            this.txtNomAsesorN.ReadOnly = true;
            this.txtNomAsesorN.Size = new System.Drawing.Size(335, 20);
            this.txtNomAsesorN.TabIndex = 61;
            // 
            // txtCodAsesorN
            // 
            this.txtCodAsesorN.Enabled = false;
            this.txtCodAsesorN.Location = new System.Drawing.Point(12, 194);
            this.txtCodAsesorN.Name = "txtCodAsesorN";
            this.txtCodAsesorN.Size = new System.Drawing.Size(100, 20);
            this.txtCodAsesorN.TabIndex = 60;
            // 
            // btnAsesor
            // 
            this.btnAsesor.Location = new System.Drawing.Point(475, 192);
            this.btnAsesor.Name = "btnAsesor";
            this.btnAsesor.Size = new System.Drawing.Size(26, 23);
            this.btnAsesor.TabIndex = 2;
            this.btnAsesor.Text = "...";
            this.btnAsesor.UseVisualStyleBackColor = true;
            this.btnAsesor.Click += new System.EventHandler(this.btnAsesor_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(215, 240);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 31);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCambVend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 292);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAsesor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomAsesorN);
            this.Controls.Add(this.txtCodAsesorN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomAsesor);
            this.Controls.Add(this.txtCodAsesor);
            this.Controls.Add(this.txtSolicitud);
            this.Controls.Add(this.txtNomCliente);
            this.Controls.Add(this.txtCodCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCambVend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de vendedores en operaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtSolicitud;
        private System.Windows.Forms.TextBox txtNomAsesor;
        private System.Windows.Forms.TextBox txtCodAsesor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomAsesorN;
        private System.Windows.Forms.TextBox txtCodAsesorN;
        private System.Windows.Forms.Button btnAsesor;
        private System.Windows.Forms.Button btnGuardar;
    }
}