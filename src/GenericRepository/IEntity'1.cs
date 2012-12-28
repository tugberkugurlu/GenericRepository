
namespace GenericRepository {
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId> {

        TId Id { get; set; }
    }
}