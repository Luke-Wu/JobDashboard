namespace JobDashBoard.IBLL
{
    /// <summary>
    /// Base service interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">entity need to be added</param>
        /// <returns>new entity after added</returns>
        T Add(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity need to be added</param>
        /// <returns>update successfully or not</returns>
        bool Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity need to be delete</param>
        /// <returns>delete successfully or not</returns>
        bool Delete(T entity);

    }
}
