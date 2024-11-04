using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsFactura
    {
        private int idfactura;
        private int idpedido;
        private DateTime fechaFactura;
        private decimal totalFactura;

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsFactura() { }

        public ClsFactura(int idfactura, int idpedido, DateTime fechaFactura, decimal totalFactura)
        {
            this.Idfactura = idfactura;
            this.Idpedido = idpedido;
            this.FechaFactura = fechaFactura;
            this.TotalFactura = totalFactura;
        }

        public int Idfactura { get => idfactura; set => idfactura = value; }
        public int Idpedido { get => idpedido; set => idpedido = value; }
        public DateTime FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public decimal TotalFactura { get => totalFactura; set => totalFactura = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }

}
