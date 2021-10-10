using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Models.DTOs
{
    public class PersonaDto
    {
        [Display(Name = "Nombre de Persona")] //Personalizar la etiqueta en el formulario
        public string NombrePersona { get; set; }
       
        [Display(Name = "Apellido de Persona")]
        public string ApellidoPersona { get; set; }

        [Display(Name = "Edad de Persona")]
        public int EdadPersona { get; set; }
    }
}
