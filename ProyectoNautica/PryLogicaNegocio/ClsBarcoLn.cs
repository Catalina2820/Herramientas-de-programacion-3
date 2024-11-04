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
    public class ClsBarcoLn
    {
        #region VariablePrivada

        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region MetodoIndex
        public void Index(ref ClsBarco ObjBarco)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Barcos",
                NombreSP = "[SP_Barcos_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjBarco);
        }

        #endregion

        private void Ejecutar(ref ClsBarco ObjBarco)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null) //No hay error
            {
                if (ObjDataBase.Scalar)
                {
                    ObjBarco.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjBarco.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjBarco.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjBarco.DtResultados.Rows)
                        {
                            ObjBarco.Nro_Matricula = item["nroMatricula"].ToString();
                            ObjBarco.Nombre = item["nombreBarco"].ToString();
                            ObjBarco.NroAmarre = item["nroAmarre"].ToString();
                            ObjBarco.VlrCuota = Convert.ToDouble(item["vlrCuota"].ToString());
                            ObjBarco.IdSocio = item["IdSocio"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjBarco.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }

        #region  MetodosCrud
        public void Create(ref ClsBarco ObjBarco)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Barcos",
                NombreSP = "[SP_Barcos_Create]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjBarco.Nro_Matricula);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreBarco", "16", ObjBarco.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@NroAmarre", "16", ObjBarco.NroAmarre);
            ObjDataBase.DtParametros.Rows.Add(@"@VlrCuota", "16", ObjBarco.VlrCuota);
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjBarco.IdSocio);

            Ejecutar(ref ObjBarco);
        }

        public void Update(ref ClsBarco ObjBarco)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Barcos",
                NombreSP = "[SP_Barcos_Update]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjBarco.Nro_Matricula);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreBarco", "16", ObjBarco.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@NroAmarre", "11", ObjBarco.NroAmarre);
            ObjDataBase.DtParametros.Rows.Add(@"@VlrCuota", "16", ObjBarco.VlrCuota);
            ObjDataBase.DtParametros.Rows.Add(@"@IdSocio", "16", ObjBarco.IdSocio);

            Ejecutar(ref ObjBarco);
        }

        public void Delete(ref ClsBarco ObjBarco)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Barcos",
                NombreSP = "[SP_Barcos_Delete]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjBarco.Nro_Matricula);
            Ejecutar(ref ObjBarco);
        }

        public void Read(ref ClsBarco ObjBarco)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Barcos",
                NombreSP = "[SP_Barcos_Read]",
                Scalar = false

            };
            ObjDataBase.DtParametros.Rows.Add(@"@NroMatricula", "16", ObjBarco.Nro_Matricula);

            Ejecutar(ref ObjBarco);
        }
        #endregion
    }
}
