using AutoMapper;
using LibraryManager.Dtos;
using LibraryManager.Models;

namespace LibraryManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<DocumentType, DocumentTypeDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<CheckOut, CheckOutDto>();
        }
    }
}