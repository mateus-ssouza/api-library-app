using ApiBiblioteca.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiBiblioteca.Application.Utils;
using ApiBiblioteca.Application.ViewModel;
using AutoMapper;
using ApiBiblioteca.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using ApiBiblioteca.Application.Services;

namespace ApiBiblioteca.Controllers
{
    [Authorize]
    [Route("api/v1/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public LoansController(ILoanRepository loanRepository, IMapper mapper, TokenService tokenService)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _loanRepository.GetAll();
            var loansDTO = loans.Select(l => _mapper.Map<LoanDTO>(l));

            return Ok(loansDTO);
        }

        [HttpGet("myloans")]
        public async Task<IActionResult> GetAllMyLoans()
        {
            var userId = Guid.Parse(_tokenService.GetIdByToken(HttpContext));

            var loans = await _loanRepository.GetAllByUserId(userId);
            var loansDTO = loans.Select(l => _mapper.Map<LoanDTO>(l));

            return Ok(loansDTO);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loan = await _loanRepository.GetById(id);
            var loanDTO = _mapper.Map<LoanDTO>(loan);

            return loanDTO == null ? NotFound() : Ok(loanDTO);
        }

        [HttpGet("myloans/{id}")]
        public async Task<IActionResult> GetByIdMyLoans(Guid id)
        {
            var userId = Guid.Parse(_tokenService.GetIdByToken(HttpContext));
            
            var loanExists = await _loanRepository.ExistsLoan(id);
            if (loanExists == false) return NotFound();

            var loanIsUser = await _loanRepository.LoanIsUser(userId, id);
            if (loanIsUser == false) return BadRequest();

            var loan = await _loanRepository.GetById(id);
            var loanDTO = _mapper.Map<LoanDTO>(loan);

            return Ok(loanDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanViewModel viewModel)
        {
            var userId = _tokenService.GetIdByToken(HttpContext);

            var loan = CreateUtil.LoanCreate(viewModel);
            loan.UserId = Guid.Parse(userId);
            
            await _loanRepository.Add(loan);

            return StatusCode(201);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] LoanEditViewModel viewModel, Guid id)
        {
            var loanExists = await _loanRepository.ExistsLoan(id);
            if (loanExists == false) return NotFound();

            var loan = CreateUtil.LoanCreate(viewModel);
            await _loanRepository.Update(id, loan);

            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var loanExists = await _loanRepository.ExistsLoan(id);
            if (loanExists == false) return NotFound();

            await _loanRepository.Delete(id);

            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}/validate")]
        public async Task<IActionResult> Validate(Guid id)
        {
            var loanExists = await _loanRepository.ExistsLoan(id);
            if (loanExists == false) return NotFound();

            await _loanRepository.Validate(id);

            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}/finalize")]
        public async Task<IActionResult> Finalize(Guid id)
        {
            var loanExists = await _loanRepository.ExistsLoan(id);
            if (loanExists == false) return NotFound();

            await _loanRepository.Finalize(id);

            return Ok();
        }
    }
}
