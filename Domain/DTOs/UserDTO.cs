using ApiBiblioteca.Domain.Enums;

namespace ApiBiblioteca.Domain.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }
    }
}
