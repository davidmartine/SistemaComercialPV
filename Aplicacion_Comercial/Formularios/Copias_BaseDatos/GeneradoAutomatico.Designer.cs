
namespace Aplicacion_Comercial.Formularios.Copias_BaseDatos
{
    partial class GeneradoAutomatico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneradoAutomatico));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRuta = new Guna.UI.WinForms.GunaLineTextBox();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pCargando = new System.Windows.Forms.PictureBox();
            this.timerContador = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Panel12 = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCargando)).BeginInit();
            this.Panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "COPIA DE SEGURIDAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.menuStrip3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTiempo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 332);
            this.panel1.TabIndex = 1;
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(168)))));
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuta.ForeColor = System.Drawing.Color.White;
            this.txtRuta.LineColor = System.Drawing.Color.White;
            this.txtRuta.Location = new System.Drawing.Point(109, 281);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.SelectedText = "";
            this.txtRuta.Size = new System.Drawing.Size(299, 26);
            this.txtRuta.TabIndex = 623;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.CheckedState.Parent = this.btnCancelar;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.CustomImages.Parent = this.btnCancelar;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnCancelar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnCancelar.HoverState.Parent = this.btnCancelar;
            this.btnCancelar.Location = new System.Drawing.Point(109, 133);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShadowDecoration.Parent = this.btnCancelar;
            this.btnCancelar.Size = new System.Drawing.Size(318, 61);
            this.btnCancelar.TabIndex = 622;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // menuStrip3
            // 
            this.menuStrip3.AutoSize = false;
            this.menuStrip3.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip3.Location = new System.Drawing.Point(43, 223);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(57, 34);
            this.menuStrip3.TabIndex = 21;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 30);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(103, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "RUTA DE COPIAS DE SEGURIDAD";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.White;
            this.lblTiempo.Location = new System.Drawing.Point(237, 65);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(67, 54);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "10";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "SE GENERARA COPIA DE SEGURIDAD \r\nPROGRAMADA EN:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pCargando
            // 
            this.pCargando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(49)))));
            this.pCargando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCargando.Image = ((System.Drawing.Image)(resources.GetObject("pCargando.Image")));
            this.pCargando.Location = new System.Drawing.Point(0, 394);
            this.pCargando.Name = "pCargando";
            this.pCargando.Size = new System.Drawing.Size(537, 197);
            this.pCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pCargando.TabIndex = 2;
            this.pCargando.TabStop = false;
            // 
            // timerContador
            // 
            this.timerContador.Interval = 1000;
            this.timerContador.Tick += new System.EventHandler(this.timerContador_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Panel12
            // 
            this.Panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.Panel12.Controls.Add(this.guna2ControlBox1);
            this.Panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel12.Location = new System.Drawing.Point(0, 0);
            this.Panel12.Name = "Panel12";
            this.Panel12.Size = new System.Drawing.Size(537, 30);
            this.Panel12.TabIndex = 607;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(482, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 30);
            this.guna2ControlBox1.TabIndex = 1;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.Panel12;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // GeneradoAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(537, 591);
            this.Controls.Add(this.pCargando);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneradoAutomatico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneradoAutomatico_FormClosing);
            this.Load += new System.EventHandler(this.GeneradoAutomatico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCargando)).EndInit();
            this.Panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pCargando;
        private System.Windows.Forms.Timer timerContador;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI.WinForms.GunaLineTextBox txtRuta;
        internal System.Windows.Forms.Panel Panel12;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}