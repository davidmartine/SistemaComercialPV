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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private int idCliente;
        private string Estado;
        private void Clientes_Load(object sender, EventArgs e)
        {
            mostrar_cliente();
        }

        private void insertar_cliente()
        {
            LCliente cliente_parametros = new LCliente();
            CADInsertarDatos funcion = new CADInsertarDatos();
            cliente_parametros.Nombre = txtNombre.Text;
            cliente_parametros.Direccion = txtDireccion.Text;
            cliente_parametros.IdentificadorFiscal = txtNit.Text;
            cliente_parametros.Movil = txtTelCel.Text;
            if (funcion.insertar_clientes(cliente_parametros) == true)
            {
                mostrar_cliente();
            }
        }
        private void mostrar_cliente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_cliente(ref dt);
            datalistado.DataSource = dt;
            panelRegistro.Visible = false;
            pintar_datalistado();

        }
        private void actualizar_cliente()
        {
            LCliente cliente_parametros = new LCliente();
            CADEditarDatos funcion = new CADEditarDatos();
            cliente_parametros.idCliente = idCliente;
            cliente_parametros.Nombre = txtNombre.Text;
            cliente_parametros.Direccion = txtDireccion.Text;
            cliente_parametros.IdentificadorFiscal = txtNit.Text;
            cliente_parametros.Movil = txtTelCel.Text;
            if (funcion.editar_cliente(cliente_parametros) == true)
            {
                mostrar_cliente();
            }
        }
        private void eliminar_cliente()
        {
            try
            {
                LCliente cliente_parametros = new LCliente();
                CADEliminarDatos funcion = new CADEliminarDatos();
                cliente_parametros.idCliente = idCliente;
                if (funcion.eliminar_cliente(cliente_parametros) == true)
                {
                    mostrar_cliente();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void restaurar_cliente()
        {
            LCliente cliente_parametros = new LCliente();
            CADEditarDatos funcion = new CADEditarDatos();
            cliente_parametros.idCliente = idCliente;
            if (funcion.restaurar_cliente(cliente_parametros) == true)
            {
                mostrar_cliente();
            }
        }
        private void buscar_cliente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_cliente(ref dt, txtbusca.Text);
            datalistado.DataSource = dt;
            pintar_datalistado();
        }
        private void pintar_datalistado()
        {
            Logica.BasesPCProgram.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
            foreach(DataGridViewRow row in datalistado.Rows)
            {
                string Estado =Convert.ToString(row.Cells["Estado"].Value);
                if(Estado == "ELIMINADO")
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtTelCel.Text))
                {
                    if (!string.IsNullOrEmpty(txtDireccion.Text))
                    {
                        if (!string.IsNullOrEmpty(txtNit.Text))
                        {
                            insertar_cliente();
                        }
                        else
                        {
                            MessageBox.Show("EL CAMPO DE NUMERO DE IDENTIFICACION ES OBLIGATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("EL CAMPO NUMERO DE TELEFONO/MOVIL ES OBLIATORIO", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.ColumnIndex == datalistado.Columns["Editar"].Index)
            {
                obtener_datos();
            }
            if (e.ColumnIndex == datalistado.Columns["Eliminar"].Index)
            {
                obtener_id_estado();
                if (Estado == "ACTIVO")
                {
                    DialogResult result;
                    result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR ESTE PROVEEDOR?", "ELIMINAR PROVEEDOR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        eliminar_cliente(); 
                    }
                }


            }
        }

        private void obtener_id_estado()
        {
            try
            {
                idCliente =Convert.ToInt32(datalistado.SelectedCells[2].Value);
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
                idCliente = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtNombre.Text = datalistado.SelectedCells[3].Value.ToString();
                txtDireccion.Text = datalistado.SelectedCells[4].Value.ToString();
                txtNit.Text = datalistado.SelectedCells[5].Value.ToString();
                txtTelCel.Text = datalistado.SelectedCells[6].Value.ToString();
                Estado = datalistado.SelectedCells[7].Value.ToString();
                if (Estado == "ELIMINADO")
                {
                    DialogResult result;
                    result = MessageBox.Show("ESTE PROVEEDOR SE ENCUENTRA EN ESTADO ELIMINADO.¿DESEAS HABILITARLO?", "RESTAURAR PROVEEDOR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        restaurar_cliente();
                        ver_edicion_panel_registro();
                    }

                }
                else
                {
                    ver_edicion_panel_registro();
                }
            }
            catch (Exception)
            {

            }
           
        }
        private void ver_edicion_panel_registro()
        {
            panelRegistro.Visible = true;
            panelRegistro.Dock = DockStyle.Fill;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }
        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscar_cliente();
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtTelCel.Text))
                {
                    if (!string.IsNullOrEmpty(txtDireccion.Text))
                    {
                        if (!string.IsNullOrEmpty(txtNit.Text))
                        {
                            actualizar_cliente();
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
        }
    }
}
