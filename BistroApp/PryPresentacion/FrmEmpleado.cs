using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PryEntidades;
using PryLogicaNegocio;

namespace PryPresentacion
{
    public partial class FrmEmpleado : Form
    {

        private ClsEmpleado ObjEmpleado = null;
        private readonly ClsEmpleadoLn ObjEmpleadoLn = new ClsEmpleadoLn();
        public FrmEmpleado()
        {
            InitializeComponent();
            // cargar la lista de Empleados en el dt gread view
            CargarListaEmpleado();
        }

        private void CargarListaEmpleado()
        {
            ObjEmpleado = new ClsEmpleado();
            ObjEmpleadoLn.Index(ref ObjEmpleado);
            if (ObjEmpleado.MensajeError == null)
            {
                dtvEmpleados.DataSource = ObjEmpleado.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Error Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            ObjEmpleado = new ClsEmpleado()
            {
                IdEmpleado = txtIdEmpleado.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Puesto = txtPuesto.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
            };
            ObjEmpleadoLn.Create(ref ObjEmpleado);
            if (ObjEmpleado.MensajeError == null)
            {
                MessageBox.Show("El Empleado: " + ObjEmpleado.ValorScalar + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaEmpleado();
            }
            else
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Error Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdEmpleado.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtPuesto.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            ObjEmpleado = new ClsEmpleado()
            {
                IdEmpleado = txtIdEmpleado.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Puesto = txtPuesto.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
            };
            ObjEmpleadoLn.Update(ref ObjEmpleado);
            if (ObjEmpleado.MensajeError == null)
            {
                MessageBox.Show("El Empleado: " + ObjEmpleado.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaEmpleado();
            }
            else
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Error Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdEmpleado.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtPuesto.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

      
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjEmpleado = new ClsEmpleado()
                {
                    IdEmpleado = txtIdEmpleado.Text,
                };

                ObjEmpleadoLn.Delete(ref ObjEmpleado);

                if (ObjEmpleado.MensajeError == null)
                {
                    MessageBox.Show("El Empleado: " + ObjEmpleado.Nombre + " " + ObjEmpleado.Apellido + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaEmpleado();
                }
                else
                {
                    MessageBox.Show(ObjEmpleado.MensajeError, "Error Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdEmpleado.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtPuesto.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
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

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEmpleado.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ObjEmpleado = new ClsEmpleado()
            {
                IdEmpleado = txtIdEmpleado.Text
            };

            // Llamar al método Read para buscar el empleado
            ObjEmpleadoLn.Buscar(ref ObjEmpleado);

            if (ObjEmpleado.MensajeError != null)
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si no hay error, asignar los datos a los TextBox
            if (ObjEmpleado.DtResultados.Rows.Count > 0)
            {
                DataRow row = ObjEmpleado.DtResultados.Rows[0];
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtPuesto.Text = row["Puesto"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró un empleado con ese ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
