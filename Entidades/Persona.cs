using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_Prestamo.Entidades
{
    public class Persona
    {
        [Key]
        public int  PersonaId { get; set; }
        public string Nombres { get; set; }
        public decimal Balance { get; set; }
    }
}
