﻿using SistemaVotacionAutomatizada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SistemaVotacionAutomatizada.DTO
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigurePartidos();
        }
        private void ConfigurePartidos() {
            CreateMap<PartidosDTO, Partidos>();
            CreateMap<Partidos, PartidosDTO>().ForMember(dest => dest.Logo, opt => opt.Ignore());
            CreateMap<CandidatosDTO, Candidatos>();
            CreateMap<Candidatos, CandidatosDTO>().ForMember(dest => dest.PhotoProfile, opt => opt.Ignore());
        }

    }
}
