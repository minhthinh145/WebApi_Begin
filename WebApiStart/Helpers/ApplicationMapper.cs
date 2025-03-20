using AutoMapper;
using WebApiStart.Data;
using WebApiStart.Models;

namespace WebApiStart.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
