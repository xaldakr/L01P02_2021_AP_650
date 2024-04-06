using System.ComponentModel.DataAnnotations;
namespace L01P02_2021_AP_650.Models{
    public class depart
    {
        [Key]
        [Display (Name = "Id")]
        public int id { get; set; }
        [Display (Name = "Departamento")]
        [Required (ErrorMessage = "El nombre del departamento no es opcional")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar 100 caracteres!")]
        public string departamento { get; set; }    
    }
}