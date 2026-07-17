using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas
{
    internal class Navegador
    {        
        public static void Abrir(Form actual, Form nuevo)
        {
            nuevo.Show();
            actual.Hide();
        }

        // Menú principal
        public static void Irmenu(Form actual)
        {
            Abrir(actual, new menu());
        }

        // Productos
        public static void Irproductos(Form actual)
        {
            Abrir(actual, new Productos());
        }

        // Ventas
        public static void Irventas(Form actual)
        {
            Abrir(actual, new VENTAS());
        }

        // Inventario
        public static void Irinventario(Form actual)
        {
            Abrir(actual, new Form_Inventario());
        }

        // Proveedores
        public static void Irproveedores(Form actual)
        {
            Abrir(actual, new Proveedores());
        }

        // Reportes
        public static void Irreportes(Form actual)
        {
            Abrir(actual, new FormReportes());
        }

        // Login
        public static void Cerrarsesion(Form actual)
        {
            Abrir(actual, new Formlogin2());
        }

        // Salir del sistema
        public static void Salir()
        {
            Application.Exit();
        }
    }
}
       
