using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsEmpleado
    {
        private string idEmpleado;
        private string nombre;
        private string apellido;
        private string puesto; // 'Mesero', 'Cocinero', etc.
        private string telefono;
        private string correo;

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsEmpleado() { }

        public ClsEmpleado(string idEmpleado, string nombre, string apellido, string puesto, string telefono, string correo)
        {
            this.IdEmpleado = idEmpleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Puesto = puesto;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }

}
