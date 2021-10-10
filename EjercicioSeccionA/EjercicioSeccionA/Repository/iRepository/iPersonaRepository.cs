using EjercicioSeccionA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Repository.iRepository
{
    interface iPersonaRepository
    {
        ICollection<PersonaModel> GetPersonaModels();  //Obtengo un listado completo de todas las personas
        PersonaModel GetPersona(int nCodigoPersona); //Obtengo a la persona según el código que le envíe.
        bool CrearPersona(PersonaModel persona); //Creo un registro en la base de datos con inf. de la persona
        bool ActualizarPersona(PersonaModel persona);//Actualiza un registro en la base de datos.
        bool BorrarPersona(PersonaModel persona);//Borra un registro en la tabla. DEBE CONSIDERAR QUE DEBEMOS REALIZAR BORRADO LÓGICO A TRAVÉS DE UN ESTADO DEL REGISTRO
        bool GuardarPersona(); //Guardar los datos en la BD.

    }
}
