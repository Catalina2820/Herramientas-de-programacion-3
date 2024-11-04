using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsSalidas
    {
        private string idSalida;
        private DateTime fechaSalida;
        private string destino;
        private string nroMatricula;
        private string idPatron;

        //Atributos Para la base de datos 
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        public ClsSalidas()
        {

        }

        public ClsSalidas(string idSalida, DateTime fechaSalida, string destino, string nroMatricula, string idPatron, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            this.IdSalida = idSalida;
            this.FechaSalida = fechaSalida;
            this.Destino = destino;
            this.NroMatricula = nroMatricula;
            this.IdPatron = idPatron;
            this.MensajeError = mensajeError;
            this.ValorScalar = valorScalar;
            this.DtResultados = dtResultados;
        }

        public string IdSalida { get => idSalida; set => idSalida = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string Destino { get => destino; set => destino = value; }
        public string NroMatricula { get => nroMatricula; set => nroMatricula = value; }
        public string IdPatron { get => idPatron; set => idPatron = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
