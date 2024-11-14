
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

        public IQueryable<T> Get()
        {
            return _table.AsQueryable();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public List<T> GetAll()
        {
            var query = Get();
            return query.ToList();
        }
        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
