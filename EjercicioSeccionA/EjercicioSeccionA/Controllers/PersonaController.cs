using EjercicioSeccionA.Connection;
using EjercicioSeccionA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly Conn _context;

        public PersonaController(Conn context)
        {
            _context = context;  
        }

        public IActionResult Personas()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_personas.ToListAsync());  //Lista registros de la tabla tbl_personas.
        }
        [HttpPost]
        public async Task<IActionResult> Personas([Bind("CodigoPersona, NombrePersona, ApellidoPersona, EdadPersona, EstadoPersona")] PersonaModel personamodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personamodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personamodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaPersona(string id) {

            if (id == null) {
                return NotFound();
            }
            var Datos = await _context.tbl_personas
                .FirstOrDefaultAsync(a => a.CodigoPersona == int.Parse(id));
            return View(Datos);        
        }

        public async Task<IActionResult> EditaPersona(string id) {
            int nCodigoPersona;
            if (id == null) {
                return NotFound();
            }

            nCodigoPersona = int.Parse(id);
            var Datos = await _context.tbl_personas.FindAsync(nCodigoPersona);

            if (Datos == null) {
                return NotFound();
            }
            return View(Datos);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditaPersona(string id,[Bind("CodigoPersona,NombrePersona, ApellidoPersona, EdadPersona")] PersonaModel personamodel)
        {

            if (id == null) {
                return NotFound();
            }

            if (ModelState.IsValid)
            try
            {
                    _context.Update(personamodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaPersona(personamodel.CodigoPersona.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }

        private bool BuscaPersona(string id)
        {
            return _context.tbl_personas.Any(e => e.CodigoPersona.ToString() == id);
        }
    }

 }
