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
    public partial class FormReportes : Form
    {
        dataAcces conexion = new dataAcces();

        public FormReportes()
        {
            InitializeComponent();
        }

        private void CargarReportes()
        {
            try
            {
                using (MySqlConnection con = conexion.getConnection())
                {

                    // Mostrar productos vendidos
                    string consulta = @"SELECT
                                p.nombre_producto AS Producto,
                                dv.Cantidad,
                                dv.PrecioU,
                                dv.Subtotal
                                FROM venta v
                                INNER JOIN detalle_venta dv
                                    ON v.id_venta = dv.id_venta
                                INNER JOIN productos p
                                    ON dv.id_Producto = p.id_Producto
                                WHERE v.Fecha_venta = @fecha";

                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);
                    da.SelectCommand.Parameters.AddWithValue("@fecha",
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    MessageBox.Show("Filas encontradas: " + dt.Rows.Count);
                    data_reportes.DataSource = dt;

                    // Total de ventas
                    MySqlCommand cmd1 = new MySqlCommand(
                        "SELECT IFNULL(SUM(Total),0) FROM venta WHERE Fecha_venta=@fecha", con);
                    cmd1.Parameters.AddWithValue("@fecha",
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    lbl_totalventas.Text = cmd1.ExecuteScalar().ToString();

                    // Número de ventas
                    MySqlCommand cmd2 = new MySqlCommand(
                        "SELECT COUNT(*) FROM venta WHERE Fecha_venta=@fecha", con);
                    cmd2.Parameters.AddWithValue("@fecha",
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    lbl_numeroventas.Text = cmd2.ExecuteScalar().ToString();

                    // Productos vendidos
                    MySqlCommand cmd3 = new MySqlCommand(
                        @"SELECT IFNULL(SUM(Cantidad),0)
                  FROM detalle_venta dv
                  INNER JOIN venta v ON dv.id_venta=v.id_venta
                  WHERE v.Fecha_venta=@fecha", con);
                    cmd3.Parameters.AddWithValue("@fecha",
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    lbl_productosvendidos.Text = cmd3.ExecuteScalar().ToString();

                    // Clientes atendidos
                    MySqlCommand cmd4 = new MySqlCommand(
                        "SELECT COUNT(DISTINCT id_cliente) FROM venta WHERE Fecha_venta=@fecha", con);
                    cmd4.Parameters.AddWithValue("@fecha",
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    lbl_clientesatendidos.Text = cmd4.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            Navegador.Irinventario(this);
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en este formulario.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btn_proovedores_Click(object sender, EventArgs e)
        {
            Navegador.Irproveedores(this);
        }

        private void data_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            CargarReportes();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarReportes();   
        }
    }
}
