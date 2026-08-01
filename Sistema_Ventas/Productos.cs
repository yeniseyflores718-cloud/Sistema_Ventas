using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Sistema_Ventas.DataAcces;

namespace Sistema_Ventas
{
    public partial class Productos : Form
    {
        private dataAcces conexion;
        public Productos()
        {
            InitializeComponent();
        }

        private void cargarDatos(int categoria = 0)
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            string consulta = @"
            SELECT
            p.id_Producto,
            p.nombre_producto,
            p.precio_c,
            p.precio_v,
            p.stock_act,
            p.stock_min,
            p.fecha_com,
            p.fecha_cad,
            c.categoria
            FROM productos p
            INNER JOIN categoria c
            ON p.id_categoria = c.id_categoria";

            if (categoria != 0)
            {
                consulta += " WHERE p.id_categoria=@categoria";
            }

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);

            if (categoria != 0)
            {
                da.SelectCommand.Parameters.AddWithValue("@categoria", categoria);
            }

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_productos.DataSource = dt;

        }
        private void cargarCategorias()
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            string consulta = "SELECT id_categoria, categoria FROM categoria";

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // ===== Combo para AGREGAR/EDITAR =====
            cmb_categoriaProducto.DataSource = dt.Copy();
            cmb_categoriaProducto.DisplayMember = "categoria";
            cmb_categoriaProducto.ValueMember = "id_categoria";

            // ===== Combo para FILTRAR =====
            DataTable dtFiltro = dt.Copy();

            DataRow fila = dtFiltro.NewRow();
            fila["id_categoria"] = 0;
            fila["categoria"] = "Todas";
            dtFiltro.Rows.InsertAt(fila, 0);

            cmb_categoria.DataSource = dtFiltro;
            cmb_categoria.DisplayMember = "categoria";
            cmb_categoria.ValueMember = "id_categoria";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            cargarDatos();
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            string nombre = txt_nombre.Text;
            DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar el producto '{nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No)
            {
                return;
            }
            try
            {
                conexion = new dataAcces();
                MySqlConnection con = conexion.getConnection();
                string consulta = "DELETE FROM productos WHERE id_Producto=@id";
                MySqlCommand comando = new MySqlCommand(consulta, con);
                comando.Parameters.AddWithValue("@id", id);

                int filasAfectadas = comando.ExecuteNonQuery();
                con.Close();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dgv_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_precio_compra.Text) || string.IsNullOrEmpty(txt_stock_actual.Text) || string.IsNullOrEmpty(txt_precio_venta.Text) || string.IsNullOrEmpty(txt_stock_minimo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txt_precio_compra.Text, out decimal precioCompra))
            {
                MessageBox.Show("Ingrese un precio de compra válido.");
                return;
            }

            if (!decimal.TryParse(txt_precio_venta.Text, out decimal precioVenta))
            {
                MessageBox.Show("Ingrese un precio de venta válido.");
                return;
            }

            if (!int.TryParse(txt_stock_actual.Text, out int stockActual))
            {
                MessageBox.Show("Ingrese un stock actual válido.");
                return;
            }

            if (!int.TryParse(txt_stock_minimo.Text, out int stockMinimo))
            {
                MessageBox.Show("Ingrese un stock mínimo válido.");
                return;
            }
            if (precioCompra <= 0)
            {
                MessageBox.Show("El precio de compra debe ser mayor a 0.");
                return;
            }

            if (precioVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser mayor a 0.");
                return;
            }
            if (stockActual < 0)
            {
                MessageBox.Show("El stock actual no puede ser negativo.");
                return;
            }

            if (stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo no puede ser negativo.");
                return;
            }
            if (stockMinimo > stockActual)
            {
                MessageBox.Show("El stock mínimo no puede ser mayor que el stock actual.");
                return;
            }
            if (dtp_fechaCad.Value < dtp_fechaCom.Value)
            {
                MessageBox.Show("La fecha de caducidad no puede ser menor que la fecha de compra.");
                return;
            }
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con == null)
                return;
            try
            {
                int idCategoria = Convert.ToInt32(cmb_categoriaProducto.SelectedValue);
                string consulta = @"INSERT INTO productos
                (nombre_producto, precio_c, stock_act, precio_v, stock_min, fecha_com, fecha_cad, id_categoria)
                VALUES
                (@nombre_producto, @precio_c, @stock_act, @precio_v, @stock_min, @fecha_com, @fecha_cad, @id_categoria)";
                MySqlCommand comando = new MySqlCommand(consulta, con);
                comando.Parameters.AddWithValue("@nombre_producto", txt_nombre.Text);
                comando.Parameters.AddWithValue("@precio_c", precioCompra);
                comando.Parameters.AddWithValue("@stock_act", stockActual);
                comando.Parameters.AddWithValue("@precio_v", precioVenta);
                comando.Parameters.AddWithValue("@stock_min", stockMinimo);
                comando.Parameters.AddWithValue("@fecha_com", dtp_fechaCom.Value.Date);
                comando.Parameters.AddWithValue("fecha_cad", dtp_fechaCad.Value.Date);
                comando.Parameters.AddWithValue("@id_categoria", idCategoria);

                int filasAfectadas = comando.ExecuteNonQuery();
                con.Close();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    limpiarCampos();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
            }
        }
        private void limpiarCampos()
        {
            txt_nombre.Text = "";
            txt_precio_compra.Text = "";
            txt_stock_actual.Text = "";
            txt_precio_venta.Text = "";
            txt_stock_minimo.Text = "";
            cmb_categoriaProducto.SelectedIndex = 0;
        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_productos.Rows[e.RowIndex];
                txt_id.Text = fila.Cells["id_Producto"].Value.ToString();

                txt_nombre.Text = fila.Cells["nombre_Producto"].Value.ToString();
                txt_precio_compra.Text = fila.Cells["precio_c"].Value.ToString();
                txt_stock_actual.Text = fila.Cells["stock_act"].Value.ToString();
                txt_precio_venta.Text = fila.Cells["precio_v"].Value.ToString();
                txt_stock_minimo.Text = fila.Cells["stock_min"].Value.ToString();
                cmb_categoriaProducto.Text = fila.Cells["categoria"].Value.ToString();
                dtp_fechaCom.Value = Convert.ToDateTime(fila.Cells["fecha_com"].Value);
                dtp_fechaCad.Value = Convert.ToDateTime(fila.Cells["fecha_cad"].Value);
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            // Rescatamos los datos del formulario
            string nombre = txt_nombre.Text;

            if (!decimal.TryParse(txt_precio_compra.Text, out decimal precioCompra))
            {
                MessageBox.Show("Ingrese un precio de compra válido.");
                return;
            }

            if (!decimal.TryParse(txt_precio_venta.Text, out decimal precioVenta))
            {
                MessageBox.Show("Ingrese un precio de venta válido.");
                return;
            }

            if (!int.TryParse(txt_stock_actual.Text, out int stockActual))
            {
                MessageBox.Show("Ingrese un stock actual válido.");
                return;
            }

            if (!int.TryParse(txt_stock_minimo.Text, out int stockMinimo))
            {
                MessageBox.Show("Ingrese un stock mínimo válido.");
                return;
            }
            if (precioCompra <= 0)
            {
                MessageBox.Show("El precio de compra debe ser mayor a 0.");
                return;
            }

            if (precioVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser mayor a 0.");
                return;
            }
            if (stockActual < 0)
            {
                MessageBox.Show("El stock actual no puede ser negativo.");
                return;
            }

            if (stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo no puede ser negativo.");
                return;
            }
            if (stockMinimo > stockActual)
            {
                MessageBox.Show("El stock mínimo no puede ser mayor que el stock actual.");
                return;
            }
            if (dtp_fechaCad.Value < dtp_fechaCom.Value)
            {
                MessageBox.Show("La fecha de caducidad no puede ser menor que la fecha de compra.");
                return;
            }

            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con == null)
                return;

            try
            {
                string consulta = @"UPDATE productos
                            SET nombre_producto = @nombre,
                                precio_c = @precioCompra,
                                precio_v = @precioVenta,
                                stock_act = @stockActual,
                                stock_min = @stockMinimo,
                                fecha_com = @fechaCompra,
                                fecha_cad = @fechaCaducidad
                            WHERE id_Producto = @id";

                MySqlCommand comando = new MySqlCommand(consulta, con);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@precioCompra", precioCompra);
                comando.Parameters.AddWithValue("@precioVenta", precioVenta);
                comando.Parameters.AddWithValue("@stockActual", stockActual);
                comando.Parameters.AddWithValue("@stockMinimo", stockMinimo);
                comando.Parameters.AddWithValue("@fechaCompra", dtp_fechaCom.Value.Date);
                comando.Parameters.AddWithValue("@fechaCaducidad", dtp_fechaCad.Value.Date);
                comando.Parameters.AddWithValue("@idCategoria",
                cmb_categoriaProducto.SelectedValue);
                comando.Parameters.AddWithValue("@id", txt_id.Text);

                int filasAfectadas = comando.ExecuteNonQuery();
                con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto editado correctamente.");
                    cargarDatos();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txt_buscador_prod_TextChanged(object sender, EventArgs e)
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con != null)
            {
                TextBox txt = (TextBox)sender;
                string consulta = @"
                SELECT
                p.id_Producto,
                p.nombre_producto,
                p.precio_c,
                p.precio_v,
                p.stock_act,
                p.stock_min,
                p.fecha_com,
                p.fecha_cad,
                c.categoria
                FROM productos p
                INNER JOIN categoria c
                ON p.id_categoria = c.id_categoria
                WHERE p.nombre_producto LIKE @busqueda";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, con);
                adaptador.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + txt.Text + "%");
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgv_productos.DataSource = dt;
                dgv_productos.Columns["id_Producto"].Visible = false;               
            }
        }


        private void btn_inicio_Click(object sender, EventArgs e)
        {
            Navegador.Irmenu(this);
        }
        
        private void btn_venta_Click(object sender, EventArgs e)
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
            Navegador.Irreportes(this);
        }

        private void btn_proveedores_Click(object sender, EventArgs e)
        {
            Navegador.Irproveedores(this);
        }

        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_categoria.SelectedValue != null &&
        int.TryParse(cmb_categoria.SelectedValue.ToString(), out int categoria))
            {
                cargarDatos(categoria);
            }
        }

        private void txt_categoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Agregar_categoria categoria = new Agregar_categoria();

            if (categoria.ShowDialog() == DialogResult.OK)
            {
                cargarCategorias(); // vuelve a cargar el ComboBox
            }
        }
    }
    
}

