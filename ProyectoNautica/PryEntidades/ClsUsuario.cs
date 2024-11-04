using System.Data;

namespace PryEntidades
{
    public class ClsUsuario
    {
        #region AtributosPrivados
        private string email, password;

        // Atributos para la conxion de base datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;
        #endregion

        #region AtributosPublicos
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
        #endregion
    }
}
