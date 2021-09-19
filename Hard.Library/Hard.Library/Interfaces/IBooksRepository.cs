using Hard.Library.Models;
using System;
using System.Collections.Generic;

namespace Hard.Library.Interfaces
{
    public interface IBooksRepository
    {
        Book GetById(Guid id);
        IEnumerable<Book> GetAll();
        Book Create(Book model);
        void Update(Guid id, Book model);
        void Delete(Guid id);
    }
}
