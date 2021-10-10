using AutoMapper;
using EjercicioSeccionA.Repository.iRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Controllers
{
    [Route("api/Persona")]
    [ApiController]
    public class PersonaControllerAPI : Controller
    {
        private readonly iPersonaRepository _ctopersonas;
        private readonly IMapper _mapper;

        //Constructor
        public PersonaControllerAPI(iPersonaRepository ctoPersonas,  IMapper mapper)
        {
            _ctopersonas = ctoPersonas;
            _mapper = mapper;
        }
    }
}
