using AutoMapper;
using SenhasAPI.Data.Dtos.SenhaDtos;
using SenhasAPI.Models;

namespace SenhasAPI.Profiles
{
    public class SenhaProfile : Profile
    {
        public SenhaProfile() 
        {
            CreateMap<CreateSenhaDto,Senha>();
            CreateMap<Senha, ReadSenhaDto>();
            CreateMap<UpdateSenhaDto,Senha>();
        }
    }
}
