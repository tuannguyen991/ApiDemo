using ApiDemo.Authors;
using ApiDemo.Books;
using AutoMapper;

namespace ApiDemo;

public class ApiDemoApplicationAutoMapperProfile : Profile
{
    public ApiDemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Author, AuthorDto>();
        CreateMap<Book, BookDto>();
    }
}
