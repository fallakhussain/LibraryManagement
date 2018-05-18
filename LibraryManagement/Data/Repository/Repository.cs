using LibraryManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryDbContext _context;

        public Repository(LibraryDbContext context) => _context = context;

        public int Count(Func<T, bool> precidate)
        {
            throw new NotImplementedException();
        }

        protected void Save() => _context.SaveChanges();

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
