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
using System.Drawing.Text;

namespace Sistema_Ventas
{
    public partial class Form_Inventario : Form
    {
        private dataAcces conexion;
        public Form_Inventario()
        {
            InitializeComponent();
        }
        private void cargarDatos()
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            string consulta = @"SELECT
            p.id_Producto,
            p.nombre_producto,
            c.categoria,
            p.stock_act,
            p.stock_min,
            p.fecha_com,
            p.fecha_cad,
            CASE
                WHEN p.stock_act <= p.stock_min THEN 'Stock bajo'
                WHEN p.fecha_cad < CURDATE() THEN 'Caducado'
                WHEN p.fecha_cad BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY) THEN 'Próximo a caducar'
                ELSE 'Disponible'
            END AS estado
            FROM productos p
            INNER JOIN categoria c
            ON p.id_categoria = c.id_categoria;";

            MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv_inventario.DataSource = dt;

        }
        private void TotalProductos()
        {
            MySqlConnection con = conexion.getConnection();

            string consulta = "SELECT COUNT(*) FROM productos";

            MySqlCommand cmd = new MySqlCommand(consulta, con);

            lbl_productosRg.Text = cmd.ExecuteScalar().ToString();

            con.Close();
        }
        private void BajoStock()
        {
            MySqlConnection con = conexion.getConnection();

            string consulta = @"SELECT COUNT(*)
                        FROM productos
                        WHERE stock_act <= stock_min";

            MySqlCommand cmd = new MySqlCommand(consulta, con);

            lbl_stockbajo.Text = cmd.ExecuteScalar().ToString();

            con.Close();
        }
        private void ProximosCaducar()
        {
            MySqlConnection con = conexion.getConnection();

            string consulta = @"SELECT COUNT(*)
                        FROM productos
                        WHERE fecha_cad BETWEEN CURDATE()
                        AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

            MySqlCommand cmd = new MySqlCommand(consulta, con);

            lbl_Pcaducar.Text= cmd.ExecuteScalar().ToString();

            con.Close();
        }
        private void ProductosCaducados()
        {
            MySqlConnection con = conexion.getConnection();

            string consulta = @"SELECT COUNT(*)
                        FROM productos
                        WHERE fecha_cad < CURDATE()";

            MySqlCommand cmd = new MySqlCommand(consulta, con);

           lbl_caducados.Text = cmd.ExecuteScalar().ToString();

            con.Close();
        }
        private void CargarIndicadores()
        {
            TotalProductos();
            BajoStock();
            ProximosCaducar();
            ProductosCaducados();
        }
        private void FiltrarProductos()
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            string consulta = @"
            SELECT
            p.id_Producto,
            p.nombre_producto,
            c.categoria,
            p.stock_act,
            p.stock_min,
            p.fecha_com,
            p.fecha_cad,
            CASE
                WHEN p.stock_act <= p.stock_min THEN 'Stock bajo'
                WHEN p.fecha_cad < CURDATE() THEN 'Caducado'
                WHEN p.fecha_cad BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY) THEN 'Próximo a caducar'
                ELSE 'Disponible'
            END AS estado
            FROM productos p
            INNER JOIN categoria c
            ON p.id_categoria = c.id_categoria
            WHERE 1=1";
            if (txt_busqueda.Text.Trim() != "")
            {
                consulta += " AND p.nombre_producto LIKE @nombre";
            }
            if (cmb_categoria.Text != "Todas")
            {
                consulta += " AND c.categoria = @categoria";
            }
            switch (cmb_estado.Text)
            {
                case "Disponible":
                    consulta += " AND p.stock_act > p.stock_min AND p.fecha_cad >= CURDATE()";
                    break;

                case "Stock bajo":
                    consulta += " AND p.stock_act <= p.stock_min";
                    break;

                case "Próximo a caducar":
                    consulta += @" AND p.fecha_cad BETWEEN CURDATE()
                           AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)";
                    break;

                case "Caducado":
                    consulta += " AND p.fecha_cad < CURDATE()";
                    break;
            }
            MySqlCommand cmd = new MySqlCommand(consulta, con);

            if (txt_busqueda.Text.Trim() != "")
                cmd.Parameters.AddWithValue("@nombre", "%" + txt_busqueda.Text + "%");

            if (cmb_categoria.Text != "Todas")
            
                cmd.Parameters.AddWithValue("@categoria", cmb_categoria.Text);
            

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_inventario.DataSource = dt;

            con.Close();
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            Navegador.Irmenu(this);
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            Navegador.Irventas(this);
        }

        private void btn_productos_Click(object sender, EventArgs e)
        {
            Navegador.Irproductos(this);
        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en este formulario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            Navegador.Irreportes(this);
        }

        private void btn_proovedores_Click(object sender, EventArgs e)
        {
            Navegador.Irproveedores(this);
        }

        private void lbl_productosRg_Click(object sender, EventArgs e)
        {

        }

        private void Form_Inventario_Load(object sender, EventArgs e)
        {
            cmb_categoria.SelectedIndex = 0; // Todas
            cmb_estado.SelectedIndex = 0;
            cargarDatos();
            FiltrarProductos();
            CargarIndicadores();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt_busqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmb_estado.SelectedItem = "Stock bajo";
        }

        private void btn_proximosC_Click(object sender, EventArgs e)
        {
            cmb_estado.SelectedItem = "Próximo a caducar";
        }

        private void btn_caducados_Click(object sender, EventArgs e)
        {
            cmb_estado.SelectedItem = "Caducado";
        }
    }
}
