using PryAccesoDatos;
using PryEntidades;
using System;
using System.Data;

namespace PryLogicaNegocio
{
    public class ClsSocioLn
    {
        #region VariablePrivada

        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region MetodoIndex
        public void Index(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjSocio);
        }

       /* public DataTable ListarSocio(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjSocio);
        }*/

        #endregion

        private void Ejecutar(ref ClsSocio ObjSocio)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null) //No hay error
            {
                if (ObjDataBase.Scalar)
                {
                    ObjSocio.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjSocio.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjSocio.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjSocio.DtResultados.Rows)
                        {
                            ObjSocio.Identificacion = item["IdSocio"].ToString();
                            ObjSocio.Nombre = item["Nombre"].ToString();
                            ObjSocio.FechaNacim = Convert.ToDateTime(item["FechaNac"].ToString());
                            ObjSocio.Celular = item["Celular"].ToString();
                            ObjSocio.Email = item["Email"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjSocio.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }



        #region  MetodosCrud
        public void Create(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Create]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjSocio.Identificacion);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreS", "16", ObjSocio.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaN", "11", ObjSocio.FechaNacim);
            ObjDataBase.DtParametros.Rows.Add(@"@celular", "16", ObjSocio.Celular);
            ObjDataBase.DtParametros.Rows.Add(@"@email", "16", ObjSocio.Email);

            Ejecutar(ref ObjSocio);
        }

        public void Update(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Update]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjSocio.Identificacion);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreS", "16", ObjSocio.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaN", "11", ObjSocio.FechaNacim);
            ObjDataBase.DtParametros.Rows.Add(@"@Celular", "16", ObjSocio.Celular);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "16", ObjSocio.Email);

            Ejecutar(ref ObjSocio);
        }

        public void Delete(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Delete]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjSocio.Identificacion);
            Ejecutar(ref ObjSocio);
        }

        public void Read(ref ClsSocio ObjSocio)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Socios",
                NombreSP = "[SP_Socios_Read]",
                Scalar = false

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjSocio.Identificacion);

            Ejecutar(ref ObjSocio);
        }
        #endregion

    }
}
