using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Prestamo.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();
    }
}
