using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroEjemplo.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        
        public String Nombres { get; set; }
        public String Cedula { get; set;}
        public String Telefono { get; set;}
        public String Direccion { get; set;}

        public Persona()
        {
            PersonaId = 0;
            Nombres = String.Empty;
            Cedula = String.Empty;
            Telefono = String.Empty;
            Direccion = String.Empty;


        }


    }
}
