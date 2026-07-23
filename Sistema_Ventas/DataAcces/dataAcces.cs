using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sistema_Ventas.DataAcces
{
    internal class dataAcces
    {
        private readonly string cadena;
        public dataAcces()
        {
            cadena = "Server=localhost;Database=SistemaVentas;Uid=root;Pwd=;Port=3306;SslMode=0";
        }
        public MySqlConnection getConnection()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(cadena);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion : " + ex.Message);
                return null;
            }
        }
    }
}
