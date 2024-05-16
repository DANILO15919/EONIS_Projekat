using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.KorisnikDTOs;

namespace EONISIT32020.Profiles
{
    public class KorisnikProfile : Profile
    {

        public KorisnikProfile()
        {
            CreateMap<KorisnikDTO, Korisnik>().ReverseMap();
            CreateMap<KorisnikCreateDTO, Korisnik>().ReverseMap();
            CreateMap<KorisnikUpdateDTO, Korisnik>().ReverseMap();
        }
    }
}
