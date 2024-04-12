using ApiBiblioteca.Application.Services;
using ApiBiblioteca.Application.ViewModel;
using ApiBiblioteca.Domain.DTOs;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(IUserRepository userRepository, TokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel viewModel)
        {
            var isRegisteredEmail = await _userRepository.IsRegisteredEmail(viewModel.Email);
            if (isRegisteredEmail) return BadRequest();
            
            var user = _mapper.Map<User>(viewModel);
            var passwordHash = CryptographyService.Encrypt(viewModel.Password);
            user.Password = passwordHash;

            await _userRepository.Add(user);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {

            var user = await _userRepository.GetByEmail(viewModel.Email);

            if (user == null) return NotFound();

            if (CryptographyService.Verify(viewModel.Password, user.Password))
            {
                var token = _tokenService.GenerateToken(user);
                var userDTO = _mapper.Map<UserDTO>(user);

                object response = new
                {
                    User = userDTO,
                    Token = token
                };

                return Ok(response);
            }

            return BadRequest();
        }
    }
}
