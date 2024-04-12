using ApiBiblioteca.Domain.Enums;

namespace ApiBiblioteca.Application.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
