using PryAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PryEntidades;

namespace PryLogicaNegocio
{
    public class ClsMenuLn
    {
        #region VariablePrivada
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region MetodoIndex
        public void Index(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjMenu);
        }

        #endregion

        private void Ejecutar(ref ClsMenu ObjMenu)
        {
            ObjDataBase.CRUD(ref ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null) //No hay error
            {
                if (ObjDataBase.Scalar)
                {
                    ObjMenu.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjMenu.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjMenu.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjMenu.DtResultados.Rows)
                        {
                            ObjMenu.NombrePlato = item["NombrePlato"].ToString();
                            ObjMenu.Descripcion = item["Descripcion"].ToString();
                            ObjMenu.Precio = Convert.ToDecimal(item["Precio"].ToString());
                            ObjMenu.Disponibilidad = bool.Parse(item["Disponibilidad"].ToString());
                        }
                    }
                }
            }
            else
            {
                ObjMenu.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }


        #region  MetodosCrud
        public void Create(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Create]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPlato", "16", ObjMenu.IdPlato);
            ObjDataBase.DtParametros.Rows.Add(@"@NombrePlato", "16", ObjMenu.NombrePlato);
            ObjDataBase.DtParametros.Rows.Add(@"@Descripcion", "16", ObjMenu.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@Precio", "16", ObjMenu.Precio);
            ObjDataBase.DtParametros.Rows.Add(@"Disponibilidad", "1", ObjMenu.Disponibilidad);

            Ejecutar(ref ObjMenu);
        }

        public void Update(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Update]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPlato", "16", ObjMenu.IdPlato);
            ObjDataBase.DtParametros.Rows.Add(@"@NombrePlato", "16", ObjMenu.NombrePlato);
            ObjDataBase.DtParametros.Rows.Add(@"@Descripcion", "16", ObjMenu.Descripcion);
            ObjDataBase.DtParametros.Rows.Add(@"@Precio", "16", ObjMenu.Precio);
            ObjDataBase.DtParametros.Rows.Add(@"Disponibilidad", "1", ObjMenu.Disponibilidad);

            Ejecutar(ref ObjMenu);
        }

        public void Delete(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Delete]",
                Scalar = true

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPlato", "16", ObjMenu.IdPlato);
            Ejecutar(ref ObjMenu);
        }

        public void Read(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Read]",
                Scalar = false

            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdPlato", "16", ObjMenu.IdPlato);

            Ejecutar(ref ObjMenu);
        }


        public void Buscar(ref ClsMenu ObjMenu)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Menu",
                NombreSP = "[SP_Menu_Buscar]",
                Scalar = false,
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdPlato", "16", ObjMenu.IdPlato);
            Ejecutar(ref ObjMenu);
        }

        #endregion

    }
}
