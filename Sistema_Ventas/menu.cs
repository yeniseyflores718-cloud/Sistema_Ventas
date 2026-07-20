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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void btn_formproductos_Click(object sender, EventArgs e)
        {
            Navegador.Irproductos(this);
        }

        private void btn_formventas_Click(object sender, EventArgs e)
        {
            Navegador.Irventas(this);
        }

        private void btn_forminventario_Click(object sender, EventArgs e)
        {
            Navegador.Irinventario(this);
        }

        private void btn_form_reportes_Click(object sender, EventArgs e)
        {
            Navegador.Irreportes(this);
        }

        private void btn_form_proovedores_Click(object sender, EventArgs e)
        {
            Navegador.Irproveedores(this);
        }

        private void btn_salirsistema_Click(object sender, EventArgs e)
        {
            Navegador.Salir();
        }

        private void btn_nuevousuario_Click(object sender, EventArgs e)
        {
            FormNuevoUsuario frm = new FormNuevoUsuario();
            frm.ShowDialog();
        }
    }
}
