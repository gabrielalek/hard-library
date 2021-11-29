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
    public class GendersRepository : IGendersRepository
    {
        private readonly DataContext _context;

        public GendersRepository(DataContext context)
        {
            _context = context;
        }
           
        public Gender Create(Gender gender)
        {
            gender.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(gender.Name))
                throw new ArgumentNullException(nameof(Gender.Name), "O nome do Genero é obrigatório");

            _context.Genders.Add(gender);
            _context.SaveChanges();

            return gender;
        }

        public void Delete(Gender genders)
        {
            var gender = GetById(genders.Id);

            if (gender == null)
                throw new InvalidOperationException("Gênero não encontrado");

            _context.Genders.Remove(gender);
            _context.SaveChanges();
        }

        public async Task Update(Gender gender)
        {
            var entity = GetById(gender.Id);

            entity.Name = gender.Name;
            
            entity.LastUpdate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Gender> GetAll() => _context.Genders.Include(g => g.Name).ToList();
        
        public Gender GetById(Guid id)
        {
            return _context.Genders.FirstOrDefault(x => x.Id == id);
        }
    }
}
