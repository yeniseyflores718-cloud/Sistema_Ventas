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
    public partial class VENTAS : Form
    {
        public VENTAS()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
