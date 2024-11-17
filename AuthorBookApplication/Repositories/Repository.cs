
using AuthorBookApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AuthorBookContext _context;
        private readonly DbSet<T> _table;
        public Repository(AuthorBookContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
       
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        // This Method is Optional We Can Do This By GetAll() Method As Well in Service Layer.
        public T GetById(int id)
        {
            return _table.Find(id);
        }


        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
