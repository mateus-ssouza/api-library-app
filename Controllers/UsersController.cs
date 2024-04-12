using Microsoft.AspNetCore.Mvc;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Application.ViewModel;
using AutoMapper;
using ApiBiblioteca.Domain.Models;
using ApiBiblioteca.Application.Services;
using Microsoft.AspNetCore.Authorization;
using ApiBiblioteca.Domain.DTOs;
using ApiBiblioteca.Infra.Repositories;

namespace ApiBiblioteca.Controllers
{
    [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsersController(IUserRepository userRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = Guid.Parse(_tokenService.GetIdByToken(HttpContext));

            var users = await _userRepository.GetAll(userId);
            var usersDTO = users.Select(u => _mapper.Map<UserDTO>(u));

            return Ok(usersDTO);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = Guid.Parse(_tokenService.GetIdByToken(HttpContext));

            var user = await _userRepository.GetById(userId);
            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO == null ? NotFound() : Ok(userDTO);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO == null ? NotFound() : Ok(userDTO);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserEditViewModel viewModel, Guid id)
        {
            var userExists = await _userRepository.GetById(id);
            if (userExists == null) return NotFound();

            var user = _mapper.Map<User>(viewModel);
            
            user.UserType = userExists.UserType;
            user.Email = userExists.Email;
            user.Password = userExists.Password;

            await _userRepository.Update(id, user);

            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userExists = await _userRepository.ExistsUser(id);
            if (userExists == false) return NotFound();

            await _userRepository.Delete(id);

            return Ok();
        }
    }
}
