using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1029_Turibus.Models;
using System.Security.Cryptography;
using System.Text;

namespace _1029_Turibus.Controllers
{
    public class AccesoController : Controller
    {
        static string cadena = "Data Source=(B6-603-4917); Initial Catalog=bd_Turybus; Integrated Security=true";
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(texto));
                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario)
        {
            bool registrado;
            string mensaje;

            if (oUsuario.clave == oUsuario.confirmarClave)
            {
                oUsuario.clave = ConvertirSha256(oUsuario.clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            return View();
        }
    }
}