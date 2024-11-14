﻿namespace AuthorBookApplication.Repositories
{
    public interface IRepository<T>
    {
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public T GetById(int id);
        public IQueryable<T> Get();
        public List<T> GetAll();

    }
}