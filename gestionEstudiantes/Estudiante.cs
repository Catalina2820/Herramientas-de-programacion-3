using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEstudiantes
{
    internal class Estudiante
    {
        //Atributos privados
        private string nombre, carrera;
        private int matricula;
        private double promedio;

        public Estudiante()
        {
        }

        public Estudiante(string nombre,
                          int matricula,
                          string carrera,
                          double promedio)
        {
            this.nombre = nombre;
            this.matricula = matricula;
            this.carrera = carrera;
            this.promedio = promedio;
        }

        //Atributos públicos
        public string Nombre { get => nombre; set => nombre = value; }
        public int Matricula { get => matricula; set => matricula = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public double Promedio { get => promedio; set => promedio = value; }

        public int ObtenerValorCredito()
        {
            switch (Carrera)
            {
                case "Ingeniería":
                    return 354000;
                case "Administración":
                    return 25100;
                case "Medicina":
                    return 587000;
                default:
                    return 0;
            }
        }

        public void ConsultarBeca()
        {
            if (Promedio > 4.5)
            {
                MessageBox.Show("El estudiante es apto para beca");
            }
            else
            {
                MessageBox.Show("El estudiante no es apto para beca");
            }
        }
    }
}
