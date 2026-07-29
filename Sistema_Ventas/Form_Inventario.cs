using MySql.Data.MySqlClient;
using Sistema_Ventas.DataAcces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas
{
    public partial class Form_Inventario : Form
    {
        private dataAcces conexion;
        private int filaActualImpresion = 0;
        private string tituloReporte = "";
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
            p.nombre_producto AS 'Producto',
            c.categoria AS 'Categoría',
            p.stock_act AS 'Stock Actual',
            p.stock_min AS 'Stock Mínimo',
            p.fecha_com AS 'Fecha de Compra',
            p.fecha_cad AS 'Fecha de Caducidad',
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
            dgv_inventario.Columns["id_Producto"].Visible = false;  

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
            p.nombre_producto AS 'Producto',
            c.categoria AS 'Categoría',
            p.stock_act AS 'Stock Actual',
            p.stock_min AS 'Stock Mínimo',
            p.fecha_com AS 'Fecha de Compra',
            p.fecha_cad AS 'Fecha de Caducidad',
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
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Times New Roman", 16, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fuenteEncabezado = new Font("Times New Roman", 10, FontStyle.Bold);
            Font fuenteTexto = new Font("Times New Roman", 10);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int altoFila = 30;

            int cantidadColumnas = dgv_inventario.Columns.Count;
            int anchoColumna = e.MarginBounds.Width / cantidadColumnas;

            // ENCABEZADO

            e.Graphics.DrawString("SISTEMA DE VENTAS",
                fuenteTitulo,
                Brushes.Black,
                x,
                y);

            y += 30;

            e.Graphics.DrawString(tituloReporte,
                fuenteSubtitulo,
                Brushes.Black,
                x,
                y);

            y += 25;

            e.Graphics.DrawString(
                "Fecha de impresión: " +
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                fuenteTexto,
                Brushes.Black,
                x,
                y);

            y += 20;

            // ENCABEZADOS

            for (int i = 0; i < dgv_inventario.Columns.Count; i++)
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
                    dgv_inventario.Columns[i].HeaderText,
                    fuenteEncabezado,
                    Brushes.Black,
                    rectangulo,
                    formato);
            }

            y += altoFila;

            // DATOS

            while (filaActualImpresion < dgv_inventario.Rows.Count)
            {
                DataGridViewRow fila = dgv_inventario.Rows[filaActualImpresion];

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

                for (int i = 0; i < dgv_inventario.Columns.Count; i++)
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
            tituloReporte = "PRODUCTOS CON STOCK BAJO";
            cmb_estado.SelectedItem = "Stock bajo";
        }

        private void btn_proximosC_Click(object sender, EventArgs e)
        {
            tituloReporte = "PRODUCTOS PRÓXIMOS A CADUCAR";
            cmb_estado.SelectedItem = "Próximo a caducar";
        }

        private void btn_caducados_Click(object sender, EventArgs e)
        {
            tituloReporte = "PRODUCTOS CADUCADOS";
            cmb_estado.SelectedItem = "Caducado";
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            {
                if (dgv_inventario.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para imprimir.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

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
}
