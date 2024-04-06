using System.ComponentModel.DataAnnotations;
namespace L01P02_2021_AP_650.Models{
    public class alumn
    {
        [Key]
        [Display (Name = "Id")]
        public int id { get; set; }
        [Display (Name = "Codigo")]
        [Required (ErrorMessage = "El codigo del estudiante no es opcional")]
        [StringLength(10, ErrorMessage = "El codigo no debe superar 10 caracteres!")]
        public string codigo { get; set; }    
        [Display (Name = "Nombres")]
        [Required (ErrorMessage = "El nombre del estudiante no es opcional")]
        [StringLength(50, ErrorMessage = "El nombre no debe superar 50 caracteres!")]
        public string nombre { get; set; }    
        [Display (Name = "Apellidos")]
        [Required (ErrorMessage = "Los apellidos del estudiante no son opcionales")]
        [StringLength(50, ErrorMessage = "El apellido no debe superar 50 caracteres!")]
        public string apellidos { get; set; }    
        [Display (Name = "DUI")]
        [Required (ErrorMessage = "El DUI del estudiante no es opcional")]
        [Range(10000000, 999999999, ErrorMessage ="Escriba bien el DUI!!!!")]
        public int? dui { get; set; }    
        [Range(0, 1, ErrorMessage ="Solo se admite 0 y 1")]
        public int? estado {get; set;}
    }
}