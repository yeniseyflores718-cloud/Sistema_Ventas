using MySql.Data.MySqlClient;
using Sistema_Ventas.DataAcces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas
{
    public partial class Agregar_categoria : Form
    {
        public Agregar_categoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Escribe una categoría");
                return;
            }

            dataAcces conexion = new dataAcces();

            using (MySqlConnection con = conexion.getConnection())
            {
                string query = "INSERT INTO categoria(categoria) VALUES(@categoria)";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Categoría agregada correctamente");

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
