using SistemaVotacionAutomatizada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVotacionAutomatizada.DTO
{
    public class EleccionesDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<VotosElecciones> VotosElecciones { get; set; }
    }
}
