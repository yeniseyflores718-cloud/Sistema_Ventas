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
    public partial class Proveedores : Form
    {
        private dataAcces conexion;
        public Proveedores()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgv_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_diaentrega_TextChanged(object sender, EventArgs e)
        {

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
            Navegador.Irreportes(this);
        }

        private void btn_proveedores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en este formulario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con != null)
            {
                string consulta = "SELECT * FROM proveedor";
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv_proveedores.DataSource = dt;
                dgv_proveedores.Columns["id_proveedor"].Visible = false;
                dgv_proveedores.Columns["apellido_p"].Visible = false;
                dgv_proveedores.Columns["apellido_m"].Visible = false;

            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txt_id.Text);
            string nombre = txt_nombre.Text;
            DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar el proveedor '{nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No)
            {
                return;
            }
            try
            {
                conexion=new dataAcces();
                MySqlConnection con = conexion.getConnection();
                string consulta = "DELETE FROM proveedor WHERE id_proveedor=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@id", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el proveedor.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }       
        }
        private void limpiarCampos()
        {
            txt_nombre.Text = "";
            txt_telefono.Text = "";
            txt_diaentrega.Text = "";
            txt_empresa.Text = "";
            txt_estado.Text = "";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_telefono.Text) || string.IsNullOrWhiteSpace(txt_diaentrega.Text) || string.IsNullOrWhiteSpace(txt_empresa.Text) || string.IsNullOrWhiteSpace(txt_estado.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar un proveedor.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataAcces conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con == null)
                return;
            try
            {
                string consulta= @"INSERT INTO proveedor(nombre, telefono, empresa, dia_entrega, estado) VALUES(@nombre, @telefono, @empresa, @dia_entrega, @estado)";
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                cmd.Parameters.AddWithValue("@telefono", txt_telefono.Text);
                cmd.Parameters.AddWithValue("@empresa", txt_empresa.Text);
                cmd.Parameters.AddWithValue("@dia_entrega", txt_diaentrega.Text);
                cmd.Parameters.AddWithValue("@estado", txt_estado.Text);

                int filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    limpiarCampos();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
            }
        
        }

        private void dgv_proveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_proveedores.Rows[e.RowIndex];
                txt_id.Text = row.Cells["id_proveedor"].Value.ToString();
                txt_nombre.Text = row.Cells["nombre"].Value.ToString();
                txt_telefono.Text = row.Cells["telefono"].Value.ToString();
                txt_empresa.Text = row.Cells["empresa"].Value.ToString();
                txt_diaentrega.Text = row.Cells["dia_entrega"].Value.ToString();
                txt_estado.Text = row.Cells["estado"].Value.ToString();
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Text;
            string telefono = txt_telefono.Text;
            string empresa = txt_empresa.Text;
            string diaEntrega = txt_diaentrega.Text;
            string estado = txt_estado.Text;
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();

            if (con == null)
                return;
            try
            {
                string consulta= @"UPDATE proveedor 
                                    SET nombre=@nombre, 
                                    telefono=@telefono, 
                                    empresa=@empresa, 
                                    dia_entrega=@dia_entrega, 
                                    estado=@estado 
                                    WHERE id_proveedor=@id";
                MySqlCommand cmd= new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@dia_entrega", diaEntrega);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                int filasAfectadas = cmd.ExecuteNonQuery();
                con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Proveedor editado correctamente.");
                    cargarDatos();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el proveedor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }       
        }

        private void txt_buscador_prov_TextChanged(object sender, EventArgs e)
        {
            conexion = new dataAcces();
            MySqlConnection con = conexion.getConnection();
            if (con != null)
            {
                TextBox txt = (TextBox)sender;
                string consulta = "SELECT * FROM proveedor WHERE nombre LIKE @busqueda";
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, con);
                adapter.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + txt.Text+ "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv_proveedores.DataSource = dt;
                dgv_proveedores.Columns["id_proveedor"].Visible = false;
                dgv_proveedores.Columns["apellido_p"].Visible = false;
                dgv_proveedores.Columns["apellido_m"].Visible = false;

            }
        }
    }
}
