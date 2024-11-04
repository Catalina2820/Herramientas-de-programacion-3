using PryAccesoDatos;
using PryEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryLogicaNegocio
{
    public class ClsEmpleadoLn
    {
        #region Variables Privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        public void Index(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Index]",
                Scalar = false,
            };
            Ejecutar(ref objEmpleado);
        }

        private void Ejecutar(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if (ObjDataBase.Scalar)
                {
                    objEmpleado.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objEmpleado.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if (objEmpleado.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objEmpleado.DtResultados.Rows)
                        {
                            objEmpleado.Nombre = item["nombre"].ToString();
                            objEmpleado.Apellido = item["apellido"].ToString();
                            objEmpleado.Puesto = item["puesto"].ToString();
                            objEmpleado.Telefono = item["telefono"].ToString();
                            objEmpleado.Correo = item["correo"].ToString();
                        }
                    }
                }
            }
            else
            {
                objEmpleado.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }


        #region CRUD Empleado
        public void Create(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdEmpleado", "16", objEmpleado.IdEmpleado);
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objEmpleado.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objEmpleado.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Puesto", "16", objEmpleado.Puesto);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objEmpleado.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objEmpleado.Correo);
            Ejecutar(ref objEmpleado);
        }

        public void Update(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdEmpleado", "16", objEmpleado.IdEmpleado);
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objEmpleado.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objEmpleado.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Puesto", "16", objEmpleado.Puesto);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objEmpleado.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objEmpleado.Correo);
            Ejecutar(ref objEmpleado);
        }

        public void Delete(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdEmpleado", "16", objEmpleado.IdEmpleado);
            Ejecutar(ref objEmpleado);
        }


        public void Read(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objEmpleado.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objEmpleado.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Puesto", "16", objEmpleado.Puesto);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objEmpleado.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "16", objEmpleado.Correo);
            Ejecutar(ref objEmpleado);
        }

        public void Buscar(ref ClsEmpleado objEmpleado)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Empleado",
                NombreSP = "[SP_Empleado_Buscar]",
                Scalar = false,
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdEmpleado", "10", objEmpleado.IdEmpleado);
            Ejecutar(ref objEmpleado);
        }

        #endregion
    }
}
