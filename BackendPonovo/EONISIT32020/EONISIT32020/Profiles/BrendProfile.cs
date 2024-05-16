using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.BrandDTOs;
using System.Data;

namespace EONISIT32020.Profiles
{
    public class BrendProfile : Profile
    {
        public BrendProfile()
        {
            CreateMap<BrendDTO, Brend>().ReverseMap();
            CreateMap<BrendCreateDTO, Brend>().ReverseMap();
            CreateMap<BrendUpdateDTO, Brend>().ReverseMap();
        }
    }
}
