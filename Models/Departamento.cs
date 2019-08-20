using System.ComponentModel.DataAnnotations;


namespace PRJ_MVC_CORE_ORACLE.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo é obrigatório")]
        [MaxLength(25, ErrorMessage = "O tamanho máximo de 50 caracteres!")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo de 5 caracteres!")]
        public string Descricao { get; set; }
        
    }
}
