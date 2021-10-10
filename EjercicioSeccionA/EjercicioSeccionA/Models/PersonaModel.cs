using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioSeccionA.Models
{
    public class PersonaModel
    {
        //Atributos de mi clase
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Para genear un auto incrementable en la base de datos (secuencial)
        [Display(Name = "Código de Persona")]
        public int CodigoPersona { get; set; }

        [Required(ErrorMessage = "El campo nombre persona es obligatorio")]                         //Para hacer obligatorio en campo en el formulario
        [Column(TypeName ="varchar(35)")]  //Defino el tipo de dato que utilizará en base de datos
        [Display(Name ="Nombre de Persona")] //Personalizar la etiqueta en el formulario
        public string NombrePersona { get; set; }
        [Required(ErrorMessage = "El campo apellido persona es obligatorio")]
        [Column(TypeName ="varchar(35)")]
        [Display(Name ="Apellido de Persona")]
        public string ApellidoPersona { get; set; }

        [Required(ErrorMessage = "El campo edad  es obligatorio")]
        [Column(TypeName = "int")]
        [Display(Name = "Edad de Persona")]
        public int EdadPersona { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Display(Name = "Estado de Persona")]
        public string EstadoPersona { get; set; } = "ACT";
     }
}
