using System;
using System.Data;

namespace PryEntidades
{
    public class ClsSocio
    {
        private string identificacion;
        private string nombre;
        private DateTime fechaNacim;
        private string celular;
        private string email;

        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        public ClsSocio() { }
        public ClsSocio(string identificacion, string nombre, DateTime fechaNacim, string celular, string email)
        {
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.FechaNacim = fechaNacim;
            this.Celular = celular;
            this.Email = email;
        }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacim { get => fechaNacim; set => fechaNacim = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
