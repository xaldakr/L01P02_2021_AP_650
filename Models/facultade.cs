using System.ComponentModel.DataAnnotations;
namespace L01P02_2021_AP_650.Models{
    public class facultade
    {
        [Key]
        [Display (Name = "Id")]
        public int id { get; set; }
        [Display (Name = "Facultad")]
        [Required (ErrorMessage = "El nombre de la facultad no es opcional")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar 100 caracteres!")]
        public string facultad { get; set; }    
    }
}