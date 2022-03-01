using AutoMapper;
using Selenium.DTOs;
using Selenium.Models;

namespace Selenium.AutoMapperProfiles
{
    public class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<CurrencyCreateRequest, Currency>();
        }
    }
}
