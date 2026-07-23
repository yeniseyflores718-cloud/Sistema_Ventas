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
            string usuario = txt_usuario.Text.Trim();
            string pass = txt_contrasena.Text.Trim();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataAcces con = new dataAcces();
            MySqlConnection dbconn = con.getConnection();

            if (dbconn == null)
            {
                MessageBox.Show("No se pudo conectar a la Base de Datos. Verifica que MySQL esté activo.", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string consulta = "SELECT contrasena, rol FROM empleados WHERE nombre_usuario=@nombre";
            MySqlCommand cmd = new MySqlCommand(consulta, dbconn);
            cmd.Parameters.AddWithValue("@nombre", usuario);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string hashAlmacenado = reader["contrasena"].ToString();
                string rol = reader["rol"].ToString();
                bool credencialValida = BCrypt.Net.BCrypt.Verify(pass, hashAlmacenado);
                if (credencialValida)
                {
                    MessageBox.Show("¡Bienvenido al sistema!", "Acceso Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbconn.Close();

                    menu menuu= new menu();
                    this.Hide();
                    menuu.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El usuario no existe.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dbconn.Close();
        

        }

    }
}
