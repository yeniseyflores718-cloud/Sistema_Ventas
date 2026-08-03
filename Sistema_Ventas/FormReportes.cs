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
using System.Drawing.Printing;

namespace Sistema_Ventas
{
    public partial class FormReportes : Form
    {
        private int filaActualImpresion = 0;
        private string tituloReporte = "";
        public FormReportes()
        {
            InitializeComponent();
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

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                try
                {
                    string queryTabla = @"SELECT 
                         d.id_venta AS 'ID Venta',
                         v.Fecha_venta AS 'Fecha',
                         p.nombre_producto AS 'Producto',
                         d.Cantidad AS 'Cantidad',
                         d.PrecioU AS 'Precio Unitario ($)',
                         d.Subtotal AS 'Subtotal ($)',
                         IFNULL(e.nombre_usuario, 'Sin Vendedor') AS 'Vendedor'
                     FROM detalle_venta d
                     INNER JOIN venta v ON d.id_venta = v.id_venta
                     INNER JOIN productos p ON d.id_Producto = p.id_Producto
                     LEFT JOIN empleados e ON v.id_empleado = e.id_empleado
                     WHERE v.Fecha_venta BETWEEN @inicio AND @fin";

                    MySqlCommand cmd = new MySqlCommand(queryTabla, con);
                    cmd.Parameters.AddWithValue("@inicio", dtp_inicio.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtp_fin.Value.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_reporte.DataSource = dt;

                    string queryTotales = @"SELECT 
                                        IFNULL(SUM(Total), 0) AS TotalDinero,
                                        COUNT(id_venta) AS TotalVentas,
                                        COUNT(DISTINCT id_cliente) AS TotalClientes
                                     FROM venta 
                                     WHERE Fecha_venta BETWEEN @inicio AND @fin";

                    MySqlCommand cmdTotales = new MySqlCommand(queryTotales, con);
                    cmdTotales.Parameters.AddWithValue("@inicio", dtp_inicio.Value.ToString("yyyy-MM-dd"));
                    cmdTotales.Parameters.AddWithValue("@fin", dtp_fin.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader dr = cmdTotales.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lbl_totalVentas.Text = Convert.ToDouble(dr["TotalDinero"]).ToString("C");
                            lbl_numVentas.Text = dr["TotalVentas"].ToString();
                            lbl_clientesAtendidos.Text = dr["TotalClientes"].ToString();
                        }
                    }

                    // 3. Consulta para la cantidad total de artículos que se saieron o descontaron de la tienda
                    string queryProductos = @"SELECT IFNULL(SUM(d.Cantidad), 0) AS TotalProd
                                     FROM detalle_venta d
                                     INNER JOIN venta v ON d.id_venta = v.id_venta
                                     WHERE v.Fecha_venta BETWEEN @inicio AND @fin";

                    MySqlCommand cmdProd = new MySqlCommand(queryProductos, con);
                    cmdProd.Parameters.AddWithValue("@inicio", dtp_inicio.Value.ToString("yyyy-MM-dd"));
                    cmdProd.Parameters.AddWithValue("@fin", dtp_fin.Value.ToString("yyyy-MM-dd"));

                    lbl_productosVendidos.Text = cmdProd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_menosVendido_Click(object sender, EventArgs e)
        {
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                try
                {
                    string query = @"SELECT p.nombre_producto, SUM(d.Cantidad) AS Total
                             FROM detalle_venta d
                             INNER JOIN venta v ON d.id_venta = v.id_venta
                             INNER JOIN productos p ON d.id_Producto = p.id_Producto
                             WHERE v.Fecha_venta BETWEEN @inicio AND @fin
                             GROUP BY p.id_Producto, p.nombre_producto
                             ORDER BY Total ASC 
                             LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@inicio", dtp_inicio.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtp_fin.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string producto = dr["nombre_producto"].ToString();
                            string cantidad = dr["Total"].ToString();
                            MessageBox.Show($" El producto menos vendido en este rango es:\n\n {producto} ({cantidad} unidades)",
                                            "Bajo Rendimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No hay datos de ventas en este rango de fechas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_masVendido_Click(object sender, EventArgs e)
        {
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                try
                {
                    string query = @"SELECT p.nombre_producto, SUM(d.Cantidad) AS Total
                             FROM detalle_venta d
                             INNER JOIN venta v ON d.id_venta = v.id_venta
                             INNER JOIN productos p ON d.id_Producto = p.id_Producto
                             WHERE v.Fecha_venta BETWEEN @inicio AND @fin
                             GROUP BY p.id_Producto, p.nombre_producto
                             ORDER BY Total DESC 
                             LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@inicio", dtp_inicio.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtp_fin.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string producto = dr["nombre_producto"].ToString();
                            string cantidad = dr["Total"].ToString();
                            MessageBox.Show($" El producto más vendido en este rango es:\n\n {producto} ({cantidad} unidades)",
                                            "Producto Estrella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No hay datos de ventas en este rango de fechas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fuenteEncabezado = new Font("Times New Roman", 10, FontStyle.Bold);
            Font fuenteTexto = new Font("Times New Roman", 10);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int altoFila = 30;

            int cantidadColumnas = dgv_reporte.Columns.Count;
            int anchoColumna = e.MarginBounds.Width / cantidadColumnas;

            // Encabezado

            e.Graphics.DrawString(
                "SISTEMA DE VENTAS",
                fuenteTitulo,
                Brushes.Black,
                x,
                y);

            y += 30;

            e.Graphics.DrawString(
                tituloReporte,
                fuenteSubtitulo,
                Brushes.Black,
                x,
                y);

            y += 25;

            e.Graphics.DrawString(
                "Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                fuenteTexto,
                Brushes.Black,
                x,
                y);

            y += 20;

            // Encabezados

            for (int i = 0; i < dgv_reporte.Columns.Count; i++)
            {
                Rectangle rectangulo = new Rectangle(
                    x + (i * anchoColumna),
                    y,
                    anchoColumna,
                    altoFila);

                e.Graphics.FillRectangle(Brushes.LightGray, rectangulo);
                e.Graphics.DrawRectangle(Pens.Black, rectangulo);

                StringFormat formato = new StringFormat();
                formato.Alignment = StringAlignment.Center;
                formato.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(
                    dgv_reporte.Columns[i].HeaderText,
                    fuenteEncabezado,
                    Brushes.Black,
                    rectangulo,
                    formato);
            }

            y += altoFila;

            // Datos

            while (filaActualImpresion < dgv_reporte.Rows.Count)
            {
                DataGridViewRow fila = dgv_reporte.Rows[filaActualImpresion];

                if (fila.IsNewRow)
                {
                    filaActualImpresion++;
                    continue;
                }

                if (y + altoFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                for (int i = 0; i < dgv_reporte.Columns.Count; i++)
                {
                    Rectangle rectangulo = new Rectangle(
                        x + (i * anchoColumna),
                        y,
                        anchoColumna,
                        altoFila);

                    e.Graphics.DrawRectangle(Pens.Black, rectangulo);

                    string valor = fila.Cells[i].Value?.ToString() ?? "";

                    StringFormat formato = new StringFormat();
                    formato.Alignment = StringAlignment.Center;
                    formato.LineAlignment = StringAlignment.Center;

                    RectangleF texto = new RectangleF(
                        rectangulo.X + 2,
                        rectangulo.Y + 2,
                        rectangulo.Width - 4,
                        rectangulo.Height - 4);

                    e.Graphics.DrawString(
                        valor,
                        fuenteTexto,
                        Brushes.Black,
                        texto,
                        formato);
                }

                y += altoFila;
                filaActualImpresion++;
            }

            e.HasMorePages = false;
            filaActualImpresion = 0;

            fuenteTitulo.Dispose();
            fuenteSubtitulo.Dispose();
            fuenteEncabezado.Dispose();
            fuenteTexto.Dispose();
        }
        private void FormReportes_Load(object sender, EventArgs e)
        {

        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            if (dgv_reporte.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para imprimir.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            tituloReporte =
                "REPORTE DE VENTAS\n" +
                "DEL " + dtp_inicio.Value.ToString("dd/MM/yyyy") +
                " AL " + dtp_fin.Value.ToString("dd/MM/yyyy");

            filaActualImpresion = 0;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            pd.DefaultPageSettings.Landscape = true;

            PrintPreviewDialog ppd = new PrintPreviewDialog();

            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;

            ppd.ShowDialog();
        }
    
    }
    
}
