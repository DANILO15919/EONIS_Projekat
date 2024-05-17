using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.ProizvodDTOs;

namespace EONISIT32020.Profiles
{
    public class ProizvodProfile : Profile
    {

        public ProizvodProfile()
        {
            CreateMap<ProizvodDTO, Proizvod>().ReverseMap();
            CreateMap<ProizvodCreateDTO, Proizvod>().ReverseMap();
            CreateMap<ProizvodUpdateDTO, Proizvod>().ReverseMap();
        }
    }
}
