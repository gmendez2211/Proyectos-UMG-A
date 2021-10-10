using EjercicioSeccionA.Connection;
using EjercicioSeccionA.Models;
using EjercicioSeccionA.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Repository
{
    public class PersonaRepository : iPersonaRepository

    {
        private readonly Conn _db;

        public PersonaRepository(Conn db)  //Contructor de la clase
        {
            _db = db;
        }

        public bool ActualizarPersona(PersonaModel persona)
        {
            _db.tbl_personas.Update(persona);
            return GuardarPersona();
        }

        public bool BorrarPersona(PersonaModel persona)
        {
            _db.tbl_personas.Remove(persona);
            return GuardarPersona();
        }

        public bool CrearPersona(PersonaModel persona)
        {
            _db.tbl_personas.Add(persona);
            return GuardarPersona();
        }

        public PersonaModel GetPersona(int nCodigoPersona)
        {
            return _db.tbl_personas.FirstOrDefault(p => p.CodigoPersona == nCodigoPersona);
        }

        public ICollection<PersonaModel> GetPersonaModels()
        {
            return _db.tbl_personas.OrderBy(p => p.ApellidoPersona).ToList();
        }

        public bool GuardarPersona()
        {
            return _db.SaveChanges() >= 0 ? true : false;

        }
    }
}
