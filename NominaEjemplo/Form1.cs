namespace NominaEjemplo
{
    public partial class Form1 : Form
    {
        Empleado trabajador = new Empleado();
        DialogResult result;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Valor_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            trabajador.Nombre = txt_Nombre.Text;
            trabajador.Cargo = cbx_Cargo.SelectedText;
            txt_Valor.Text = trabajador.ValorHora.ToString();
            trabajador.Cantidad = Convert.ToInt32(txt_Cantidad.Text);
            MessageBox.Show("Se guardó la información", "Información");
        }

        private void cbx_Cargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Cargo.SelectedItem.Equals("Auxiliar"))
            {
                trabajador.ValorHora = 25000;
            }
            else if (cbx_Cargo.SelectedItem.Equals("Coordinador"))
            {
                trabajador.ValorHora = 58000;
            }
            else
            {
                trabajador.ValorHora = 88000;
            }
            txt_Valor.Text = trabajador.ValorHora.ToString();
        }

        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            txt_Total.Text = trabajador.CalcularNomina().ToString();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Está seguro de salir?", "Consulta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}