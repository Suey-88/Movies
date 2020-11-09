using Movies.Api.Dto;
using Movies.EFDataAccess.Models;
using AutoMapper;

namespace Movies.Api.Models.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Uses Reflection to do this, go and google reflection and AutoMapper. 
            CreateMap<Movie, MovieDto>();
            CreateMap<Cart, CartDto>();

        }
    }
}