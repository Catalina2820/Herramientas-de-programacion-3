using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsMesa
    {
        private int idMesa;
        private string numero;
        private string capacidad;

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsMesa() {}

        public ClsMesa(int idMesa, string numero, string capacidad)
        {
            this.IdMesa = idMesa;
            this.Numero = numero;
            this.Capacidad = capacidad;
        }

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
