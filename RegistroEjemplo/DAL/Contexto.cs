using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RegistroEjemplo.Entidades;
namespace RegistroEjemplo.DAL

{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set;}

        public Contexto() : base("ConStr") { }

    

    }
}
