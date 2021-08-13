using System;

namespace Api.Dto.Usuario
{
    public class ObterUsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Role { get; set; }
        public bool Excluido { get; set; }
    }
}
