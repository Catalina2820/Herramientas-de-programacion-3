using MaterialSkin;
using MaterialSkin.Controls;
using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Windows.Forms;

namespace PryPresentacion
{
    public partial class FrmSocio : MaterialForm
    {
        private ClsSocio ObjSocio = null;
        private readonly ClsSocioLn ObjSocioLn = new ClsSocioLn();
        public FrmSocio()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey800, Primary.Grey900,
                Primary.Grey500, Accent.Indigo700,
                TextShade.WHITE);

            // cargar la lista de socios en el dt gread view
            CargarListaSocio();
        }

        private void FrmSocio_Load(object sender, EventArgs e)
        {

        }

        private void CargarListaSocio()
        {
            ObjSocio = new ClsSocio();
            ObjSocioLn.Index(ref ObjSocio);
            if (ObjSocio.MensajeError == null)
            {
                dtvListaSocios.DataSource = ObjSocio.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjSocio.MensajeError, "Error Socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjSocio = new ClsSocio()
                {
                    Identificacion = txtIdentificacion.Text,
                };
                ObjSocioLn.Delete(ref ObjSocio);
                if (ObjSocio.MensajeError == null)
                {
                    MessageBox.Show("El socio: " + ObjSocio.ValorScalar + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaSocio();
                }
                else
                {
                    MessageBox.Show(ObjSocio.MensajeError, "Error Socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdentificacion.Text = "";
                txtNombreComp.Text = "";
                dtpFechaNacimiento.Value = DateTime.Now;
                txtCelular.Text = "";
                txtEmail.Text = "";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjSocio = new ClsSocio()
            {
                Identificacion = txtIdentificacion.Text,
                Nombre = txtNombreComp.Text,
                FechaNacim = dtpFechaNacimiento.Value,
                Celular = txtCelular.Text,
                Email = txtEmail.Text,
            };
            ObjSocioLn.Update(ref ObjSocio);
            if (ObjSocio.MensajeError == null)
            {
                MessageBox.Show("El socio: " + ObjSocio.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaSocio();
            }
            else
            {
                MessageBox.Show(ObjSocio.MensajeError, "Error Socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdentificacion.Text = "";
            txtNombreComp.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCelular.Text = "";
            txtEmail.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjSocio = new ClsSocio()
            {
                Identificacion = txtIdentificacion.Text,
                Nombre = txtNombreComp.Text,
                FechaNacim = dtpFechaNacimiento.Value,
                Celular = txtCelular.Text,
                Email = txtEmail.Text,
            };
            ObjSocioLn.Create(ref ObjSocio);
            if (ObjSocio.MensajeError == null)
            {
                MessageBox.Show("El socio: " + ObjSocio.ValorScalar + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaSocio();
            }
            else
            {
                MessageBox.Show(ObjSocio.MensajeError, "Error Socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtIdentificacion.Text = "";
            txtNombreComp.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCelular.Text = "";
            txtEmail.Text = "";
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

        private void dtvListaSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtvListaSocios.Columns[e.ColumnIndex].Name == "Editar")
            {
                ObjSocio = new ClsSocio()
                {
                    Identificacion = dtvListaSocios.Rows[e.RowIndex].Cells["IdSocio"].Value.ToString()

                };
                ObjSocioLn.Read(ref ObjSocio);

                txtIdentificacion.Text = ObjSocio.Identificacion;
                txtNombreComp.Text = ObjSocio.Nombre;
                dtpFechaNacimiento.Value = ObjSocio.FechaNacim;
                txtCelular.Text = ObjSocio.Celular;
                txtEmail.Text = ObjSocio.Email;
            }
        }
    }
}
