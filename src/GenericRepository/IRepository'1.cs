
namespace GenericRepository {
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntity<int> {
    }
}