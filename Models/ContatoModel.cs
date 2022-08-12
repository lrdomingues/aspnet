using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o número do contato")]
        [Phone(ErrorMessage = "O número informado não é válido")]
        [MaxLength(9)]
        public string Contato { get; set; }

    }
}
