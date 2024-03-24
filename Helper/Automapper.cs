using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;

namespace BookStoreAPI.Helper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
