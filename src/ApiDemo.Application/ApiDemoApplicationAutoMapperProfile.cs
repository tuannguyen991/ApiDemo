using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using ApiDemo.Users;
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
        CreateMap<User, UserDto>();
        CreateMap<ReadingPackage, ReadingPackageDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Book, BookDto>();
        CreateMap<UserReadingPackage, UserReadingPackageDto>();
        CreateMap<UserHistory, UserHistoryDto>();
        CreateMap<BookWithAuthor, BookWithAuthorDto>();
        CreateMap<BookWithCategory, BookWithCategoryDto>();
        CreateMap<Highlight, HighlightDto>();
    }
}
