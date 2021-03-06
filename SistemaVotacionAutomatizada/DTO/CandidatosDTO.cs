﻿using Microsoft.AspNetCore.Http;
using SistemaVotacionAutomatizada.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVotacionAutomatizada.DTO
{
    public class CandidatosDTO
    {
        public CandidatosDTO()
        {
            VotosElecciones = new HashSet<VotosElecciones>();
        }

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IFormFile PhotoProfile { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int PartidoId { get; set; }

        [Required]
        public int PuestoElectivosId { get; set; }


        public virtual Partidos Partido { get; set; }
        public virtual PuestoElectivos PuestoElectivos { get; set; }
        public virtual ICollection<VotosElecciones> VotosElecciones { get; set; }
    }
}
