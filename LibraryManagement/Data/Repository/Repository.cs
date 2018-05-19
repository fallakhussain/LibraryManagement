using LibraryManagement.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public int Count(Func<T, bool> predicate) => _context.Set<T>().Where(predicate).Count();

        protected void Save() => _context.SaveChanges();

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate) => _context.Set<T>().Where(predicate);

        public IEnumerable<T> GetAll() => _context.Set<T>();

        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Update(T entity)
        {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
        }
    }
}
