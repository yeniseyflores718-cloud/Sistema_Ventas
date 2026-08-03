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
using System.Transactions;
using System.Windows.Forms;

namespace Sistema_Ventas
{
    public partial class VENTAS : Form
    {
        private dataAcces conexion;
        public VENTAS()
        {
            InitializeComponent();
        }
        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            Navegador.Irmenu(this);
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en este formulario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_provedores_Click(object sender, EventArgs e)
        {
            Navegador.Irproveedores(this);
        }

        private void btn_cancelarventa_Click(object sender, EventArgs e)
        {
            Devoluciones frm = new Devoluciones();
            frm.ShowDialog();
        }
      

        private void VENTAS_Load(object sender, EventArgs e)
        {
            // Limpiamos por si acaso
            dgv_ventas.Columns.Clear();

            // Agregamos las columnas: Add("NombreProgramatico", "TextoEncabezado")
            dgv_ventas.Columns.Add("col_id", "ID");
            dgv_ventas.Columns.Add("col_nombre", "Producto");
            dgv_ventas.Columns.Add("col_cantidad", "Cantidad");
            dgv_ventas.Columns.Add("col_precio", "Precio U.");
            dgv_ventas.Columns.Add("col_subtotal", "Subtotal");


            // Configurar el TextBox para que sugiera mientras escribes
            txt_buscarProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_buscarProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection listaProductos = new AutoCompleteStringCollection();

            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                string consulta = "SELECT nombre_Producto FROM productos";
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Agregamos cada nombre a la lista de sugerencias
                    listaProductos.Add(reader.GetString("nombre_Producto"));
                }
                con.Close();
            }

