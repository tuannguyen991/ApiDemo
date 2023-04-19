using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.TotalReadingTime, act => act.MapFrom(src => Math.Ceiling(src.TotalReadingTime)));;
        CreateMap<ReadingPackage, ReadingPackageDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Book, BookDto>();
        CreateMap<UserReadingPackage, UserReadingPackageDto>();
        CreateMap<UserHistory, UserHistoryDto>()
            .ForMember(dest => dest.ReadingTime, act => act.MapFrom(src => Math.Ceiling(src.ReadingTime.TotalMinutes)));
        CreateMap<BookWithAuthor, BookWithAuthorDto>();
        CreateMap<BookWithCategory, BookWithCategoryDto>();
        CreateMap<Highlight, HighlightDto>();
    }
}