namespace SiemensEnergyTeste.Domain.Interfaces
{
    public interface IGenerico<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(Guid id);
    }
}
