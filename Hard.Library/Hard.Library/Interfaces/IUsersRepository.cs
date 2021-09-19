using Hard.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hard.Library.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        User Create(User model);
        void Update(Guid id, User model);
        void Delete(Guid id);
    }
}
