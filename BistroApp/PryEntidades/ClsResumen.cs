using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsResumen
    {
        private int idResumen;
        private int idPedido; // Relaciona con Pedidos
        private int idPlato; // Relaciona con los platos del menú
        private int cantidad;
        private decimal precioUnitario;
        private string estado; // 'Pendiente', 'En Proceso', 'Terminado'

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsResumen() { }

        public ClsResumen(int idResumen, int idPedido, int idPlato, int cantidad, decimal precioUnitario, string estado)
        {
            this.IdResumen = idResumen;
            this.IdPedido = idPedido;
            this.IdPlato = idPlato;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Estado = estado;
        }

        public int IdResumen { get => idResumen; set => idResumen = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdPlato { get => idPlato; set => idPlato = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public string Estado { get => estado; set => estado = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }


}
