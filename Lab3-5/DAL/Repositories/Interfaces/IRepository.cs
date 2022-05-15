namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> Create(T e);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Update(T e);
        Task<bool> Delete(int id);
    }
}
