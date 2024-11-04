using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace PryPresentacion
{
    public partial class FrmMenu : MaterialForm
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSocio frmSocio = new FrmSocio();
            frmSocio.MdiParent = this;
            frmSocio.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void patronesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPatrones frmPatron = new FrmPatrones();
            frmPatron.MdiParent = this;
            frmPatron.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir del aplicativo?", "Confirmar salida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void barcosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBarcos frmbarco = new FrmBarcos();
            frmbarco.MdiParent = this;
            frmbarco.Show();
        }
    }
}
