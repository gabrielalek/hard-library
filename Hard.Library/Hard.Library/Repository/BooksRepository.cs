using Hard.Library.Interfaces;
using Hard.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hard.Library.Repository
{
    public class BooksRepository : IBooksRepository
    {
        readonly IList<Book> books = new List<Book>()
        {
            new Book { Id = Guid.NewGuid(), Name = "Divergente", Gender = "Ficção", Author = "Veronica Roth", Editor = "Porto Editora" },
            new Book { Id = Guid.NewGuid(), Name = "A mão e a luva", Gender = "Romance", Author = "Machado de Assis", Editor = "Martin Claret" },
        };
        
        public Book Create(Book model)
        {
            model.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Book.Name), "O nome do livro é obrigatório");

            books.Add(model);

            return model;
        }

        public void Delete(Guid id)
        {
            var book = GetById(id);

            if (book == null)
                throw new InvalidOperationException("Livro não encontrado");

            books.Remove(book);
        }
        public void Update(Guid id, Book model)
        {
            var book = GetById(id);

            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Book.Name), "O nome do livro é obrigatório");

            if (book == null)
                throw new InvalidOperationException("Livro não encontrado");

            book.Name = model.Name;
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book GetById(Guid id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

    }
}
