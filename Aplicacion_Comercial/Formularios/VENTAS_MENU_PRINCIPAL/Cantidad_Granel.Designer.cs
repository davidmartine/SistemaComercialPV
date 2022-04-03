namespace Aplicacion_Comercial.Formularios.VENTAS_MENU_PRINCIPAL
{
    partial class Cantidad_Granel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cantidad_Granel));
            this.LblcantidadAumentar = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtprecio_unitario = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Puertos = new System.IO.Ports.SerialPort(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCencelar = new Guna.UI2.WinForms.Guna2Button();
            this.BtnCerrar_turno = new Guna.UI2.WinForms.Guna2Button();
            this.panel8.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblcantidadAumentar
            // 
            this.LblcantidadAumentar.AutoSize = true;
            this.LblcantidadAumentar.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.LblcantidadAumentar.ForeColor = System.Drawing.Color.White;
            this.LblcantidadAumentar.Location = new System.Drawing.Point(47, 74);
            this.LblcantidadAumentar.Name = "LblcantidadAumentar";
            this.LblcantidadAumentar.Size = new System.Drawing.Size(290, 37);
            this.LblcantidadAumentar.TabIndex = 537;
            this.LblcantidadAumentar.Text = "Cantidad a Aumentar";
            this.LblcantidadAumentar.Visible = false;
            // 
            // txtProducto
            // 
            this.txtProducto.AutoSize = true;
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.txtProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtProducto.Location = new System.Drawing.Point(233, 16);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(205, 46);
            this.txtProducto.TabIndex = 538;
            this.txtProducto.Text = "PRODUCTO";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtcantidad.Location = new System.Drawing.Point(61, 152);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(163, 43);
            this.txtcantidad.TabIndex = 547;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            // 
            // txttotal
            // 
            this.txttotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txttotal.Location = new System.Drawing.Point(279, 152);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(205, 43);
            this.txttotal.TabIndex = 546;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.Label27.ForeColor = System.Drawing.Color.White;
            this.Label27.Location = new System.Drawing.Point(306, 124);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(160, 28);
            this.Label27.TabIndex = 544;
            this.Label27.Text = "Importe Actual:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.White;
            this.Label14.Location = new System.Drawing.Point(83, 124);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(101, 28);
            this.Label14.TabIndex = 545;
            this.Label14.Text = "Cantidad:";
            // 
            // txtprecio_unitario
            // 
            this.txtprecio_unitario.AutoSize = true;
            this.txtprecio_unitario.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtprecio_unitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtprecio_unitario.Location = new System.Drawing.Point(317, 243);
            this.txtprecio_unitario.Name = "txtprecio_unitario";
            this.txtprecio_unitario.Size = new System.Drawing.Size(33, 37);
            this.txtprecio_unitario.TabIndex = 548;
            this.txtprecio_unitario.Text = "0";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.Label38.ForeColor = System.Drawing.Color.White;
            this.Label38.Location = new System.Drawing.Point(48, 243);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(263, 37);
            this.Label38.TabIndex = 549;
            this.Label38.Text = "PRECIO UNITARIO :";
            // 
            // Puertos
            // 
            this.Puertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Puertos_DataReceived);
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
            this.panel8.Size = new System.Drawing.Size(793, 30);
            this.panel8.TabIndex = 603;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.DodgerBlue;
            this.guna2ControlBox3.Location = new System.Drawing.Point(628, 0);
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
            this.guna2ControlBox2.Location = new System.Drawing.Point(683, 0);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(738, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 30);
            this.panel1.TabIndex = 604;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(743, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(50, 360);
            this.panel2.TabIndex = 605;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 360);
            this.panel3.TabIndex = 606;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 39);
            this.label1.TabIndex = 607;
            this.label1.Text = "CANTIDAD GRANEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnCencelar);
            this.guna2Panel1.Controls.Add(this.BtnCerrar_turno);
            this.guna2Panel1.Controls.Add(this.txtProducto);
            this.guna2Panel1.Controls.Add(this.LblcantidadAumentar);
            this.guna2Panel1.Controls.Add(this.txttotal);
            this.guna2Panel1.Controls.Add(this.Label27);
            this.guna2Panel1.Controls.Add(this.txtcantidad);
            this.guna2Panel1.Controls.Add(this.txtprecio_unitario);
            this.guna2Panel1.Controls.Add(this.Label14);
            this.guna2Panel1.Controls.Add(this.Label38);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(50, 69);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(693, 321);
            this.guna2Panel1.TabIndex = 608;
            // 
            // btnCencelar
            // 
            this.btnCencelar.BorderRadius = 10;
            this.btnCencelar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnCencelar.BorderThickness = 1;
            this.btnCencelar.CheckedState.Parent = this.btnCencelar;
            this.btnCencelar.CustomImages.Parent = this.btnCencelar;
            this.btnCencelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.btnCencelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCencelar.ForeColor = System.Drawing.Color.White;
            this.btnCencelar.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.btnCencelar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.btnCencelar.HoverState.Parent = this.btnCencelar;
            this.btnCencelar.Location = new System.Drawing.Point(511, 195);
            this.btnCencelar.Name = "btnCencelar";
            this.btnCencelar.ShadowDecoration.Parent = this.btnCencelar;
            this.btnCencelar.Size = new System.Drawing.Size(148, 52);
            this.btnCencelar.TabIndex = 604;
            this.btnCencelar.Text = "AGREGAR";
            // 
            // BtnCerrar_turno
            // 
            this.BtnCerrar_turno.BorderRadius = 10;
            this.BtnCerrar_turno.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.BtnCerrar_turno.BorderThickness = 1;
            this.BtnCerrar_turno.CheckedState.Parent = this.BtnCerrar_turno;
            this.BtnCerrar_turno.CustomImages.Parent = this.BtnCerrar_turno;
            this.BtnCerrar_turno.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.BtnCerrar_turno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCerrar_turno.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar_turno.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.BtnCerrar_turno.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.BtnCerrar_turno.HoverState.Parent = this.BtnCerrar_turno;
            this.BtnCerrar_turno.Location = new System.Drawing.Point(511, 74);
            this.BtnCerrar_turno.Name = "BtnCerrar_turno";
            this.BtnCerrar_turno.ShadowDecoration.Parent = this.BtnCerrar_turno;
            this.BtnCerrar_turno.Size = new System.Drawing.Size(148, 52);
            this.BtnCerrar_turno.TabIndex = 603;
            this.BtnCerrar_turno.Text = "AGREGAR";
            this.BtnCerrar_turno.Click += new System.EventHandler(this.BtnCerrar_turno_Click_1);
            // 
            // Cantidad_Granel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(793, 420);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cantidad_Granel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANTIDAD GRANEL";
            this.Load += new System.EventHandler(this.CANTIDAD_A_GRANEL_Load);
            this.panel8.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LblcantidadAumentar;
        internal System.Windows.Forms.Label txtProducto;
        internal System.Windows.Forms.TextBox txtcantidad;
        internal System.Windows.Forms.TextBox txttotal;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label txtprecio_unitario;
        internal System.Windows.Forms.Label Label38;
        private System.IO.Ports.SerialPort Puertos;
        private System.Windows.Forms.Panel panel8;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button BtnCerrar_turno;
        private Guna.UI2.WinForms.Guna2Button btnCencelar;
    }
}