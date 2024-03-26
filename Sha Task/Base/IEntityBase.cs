namespace Sha_Task.Base
{
    public interface IEntityBase <T> where T : class, IBase,new()
    {
        Task <IEnumerable<T>> GetALL();
        Task <T> GetById( int id);

        Task  Add(T entity );

        Task  Update( T entity );

        Task  Delete( int id );

    }
}
