using ApiBiblioteca.Application.ViewModel;
using ApiBiblioteca.Domain.DTOs;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiBiblioteca.Controllers
{
    [Authorize]
    [Route("api/v1/copies")]
    [ApiController]
    public class CopiesController : ControllerBase
    {
        private readonly ICopyRepository _copyRepository;
        private readonly IMapper _mapper;

        public CopiesController(ICopyRepository copyRepository, IMapper mapper)
        {
            _copyRepository = copyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var copies = await _copyRepository.GetAll();
            var copiesDTO = copies.Select(c => _mapper.Map<CopyDTO>(c));

            return Ok(copiesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var copy = await _copyRepository.GetById(id);
            var copyDTO = _mapper.Map<CopyDTO>(copy);

            return copyDTO == null ? NotFound() : Ok(copyDTO);
        }

        [HttpGet("books-with-copies")]
        public async Task<IActionResult> GetAllBooksWithCopies() 
        {
            var booksWithCopies = await _copyRepository.GetAllBooksWithCopies();
            var booksDTO = booksWithCopies.Select(b => _mapper.Map<BookDTO>(b));

            return Ok(booksDTO);
        }

        [HttpGet("books-without-copies")]
        public async Task<IActionResult> GetAllBooksWithoutCopies()
        {
            var booksWithoutCopies = await _copyRepository.GetBooksWithoutCopies();
            var booksDTO = booksWithoutCopies.Select(b => _mapper.Map<BookDTO>(b));

            return Ok(booksDTO);
        }

        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetByBookId(Guid id)
        {
            var copies = await _copyRepository.GetByBookId(id);
            var copiesDTO = copies.Select(c => _mapper.Map<CopyDTO>(c));

            return Ok(copiesDTO);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("book/{id}")]
        public async Task<IActionResult> Add([FromBody] CopyViewModel viewModel, Guid id)
        {
            var isRegisteredCopyCode = await _copyRepository.IsRegisteredCopyCode(viewModel.CopyCode);
            if (isRegisteredCopyCode) return BadRequest();

            var copy = _mapper.Map<Copy>(viewModel);
            copy.BookId = id;
            await _copyRepository.Add(copy);

            return StatusCode(201);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CopyViewModel viewModel, Guid id)
        {
            var copyExists = await _copyRepository.GetById(id);
            if (copyExists == null) return NotFound();

            var isRegisteredCopyCode = await _copyRepository.IsRegisteredCopyCode(viewModel.CopyCode);
            if (isRegisteredCopyCode && copyExists.CopyCode != viewModel.CopyCode)
            {
                return BadRequest();
            }

            var copy = _mapper.Map<Copy>(viewModel);
            await _copyRepository.Update(id, copy);

            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var copyExists = await _copyRepository.GetById(id);
            if (copyExists == null) return NotFound();

            await _copyRepository.Delete(id);

            return Ok();
        }
    }
}
