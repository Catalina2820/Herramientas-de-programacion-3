using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsBarco
    {
        private string nro_Matricula;
        private string nombre;
        private string nroAmarre;
        private double vlrCuota;
        private string idSocio;

        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        public ClsBarco() { }
        public ClsBarco(string nro_Matricula, string nombre, string nroAmarre, double vlrCuota, string idSocio)
        {
            this.nro_Matricula = nro_Matricula;
            this.nombre = nombre;
            this.nroAmarre = nroAmarre;
            this.vlrCuota = vlrCuota;
            this.idSocio = idSocio;
        }

        public string Nro_Matricula { get => nro_Matricula; set => nro_Matricula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string NroAmarre { get => nroAmarre; set => nroAmarre = value; }
        public double VlrCuota { get => vlrCuota; set => vlrCuota = value; }
        public string IdSocio { get => idSocio; set => idSocio = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
