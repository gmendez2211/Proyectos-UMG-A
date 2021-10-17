using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Models.DTOs
{
    public class PersonaSaveDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Para genear un auto incrementable en la base de datos (secuencial)
        [Display(Name = "Código de Persona")]
        public int CodigoPersona { get; set; }
        public string NombrePersona { get; set; }

        public string ApellidoPersona { get; set; }

        public int EdadPersona { get; set; }
    }
}
