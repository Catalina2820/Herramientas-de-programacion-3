using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1029_Turibus.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string confirmarClave { get; set; }

    }
}