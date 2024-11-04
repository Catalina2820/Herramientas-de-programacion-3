using MaterialSkin;
using MaterialSkin.Controls;
using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Windows.Forms;

namespace PryPresentacion
{
    public partial class FrmPatrones : MaterialForm
    {
        private ClsPatrones ObjPatrones = null;
        private readonly ClsPatronesLn ObjPatronesLn = new ClsPatronesLn();

        public FrmPatrones()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey800, Primary.Grey900,
                Primary.Grey500, Accent.Indigo700,
                TextShade.WHITE);

            // cargar la lista de socios en el dt gread view
            CargarListaPatrones();
        }

        private void FrmPatrones_Load(object sender, EventArgs e)
        {

        }

        private void CargarListaPatrones()
        {
            ObjPatrones = new ClsPatrones();
            ObjPatronesLn.Index(ref ObjPatrones);
            if (ObjPatrones.MensajeError == null)
            {
                dtvListaPatrones.DataSource = ObjPatrones.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjPatrones.MensajeError, "Error Patrones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjPatrones = new ClsPatrones()
                {
                    IdPatron = txtIdentificacion.Text,
                };
                ObjPatronesLn.Delete(ref ObjPatrones);
                if (ObjPatrones.MensajeError == null)
                {
                    MessageBox.Show("El patron: " + ObjPatrones.ValorScalar + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaPatrones();
                }
                else
                {
                    MessageBox.Show(ObjPatrones.MensajeError, "Error Patrones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdentificacion.Text = "";
                txtNombreComp.Text = "";
                dtpFechaNacimiento.Value = DateTime.Now;
                txtCelular.Text = "";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjPatrones = new ClsPatrones()
            {
                IdPatron = txtIdentificacion.Text,
                NombrePatron = txtNombreComp.Text,
                FechaNacPatron = dtpFechaNacimiento.Value,
                CelPatron = txtCelular.Text,
            };
            ObjPatronesLn.Update(ref ObjPatrones);
            if (ObjPatrones.MensajeError == null)
            {
                MessageBox.Show("El patron: " + ObjPatrones.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaPatrones();
            }
            else
            {
                MessageBox.Show(ObjPatrones.MensajeError, "Error Patrones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdentificacion.Text = "";
            txtNombreComp.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCelular.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjPatrones = new ClsPatrones()
            {
                IdPatron = txtIdentificacion.Text,
                NombrePatron = txtNombreComp.Text,
                FechaNacPatron = dtpFechaNacimiento.Value,
                CelPatron = txtCelular.Text,
            };
            ObjPatronesLn.Create(ref ObjPatrones);
            if (ObjPatrones.MensajeError == null)
            {
                MessageBox.Show("El patron: " + ObjPatrones.ValorScalar + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaPatrones();
            }
            else
            {
                MessageBox.Show(ObjPatrones.MensajeError, "Error Patrones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdentificacion.Text = "";
            txtNombreComp.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCelular.Text = "";
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

        private void dtvListaPatrones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtvListaPatrones.Columns[e.ColumnIndex].Name == "Editar")
            {
                ObjPatrones = new ClsPatrones()
                {
                    IdPatron = dtvListaPatrones.Rows[e.RowIndex].Cells["idPatron"].Value.ToString()

                };
                ObjPatronesLn.Read(ref ObjPatrones);

                txtIdentificacion.Text = ObjPatrones.IdPatron;
                txtNombreComp.Text = ObjPatrones.NombrePatron;
                dtpFechaNacimiento.Value = ObjPatrones.FechaNacPatron;
                txtCelular.Text = ObjPatrones.CelPatron;
            }
        }
    }
}
