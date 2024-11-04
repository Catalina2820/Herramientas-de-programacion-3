using System;
using System.Data;
using System.Windows.Forms;
using PryEntidades;
using PryLogicaNegocio;

namespace PryPresentacion
{
    public partial class FrmCliente : Form
    {

        private ClsMenu ObjMenu = null;
        private readonly ClsMenuLn ObjMenuLn = new ClsMenuLn();

        public FrmCliente()
        {
            InitializeComponent();
            // cargar la lista de Menus en el dt gread view
            CargarListaMenu();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjMenu = new ClsMenu()
            {
                IdPlato = txtIdPlato.Text,
                NombrePlato = txtNombrePlato.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Disponibilidad = bool.Parse(cmbDisponibilidad.Text)
            };

            ObjMenuLn.Create(ref ObjMenu);
            if (ObjMenu.MensajeError == null)
            {
                MessageBox.Show("El Plato: " + ObjMenu.NombrePlato + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaMenu();
            }
            else
            {
                MessageBox.Show(ObjMenu.MensajeError, "Error Menus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdPlato.Text = "";
            txtNombrePlato.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbDisponibilidad.Text = "";
        }

        private void CargarListaMenu()
        {
            ObjMenu = new ClsMenu();
            ObjMenuLn.Index(ref ObjMenu);
            if (ObjMenu.MensajeError == null)
            {
                dtvMenu.DataSource = ObjMenu.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjMenu.MensajeError, "Error Menus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPlato.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID del Plato.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ObjMenu = new ClsMenu()
            {
                IdPlato = txtIdPlato.Text
            };

            // Llamar al método Read para buscar el Menu
            ObjMenuLn.Buscar(ref ObjMenu);

            if (ObjMenu.MensajeError != null)
            {
                MessageBox.Show(ObjMenu.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si no hay error, asignar los datos a los TextBox
            if (ObjMenu.DtResultados.Rows.Count > 0)
            {
                DataRow row = ObjMenu.DtResultados.Rows[0];
                txtNombrePlato.Text = row["NombrePlato"].ToString();
                txtDescripcion.Text = row["Descripcion"].ToString();
                txtPrecio.Text = row["Precio"].ToString();
                cmbDisponibilidad.Text = row["Disponibilidad"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró un Plato con ese ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjMenu = new ClsMenu()
            {
                NombrePlato = txtNombrePlato.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Disponibilidad = bool.Parse(cmbDisponibilidad.Text)
            };
            ObjMenuLn.Update(ref ObjMenu);
            if (ObjMenu.MensajeError == null)
            {
                MessageBox.Show("El Menu: " + ObjMenu.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaMenu();
            }
            else
            {
                MessageBox.Show(ObjMenu.MensajeError, "Error Menus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdPlato.Text = "";
            txtNombrePlato.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbDisponibilidad.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjMenu = new ClsMenu()
                {
                    IdPlato = txtIdPlato.Text,
                };

                ObjMenuLn.Delete(ref ObjMenu);

                if (ObjMenu.MensajeError == null)
                {
                    MessageBox.Show("El Plato: " + ObjMenu.NombrePlato + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaMenu();
                }
                else
                {
                    MessageBox.Show(ObjMenu.MensajeError, "Error Menus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdPlato.Text = "";
                txtNombrePlato.Text = "";
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                cmbDisponibilidad.Text = "";
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
