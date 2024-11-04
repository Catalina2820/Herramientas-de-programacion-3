using System;
using System.Data;

namespace PryEntidades
{
    public class ClsPatrones
    {
        private string idPatron;
        private string nombrePatron;
        private DateTime fechaNacPatron;
        private string celPatron;

        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        public ClsPatrones() { }

        public ClsPatrones(string idPatron, string nombrePatron, DateTime fechaNacPatron, string celPatron)
        {
            this.idPatron = idPatron;
            this.nombrePatron = nombrePatron;
            this.fechaNacPatron = fechaNacPatron;
            this.celPatron = celPatron;
        }

        public string IdPatron { get => idPatron; set => idPatron = value; }
        public string NombrePatron { get => nombrePatron; set => nombrePatron = value; }
        public DateTime FechaNacPatron { get => fechaNacPatron; set => fechaNacPatron = value; }
        public string CelPatron { get => celPatron; set => celPatron = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
