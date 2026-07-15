namespace Sistema_Ventas
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.btn_venta = new System.Windows.Forms.Button();
            this.btn_productos = new System.Windows.Forms.Button();
            this.btn_inventario = new System.Windows.Forms.Button();
            this.btn_reportes = new System.Windows.Forms.Button();
            this.btn_proveedores = new System.Windows.Forms.Button();
            this.lbl_buscar = new System.Windows.Forms.Label();
            this.txt_buscador_prod = new System.Windows.Forms.TextBox();
            this.dgv_productos = new System.Windows.Forms.DataGridView();
            this.cmb_categoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_precio_venta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_precio_compra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_categoria = new System.Windows.Forms.TextBox();
            this.txt_stock_minimo = new System.Windows.Forms.TextBox();
            this.txt_stock_inicial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_impuesto = new System.Windows.Forms.TextBox();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.btn_proveedores);
            this.panel1.Controls.Add(this.btn_reportes);
            this.panel1.Controls.Add(this.btn_inventario);
            this.panel1.Controls.Add(this.btn_productos);
            this.panel1.Controls.Add(this.btn_venta);
            this.panel1.Controls.Add(this.btn_inicio);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 561);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(211)))), ((int)(((byte)(234)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.btn_actualizar);
            this.panel2.Controls.Add(this.btn_eliminar);
            this.panel2.Controls.Add(this.btn_agregar);
            this.panel2.Controls.Add(this.txt_impuesto);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txt_stock_inicial);
            this.panel2.Controls.Add(this.txt_stock_minimo);
            this.panel2.Controls.Add(this.txt_categoria);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_precio_compra);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_precio_venta);
            this.panel2.Controls.Add(this.txt_nombre);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmb_categoria);
            this.panel2.Controls.Add(this.dgv_productos);
            this.panel2.Controls.Add(this.txt_buscador_prod);
            this.panel2.Controls.Add(this.lbl_buscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 461);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(778, 100);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistema_Ventas.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_inicio
            // 
            this.btn_inicio.FlatAppearance.BorderSize = 0;
            this.btn_inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inicio.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inicio.ForeColor = System.Drawing.Color.White;
            this.btn_inicio.Image = global::Sistema_Ventas.Properties.Resources.inicio;
            this.btn_inicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_inicio.Location = new System.Drawing.Point(3, 136);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(194, 41);
            this.btn_inicio.TabIndex = 39;
            this.btn_inicio.Text = "Inicio";
            this.btn_inicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_inicio.UseVisualStyleBackColor = true;
            // 
            // btn_venta
            // 
            this.btn_venta.FlatAppearance.BorderSize = 0;
            this.btn_venta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_venta.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_venta.ForeColor = System.Drawing.Color.White;
            this.btn_venta.Image = global::Sistema_Ventas.Properties.Resources.ventas;
            this.btn_venta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_venta.Location = new System.Drawing.Point(3, 186);
            this.btn_venta.Name = "btn_venta";
            this.btn_venta.Size = new System.Drawing.Size(194, 41);
            this.btn_venta.TabIndex = 40;
            this.btn_venta.Text = "Ventas";
            this.btn_venta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_venta.UseVisualStyleBackColor = true;
            // 
            // btn_productos
            // 
            this.btn_productos.FlatAppearance.BorderSize = 0;
            this.btn_productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_productos.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_productos.ForeColor = System.Drawing.Color.White;
            this.btn_productos.Image = global::Sistema_Ventas.Properties.Resources.producto;
            this.btn_productos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_productos.Location = new System.Drawing.Point(3, 237);
            this.btn_productos.Name = "btn_productos";
            this.btn_productos.Size = new System.Drawing.Size(194, 41);
            this.btn_productos.TabIndex = 41;
            this.btn_productos.Text = "Productos";
            this.btn_productos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_productos.UseVisualStyleBackColor = true;
            // 
            // btn_inventario
            // 
            this.btn_inventario.FlatAppearance.BorderSize = 0;
            this.btn_inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inventario.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inventario.ForeColor = System.Drawing.Color.White;
            this.btn_inventario.Image = global::Sistema_Ventas.Properties.Resources.inventario;
            this.btn_inventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_inventario.Location = new System.Drawing.Point(3, 288);
            this.btn_inventario.Name = "btn_inventario";
            this.btn_inventario.Size = new System.Drawing.Size(194, 41);
            this.btn_inventario.TabIndex = 42;
            this.btn_inventario.Text = "Inventario";
            this.btn_inventario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_inventario.UseVisualStyleBackColor = true;
            // 
            // btn_reportes
            // 
            this.btn_reportes.FlatAppearance.BorderSize = 0;
            this.btn_reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reportes.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reportes.ForeColor = System.Drawing.Color.White;
            this.btn_reportes.Image = global::Sistema_Ventas.Properties.Resources.reportes;
            this.btn_reportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reportes.Location = new System.Drawing.Point(3, 339);
            this.btn_reportes.Name = "btn_reportes";
            this.btn_reportes.Size = new System.Drawing.Size(194, 41);
            this.btn_reportes.TabIndex = 43;
            this.btn_reportes.Text = "Reportes";
            this.btn_reportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reportes.UseVisualStyleBackColor = true;
            // 
            // btn_proveedores
            // 
            this.btn_proveedores.FlatAppearance.BorderSize = 0;
            this.btn_proveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_proveedores.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proveedores.ForeColor = System.Drawing.Color.White;
            this.btn_proveedores.Image = global::Sistema_Ventas.Properties.Resources.proveedores;
            this.btn_proveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_proveedores.Location = new System.Drawing.Point(3, 390);
            this.btn_proveedores.Name = "btn_proveedores";
            this.btn_proveedores.Size = new System.Drawing.Size(194, 41);
            this.btn_proveedores.TabIndex = 44;
            this.btn_proveedores.Text = "Proveedores";
            this.btn_proveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_proveedores.UseVisualStyleBackColor = true;
            // 
            // lbl_buscar
            // 
            this.lbl_buscar.AutoSize = true;
            this.lbl_buscar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_buscar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buscar.Location = new System.Drawing.Point(25, 21);
            this.lbl_buscar.Name = "lbl_buscar";
            this.lbl_buscar.Size = new System.Drawing.Size(98, 14);
            this.lbl_buscar.TabIndex = 18;
            this.lbl_buscar.Text = "Buscar Producto";
            // 
            // txt_buscador_prod
            // 
            this.txt_buscador_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_buscador_prod.Location = new System.Drawing.Point(28, 38);
            this.txt_buscador_prod.Multiline = true;
            this.txt_buscador_prod.Name = "txt_buscador_prod";
            this.txt_buscador_prod.Size = new System.Drawing.Size(378, 31);
            this.txt_buscador_prod.TabIndex = 19;
            // 
            // dgv_productos
            // 
            this.dgv_productos.BackgroundColor = System.Drawing.Color.White;
            this.dgv_productos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_productos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productos.Location = new System.Drawing.Point(28, 86);
            this.dgv_productos.Name = "dgv_productos";
            this.dgv_productos.Size = new System.Drawing.Size(708, 210);
            this.dgv_productos.TabIndex = 20;
            // 
            // cmb_categoria
            // 
            this.cmb_categoria.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_categoria.FormattingEnabled = true;
            this.cmb_categoria.Location = new System.Drawing.Point(530, 38);
            this.cmb_categoria.Name = "cmb_categoria";
            this.cmb_categoria.Size = new System.Drawing.Size(203, 27);
            this.cmb_categoria.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "Precio de venta";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre.Location = new System.Drawing.Point(82, 311);
            this.txt_nombre.Multiline = true;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(217, 16);
            this.txt_nombre.TabIndex = 27;
            // 
            // txt_precio_venta
            // 
            this.txt_precio_venta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_precio_venta.Location = new System.Drawing.Point(123, 352);
            this.txt_precio_venta.Multiline = true;
            this.txt_precio_venta.Name = "txt_precio_venta";
            this.txt_precio_venta.Size = new System.Drawing.Size(176, 16);
            this.txt_precio_venta.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "Precio de compra";
            // 
            // txt_precio_compra
            // 
            this.txt_precio_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_precio_compra.Location = new System.Drawing.Point(135, 387);
            this.txt_precio_compra.Multiline = true;
            this.txt_precio_compra.Name = "txt_precio_compra";
            this.txt_precio_compra.Size = new System.Drawing.Size(164, 16);
            this.txt_precio_compra.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 31;
            this.label7.Text = "Stock inicial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 32;
            this.label8.Text = "Stock minimo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(527, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 14);
            this.label9.TabIndex = 33;
            this.label9.Text = "Categoria";
            // 
            // txt_categoria
            // 
            this.txt_categoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_categoria.Location = new System.Drawing.Point(593, 352);
            this.txt_categoria.Multiline = true;
            this.txt_categoria.Name = "txt_categoria";
            this.txt_categoria.Size = new System.Drawing.Size(143, 16);
            this.txt_categoria.TabIndex = 34;
            // 
            // txt_stock_minimo
            // 
            this.txt_stock_minimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_stock_minimo.Location = new System.Drawing.Point(412, 352);
            this.txt_stock_minimo.Multiline = true;
            this.txt_stock_minimo.Name = "txt_stock_minimo";
            this.txt_stock_minimo.Size = new System.Drawing.Size(91, 16);
            this.txt_stock_minimo.TabIndex = 35;
            // 
            // txt_stock_inicial
            // 
            this.txt_stock_inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_stock_inicial.Location = new System.Drawing.Point(401, 311);
            this.txt_stock_inicial.Multiline = true;
            this.txt_stock_inicial.Name = "txt_stock_inicial";
            this.txt_stock_inicial.Size = new System.Drawing.Size(102, 16);
            this.txt_stock_inicial.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(527, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 14);
            this.label11.TabIndex = 38;
            this.label11.Text = "Impuesto";
            // 
            // txt_impuesto
            // 
            this.txt_impuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_impuesto.Location = new System.Drawing.Point(593, 310);
            this.txt_impuesto.Multiline = true;
            this.txt_impuesto.Name = "txt_impuesto";
            this.txt_impuesto.Size = new System.Drawing.Size(143, 16);
            this.txt_impuesto.TabIndex = 40;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.ForeColor = System.Drawing.Color.White;
            this.btn_actualizar.Location = new System.Drawing.Point(337, 420);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(127, 28);
            this.btn_actualizar.TabIndex = 43;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.Red;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_eliminar.Location = new System.Drawing.Point(470, 420);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(127, 28);
            this.btn_eliminar.TabIndex = 42;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.ForeColor = System.Drawing.Color.White;
            this.btn_agregar.Location = new System.Drawing.Point(201, 420);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(127, 28);
            this.btn_agregar.TabIndex = 41;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Productos";
            this.Text = "Productos";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.Button btn_proveedores;
        private System.Windows.Forms.Button btn_reportes;
        private System.Windows.Forms.Button btn_inventario;
        private System.Windows.Forms.Button btn_productos;
        private System.Windows.Forms.Button btn_venta;
        private System.Windows.Forms.Label lbl_buscar;
        private System.Windows.Forms.TextBox txt_buscador_prod;
        private System.Windows.Forms.DataGridView dgv_productos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_precio_compra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_precio_venta;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_impuesto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_stock_inicial;
        private System.Windows.Forms.TextBox txt_stock_minimo;
        private System.Windows.Forms.TextBox txt_categoria;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_agregar;
    }
}