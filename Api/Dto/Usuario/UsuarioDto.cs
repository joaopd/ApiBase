using Dominio.Entidades.Base;
using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Usuario
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "E-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail em Invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha é obrigatorio")]
        [ValidadorDeSenha]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirmar senha é obrigatorio")]
        [Compare(nameof(Senha), ErrorMessage = "Senha nao coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}
