using Microsoft.EntityFrameworkCore;
using Registro_Prestamo.DAL;
using Registro_Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Registro_Prestamo.BLL
{
    class MorasBLL
    {
        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.MoraId))//si no existe insertamos
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        private static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Moras.Add(mora);
                paso = contexto.SaveChanges() > 0;
                Prestamos prestamo;
                List<MorasDetalle> detalle = mora.Detalle;
                foreach(MorasDetalle m in detalle)
                {
                    prestamo = PrestamoBLL.Buscar(m.PrestamoId);
                    prestamo.Mora += m.Total;
                    PrestamoBLL.Guardar(prestamo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId={mora.MoraId}");
                foreach (var item in mora.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                List<MorasDetalle> viejos = Buscar(mora.MoraId).Detalle;
                Prestamos prestamo;
                foreach (MorasDetalle m in viejos)
                {
                    prestamo = PrestamoBLL.Buscar(m.PrestamoId);
                    prestamo.Mora -= m.Total;
                }

                List<MorasDetalle> nuevo = Buscar(mora.MoraId).Detalle;
                foreach (MorasDetalle m in nuevo)
                {
                    prestamo = PrestamoBLL.Buscar(m.PrestamoId);
                    prestamo.Mora -= m.Total;
                }

                contexto.Entry(mora).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var mora = MorasBLL.Buscar(id);

                if (mora != null)
                {
                    contexto.Moras.Remove(mora); 
                    paso = contexto.SaveChanges() > 0;

                    Prestamos prestamo;
                    List<MorasDetalle> detalle = mora.Detalle;
                    foreach (MorasDetalle m in detalle)
                    {
                        prestamo = PrestamoBLL.Buscar(m.PrestamoId);
                        prestamo.Mora -= m.Total;
                        PrestamoBLL.Guardar(prestamo);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Moras Buscar(int id)
        {
            Moras mora = new Moras();
            Contexto contexto = new Contexto();

            try
            {
                mora = contexto.Moras.Include(x => x.Detalle)
                    .Where(x => x.MoraId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return mora;
        }

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> Lista = new List<Moras>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Moras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Moras.Any(e => e.MoraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
