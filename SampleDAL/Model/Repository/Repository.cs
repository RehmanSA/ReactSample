using Microsoft.EntityFrameworkCore;
using SampleDAL.Model.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDAL.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ReactSampleContext _context ;
        
        public Repository(ReactSampleContext context)
        {
            _context = context;
        }   
        public T GetById(int id)
        {
          return _context.Set<T>().Find(id);
        }
        public List<T> GetAllRecords()
        {
            return _context.Set<T>().ToList();
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            Commit();
            return entity;
        }
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;          
            Commit();
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            Commit();
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }
        public void Commit() => _context.SaveChanges();
      
    }
}
