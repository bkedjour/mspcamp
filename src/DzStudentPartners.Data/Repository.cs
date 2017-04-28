using System;
using System.Linq;
using System.Linq.Expressions;

namespace DzStudentPartners.Data
{
    internal class Repository<T> where T : class
    {
        private readonly MspContext _context;

        public Repository(MspContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

            _context.SaveChanges();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            Add(entity);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            SaveChanges();
        }
    }
}