            // Le asignamos las sugerencias al buscador
            txt_buscarProducto.AutoCompleteCustomSource = listaProductos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_buscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Solo actuamos si el usuario presiona ENTER
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_buscarProducto.Text)) return;

                conexion = new dataAcces();
                MySqlConnection con = conexion.getConnection();

                if (con != null)
                {
                    try
                    {
                        // Buscamos el producto por su nombre o código
                        string consulta = "SELECT id_Producto, nombre_Producto, precio_v, stock_act FROM productos WHERE nombre_Producto = @busqueda OR id_Producto = @busqueda";
                        MySqlCommand comando = new MySqlCommand(consulta, con);
                        comando.Parameters.AddWithValue("@busqueda", txt_buscarProducto.Text.Trim());

                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.Read())
                        {
                            int idProd = reader.GetInt32("id_Producto");
                            string nombre = reader.GetString("nombre_Producto");
                            decimal precioVenta = reader.GetDecimal("precio_v");
                            int stockActual = reader.GetInt32("stock_act");

                            // VALIDACIÓN DE STOCK (Punto 3 de tu lista)
                            if (stockActual <= 0)
                            {
                                MessageBox.Show("El producto está AGOTADO en el inventario.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_buscarProducto.Clear();
                                return;
                            }

                            // Verificar si ya existe en el DataGridView
                            bool yaExiste = false;
                            foreach (DataGridViewRow fila in dgv_ventas.Rows)
                            {
                                if (fila.Cells["col_id"].Value != null && Convert.ToInt32(fila.Cells["col_id"].Value) == idProd)
                                {
                                    int cantActual = Convert.ToInt32(fila.Cells["col_cantidad"].Value);

                                    // Validar que no sobrepase el stock disponible
                                    if (cantActual + 1 > stockActual)
                                    {
                                        MessageBox.Show("No puedes agregar más unidades. Límite de stock alcanzado.");
                                        txt_buscarProducto.Clear();
                                        return;
                                    }

                                    // Aumentar cantidad y actualizar subtotal
                                    fila.Cells["col_cantidad"].Value = cantActual + 1;
                                    fila.Cells["col_subtotal"].Value = (cantActual + 1) * precioVenta;
                                    yaExiste = true;
                                    break;
                                }
                            }

                            // Si es la primera vez que se agrega en esta venta
                            if (!yaExiste)
                            {
                                // Agrega: [ID, Nombre, Cantidad, Precio, Subtotal]
                                dgv_ventas.Rows.Add(idProd, nombre, 1, precioVenta, precioVenta);
                            }

                            CalcularTotal();
                            txt_buscarProducto.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al buscar el producto: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            int totalProductosDiferentes = 0; // Para contar cuántos renglones/productos hay
            int totalPiezas = 0;              // Para sumar la cantidad total de artículos

            foreach (DataGridViewRow fila in dgv_ventas.Rows)
            {
                // Evitamos la fila vacía de hasta abajo si está activa
                if (fila.Cells["col_subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(fila.Cells["col_subtotal"].Value);
                    totalPiezas += Convert.ToInt32(fila.Cells["col_cantidad"].Value);
                    totalProductosDiferentes++;
                }
            }

            // 1. Mostrar el TOTAL a pagar
            txt_total.Text = total.ToString("C2"); // o txt_total.Text según el nombre de tu control

            // 2. Mostrar la cantidad de productos diferentes (Ej. 1 producto)
            txt_productos.Text = totalProductosDiferentes.ToString();

            // 3. Mostrar la suma total de piezas (Ej. 2 piezas en total)
            txt_cantidad.Text = totalPiezas.ToString();
        }

        private void txt_recibido_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_recibido.Text, out decimal recibido))
            {
                // Limpiamos el signo de moneda para obtener solo el valor numérico
                string textoTotal = txt_total.Text.Replace("$", "").Trim();

                if (decimal.TryParse(textoTotal, out decimal total))
                {
                    if (recibido >= total && total > 0)
                    {
                        decimal cambio = recibido - total;
                        txt_cambio.Text = cambio.ToString("C2");
                    }
                    else
                    {
                        txt_cambio.Text = "$0.00";
                    }
                }
            }
            else
            {
                txt_cambio.Text = "$0.00";
            }
        }

        private void btn_cobrar_Click(object sender, EventArgs e)
        {
            // 1. Validación de tabla vacía
            if (dgv_ventas.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos cargados en la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validación de pago recibido suficiente
            string textoTotal = txt_total.Text.Replace("$", "").Trim();
            if (!decimal.TryParse(txt_recibido.Text, out decimal recibido) ||
                !decimal.TryParse(textoTotal, out decimal total) ||
                recibido < total || total <= 0)
            {
                MessageBox.Show("Ingrese un monto recibido válido y suficiente para cubrir el total.", "Monto insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                // Guardamos el cambio en una variable antes de limpiar la pantalla
                string cambioTexto = txt_cambio.Text;
                long idVentaGenerado = 0;

                try
                {
                    // A) INSERTAR LA VENTA GENERAL Y OBTENER SU ID
                    string consultaVenta = "INSERT INTO venta (Fecha_venta, total) VALUES (NOW(), @total);";
                    MySqlCommand cmdVenta = new MySqlCommand(consultaVenta, con);
                    cmdVenta.Parameters.AddWithValue("@total", total);
                    cmdVenta.ExecuteNonQuery();

                    // Capturamos el ID generado automáticamente por MySQL
                    idVentaGenerado = cmdVenta.LastInsertedId;

                    // B) RECORRER PRODUCTOS: GUARDAR DETALLE Y DESCONTAR STOCK
                    foreach (DataGridViewRow fila in dgv_ventas.Rows)
                    {

                        if (fila.Cells["col_id"].Value != null)
                        {
                            int idProd = Convert.ToInt32(fila.Cells["col_id"].Value);
                            int cantidadVendida = Convert.ToInt32(fila.Cells["col_cantidad"].Value);
                            decimal precioU = Convert.ToDecimal(fila.Cells["col_precio"].Value);
                            decimal subtotal = Convert.ToDecimal(fila.Cells["col_subtotal"].Value);

                            // 1. Guardar en detalle_ventas (Ajusta los nombres de columnas según tu BD)
                            string consultaDetalle = "INSERT INTO detalle_venta (id_venta, id_Producto, Cantidad, precioU, Subtotal) VALUES (@idVenta, @idProd, @cant, @precio, @subtotal)";
                            MySqlCommand cmdDetalle = new MySqlCommand(consultaDetalle, con);
                            cmdDetalle.Parameters.AddWithValue("@idVenta", idVentaGenerado);
                            cmdDetalle.Parameters.AddWithValue("@idProd", idProd);
                            cmdDetalle.Parameters.AddWithValue("@cant", cantidadVendida);
                            cmdDetalle.Parameters.AddWithValue("@precio", precioU);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                            cmdDetalle.ExecuteNonQuery();

                            // 2. Restar stock del producto
                            string consultaUpdate = "UPDATE productos SET stock_act = stock_act - @cant WHERE id_Producto = @id";
                            MySqlCommand cmdUpdate = new MySqlCommand(consultaUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@cant", cantidadVendida);
                            cmdUpdate.Parameters.AddWithValue("@id", idProd);
                            cmdUpdate.ExecuteNonQuery();                           
                        }


                    }

                    // C) MOSTRAR MENSAJE DE ÉXITO CON EL ID REAL
                    MessageBox.Show($"¡Venta procesada con éxito!\n\nID de venta: {idVentaGenerado}\nCambio: {cambioTexto}",
                                    "Venta Completada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // D) LIMPIAR PANTALLA PARA LA SIGUIENTE VENTA
                    dgv_ventas.Rows.Clear();
                    txt_buscarProducto.Clear();
                    txt_recibido.Clear();
                    txt_total.Text = "$0.00";
                    txt_cambio.Text = "$0.00";
                    txt_productos.Clear();
                    txt_cantidad.Clear();
                    txt_buscarProducto.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
                  


        private void dgv_ventas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no sea el encabezado (índice >= 0) y que tengamos filas
            if (e.RowIndex >= 0 && dgv_ventas.Columns[e.ColumnIndex].Name == "col_cantidad")
            {
                DataGridViewRow fila = dgv_ventas.Rows[e.RowIndex];

                // Validamos que la cantidad ingresada sea un número válido
                if (int.TryParse(Convert.ToString(fila.Cells["col_cantidad"].Value), out int cantidad) &&
                    decimal.TryParse(Convert.ToString(fila.Cells["col_precio"].Value), out decimal precio))
                {
                    if (cantidad < 1)
                    {
                        // Si pone 0 o un número negativo, lo regresamos a 1 mínimo
                        cantidad = 1;
                        fila.Cells["col_cantidad"].Value = 1;
                    }

                    // Recalculamos el Subtotal de esta fila
                    decimal subtotal = cantidad * precio;
                    fila.Cells["col_subtotal"].Value = subtotal;

                    // Recalculamos el Total General de la venta
                    CalcularTotal();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //nada
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            dgv_ventas.Rows.Clear();
            txt_buscarProducto.Clear();
            txt_recibido.Clear();
            txt_total.Text = "$0.00";
            txt_cambio.Text = "$0.00";
            txt_productos.Clear();
            txt_cantidad.Clear();
            txt_buscarProducto.Focus();
        }
    }
}
