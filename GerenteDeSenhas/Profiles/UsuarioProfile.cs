using AutoMapper;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;

namespace GerenteDeSenhas.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<Guid>>();
        }
    }
}
