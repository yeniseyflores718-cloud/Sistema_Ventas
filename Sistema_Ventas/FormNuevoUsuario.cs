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
using Sistema_Ventas.DataAcces;


namespace Sistema_Ventas
{
    public partial class FormNuevoUsuario : Form
    {
       private dataAcces conexion;
        public FormNuevoUsuario()
        {
            InitializeComponent();
        }

        private void FormNuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del formulario, se perderan los datos guardados", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_aceptarNuevoUS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nombre_usuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nombre_usuario.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cmb_tipoUsuario.Text))
            {
                MessageBox.Show("El tipo de usuario es obligatorio", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_tipoUsuario.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                MessageBox.Show("La contraseña es obligatoria", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_contraseña.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(txt_confirmar.Text))
            {
                MessageBox.Show("La confirmacion de contraseña es obligatoria", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_confirmar.Focus();
                return;
            }
            if(txt_contraseña.Text != txt_confirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_contraseña.Clear();
                txt_confirmar.Clear();
                txt_contraseña.Focus();
                return;
            }
            if (txt_contraseña.Text.Length<6)
            {
                MessageBox.Show("La contrasena debe tener al menos 6 caracteres.", "Validacion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txt_contraseña.Focus();
                return;
            }
            //hashear la contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txt_contraseña.Text);
            //se inserta el registro en la bd
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            //creamos la consulta
            string consulta = "INSERT INTO empleados(nombre_usuario, contrasena, rol)" + "VALUES (@nombre, @pwd, @rol)";
            MySqlCommand cmd = new MySqlCommand(consulta, con);
            //pasamos los parametros
            cmd.Parameters.AddWithValue("@nombre", txt_nombre_usuario.Text);
            cmd.Parameters.AddWithValue("@pwd", hashedPassword);
            cmd.Parameters.AddWithValue("@rol", cmb_tipoUsuario.Text);
            int filasAfectadas = cmd.ExecuteNonQuery();
            //crerramos la coneccion
            con.Close();

            //verificamos registro
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Registro exitoso");
            }
            else
            {
                MessageBox.Show("Algo falló");
            }

            //-------------------------------------------------
            // 6. Limpiar el formulario para un nuevo registro
            //-------------------------------------------------
            LimpiarFormulario();
        }
        private void LimpiarFormulario()
        {
            txt_nombre_usuario.Clear();
            txt_contraseña.Clear();
            txt_confirmar.Clear();
            
        }
    }
}
