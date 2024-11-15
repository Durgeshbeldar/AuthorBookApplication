using AuthorBookApplication.DTOs;
using AuthorBookApplication.Models;
using AutoMapper;

namespace AuthorBookApplication.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Get Request Mapping

            CreateMap<Author, AuthorDto>().ForMember
                (dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));

            // Post Request Mapping 

            CreateMap<AuthorDto, Author>();

            CreateMap<Book, BookDto>().ForMember
                (dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));

            CreateMap<BookDto, Book>();

            CreateMap<AuthorDetails, AuthorDetailsDto>().ForMember
               (dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));
            CreateMap<AuthorDetailsDto, AuthorDetails>();
        }
       
    }
}
