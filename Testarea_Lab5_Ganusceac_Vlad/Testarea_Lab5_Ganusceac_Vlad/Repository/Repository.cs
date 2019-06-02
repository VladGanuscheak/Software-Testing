using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Testarea_Lab5_Ganusceac_Vlad.Models;

namespace BusinessComponents.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetList();

        Task<IEnumerable<T>> GetListAsync();

        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);

        //IEnumerable<T> GetList(ISpecification<T> spec);

        //Task<IEnumerable<T>> GetListAsync(ISpecification<T> spec);

        void Add(T entity);

        void AddAsync(T entity);

        void Delete(T entity);

        void DeleteAsync(T entity);

        void Edit(T entity);

        void EditAsync(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> GetList()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            await Task.Delay(200);

            return _dbContext.Set<T>()
                        .AsEnumerable();
        }

        public virtual IEnumerable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            await Task.Delay(200);

            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }
        /*
        public virtual IEnumerable<T> GetList(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            await Task.Delay(200);

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }
        */

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            _dbContext.SaveChanges();
        }

        /*public async void InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }*/

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public async void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            _dbContext.SaveChanges();
        }

        public async void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            _dbContext.SaveChanges();
        }

        /*public void AddAsync(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);

            _dbContext.SaveChangesAsync();
        }*/

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void EditAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChangesAsync();
        }

        public void AddAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
