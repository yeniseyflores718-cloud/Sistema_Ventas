namespace Sistema_Ventas
{
    partial class Formlogin2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formlogin2));
            this.picicono = new System.Windows.Forms.PictureBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contrasena = new System.Windows.Forms.TextBox();
            this.btn_iniciar_sesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picicono)).BeginInit();
            this.SuspendLayout();
            // 
            // picicono
            // 
            this.picicono.BackColor = System.Drawing.Color.Transparent;
            this.picicono.Image = global::Sistema_Ventas.Properties.Resources.iconopro;
            this.picicono.Location = new System.Drawing.Point(345, 79);
            this.picicono.Name = "picicono";
            this.picicono.Size = new System.Drawing.Size(190, 143);
            this.picicono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picicono.TabIndex = 0;
            this.picicono.TabStop = false;
            // 
            // txt_usuario
            // 
            this.txt_usuario.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usuario.Location = new System.Drawing.Point(360, 267);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(154, 26);
            this.txt_usuario.TabIndex = 1;
            this.txt_usuario.Text = "👤   Usuario";
            // 
            // txt_contrasena
            // 
            this.txt_contrasena.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contrasena.Location = new System.Drawing.Point(360, 319);
            this.txt_contrasena.Name = "txt_contrasena";
            this.txt_contrasena.Size = new System.Drawing.Size(154, 26);
            this.txt_contrasena.TabIndex = 2;
            this.txt_contrasena.Text = "🔒   Contraseña";
            // 
            // btn_iniciar_sesion
            // 
            this.btn_iniciar_sesion.BackgroundImage = global::Sistema_Ventas.Properties.Resources.fondoiniciarsesion;
            this.btn_iniciar_sesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_iniciar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iniciar_sesion.Location = new System.Drawing.Point(360, 365);
            this.btn_iniciar_sesion.Name = "btn_iniciar_sesion";
            this.btn_iniciar_sesion.Size = new System.Drawing.Size(154, 34);
            this.btn_iniciar_sesion.TabIndex = 3;
            this.btn_iniciar_sesion.UseVisualStyleBackColor = true;
            this.btn_iniciar_sesion.Click += new System.EventHandler(this.btn_iniciar_sesion_Click);
            // 
            // Formlogin2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistema_Ventas.Properties.Resources.Fondo_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(875, 513);
            this.Controls.Add(this.btn_iniciar_sesion);
            this.Controls.Add(this.txt_contrasena);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.picicono);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Formlogin2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.Load += new System.EventHandler(this.Formlogin2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picicono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picicono;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contrasena;
        private System.Windows.Forms.Button btn_iniciar_sesion;
    }
}