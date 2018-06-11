using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEjemplo.Entidades;
using RegistroEjemplo.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RegistroEjemplo.BLL
{
    public class PersonasBLL
    {
        /// <summary>
        /// Permite guardar una entidad en la base de datos.
        /// </summary>
        /// <param="persona">una instancia de Persona.</param>
        /// <return>Retorna true si guardo y false si fallo</return>
        
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            ///Creamos una instancia de Contexto para poder conectar a la base de datos.
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Persona.Add(persona)!= null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        /// <summary>
        /// Permite Modificar una entidad de la base de datos.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>retorna true si modifico y false si fallo.</returns>
        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        /// <summary>
        /// Permite eliminar una entidad de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna true si elimino y false si fallo</returns>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Persona persona = contexto.Persona.Find(id);
                contexto.Persona.Remove(persona);
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Persona Buscar(int id)
        {
            
            Contexto contexto = new Contexto();
            Persona persona = new Persona();
            try
            {
               persona = contexto.Persona.Find(id);
               contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }
        /// <summary>
        /// Permite extraer una lista de personas de la base de datos.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Retorna una lista de personas</returns>
        public static List<Persona> GetList(Expression<Func<Persona, bool>> expression)
        {
            List<Persona> personas = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                personas = contexto.Persona.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return personas;

        }




        
      
    }
}
