using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsReservacion
    {
        private int idReservacion;
        private int? idCliente; // NULL si es cliente anónimo
        private int idEmpleado; // Siempre gestionado por empleados
        private int idMesa;
        private DateTime fechaReservacion;
        private bool clienteAnonimo; // 'Pendiente', 'Confirmada', 'Cancelada'

        // Atributos para el manejo de la base de datos
        private string mensajeError;
        private string valorScalar;
        private DataTable dtResultados;

        public ClsReservacion() { }

        public ClsReservacion(int idReservacion, int? idCliente, int idEmpleado, int idMesa, DateTime fechaReservacion, bool clienteAnonimo)
        {
            this.IdReservacion = idReservacion;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.IdMesa = idMesa;
            this.FechaReservacion = fechaReservacion;
            this.ClienteAnonimo = clienteAnonimo;
        }

        public int IdReservacion { get => idReservacion; set => idReservacion = value; }
        public int? IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }
        public DateTime FechaReservacion { get => fechaReservacion; set => fechaReservacion = value; }
        public bool ClienteAnonimo { get => clienteAnonimo; set => clienteAnonimo = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }

}
