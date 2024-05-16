using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.KupacDTOs;

namespace EONISIT32020.Profiles
{
    public class KupacProfile : Profile
    {

        public KupacProfile()
        {
            CreateMap<KupacDTO, Kupac>().ReverseMap();
            CreateMap<KupacCreateDTO, Kupac>().ReverseMap();
            CreateMap<KupacUpdateDTO, Kupac>().ReverseMap();
        }
    }
}
