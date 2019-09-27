using JobDashBoard.IDAL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace JobDashBoard.DAL
{
     /// <summary>
     /// Base Repository class
     /// </summary>
     /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        protected JobDashBoardDbContext jobContext = ContextFactory.GetCurrentContext();

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">entity need to be added</param>
        /// <returns>new entity after added</returns>
        public T Add(T entity)
        {
            jobContext.Entry<T>(entity).State = EntityState.Added;
            jobContext.SaveChanges();
            return entity;

        }

      

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity need to delete</param>
        /// <returns>delete successfully or not</returns>
        public bool Delete(T entity)
        {
            jobContext.Set<T>().Attach(entity);
            jobContext.Entry<T>(entity).State = EntityState.Deleted;
            return jobContext.SaveChanges() > 0;

        }

        public bool Exist(Expression<Func<T, bool>> anyLambal)
        {
            return jobContext.Set<T>().Any(anyLambal);
        }

    

        /// <summary>
        /// Find list result
        /// </summary>
        /// <param name="whereLamdba">where condition lamdba expression</param>
        /// <returns>list result</returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba)
        {
            var _list = jobContext.Set<T>().Where<T>(whereLamdba);
           
            return _list;
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity need to update</param>
        /// <returns>update successfully or not</returns>
        public bool Update(T entity)
        {
            jobContext.Set<T>().Attach(entity);
            jobContext.Entry<T>(entity).State = EntityState.Modified;
            return jobContext.SaveChanges() > 0;
        }
    }
}
