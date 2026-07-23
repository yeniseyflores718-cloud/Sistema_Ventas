namespace Sistema_Ventas
{
    partial class FormNuevoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_id_usuario = new System.Windows.Forms.TextBox();
            this.txt_nombre_usuario = new System.Windows.Forms.TextBox();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.txt_confirmar = new System.Windows.Forms.TextBox();
            this.btn_cancelarNuevoUS = new System.Windows.Forms.Button();
            this.btn_aceptarNuevoUS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_tipoUsuario = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Nuevo Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID Usuario:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 255);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 310);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Confirmar:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_id_usuario
            // 
            this.txt_id_usuario.Location = new System.Drawing.Point(124, 77);
            this.txt_id_usuario.Name = "txt_id_usuario";
            this.txt_id_usuario.Size = new System.Drawing.Size(200, 25);
            this.txt_id_usuario.TabIndex = 5;
            // 
            // txt_nombre_usuario
            // 
            this.txt_nombre_usuario.Location = new System.Drawing.Point(124, 137);
            this.txt_nombre_usuario.Name = "txt_nombre_usuario";
            this.txt_nombre_usuario.Size = new System.Drawing.Size(200, 25);
            this.txt_nombre_usuario.TabIndex = 6;
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.Location = new System.Drawing.Point(119, 247);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.Size = new System.Drawing.Size(205, 25);
            this.txt_contraseña.TabIndex = 7;
            // 
            // txt_confirmar
            // 
            this.txt_confirmar.Location = new System.Drawing.Point(119, 302);
            this.txt_confirmar.Name = "txt_confirmar";
            this.txt_confirmar.Size = new System.Drawing.Size(205, 25);
            this.txt_confirmar.TabIndex = 8;
            // 
            // btn_cancelarNuevoUS
            // 
            this.btn_cancelarNuevoUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelarNuevoUS.Location = new System.Drawing.Point(251, 371);
            this.btn_cancelarNuevoUS.Name = "btn_cancelarNuevoUS";
            this.btn_cancelarNuevoUS.Size = new System.Drawing.Size(105, 32);
            this.btn_cancelarNuevoUS.TabIndex = 9;
            this.btn_cancelarNuevoUS.Text = "❌ Cancelar";
            this.btn_cancelarNuevoUS.UseVisualStyleBackColor = true;
            this.btn_cancelarNuevoUS.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_aceptarNuevoUS
            // 
            this.btn_aceptarNuevoUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptarNuevoUS.Location = new System.Drawing.Point(388, 370);
            this.btn_aceptarNuevoUS.Name = "btn_aceptarNuevoUS";
            this.btn_aceptarNuevoUS.Size = new System.Drawing.Size(102, 33);
            this.btn_aceptarNuevoUS.TabIndex = 10;
            this.btn_aceptarNuevoUS.Text = "✔️ Aceptar";
            this.btn_aceptarNuevoUS.UseVisualStyleBackColor = true;
            this.btn_aceptarNuevoUS.Click += new System.EventHandler(this.btn_aceptarNuevoUS_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo:";
            // 
            // cmb_tipoUsuario
            // 
            this.cmb_tipoUsuario.FormattingEnabled = true;
            this.cmb_tipoUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.cmb_tipoUsuario.Location = new System.Drawing.Point(124, 198);
            this.cmb_tipoUsuario.Name = "cmb_tipoUsuario";
            this.cmb_tipoUsuario.Size = new System.Drawing.Size(200, 25);
            this.cmb_tipoUsuario.TabIndex = 12;
            // 
            // FormNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(513, 420);
            this.Controls.Add(this.cmb_tipoUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_aceptarNuevoUS);
            this.Controls.Add(this.btn_cancelarNuevoUS);
            this.Controls.Add(this.txt_confirmar);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.txt_nombre_usuario);
            this.Controls.Add(this.txt_id_usuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevoUsuario";
            this.Load += new System.EventHandler(this.FormNuevoUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_id_usuario;
        private System.Windows.Forms.TextBox txt_nombre_usuario;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.TextBox txt_confirmar;
        private System.Windows.Forms.Button btn_cancelarNuevoUS;
        private System.Windows.Forms.Button btn_aceptarNuevoUS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_tipoUsuario;
    }
}