using Hard.Library.Data;
using Hard.Library.Interfaces;
using Hard.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hard.Library.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }
        
        public Book Create(Book book)
        {
            book.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(book.Name))
                throw new ArgumentNullException(nameof(Book.Name), "O nome do livro é obrigatório");

            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public void Delete(Guid id)
        {
            var book = GetById(id);

            if (book == null)
                throw new InvalidOperationException("Livro não encontrado");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public async Task Update(Book book)
        {
            var entity = GetById(book.Id);

            entity.Name = book.Name;

            entity.LastUpdate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Book> GetAll() => _context.Books.Include(b => b.Genders).ToList();
        
        public Book GetById(Guid id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

    }
}
