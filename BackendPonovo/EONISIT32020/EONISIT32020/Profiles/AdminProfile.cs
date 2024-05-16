using EONISIT32020.Models.DTOs.BrandDTOs;
using EONISIT32020.Models;
using AutoMapper;
using EONISIT32020.Models.DTOs.AdminDTOs;

namespace EONISIT32020.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminDTO, Admin>().ReverseMap();
            CreateMap<AdminCreateDTO, Admin>().ReverseMap();
            CreateMap<AdminUpdateDTO, Admin>().ReverseMap();
        }
    }
}
