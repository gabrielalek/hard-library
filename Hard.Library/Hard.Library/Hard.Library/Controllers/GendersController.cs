using Hard.Library.Data;
using Hard.Library.Interfaces;
using Hard.Library.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hard.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        readonly IGendersRepository _repository;
        readonly IBooksRepository _repositoryBook;
        public GendersController(IGendersRepository repository, IBooksRepository repositoryBook)
        {
            _repository = repository;
            _repositoryBook = repositoryBook;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var genders = _repository.GetAll();

                return Ok(genders);
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
                var gender = _repository.GetById(id);

                if (gender == null)
                    return NotFound();

                return Ok(gender);
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
        public IActionResult Post([FromServices] DataContext context, [FromBody] Gender model)
        {
            try
            {
                List<Book> Books = new List<Book>();

                foreach (var book in model.Books)
                {
                    Books.Add(_repositoryBook.GetById(book.Id));
                }

                model.Books = Books;

                var gender = _repository.Create(model);

                return Created($"api/genders/{gender.Id}", gender);
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
        public IActionResult Put([FromServices] DataContext context, [FromBody] Gender gender)
        {
            try
            {
                var entity = _repository.GetById(gender.Id);

                if (entity == null)
                    return NotFound("Gênero não encontrado");

                _repository.Update(gender);

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
