using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EjercicioSeccionA.Models;
using EjercicioSeccionA.Models.DTOs;

namespace EjercicioSeccionA.Mapper
{
    public class PersonaMappers:Profile
    {
        public PersonaMappers()
        {
            CreateMap<PersonaModel, PersonaDto>().ReverseMap();
            CreateMap<PersonaModel, PersonaSaveDto>().ReverseMap();
        }

    }
}
