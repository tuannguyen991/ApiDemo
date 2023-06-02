using System;
using System.Linq;
using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using ApiDemo.Users;
using ApiDemo.Users.RecommendationSystem;
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
            .ForMember(dest => dest.TotalReadingTime, act => act.MapFrom(src => Math.Ceiling(src.TotalReadingTime)));
        CreateMap<ReadingPackage, ReadingPackageDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Authors, act => act.MapFrom(src => src.BookWithAuthors))
            .ForMember(dest => dest.Categories, act => act.MapFrom(src => src.BookWithCategories));
        CreateMap<UserReadingPackage, UserReadingPackageDto>();
        CreateMap<UserHistory, UserHistoryDto>()
            .ForMember(dest => dest.ReadingTime, act => act.MapFrom(src => Math.Ceiling(src.ReadingTime.TotalMinutes)));
        CreateMap<BookWithAuthor, AuthorDto>()
            .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.Author.BirthDate))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.ShortBio, act => act.MapFrom(src => src.Author.ShortBio))
            .ForMember(dest => dest.ImageLink, act => act.MapFrom(src => src.Author.ImageLink))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Author.Id));
        CreateMap<BookWithCategory, CategoryDto>()
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ImageLink, act => act.MapFrom(src => src.Category.ImageLink))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Category.Id));
        CreateMap<Highlight, HighlightDto>();
        CreateMap<Reminder, ReminderDto>();
        CreateMap<UserLibrary, UserLibraryDto>();
        CreateMap<Book, UserBookDto>()
            .ForMember(dest => dest.Authors, act => act.MapFrom(src => src.BookWithAuthors))
            .ForMember(dest => dest.Categories, act => act.MapFrom(src => src.BookWithCategories));
        CreateMap<Highlight, HighlightNotificationDto>()
            .ForMember(dest => dest.BookName, act => act.MapFrom(src => src.Book.Title));
        CreateMap<Book, ItemDto>()
            .ForMember(dest => dest.ItemId, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Genres, act => act.MapFrom(src => string.Join(", ", src.BookWithCategories.Select(book => book.Category.Name))));
        CreateMap<UserLibrary, RatingDto>()
        .ForMember(dest => dest.ItemId, act => act.MapFrom(src => src.BookId))
        .ForMember(dest => dest.RatingValue, act => act.MapFrom(src => (new RatingSpecification().ToExpression()(src))));
    }
}