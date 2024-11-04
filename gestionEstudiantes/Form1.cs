namespace gestionEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private List<Estudiante> estudiantes = new List<Estudiante>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int matricula = Convert.ToInt32(txtMatricula.Text);
            string carrera = cbxCarrera.Text;
            double promedio = Convert.ToDouble(txtPromedio.Text);

            Estudiante estudiante = new Estudiante(nombre, matricula, carrera, promedio);
            estudiantes.Add(estudiante);

            MessageBox.Show("Estudiante agregado exitosamente.");
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(txtMatricula.Text);
            bool encontrado = false;
            Estudiante alumno = new();

            for (int i = 0; i < estudiantes.Count; i++)
            {
                if (estudiantes[i].Matricula == matricula)
                {
                    alumno = estudiantes[i];
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                txtNombre.Text = alumno.Nombre;
                cbxCarrera.Text = alumno.Carrera;
                txtPromedio.Text = Convert.ToString(alumno.Promedio);
                txtValorCredito.Text = Convert.ToString(alumno.ObtenerValorCredito());
                alumno.ConsultarBeca();
            } else
            {
                MessageBox.Show("El estudiante no se encuentra registrado");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}