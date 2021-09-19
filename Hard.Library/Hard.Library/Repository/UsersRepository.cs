using Hard.Library.Interfaces;
using Hard.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hard.Library.Repository
{
    public class UsersRepository : IUsersRepository
    {
        readonly IList<User> users = new List<User>()
        {
            new User { Id = Guid.NewGuid(), FullName = "Gabriel Alex", Cpf = "123456789-00", Email = "example@example.com.br", PhoneNumber = "41999999999" },
            new User { Id = Guid.NewGuid(), FullName = "Deborah Alynne", Cpf = "123456789-10", Email = "example.example@example.com.br", PhoneNumber = "41989999999" },
        };

        public User Create(User model)
        {
            model.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(model.FullName))
                throw new ArgumentNullException(nameof(User.FullName), "O nome do livro é obrigatório");

            users.Add(model);

            return model;
        }

        public void Delete(Guid id)
        {
            var book = GetById(id);

            if (book == null)
                throw new InvalidOperationException("Livro não encontrado");

            users.Remove(book);
        }
        public void Update(Guid id, User model)
        {
            var book = GetById(id);

            if (string.IsNullOrEmpty(model.FullName))
                throw new ArgumentNullException(nameof(User.FullName), "O nome do livro é obrigatório");

            if (book == null)
                throw new InvalidOperationException("Livro não encontrado");

            book.FullName = model.FullName;
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}
