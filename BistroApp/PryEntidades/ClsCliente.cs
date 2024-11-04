using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsCliente
    {
        private string idCliente;
        private string nombre;
        private string apellido;
        private string telefono;
        private string correo;
        private string direccion;
    
        //Atributos para el manejo de la base de datos
        private string mensajeError; 
        private string valorScalar;
        private DataTable dtResultados;

        public ClsCliente() { 
        
        }

        public ClsCliente(string idCliente, string nombre, string apellido, string telefono, string correo, string direccion)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;

        }

        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
