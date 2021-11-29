using Hard.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hard.Library.Interfaces
{
    public interface IBooksRepository
    {
        Book GetById(Guid id);
        IEnumerable<Book> GetAll();
        Book Create(Book book);
        Task Update(Book book);
        void Delete(Book book);
        Task Emprestimo(Book book, User user);
        Task Devolucao(Book book);
    }
}
