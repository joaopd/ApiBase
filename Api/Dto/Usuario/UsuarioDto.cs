using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto.Usuario
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
