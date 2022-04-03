
namespace Aplicacion_Comercial.Formularios.Inventario_Kardex
{
    partial class KardexSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KardexSalida));
            this.label1 = new System.Windows.Forms.Label();
            this.datalistadoProductos = new System.Windows.Forms.DataGridView();
            this.Eli = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidadActual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.txtCantidad = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtBuscarProducto = new Guna.UI.WinForms.GunaLineTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoProductos)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(830, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "SALIDA DE PRODUCTOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.datalistadoProductos.Location = new System.Drawing.Point(22, 111);
            this.datalistadoProductos.Name = "datalistadoProductos";
            this.datalistadoProductos.ReadOnly = true;
            this.datalistadoProductos.RowHeadersVisible = false;
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.datalistadoProductos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistadoProductos.RowTemplate.Height = 30;
            this.datalistadoProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistadoProductos.Size = new System.Drawing.Size(667, 430);
            this.datalistadoProductos.TabIndex = 24;
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
            // txtMotivo
            // 
            this.txtMotivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.ForeColor = System.Drawing.Color.White;
            this.txtMotivo.Location = new System.Drawing.Point(137, 351);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(271, 91);
            this.txtMotivo.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "MOTIVO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(171, 280);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(129, 29);
            this.dtpFechaRegistro.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 28);
            this.label8.TabIndex = 19;
            this.label8.Text = "FECHA DE REG:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "CANTIDAD:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCantidadActual
            // 
            this.lblCantidadActual.AutoSize = true;
            this.lblCantidadActual.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadActual.ForeColor = System.Drawing.Color.White;
            this.lblCantidadActual.Location = new System.Drawing.Point(212, 156);
            this.lblCantidadActual.Name = "lblCantidadActual";
            this.lblCantidadActual.Size = new System.Drawing.Size(23, 28);
            this.lblCantidadActual.TabIndex = 7;
            this.lblCantidadActual.Text = "0";
            this.lblCantidadActual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "CANTIDAD ACTUAL:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(254, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "BUSCAR PRODUCTO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panel8.Size = new System.Drawing.Size(830, 30);
            this.panel8.TabIndex = 541;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.DodgerBlue;
            this.guna2ControlBox3.Location = new System.Drawing.Point(665, 0);
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
            this.guna2ControlBox2.Location = new System.Drawing.Point(720, 0);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(775, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 630);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(830, 30);
            this.panel4.TabIndex = 542;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 83);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 547);
            this.panel9.TabIndex = 543;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(770, 83);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(60, 547);
            this.panel10.TabIndex = 544;
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.White;
            this.panel1.BorderRadius = 20;
            this.panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.panel1.BorderThickness = 1;
            this.panel1.Controls.Add(this.datalistadoProductos);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.txtBuscarProducto);
            this.panel1.Controls.Add(this.txtMotivo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblCantidadActual);
            this.panel1.Controls.Add(this.dtpFechaRegistro);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(60, 83);
            this.panel1.Name = "panel1";
            this.panel1.ShadowDecoration.Parent = this.panel1;
            this.panel1.Size = new System.Drawing.Size(710, 547);
            this.panel1.TabIndex = 545;
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
            this.btnGuardar.Location = new System.Drawing.Point(137, 481);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ShadowDecoration.Parent = this.btnGuardar;
            this.btnGuardar.Size = new System.Drawing.Size(271, 45);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtCantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCantidad.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCantidad.ForeColor = System.Drawing.Color.White;
            this.txtCantidad.LineColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(137, 214);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PasswordChar = '\0';
            this.txtCantidad.SelectedText = "";
            this.txtCantidad.Size = new System.Drawing.Size(271, 32);
            this.txtCantidad.TabIndex = 26;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarProducto.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.txtBuscarProducto.LineColor = System.Drawing.Color.White;
            this.txtBuscarProducto.Location = new System.Drawing.Point(22, 78);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.PasswordChar = '\0';
            this.txtBuscarProducto.SelectedText = "";
            this.txtBuscarProducto.Size = new System.Drawing.Size(667, 32);
            this.txtBuscarProducto.TabIndex = 25;
            this.txtBuscarProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged_1);
            // 
            // KardexSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(830, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KardexSalida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KARDEX SALIDA";
            this.Load += new System.EventHandler(this.KardexSalida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoProductos)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidadActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView datalistadoProductos;
        private System.Windows.Forms.DataGridViewImageColumn Eli;
        private System.Windows.Forms.Panel panel8;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private Guna.UI2.WinForms.Guna2Panel panel1;
        private Guna.UI.WinForms.GunaLineTextBox txtBuscarProducto;
        private Guna.UI.WinForms.GunaLineTextBox txtCantidad;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
    }
}