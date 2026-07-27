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
    public partial class Devoluciones : Form
    {
        dataAcces conexion;
        public Devoluciones()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cancelar la devolución?","Cancelar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

       

        private void Devoluciones_Load(object sender, EventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {

            // 1. VALIDACIONES
            if (string.IsNullOrWhiteSpace(txt_idVenta.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID de venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lst_productos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidadDevolver = (int)num_cantidad.Value;
            if (cantidadDevolver <= 0)
            {
                MessageBox.Show("La cantidad a devolver debe ser mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rb_activo.Checked && !rb_inactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado (Activo / Inactivo).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. OBTENER DATOS
            int idProducto = Convert.ToInt32(lst_productos.SelectedValue);
            int idVenta = Convert.ToInt32(txt_idVenta.Text);
            string motivo = txt_motivo.Text.Trim();
            bool regresaAInventario = rb_activo.Checked;

            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                try
                {
                    // A) SI ES ACTIVO, SUMAMOS AL INVENTARIO DE LA TABLA PRODUCTOS
                    if (regresaAInventario)
                    {
                        string queryStock = "UPDATE productos SET stock_act = stock_act + @cant WHERE id_Producto = @idProd";
                        MySqlCommand cmdStock = new MySqlCommand(queryStock, con);
                        cmdStock.Parameters.AddWithValue("@cant", cantidadDevolver);
                        cmdStock.Parameters.AddWithValue("@idProd", idProducto);
                        cmdStock.ExecuteNonQuery();
                    }

                    // B) REGISTRAR EN LA TABLA DEVOLUCIONES (Usando Motivo, FechaDev, Tipo, id_venta)
                    string tipoDevolucion = regresaAInventario ? "Activo" : "Inactivo";

                    string queryDev = @"INSERT INTO devoluciones (Motivo, FechaDev, Tipo, id_venta) 
                               VALUES (@motivo, CURDATE(), @tipo, @idVenta)";

                    MySqlCommand cmdDev = new MySqlCommand(queryDev, con);
                    cmdDev.Parameters.AddWithValue("@motivo", motivo);
                    cmdDev.Parameters.AddWithValue("@tipo", tipoDevolucion);
                    cmdDev.Parameters.AddWithValue("@idVenta", idVenta);
                    cmdDev.ExecuteNonQuery();

                    string mensaje = regresaAInventario
                        ? "Devolución registrada. El producto volvió a sumar al inventario."
                        : "Devolución registrada como Inactivo. NO sumó al inventario.";

                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar campos
                    txt_idVenta.Clear();
                    lst_productos.DataSource = null;
                    num_cantidad.Value = 0;
                    txt_motivo.Clear();
                    rb_activo.Checked = false;
                    rb_inactivo.Checked = false;
                    txt_idVenta.Focus();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        

        private void LimpiarDevoluciones()
        {
            txt_idVenta.Clear();
            lst_productos.DataSource = null;
            num_cantidad.Value = 0;
            txt_motivo.Clear();
            rb_activo.Checked = false;
            rb_inactivo.Checked = false;
            txt_idVenta.Focus();
        }

        private void txt_idVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_idVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_idVenta.Text))
                {
                    MessageBox.Show("Ingrese un ID de venta válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CargarProductos(txt_idVenta.Text.Trim());
            }
        }

        private void CargarProductos(string idVenta)
        {
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con != null)
            {
                try
                {
                    // Usamos d.id_Producto (P mayúscula)
                    string query = @"SELECT d.id_Producto, p.nombre_Producto 
                             FROM detalle_venta d 
                             INNER JOIN productos p ON d.id_Producto = p.id_Producto 
                             WHERE d.id_venta = @idVenta";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idVenta", Convert.ToInt32(idVenta));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        lst_productos.DataSource = dt;
                        lst_productos.DisplayMember = "nombre_Producto";
                        lst_productos.ValueMember = "id_Producto";
                    }
                    else
                    {
                        lst_productos.DataSource = null;
                        MessageBox.Show("No se encontraron productos para esta venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        
        }
    }
    
}
