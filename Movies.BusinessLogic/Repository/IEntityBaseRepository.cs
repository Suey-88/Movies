using Movies.EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movies.BusinessLogic.Repository
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> LoadAll();
        Task<List<T>> FindMany(Expression<Func<T, bool>> predicate);
        Task<int> Count();
        Task<T> FindSingle(int id);
        Task<T> FindSingle(Expression<Func<T, bool>> predicate);
        Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        Task Commit();
    }
}
