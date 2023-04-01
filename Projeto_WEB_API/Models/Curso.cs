using System.ComponentModel.DataAnnotations;

namespace Projeto_WEB_API.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição do curso")]
        [StringLength(50)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a carga horária")]
        public int CargaHoraria { get; set; }
    }
}
