using Hard.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hard.Library.Interfaces
{
    public interface IGendersRepository
    {
        Gender GetById(Guid id);
        IEnumerable<Gender> GetAll();
        Gender Create(Gender gender);
        Task Update(Gender gender);
        void Delete(Guid id);
    }
}
