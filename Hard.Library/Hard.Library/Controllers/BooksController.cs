using Hard.Library.Interfaces;
using Hard.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hard.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBooksRepository _repository;

        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
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
        public IActionResult Post([FromBody] Book model)
        {
            try
            {
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

        [HttpPatch("{id}")]
        public IActionResult Patch(Guid id, [FromBody]Book model)
        {
            try
            {
                _repository.Update(id, model);

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
