using Api.Dto.Usuario;
using AutoMapper;
using CrossCutting.Config.Token;
using Dominio.Entidades;
using Dominio.Enum;
using Dominio.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/account")]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public AuthController(IUnitOfWork uow,
                              IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] UsuarioDto usuario)
        {
            Usuario usuarioMap = _mapper.Map<UsuarioDto, Usuario>(usuario);

            Usuario user = (await _uow.RepositorioUsuario.GetList(x => x.Nome == usuarioMap.Nome && x.Senha == usuarioMap.Senha)).FirstOrDefault();

            if (user == null)
            {
                return NotFound(new { message = "Usuario ou senha Invalidos" });
            }

            string token = TokenService.GenerateToken(user);
            return new
            {
                usuario = _mapper.Map<Usuario, ObterUsuarioDto>(usuarioMap),
                token = token
            };
        }

        [AllowAnonymous]
        [HttpPost("novo-usuario")]
        public async Task<ActionResult<dynamic>> NovoUsuario([FromBody] UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuarioExistente = (await _uow.RepositorioUsuario.GetList(x => x.Email == usuario.Email)).FirstOrDefault();

            if (usuarioExistente != null)
            {
                return NotFound(new { message = "Email ja cadastrado" });
            }

            Usuario user = new Usuario(usuario.Nome, usuario.Email, usuario.Senha, EnumRole.Usuario);

            Usuario novoUsuario = await _uow.RepositorioUsuario.Create(user);

            string token = TokenService.GenerateToken(user);
            return new
            {
                usuario = _mapper.Map<Usuario, ObterUsuarioDto>(novoUsuario),
                token = token
            };
        }
    }
}
