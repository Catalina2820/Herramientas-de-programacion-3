using PryAccesoDatos;
using PryEntidades;
using System.Data;

namespace PryLogicaNegocio
{
    public class ClsClienteLn
    {
        #region Variables Privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        public void Index(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Index]",
                Scalar = false,
            };
            Ejecutar(ref objCliente);
        }

        private void Ejecutar(ref ClsCliente objCliente)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if (ObjDataBase.Scalar)
                {
                    objCliente.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objCliente.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if (objCliente.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objCliente.DtResultados.Rows)
                        {
                            objCliente.Nombre = item["nombre"].ToString();
                            objCliente.Apellido = item["apellido"].ToString();
                            objCliente.Telefono = item["telefono"].ToString();
                            objCliente.Correo = item["correo"].ToString();
                            objCliente.Direccion = item["Direccion"].ToString();
                        }
                    }
                }
            }
            else
            {
                objCliente.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }


        #region CRUD Cliente
        public void Create(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdCliente", "16", objCliente.IdCliente);
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objCliente.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objCliente.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objCliente.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objCliente.Correo);
            ObjDataBase.DtParametros.Rows.Add(@"@Direccion", "16", objCliente.Direccion);
            Ejecutar(ref objCliente);
        }

        public void Update(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdCliente", "16", objCliente.IdCliente);
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objCliente.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objCliente.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objCliente.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objCliente.Correo);
            ObjDataBase.DtParametros.Rows.Add(@"@Direccion", "16", objCliente.Direccion);
            Ejecutar(ref objCliente);
        }

        public void Delete(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdCliente", "16", objCliente.IdCliente);
            Ejecutar(ref objCliente);
        }


        public void Read(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objCliente.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objCliente.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objCliente.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objCliente.Correo);
            ObjDataBase.DtParametros.Rows.Add(@"@Direccion", "16", objCliente.Direccion);
            Ejecutar(ref objCliente);
        }

        public void Buscar(ref ClsCliente objCliente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Cliente",
                NombreSP = "[SP_Cliente_Buscar]",
                Scalar = false,
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdCliente", "16", objCliente.IdCliente);
            Ejecutar(ref objCliente);
        }

        #endregion
    }
}
