using Hard.Library.Data;
using Hard.Library.Interfaces;
using Hard.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hard.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBooksRepository _repository;
        readonly IGendersRepository _repositoryGender;

        public BooksController(IBooksRepository repository, IGendersRepository repositoryGender)
        {
            _repository = repository;
            _repositoryGender = repositoryGender;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var books = _repository.GetAll();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var book = _repository.GetById(id);

                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromServices] DataContext context, [FromBody] Book model)
        {
            try
            {
                List<Gender> Genders = new List<Gender>();
                
                foreach (var gender in model.Genders)
                {
                    Genders.Add(_repositoryGender.GetById(gender.Id));
                }

                model.Genders = Genders;
                
                var book = _repository.Create(model);

                return Created($"api/books/{book.Id}", book);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    ex.ParamName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put([FromServices] DataContext context, [FromBody] Book book)
        {
            try
            {
                var entity = _repository.GetById(book.Id);

                if (entity == null)
                    return NotFound("Livro não encontrado");

                _repository.Update(book);

                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    ex.ParamName
                });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }
    }
}
