using System;
using System.Collections.Generic;

namespace SistemaVotacionAutomatizada.Models
{
    public partial class CandidatoPartido
    {
        public int IdCandidato { get; set; }
        public int IdPartidos { get; set; }

        public virtual Candidatos IdCandidatosNavigation { get; set; }
        public virtual Partidos IdPartidosNavigation { get; set; }
    }
}
