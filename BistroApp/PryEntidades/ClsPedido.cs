using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsPedido
    {
        private int idPedido;
        private int? idCliente; // Puede ser null para clientes no registrados
        private int? idEmpleado; // Puede ser null si no se asigna empleado
        private int? idMesa; //futura aplicacion domicilios
        private DateTime fechaPedido;
        private string modoPedido; // 'En Restaurante', 'Domicilio'
        

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsPedido() { }

        public ClsPedido(int idPedido, int? idCliente, int? idEmpleado, int? idMesa, DateTime fechaPedido, string modoPedido)
        {
            this.IdPedido = idPedido;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.IdMesa = idMesa;
            this.FechaPedido = fechaPedido;
            this.ModoPedido = modoPedido;
        }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int? IdCliente { get => idCliente; set => idCliente = value; }
        public int? IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int? IdMesa { get => idMesa; set => idMesa = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public string ModoPedido { get => modoPedido; set => modoPedido = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }



}
