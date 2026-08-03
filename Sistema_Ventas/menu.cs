using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Sistema_Ventas
{
    public partial class menu : Form
    {
        private SpeechSynthesizer lector = new SpeechSynthesizer();
        private bool lectorActivo = false;


        private bool esModoOscuro = false;
        private string rolUsuario;
        public menu()
        {
            InitializeComponent();
            rolUsuario = "";
        }
        public menu(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
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

        private void Tarjeta_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Productos. Administra el catálogo de tus productos.");
        }

        private void btn_modoOscuro_Click(object sender, EventArgs e)
        {
            esModoOscuro = !esModoOscuro;

            if (esModoOscuro)
            {
                // --- APLICAR MODO OSCURO ---
                btn_modoOscuro.Text = "☀️ Modo Claro";

                // 1. Color de fondo del Formulario
                this.BackColor = Color.FromArgb(30, 30, 30);

                tbl_superior.BackColor = Color.FromArgb(40, 43, 49);
                pnl_superior.BackColor = Color.FromArgb(38, 41, 46);

                // 2. Colores de texto (Labels)
                lbltitulo.ForeColor = Color.FromArgb(240, 240, 240);
                lblBienvenido.ForeColor = Color.FromArgb(240, 240, 240);
                lblSubtitulo.ForeColor = Color.FromArgb(180, 180, 180);

                // 3. Paneles/Tarjetas de los módulos
                pnl_productos.BackColor = Color.FromArgb(60, 64, 72);
                pnl_ventas.BackColor = Color.FromArgb(60, 64, 72);
                pnl_inventario.BackColor = Color.FromArgb(60, 64, 72);
                pnl_reportes.BackColor = Color.FromArgb(60, 64, 72);
                pnl_salir.BackColor = Color.FromArgb(60, 64, 72);
                pnl_proveedores.BackColor = Color.FromArgb(60, 64, 72);

                //// 4. Cambiar imágenes a versión clara
                picProductos.Image = Properties.Resources.productososcuro;
                picVentas.Image = Properties.Resources.ventasoscuro;
                picInventario.Image = Properties.Resources.inventariosucro;
                picReportes.Image = Properties.Resources.reporetsoscuro;
                picSalir.Image = Properties.Resources.salirosucro;
                picproveedores.Image = Properties.Resources.proveedoresoscuro;


            }
            else
            {
                btn_modoOscuro.Text = "🌙 Modo Oscuro";

                // 1. Color de fondo original
                this.BackColor = Color.FromArgb(215, 228, 242);


                pnl_superior.BackColor = Color.FromArgb(191, 211, 234);

                // 2. Colores de texto originales
                lbltitulo.ForeColor = Color.FromArgb(20, 35, 60);
                lblBienvenido.ForeColor = Color.FromArgb(20, 35, 60);
                lblSubtitulo.ForeColor = Color.FromArgb(20, 35, 60);

                // 3. Paneles/Tarjetas originales
                pnl_productos.BackColor = Color.FromArgb(200, 215, 230);
                pnl_ventas.BackColor = Color.FromArgb(200, 215, 230);
                pnl_inventario.BackColor = Color.FromArgb(200, 215, 230);
                pnl_reportes.BackColor = Color.FromArgb(200, 215, 230);
                pnl_salir.BackColor = Color.FromArgb(200, 215, 230);
                pnl_proveedores.BackColor = Color.FromArgb(200, 215, 230);
                btn_modoOscuro.BackColor = Color.White;

                picProductos.Image = Properties.Resources.producto2;
                picVentas.Image = Properties.Resources.venta2;
                picInventario.Image = Properties.Resources.inventario2;
                picReportes.Image = Properties.Resources.reportes2;
                picSalir.Image = Properties.Resources.salir2;
                picproveedores.Image = Properties.Resources.proveedor2;
            }
        }

        private void menu_Load_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Rol recibido: " + rolUsuario);
            if (rolUsuario.ToLower() == "empleado")
            {
                btn_nuevousuario.Visible = false;
            }
        }

        private void LeerTexto(string texto)
        {
            if (!lectorActivo) return;

            try
            {
                lector.SpeakAsyncCancelAll();
                lector.SpeakAsync(texto);     
            }
            catch
            { 
            
            }
        }

        private void btnActivarLector_Click(object sender, EventArgs e)
        {
            lectorActivo = !lectorActivo;

            if (lectorActivo)
            {
                btnActivarLector.Text = "Desactivar Lector";

                // Saludo de bienvenida completo ignorando el candado inicial
                try
                {
                    lector.SpeakAsyncCancelAll();
                    lector.SpeakAsync("Bienvenido al menú principal. Elige una opción para comenzar pasando el cursor sobre los módulos.");
                }
                catch { }
            }
            else
            {
                btnActivarLector.Text = "Activar Lector";
                lector.SpeakAsyncCancelAll(); // Se calla inmediatamente al apagarlo
            }
        }

        private void picProductos_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Productos. Administra el catálogo de tus productos.");
        }

        private void pnl_ventas_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Ventas. Registra ventas.");
        }

        private void picVentas_Click(object sender, EventArgs e)
        {

        }

        private void picVentas_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Ventas. Registra ventas.");
        }

        private void pnl_inventario_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Inventario. Controla el stock, entrada y salidas de tus productos.");
        }

        private void picInventario_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Inventario. Controla el stock, entrada y salidas de tus productos.");
        }

        private void pnl_reportes_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Reportes. Visualiza reportes.");
        }

        private void picReportes_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Reportes. Visualiza reportes.");
        }

        private void pnl_proveedores_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Proveedores. Administra la información de tus proveedores.");
        }

        private void picproveedores_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Módulo Proveedores. Administra la información de tus proveedores.");
        }

        private void pnl_salir_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Cerrar Sesión. Salir del sistema.");
        }

        private void picSalir_MouseEnter(object sender, EventArgs e)
        {
            LeerTexto("Cerrar Sesión. Salir del sistema.");
        }

        private void btn_modoOscuro_MouseEnter(object sender, EventArgs e)
        {
            // Cambiamos el texto dinámicamente según lo que vaya a hacer el botón
            if (this.BackColor == SystemColors.Control)
            {
                LeerTexto("Botón Modo Oscuro. Presiona para cambiar a tema oscuro.");
            }
            else
            {

                LeerTexto("Botón Modo Claro. Presiona para cambiar a tema claro.");
            }
        }
    }
}

