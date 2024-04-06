using System.ComponentModel.DataAnnotations;
namespace L01P02_2021_AP_650.Models{
    public class mater
    {
        [Key]
        [Display (Name = "Id")]
        public int id { get; set; }
        [Display (Name = "Materia")]
        [Required (ErrorMessage = "El nombre de la materia no es opcional")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar 100 caracteres!")]
        public string materia { get; set; }
        [Display (Name = "Unidades Valorativas")]
        [Range(0, 10, ErrorMessage ="Los valores aceptados son entre 0 y 10!")]
        public int? unidades_valorativas {get; set;}
        [StringLength(1, ErrorMessage = "El estado no debe superar 1 caracter!")]
        public string estado {get; set;}
    }
}