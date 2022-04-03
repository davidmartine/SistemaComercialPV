
namespace Aplicacion_Comercial.Formularios.Inventario_Kardex
{
    partial class KardexEntrada
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KardexEntrada));
            this.datalistadoProductos = new System.Windows.Forms.DataGridView();
            this.Eli = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidadActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPrecioMayoreo = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtPrecioVenta = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtCosto = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtAgregar = new Guna.UI.WinForms.GunaLineTextBox();
            this.lblAnuncio = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new Guna.UI.WinForms.GunaLineTextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datalistadoProductos
            // 
            this.datalistadoProductos.AllowUserToAddRows = false;
            this.datalistadoProductos.AllowUserToResizeRows = false;
            this.datalistadoProductos.BackgroundColor = System.Drawing.Color.White;
            this.datalistadoProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistadoProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistadoProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistadoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistadoProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eli});
            this.datalistadoProductos.EnableHeadersVisualStyles = false;
            this.datalistadoProductos.Location = new System.Drawing.Point(30, 87);
            this.datalistadoProductos.Name = "datalistadoProductos";
            this.datalistadoProductos.ReadOnly = true;
            this.datalistadoProductos.RowHeadersVisible = false;
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistadoProductos.RowTemplate.Height = 30;
            this.datalistadoProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistadoProductos.Size = new System.Drawing.Size(667, 526);
            this.datalistadoProductos.TabIndex = 21;
            this.datalistadoProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistadoProductos_CellClick);
            // 
            // Eli
            // 
            this.Eli.HeaderText = "";
            this.Eli.Image = ((System.Drawing.Image)(resources.GetObject("Eli.Image")));
            this.Eli.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eli.Name = "Eli";
            this.Eli.ReadOnly = true;
            this.Eli.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(340, 521);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(300, 47);
            this.dataGridView1.TabIndex = 23;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // txtMotivo
            // 
            this.txtMotivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.ForeColor = System.Drawing.Color.White;
            this.txtMotivo.Location = new System.Drawing.Point(138, 425);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(290, 90);
            this.txtMotivo.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(26, 457);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "MOTIVO:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(205, 380);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(141, 29);
            this.dtpFechaRegistro.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 28);
            this.label8.TabIndex = 17;
            this.label8.Text = "FECHA DE REG.:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 28);
            this.label7.TabIndex = 14;
            this.label7.Text = "PRECIO MAYOREO:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "PRECIO VENTA:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "COSTO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "AGREGAR:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCantidadActual
            // 
            this.lblCantidadActual.AutoSize = true;
            this.lblCantidadActual.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadActual.ForeColor = System.Drawing.Color.White;
            this.lblCantidadActual.Location = new System.Drawing.Point(228, 124);
            this.lblCantidadActual.Name = "lblCantidadActual";
            this.lblCantidadActual.Size = new System.Drawing.Size(23, 28);
            this.lblCantidadActual.TabIndex = 4;
            this.lblCantidadActual.Text = "0";
            this.lblCantidadActual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "CANTIDAD ACTUAL:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSCAR PRODUCTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(846, 44);
            this.label11.TabIndex = 1;
            this.label11.Text = "INGRESO DE PRODUCTO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel8.Controls.Add(this.guna2ControlBox3);
            this.panel8.Controls.Add(this.guna2ControlBox2);
            this.panel8.Controls.Add(this.guna2ControlBox1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(846, 30);
            this.panel8.TabIndex = 540;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.DodgerBlue;
            this.guna2ControlBox3.Location = new System.Drawing.Point(681, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShadowDecoration.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox3.TabIndex = 5;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Orange;
            this.guna2ControlBox2.Location = new System.Drawing.Point(736, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox2.TabIndex = 4;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(791, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 74);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 625);
            this.panel9.TabIndex = 541;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(786, 74);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(60, 625);
            this.panel10.TabIndex = 542;
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.White;
            this.panel1.BorderRadius = 20;
            this.panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.panel1.BorderThickness = 1;
            this.panel1.Controls.Add(this.datalistadoProductos);
            this.panel1.Controls.Add(this.txtPrecioMayoreo);
            this.panel1.Controls.Add(this.txtPrecioVenta);
            this.panel1.Controls.Add(this.txtCosto);
            this.panel1.Controls.Add(this.txtAgregar);
            this.panel1.Controls.Add(this.lblAnuncio);
            this.panel1.Controls.Add(this.txtBuscarProducto);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMotivo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaRegistro);
            this.panel1.Controls.Add(this.lblCantidadActual);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(60, 74);
            this.panel1.Name = "panel1";
            this.panel1.ShadowDecoration.Parent = this.panel1;
            this.panel1.Size = new System.Drawing.Size(726, 625);
            this.panel1.TabIndex = 543;
            // 
            // txtPrecioMayoreo
            // 
            this.txtPrecioMayoreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtPrecioMayoreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioMayoreo.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtPrecioMayoreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrecioMayoreo.ForeColor = System.Drawing.Color.White;
            this.txtPrecioMayoreo.LineColor = System.Drawing.Color.White;
            this.txtPrecioMayoreo.Location = new System.Drawing.Point(205, 324);
            this.txtPrecioMayoreo.Name = "txtPrecioMayoreo";
            this.txtPrecioMayoreo.PasswordChar = '\0';
            this.txtPrecioMayoreo.SelectedText = "";
            this.txtPrecioMayoreo.Size = new System.Drawing.Size(223, 32);
            this.txtPrecioMayoreo.TabIndex = 29;
            this.txtPrecioMayoreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtPrecioVenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioVenta.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrecioVenta.ForeColor = System.Drawing.Color.White;
            this.txtPrecioVenta.LineColor = System.Drawing.Color.White;
            this.txtPrecioVenta.Location = new System.Drawing.Point(176, 263);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.PasswordChar = '\0';
            this.txtPrecioVenta.SelectedText = "";
            this.txtPrecioVenta.Size = new System.Drawing.Size(252, 32);
            this.txtPrecioVenta.TabIndex = 28;
            this.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtCosto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCosto.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCosto.ForeColor = System.Drawing.Color.White;
            this.txtCosto.LineColor = System.Drawing.Color.White;
            this.txtCosto.Location = new System.Drawing.Point(135, 213);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.PasswordChar = '\0';
            this.txtCosto.SelectedText = "";
            this.txtCosto.Size = new System.Drawing.Size(293, 32);
            this.txtCosto.TabIndex = 27;
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged_1);
            // 
            // txtAgregar
            // 
            this.txtAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtAgregar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAgregar.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtAgregar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAgregar.ForeColor = System.Drawing.Color.White;
            this.txtAgregar.LineColor = System.Drawing.Color.White;
            this.txtAgregar.Location = new System.Drawing.Point(135, 165);
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.PasswordChar = '\0';
            this.txtAgregar.SelectedText = "";
            this.txtAgregar.Size = new System.Drawing.Size(293, 32);
            this.txtAgregar.TabIndex = 26;
            this.txtAgregar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgregar.TextChanged += new System.EventHandler(this.txtAgregar_TextChanged_1);
            // 
            // lblAnuncio
            // 
            this.lblAnuncio.AutoSize = true;
            this.lblAnuncio.Location = new System.Drawing.Point(135, 540);
            this.lblAnuncio.Name = "lblAnuncio";
            this.lblAnuncio.Size = new System.Drawing.Size(35, 13);
            this.lblAnuncio.TabIndex = 25;
            this.lblAnuncio.Text = "label3";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarProducto.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.txtBuscarProducto.LineColor = System.Drawing.Color.White;
            this.txtBuscarProducto.Location = new System.Drawing.Point(30, 54);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.PasswordChar = '\0';
            this.txtBuscarProducto.SelectedText = "";
            this.txtBuscarProducto.Size = new System.Drawing.Size(667, 32);
            this.txtBuscarProducto.TabIndex = 24;
            this.txtBuscarProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnGuardar.BorderThickness = 1;
            this.btnGuardar.CheckedState.Parent = this.btnGuardar;
            this.btnGuardar.CustomImages.Parent = this.btnGuardar;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnGuardar.HoverState.Parent = this.btnGuardar;
            this.btnGuardar.Location = new System.Drawing.Point(123, 568);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ShadowDecoration.Parent = this.btnGuardar;
            this.btnGuardar.Size = new System.Drawing.Size(290, 45);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel8;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // KardexEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(846, 699);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KardexEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KardexEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidadActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridView datalistadoProductos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewImageColumn Eli;
        private System.Windows.Forms.Panel panel8;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private Guna.UI2.WinForms.Guna2Panel panel1;
        private Guna.UI.WinForms.GunaLineTextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblAnuncio;
        private Guna.UI.WinForms.GunaLineTextBox txtAgregar;
        private Guna.UI.WinForms.GunaLineTextBox txtCosto;
        private Guna.UI.WinForms.GunaLineTextBox txtPrecioVenta;
        private Guna.UI.WinForms.GunaLineTextBox txtPrecioMayoreo;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}