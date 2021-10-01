﻿using Hard.Library.Models;
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
        Task Update(User user);
        void Delete(Guid id);
    }
}
