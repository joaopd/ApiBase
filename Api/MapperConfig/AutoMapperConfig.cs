using Api.Dto.Usuario;
using AutoMapper;
using Dominio.Entidades;

namespace Api.MapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            MapUsuario();
        }

        public void MapUsuario()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, ObterUsuarioDto>().ReverseMap();

        }
    }
}
