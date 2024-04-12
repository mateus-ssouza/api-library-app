namespace ApiBiblioteca.Application.ViewModel
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
