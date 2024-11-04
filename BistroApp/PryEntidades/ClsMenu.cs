using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsMenu
    {
        private string idPlato;
        private string nombrePlato;
        private string descripcion;
        private decimal precio;
        private bool disponibilidad;

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsMenu() { }

        public ClsMenu(string idPlato, string nombrePlato, string descripcion, decimal precio, bool disponibilidad)
        {
            this.IdPlato = idPlato;
            this.NombrePlato = nombrePlato;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Disponibilidad = disponibilidad;
        }

        public string IdPlato { get => idPlato; set => idPlato = value; }
        public string NombrePlato { get => nombrePlato; set => nombrePlato = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public bool Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }

}
