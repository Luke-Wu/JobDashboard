using JobDashBoard.IBLL;
using JobDashBoard.IDAL;

namespace JobDashBoard.BLL
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {

        protected IBaseRespository<T> CurrentRespository { get; set; }

        public BaseService(IBaseRespository<T> currentRespository)
        {
            CurrentRespository = currentRespository;
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">entity need to be added</param>
        /// <returns>new entity after added</returns>
        public T Add(T entity)
        {
            return CurrentRespository.Add(entity);
        }


        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity need to be delete</param>
        /// <returns>delete successfully or not</returns>
        public bool Delete(T entity)
        {
            return CurrentRespository.Delete(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity need to be added</param>
        /// <returns>update successfully or not</returns>
        public bool Update(T entity)
        {
            return CurrentRespository.Update(entity);
        }
    }
}
