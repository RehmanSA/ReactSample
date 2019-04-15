using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDAL.Model.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        List<T> GetAllRecords();
        void Delete(T entity);
        IEnumerable<T> Find(Func<T, bool> predicate);
        int Count(Func<T, bool> predicate);

    }
}
