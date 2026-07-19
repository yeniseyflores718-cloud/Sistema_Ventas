using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using Sistema_Ventas.DataAcces;

namespace Sistema_Ventas
{
    public partial class Formlogin2 : Form
    {
        public Formlogin2()
        {
            InitializeComponent();
        }

        private void Formlogin2_Load(object sender, EventArgs e)
        {

        }


        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            string usuario= txt_usuario.Text.Trim();
            string contrasena = txt_contrasena.Text.Trim();
            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese un usuario y una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataAcces conexion = new dataAcces();
            try
            {
                using (MySqlConnection con=conexion.getConnection())
                {
                    if(con==null)
                    return;
                    string consulta= "SELECT nombre_usuario FROM empleados WHERE usuario=@usuario and contrasena=@password";
                    MySqlCommand command = new MySqlCommand(consulta, con);
                    command.Parameters.AddWithValue("@usuario", txt_usuario.Text);
                    command.Parameters.AddWithValue("@password", txt_contrasena.Text);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        menu menuu = new menu();
                        this.Hide();
                        menuu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
