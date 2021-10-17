using AutoMapper;
using EjercicioSeccionA.Models;
using EjercicioSeccionA.Models.DTOs;
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
        public PersonaControllerAPI(iPersonaRepository ctoPersonas, IMapper mapper)
        {
            _ctopersonas = ctoPersonas;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaPersona()
        {
            var nListarPersonas = _ctopersonas.GetPersonaModels();
            //Aplicando Dto
            var nListarPersonasDto = new List<PersonaDto>();

            foreach (var nListar in nListarPersonas)
            {
                nListarPersonasDto.Add(_mapper.Map<PersonaDto>(nListar));
            }
            return Ok(nListarPersonasDto);
        }
        [HttpGet("{nCodigoPersona:int}", Name = "GetPersonaByCodigo")]
        public IActionResult GetPersonaByCodigo(int nCodigoPersona)
        {
            var ListarPersona = _ctopersonas.GetPersona(nCodigoPersona);
            if (ListarPersona == null)
            {
                NotFound();
            }
            var nRegistroPersonaDto = _mapper.Map<PersonaDto>(ListarPersona);
            return Ok(nRegistroPersonaDto);
        }
        [HttpPost]
        public IActionResult CreaPersona([FromBody] PersonaSaveDto personaDto)
        {
            if(personaDto == null)
            {
                return BadRequest(ModelState);
            }
            var persona = _mapper.Map<PersonaModel>(personaDto);

            if (!_ctopersonas.CrearPersona(persona))
            {
                ModelState.AddModelError("", $"Ocurrió un Error al grabar el registro { persona.CodigoPersona}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetPersonaByCodigo", new { nCodigoPersona = personaDto.CodigoPersona }, persona);
        }

    }
}
