using EONISIT32020.Models.DTOs.BrandDTOs;
using EONISIT32020.Models;
using AutoMapper;
using EONISIT32020.Models.DTOs.PorudzbinaDTOs;

namespace EONISIT32020.Profiles
{
    public class PorudzbinaProfile : Profile
    {
        public PorudzbinaProfile()
        {
            CreateMap<PorudzbinaDTO, Porudzbina>().ReverseMap();
            CreateMap<PorudzbinaCreateDTO, Porudzbina>().ReverseMap();
            CreateMap<PorudzbinaUpdateDTO, Porudzbina>().ReverseMap();
        }
    }
}
