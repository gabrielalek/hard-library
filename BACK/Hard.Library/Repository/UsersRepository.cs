using Hard.Library.Data;
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
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            user.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(user.FullName))
            {
                throw new ArgumentNullException(nameof(User.FullName), "O nome do usuário é obrigatório");
            };
                
            if (string.IsNullOrEmpty(user.Cpf))
            {
                throw new ArgumentNullException(nameof(User.Cpf), "O CPF não pode ser nulo");
            };

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentNullException(nameof(User.Email), "O Email não pode ser nulo");
            };

            if (user.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(User.DateOfBirth), "A data de nascimento não pode ser nula");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(User Usuario)
        {
            var user = GetById(Usuario.Id);

            if (user == null)
                throw new InvalidOperationException("Usuário não encontrado");

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task Update(User user)
        {
            var entity = GetById(user.Id);

            entity.FullName = user.FullName;

            entity.LastUpdate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
