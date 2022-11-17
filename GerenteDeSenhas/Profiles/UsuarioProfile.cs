using AutoMapper;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Models;

namespace GerenteDeSenhas.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
