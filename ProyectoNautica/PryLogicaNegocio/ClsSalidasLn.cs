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
    public class ClsSalidasLn
    {
        #region VariablePrivada
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region MetodoIndex
        public void Index(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Salidas",
                NombreSP = "[SP_Salidas_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjSalidas);
        }
        #endregion

        private void Ejecutar(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null) //No hay error
            {
                if (ObjDataBase.Scalar)
                {
                    ObjSalidas.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjSalidas.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjSalidas.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjSalidas.DtResultados.Rows)
                        {
                            ObjSalidas.IdSalida = item["IdSalida"].ToString();
                            ObjSalidas.FechaSalida = Convert.ToDateTime(item["FechaSalida"].ToString());
                            ObjSalidas.Destino = item["Destino"].ToString();
                            ObjSalidas.NroMatricula = item["NroMatricula"].ToString();
                            ObjSalidas.IdPatron = item["IdPatron"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjSalidas.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }

        #region  MetodosCrud
        public void Create(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Salidas",
                NombreSP = "[SP_Salidas_Create]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSalida", "16", ObjSalidas.IdSalida);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaSalida", "11", ObjSalidas.FechaSalida);
            ObjDataBase.DtParametros.Rows.Add(@"@Destino", "16", ObjSalidas.Destino);
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjSalidas.NroMatricula);
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjSalidas.IdPatron);

            Ejecutar(ref ObjSalidas);
        }

        public void Update(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Salidas",
                NombreSP = "[SP_Salidas_Update]",
                Scalar = true

            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdSalida", "16", ObjSalidas.IdSalida);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaSalida", "11", ObjSalidas.FechaSalida);
            ObjDataBase.DtParametros.Rows.Add(@"@Destino", "16", ObjSalidas.Destino);
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjSalidas.NroMatricula);
            ObjDataBase.DtParametros.Rows.Add(@"@IdPatron", "16", ObjSalidas.IdPatron);

            Ejecutar(ref ObjSalidas);
        }

        public void Delete(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Salidas",
                NombreSP = "[SP_Salidas_Delete]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSalida", "16", ObjSalidas.IdSalida);
            Ejecutar(ref ObjSalidas);
        }

        public void Read(ref ClsSalidas ObjSalidas)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Salidas",
                NombreSP = "[SP_Salidas_Read]",
                Scalar = false

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdSalida", "16", ObjSalidas.IdSalida);

            Ejecutar(ref ObjSalidas);
        }
        #endregion
    }
}
