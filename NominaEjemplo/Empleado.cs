using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaEjemplo
{
    internal class Empleado
    {
        private string nombre, cargo;
        private int cantidad, valorHora;

        public Empleado()
        {
        }

        public Empleado(string nombre,
                        string cargo,
                        int cantidad,
                        int valorHora)
        {
            this.nombre = nombre;
            this.cargo = cargo;
            this.cantidad = cantidad;
            this.valorHora = valorHora;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int ValorHora { get => valorHora; set => valorHora = value; }
        
        public int CalcularNomina()
        {
            int totalNomina;
            totalNomina = this.valorHora * this.cantidad;
            return totalNomina;
        }

    } 
}
