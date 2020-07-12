using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace DTO
{
    public abstract class DAOBase<tEntity> where tEntity : class, new()
    {
        //select lista
        virtual public List<tEntity> GetAll(ref string error)
        {
            error = string.Empty;
            List<tEntity> emptyCollection = new List<tEntity>();
            try
            {
                List<tEntity> lstResult = new List<tEntity>();

                using (workspaceEntities ctx = new workspaceEntities())
                {
                    lstResult = ctx.Set<tEntity>().Select(item => item).ToList();
                }

                return lstResult;
            }
            catch (Exception e)
            {
                error = e.Message;

                return emptyCollection;
            }
        }

        //insert// Códigos de error
        virtual public bool Insertar(ref string error, tEntity item)
        {
            error = string.Empty;

            try
            {
                using (workspaceEntities ctx = new workspaceEntities())
                {
                    ctx.Entry(item).State = EntityState.Added;
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                error = e.Message;

                return false;
            }
        }

        // actualizar
        virtual public bool Actualizar(ref string error, tEntity item)
        {
            int result = -1;
            error = string.Empty;

            try
            {
                using (workspaceEntities ctx = new workspaceEntities())
                {
                    // puede insertar registros relacionados (no actualizarlos)
                    ctx.Entry(item).State = EntityState.Modified;
                    result = ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                error = e.Message;

                return false;
            }

        }


        // Borrar
        virtual public bool Delete(ref string error, tEntity item)
        {
            error = string.Empty;

            try
            {
                using (workspaceEntities ctx = new workspaceEntities())
                {
                    ctx.Entry(item).State = EntityState.Deleted;

                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                error = e.Message;

                return false;
            }

        }

        public static bool Truncate(ref string error, string nombreTabla)
        {
            error = string.Empty;

            try
            {
                using (workspaceEntities ctx = new workspaceEntities())
                {
                    ctx.Database.ExecuteSqlCommand(string.Format("TRUNCATE TABLE {0}", nombreTabla));
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                error = e.Message;                

                return false;
            }
        }
    }
}