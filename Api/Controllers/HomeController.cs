using Api.Dto.Usuario;
using AutoMapper;
using CrossCutting.Config.Token;
using Dominio.Entidades;
using Dominio.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public HomeController(IUnitOfWork uow,
                              IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] UsuarioDto usuario)
        {
            var usuarioMap = _mapper.Map<UsuarioDto, Usuario>(usuario);

            var user = (await _uow.RepositorioUsuario.GetList(x => x.Nome == usuarioMap.Nome && x.Senha == usuarioMap.Senha)).FirstOrDefault();

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
        
        [HttpPost("novo-usuario")]
        public async Task<ActionResult<dynamic>> NovoUsuario([FromBody] UsuarioDto usuario)
        {
            var usuarioMap = _mapper.Map<UsuarioDto, Usuario>(usuario);

            var user = (await _uow.RepositorioUsuario.GetList(x => x.Nome == usuarioMap.Nome && x.Senha == usuarioMap.Senha)).FirstOrDefault();

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
    }
}
