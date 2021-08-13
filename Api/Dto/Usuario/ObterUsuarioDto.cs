using Dominio.Enum;
using System;

namespace Api.Dto.Usuario
{
    public class ObterUsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnumRole Role { get; set; }
        public bool Excluido { get; set; }
    }
}
