using ApiBiblioteca.Application.ViewModel;
using ApiBiblioteca.Domain.DTOs;
using ApiBiblioteca.Domain.Models;
using AutoMapper;

namespace ApiBiblioteca.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            // ViewModel to Model
            CreateMap<AddressViewModel, Address>();
            CreateMap<UserViewModel, User>();
            CreateMap<UserEditViewModel, User>();
            CreateMap<BookViewModel, Book>();
            CreateMap<CopyViewModel, Copy>();

            // Model to ModelDTO
            CreateMap<Address, AddressDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<Copy, CopyDTO>();
            CreateMap<Loan, LoanDTO>()
                .ForMember(dest => dest.User, m => m.MapFrom(orig => orig.User.Name))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookLendings.Select(bl => bl.Copy.Book).ToList()));
        }
    }
}
