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
        readonly IUsersRepository _repositoryUser;

        public BooksController(IBooksRepository repository, IGendersRepository repositoryGender, IUsersRepository repositoryUser)
        {
            _repository = repository;
            _repositoryGender = repositoryGender;
            _repositoryUser = repositoryUser;
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

        [System.Web.Http.HttpGet]
        public ActionResult SetAction(Guid idBook, Guid idUser, string action)
        {
            try
            {
                var book = _repository.GetById(idBook);
                var user = _repositoryUser.GetById(idUser);
                if (action == "aluguel")
                {
                    if (book == null)
                    {
                        return BadRequest();
                    }
                    if (user == null)
                    {
                        return BadRequest();
                    }

                    _repository.Emprestimo(book, user);
                    return NoContent();
                }
                if (action == "devolucao")
                {
                    if (book == null)
                    {
                        return BadRequest("o Livro não pode ser nulo");
                    }

                    _repository.Devolucao(book);
                    return NoContent();
                }
                else
                {
                    return BadRequest(action);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
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

                foreach (var gender in Genders)
                {
                    Genders.Add(_repositoryGender.GetById(gender.Id));
                }

                model.Gender = Genders;

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
                {
                    return NotFound("Livro não encontrado");
                }

                _repository.Update(book);

                return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Book book)
        {
            try
            {
                _repository.Delete(book);

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