using Aplicacion_Comercial.Datos;
using Aplicacion_Comercial.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Clientes_Proveedores
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private int idProveedor;
        private string Estado;

        private void Proveedores_Load(object sender, EventArgs e)
        {
            mostrar_proveedores();
            panel3.Location = new Point((Width - panel3.Width) / 2, (Height - panel3.Height) / 2);
            //panelRegistro.BringToFront();
        }
        private void insertar_proveedor()
        {
            LProveedor proveedor_parametros = new LProveedor();
            Datos.CADInsertarDatos funcion = new Datos.CADInsertarDatos();

            proveedor_parametros.Nombre = txtNombre.Text;
            proveedor_parametros.Direccion = txtDireccion.Text;
            proveedor_parametros.IdentificadorFiscal = txtNit.Text;
            proveedor_parametros.Movil = txtTelCel.Text;
            if (funcion.insertar_proveedor(proveedor_parametros) == true)
            {
                mostrar_proveedores();
            }
        }
        private void mostrar_proveedores()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_proveedores(ref dt);
            datalistado.DataSource = dt;
            panelRegistro.Visible = false;
            pintar_datalistado();
        }
        private void actualizar_proveedores()
        {
            LProveedor proveedor_parametros = new LProveedor();
            CADEditarDatos funcion = new CADEditarDatos();
            proveedor_parametros.idProveedor = idProveedor;
            proveedor_parametros.Nombre = txtNombre.Text;
            proveedor_parametros.Direccion = txtDireccion.Text;
            proveedor_parametros.IdentificadorFiscal = txtNit.Text;
            proveedor_parametros.Movil = txtTelCel.Text;
            if (funcion.editar_proveedores(proveedor_parametros) == true)
            {
                mostrar_proveedores();
            }
        }
        private void eliminar_proveedor()
        {
            try
            {
                LProveedor proveedor_parametros = new LProveedor();
                CADEliminarDatos funcion = new CADEliminarDatos();
                proveedor_parametros.idProveedor = idProveedor;
                if (funcion.eliminar_proveedor(proveedor_parametros) == true)
                {
                    mostrar_proveedores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void restaurar_proveedor()
        {
            LProveedor proveedor_parametros = new LProveedor();
            CADEditarDatos funcion = new CADEditarDatos();
            proveedor_parametros.idProveedor = idProveedor;
            if (funcion.restaurar_proveedor(proveedor_parametros) == true)
            {
                mostrar_proveedores();
            }
        }
        private void buscardor_proveedor()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_proveedor(ref dt, txtbusca.Text);
            datalistado.DataSource = dt;
            pintar_datalistado();
        }
        private void pintar_datalistado()
        {
            Logica.BasesPCProgram.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
            foreach (DataGridViewRow row in datalistado.Rows)
            {
                string Estado = Convert.ToString(row.Cells["Estado"].Value);
                if (Estado == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        private void nuevo()
        {
            panelRegistro.Visible = true;
            limpiar_textos();
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtNombre.Focus();
            panelRegistro.Dock = DockStyle.Fill;
        }
        private void limpiar_textos()
        {
            txtNombre.Clear();
            txtTelCel.Clear();
            txtDireccion.Clear();
            txtNit.Clear();
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtTelCel.Text))
                {
                    if (!string.IsNullOrEmpty(txtDireccion.Text))
                    {
                        if (!string.IsNullOrEmpty(txtNit.Text))
                        {
                            insertar_proveedor();
                        }
                        else
                        {
                            MessageBox.Show("EL CAMPO IDENTIFICADOR FISCAL ES OBLIGARIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNit.Focus();

                        }
                    }
                    else
                    {
                        MessageBox.Show("EL CAMPO DIRECCION ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDireccion.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("EL CAMPO TELEFONO/MOVIL ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelCel.Focus();
                }
            }
            else
            {
                MessageBox.Show("EL CAMPO NOMBRE ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
        }
        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == datalistado.Columns["Editar"].Index)
            {
                obtener_datos();
            }
            if(e.ColumnIndex == datalistado.Columns["Eliminar"].Index)
            {
                obtener_id_estado();
                if(Estado == "ACTIVO")
                {
                    DialogResult result;
                    result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR ESTE PROVEEDOR?", "ELIMINAR PROVEEDOR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        eliminar_proveedor();
                    }
                }

                
            }
        }
        private void obtener_id_estado()
        {
            try
            {
                idProveedor =Convert.ToInt32(datalistado.SelectedCells[2].Value);
                Estado = datalistado.SelectedCells[7].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void obtener_datos()
        {
            try
            {
                idProveedor = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtNombre.Text = datalistado.SelectedCells[3].Value.ToString();
                txtDireccion.Text = datalistado.SelectedCells[4].Value.ToString();
                txtNit.Text = datalistado.SelectedCells[5].Value.ToString();
                txtTelCel.Text = datalistado.SelectedCells[6].Value.ToString();
                Estado = datalistado.SelectedCells[7].Value.ToString();
                if(Estado == "ELIMINADO")
                {
                    DialogResult result;
                    result = MessageBox.Show("ESTE PROVEEDOR SE ENCUENTRA EN ESTADO ELIMINADO.¿DESEAS HABILITARLO?", "RESTAURAR PROVEEDOR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(result == DialogResult.OK)
                    {
                        restaurar_proveedor();
                        ver_edicion_panel_registros();
                    }
                    
                }
                else
                {
                    ver_edicion_panel_registros();
                }
            }
            catch (Exception)
            {

                
            }
            
            
        }
        private void ver_edicion_panel_registros()
        {
            panelRegistro.Visible = true;
            panelRegistro.Dock = DockStyle.Fill;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
        }

        private void btnGuardarCambios_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtTelCel.Text))
                {
                    if (!string.IsNullOrEmpty(txtDireccion.Text))
                    {
                        if (!string.IsNullOrEmpty(txtNit.Text))
                        {
                            actualizar_proveedores();
                        }
                        else
                        {
                            MessageBox.Show("EL CAMPO IDENTIFICADOR FISCAL ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNit.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("EL CAMPO DIRECCION ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDireccion.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("EL CAMPO TELEFONO/MOVIL ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelCel.Focus();
                }
            }
            else
            {
                MessageBox.Show("EL CAMPO NOMBRE ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
        }
        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscardor_proveedor();
        }
    }
}
