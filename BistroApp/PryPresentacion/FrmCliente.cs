using System;
using System.Data;
using System.Windows.Forms;
using PryEntidades;
using PryLogicaNegocio;

namespace PryPresentacion
{
    public partial class FrmCliente : Form
    {

        private ClsCliente ObjCliente = null;
        private readonly ClsClienteLn ObjClienteLn = new ClsClienteLn();
        public FrmCliente()
        {
            InitializeComponent();
            // cargar la lista de Clientes en el dt gread view
            CargarListaCliente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjCliente = new ClsCliente()
            {
                IdCliente = txtIdCliente.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text,
            };

            ObjClienteLn.Create(ref ObjCliente);
            if (ObjCliente.MensajeError == null)
            {
                MessageBox.Show("El Cliente: " + ObjCliente.ValorScalar + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaCliente();
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Error Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void CargarListaCliente()
        {
            ObjCliente = new ClsCliente();
            ObjClienteLn.Index(ref ObjCliente);
            if (ObjCliente.MensajeError == null)
            {
                dtvClientes.DataSource = ObjCliente.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Error Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de Cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ObjCliente = new ClsCliente()
            {
                IdCliente = txtIdCliente.Text
            };

            // Llamar al método Read para buscar el Cliente
            ObjClienteLn.Buscar(ref ObjCliente);

            if (ObjCliente.MensajeError != null)
            {
                MessageBox.Show(ObjCliente.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si no hay error, asignar los datos a los TextBox
            if (ObjCliente.DtResultados.Rows.Count > 0)
            {
                DataRow row = ObjCliente.DtResultados.Rows[0];
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró un Cliente con ese ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjCliente = new ClsCliente()
            {
                IdCliente = txtIdCliente.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text,
            };
            ObjClienteLn.Update(ref ObjCliente);
            if (ObjCliente.MensajeError == null)
            {
                MessageBox.Show("El Cliente: " + ObjCliente.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaCliente();
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Error Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjCliente = new ClsCliente()
                {
                    IdCliente = txtIdCliente.Text,
                };

                ObjClienteLn.Delete(ref ObjCliente);

                if (ObjCliente.MensajeError == null)
                {
                    MessageBox.Show("El Cliente: " + ObjCliente.ValorScalar + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaCliente();
                }
                else
                {
                    MessageBox.Show(ObjCliente.MensajeError, "Error Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdCliente.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
