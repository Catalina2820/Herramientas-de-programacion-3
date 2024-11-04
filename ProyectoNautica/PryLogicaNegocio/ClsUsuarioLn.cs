using PryAccesoDatos;
using PryEntidades;
using System.Data;

namespace PryLogicaNegocio
{
    public class ClsUsuarioLn
    {
        #region Variables Privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        public void Index(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_Usuario_Index]",
                Scalar = false,
            };
            Ejecutar(ref objUsuario);
        }

        private void Ejecutar(ref ClsUsuario objUsuario)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if (ObjDataBase.Scalar)
                {
                    objUsuario.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objUsuario.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if (objUsuario.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objUsuario.DtResultados.Rows)
                        {
                            objUsuario.Email = item["email"].ToString();
                            objUsuario.Password = item["contrasena"].ToString();
                        }
                    }
                }
            }
            else
            {
                objUsuario.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }


        #region CRUD Usuario
        public void Create(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_Usuarios_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaP", "15", objUsuario.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreP", "15", objUsuario.Password);
            Ejecutar(ref objUsuario);
        }

        public void Update(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_Usuarios_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objUsuario.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Password", "15", objUsuario.Password);
            Ejecutar(ref objUsuario);
        }

        public void Delete(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_Usuario_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objUsuario.Email);
            Ejecutar(ref objUsuario);
        }


        public void Read(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_Usuarios_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objUsuario.Email);
            Ejecutar(ref objUsuario);
        }

        public void Validar(ref ClsUsuario objUsuario)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "tbl_usuario",
                NombreSP = "[dbo].[SP_ValidarUsuario]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@email", "15", objUsuario.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@contra", "15", objUsuario.Password);
            Ejecutar(ref objUsuario);
        }
        #endregion
    }
}

