using PryAccesoDatos;
using PryEntidades;
using System;
using System.Data;

namespace PryLogicaNegocio
{
    public class ClsPatronesLn
    {
        #region VariablePrivada
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region MetodoIndex
        public void Index(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Patrones",
                NombreSP = "[SP_Patrones_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjPatrones);
        }

        #endregion

        private void Ejecutar(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null) //No hay error
            {
                if (ObjDataBase.Scalar)
                {
                    ObjPatrones.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjPatrones.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjPatrones.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjPatrones.DtResultados.Rows)
                        {
                            ObjPatrones.IdPatron = item["idPatron"].ToString();
                            ObjPatrones.NombrePatron = item["nombrePatron"].ToString();
                            ObjPatrones.FechaNacPatron = Convert.ToDateTime(item["fechaNacPatron"].ToString());
                            ObjPatrones.CelPatron = item["celPatron"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjPatrones.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }

        #region  MetodosCrud
        public void Create(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Patrones",
                NombreSP = "[SP_Patrones_Create]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjPatrones.IdPatron);
            ObjDataBase.DtParametros.Rows.Add(@"@NombrePatron", "16", ObjPatrones.NombrePatron);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaNacPatron", "11", ObjPatrones.FechaNacPatron);
            ObjDataBase.DtParametros.Rows.Add(@"@CelPatron", "16", ObjPatrones.CelPatron);

            Ejecutar(ref ObjPatrones);
        }

        public void Update(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Patrones",
                NombreSP = "[SP_Patrones_Update]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjPatrones.IdPatron);
            ObjDataBase.DtParametros.Rows.Add(@"@NombrePatron", "16", ObjPatrones.NombrePatron);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaNacPatron", "11", ObjPatrones.FechaNacPatron);
            ObjDataBase.DtParametros.Rows.Add(@"@CelPatron", "16", ObjPatrones.CelPatron);

            Ejecutar(ref ObjPatrones);
        }

        public void Delete(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Patrones",
                NombreSP = "[SP_Patrones_Delete]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjPatrones.IdPatron);
            Ejecutar(ref ObjPatrones);
        }

        public void Read(ref ClsPatrones ObjPatrones)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Patrones",
                NombreSP = "[SP_Patrones_Read]",
                Scalar = false

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjPatrones.IdPatron);

            Ejecutar(ref ObjPatrones);
        }
        #endregion
    }
}
