using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;
using System.Data;
using AutoMapper;

namespace Lesson27Task
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDTO, Product>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Product, ProductDTO>();
            CreateMap<ApartmentDTO, Apartment>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Apartment, ApartmentDTO>();
        }
    }
}
