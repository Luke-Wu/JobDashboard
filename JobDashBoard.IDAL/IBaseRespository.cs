using System;
using System.Linq;
using System.Linq.Expressions;

namespace JobDashBoard.IDAL
{
    /// <summary>
    /// Interface of Base Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRespository<T>
    {
        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="entity">Data Entity</param>
        /// <returns>Entity after add</returns>
        T Add(T entity);



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Data Entity</param>
        /// <returns>Whether update successfully</returns>
        bool Update(T entity);



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">Data Entity</param>
        /// <returns>Whether delete successfully</returns>
        bool Delete(T entity);


     

        /// <summary>
        /// Is exist or not 
        /// </summary>
        /// <param name="anyLambal">query conditions</param>
        /// <returns>bool value to indicate whether exist or not</returns>
        bool Exist(Expression<Func<T, bool>> anyLambal);




        /// <summary>
        /// Query data records list result
        /// </summary>
        /// <param name="whereLamdba">where conditions</param>
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba);


    }
}
