using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPresentacion
{
    public partial class FrmBarcos : Form
    {
        private ClsBarco ObjBarco = null;
        private readonly ClsBarcoLn ObjBarcoLn = new ClsBarcoLn();
        private readonly ClsSocioLn ObjSocioLn = new ClsSocioLn();
        public FrmBarcos()
        {
            InitializeComponent();
            CargarListaBarcos();
            ListarSocios();
        }

        private void FrmBarcos_Load(object sender, EventArgs e)
        {

        }

        private void ListarSocios()
        {
            ClsSocio ObjSocio = new ClsSocio();
            ObjSocioLn.Index(ref ObjSocio);
            cmbSocio.DataSource= ObjSocio.DtResultados;
            cmbSocio.DisplayMember = "Nombre";
            cmbSocio.ValueMember = "IdSocio";
        }

        private void CargarListaBarcos()
        {
            ObjBarco = new ClsBarco();
            ObjBarcoLn.Index(ref ObjBarco);
            if (ObjBarco.MensajeError == null)
            {
                dgvBarcos.DataSource = ObjBarco.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjBarco.MensajeError, "Error Barcos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmar eliminacion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ObjBarco = new ClsBarco()
                {
                    Nro_Matricula = txtNroMatricula.Text,
                };
                ObjBarcoLn.Delete(ref ObjBarco);
                if (ObjBarco.MensajeError == null)
                {
                    MessageBox.Show("El barco: " + ObjBarco.ValorScalar + " fue ELIMINADO correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaBarcos();
                }
                else
                {
                    MessageBox.Show(ObjBarco.MensajeError, "Error Barcos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtNroMatricula.Text = "";
                txtNomBarco.Text = "";
                txtNroAmarre.Text = "";
                txtVlrCuota.Text = "";
                
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjBarco = new ClsBarco()
            {

                Nro_Matricula = txtNroMatricula.Text,
                Nombre = txtNomBarco.Text,
                NroAmarre = txtNroAmarre.Text,
                VlrCuota = Convert.ToInt32(txtVlrCuota.Text),
                
            };
            ObjBarcoLn.Update(ref ObjBarco);
            if (ObjBarco.MensajeError == null)
            {
                MessageBox.Show("El barco: " + ObjBarco.ValorScalar + " fue actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaBarcos();
            }
            else
            {
                MessageBox.Show(ObjBarco.MensajeError, "Error Barcos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNroMatricula.Text = "";
            txtNomBarco.Text = "";
            txtNroAmarre.Text = "";
            txtVlrCuota.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjBarco = new ClsBarco()
            {
                Nro_Matricula = txtNroMatricula.Text,
                Nombre = txtNomBarco.Text,
                NroAmarre = txtNroAmarre.Text,
                VlrCuota = Convert.ToInt32(txtVlrCuota.Text),
                IdSocio = cmbSocio.SelectedValue.ToString(),
            };
            ObjBarcoLn.Create(ref ObjBarco);
            if (ObjBarco.MensajeError == null)
            {
                MessageBox.Show("El socio: " + ObjBarco.ValorScalar + " fue agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaBarcos();
            }
            else
            {
                MessageBox.Show(ObjBarco.MensajeError, "Error Socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNroMatricula.Text = "";
            txtNomBarco.Text = "";
            txtNroAmarre.Text = "";
            txtVlrCuota.Text = "";
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

        private void dgvBarcos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBarcos.Columns[e.ColumnIndex].Name == "Editar")
            {
                ObjBarco = new ClsBarco()
                {
                    Nro_Matricula = dgvBarcos.Rows[e.RowIndex].Cells["nroMatricula"].Value.ToString()

                };
                ObjBarcoLn.Read(ref ObjBarco);

                txtNroMatricula.Text = ObjBarco.Nro_Matricula;
                txtNomBarco.Text = ObjBarco.Nombre;
                txtNroAmarre.Text = ObjBarco.NroAmarre;
                txtVlrCuota.Text = ObjBarco.VlrCuota.ToString();
                                
            }
        }
    }
}
