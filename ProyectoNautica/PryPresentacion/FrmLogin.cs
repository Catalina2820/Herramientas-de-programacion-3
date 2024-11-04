using MaterialSkin.Controls;
using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Windows.Forms;


namespace PryPresentacion
{
    public partial class FrmLogin : MaterialForm
    {
        private ClsUsuario objUsuario = null;
        private readonly ClsUsuarioLn objUsuarioLn = new ClsUsuarioLn();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            objUsuario = new ClsUsuario()
            {
                Email = txtEmail.Text,
                Password = txtContrasena.Text,
            };
            objUsuarioLn.Validar(ref objUsuario);

            if (objUsuario.MensajeError == null)
            {
                if (objUsuario.DtResultados.Rows.Count > 0)
                {
                    MessageBox.Show("Bienvenido a Cruceiro do neymar " + objUsuario.Email, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMenu frmMenu = new FrmMenu();
                    frmMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(objUsuario.MensajeError, "Usuario y/o Contraseña incorrecta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error DB " + objUsuario.MensajeError);
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
