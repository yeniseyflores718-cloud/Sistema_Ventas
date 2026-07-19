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
        private void cargarDatos()
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con != null)
            {
                string consulta = "SELECT * FROM productos";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, con);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgv_productos.DataSource = dt;
                dgv_productos.Columns["id_Producto"].Visible = false;
                dgv_productos.Columns["descripcion"].Visible = false;
                dgv_productos.Columns["fecha_com"].Visible = false;
                dgv_productos.Columns["fecha_cad"].Visible = false;
                dgv_productos.Columns["id_categoria"].Visible = false;
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_precio_compra.Text) || string.IsNullOrEmpty(txt_stock_actual.Text) || string.IsNullOrEmpty(txt_precio_venta.Text) || string.IsNullOrEmpty(txt_stock_minimo.Text) || string.IsNullOrEmpty(txt_categoria.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con == null)
                return;
            try
            {
                string consulta = @"INSERT INTO productos (nombre_Producto, precio_c, stock_act, precio_v, stock_min) VALUES (@nombre_Producto, @precio_c, @stock_act, @precio_v, @stock_min)";
                MySqlCommand comando = new MySqlCommand(consulta, con);
                comando.Parameters.AddWithValue("@nombre_Producto", txt_nombre.Text);
                comando.Parameters.AddWithValue("@precio_c", txt_precio_compra.Text);
                comando.Parameters.AddWithValue("@stock_act", txt_stock_actual.Text);
                comando.Parameters.AddWithValue("@precio_v", txt_precio_venta.Text);
                comando.Parameters.AddWithValue("@stock_min", txt_stock_minimo.Text);
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
            txt_categoria.Text = "";
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
                                stock_min = @stockMinimo
                            WHERE id_Producto = @id";

                MySqlCommand comando = new MySqlCommand(consulta, con);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@precioCompra", precioCompra);
                comando.Parameters.AddWithValue("@precioVenta", precioVenta);
                comando.Parameters.AddWithValue("@stockActual", stockActual);
                comando.Parameters.AddWithValue("@stockMinimo", stockMinimo);
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
                string consulta = "SELECT * FROM productos WHERE nombre_Producto LIKE @busqueda";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, con);
                adaptador.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + txt.Text + "%");
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgv_productos.DataSource = dt;
                dgv_productos.Columns["id_Producto"].Visible = false;
                dgv_productos.Columns["descripcion"].Visible = false;
                dgv_productos.Columns["fecha_com"].Visible = false;
                dgv_productos.Columns["fecha_cad"].Visible = false;
                dgv_productos.Columns["id_categoria"].Visible = false;
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
            MessageBox.Show("Ya estás en este formulario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
    
}

