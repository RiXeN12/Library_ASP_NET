namespace Library_NPR321.Repositories
{
    public interface IGenericRepository<TModel>
        where TModel : class
    {
        Task<bool> AddAsync(TModel model);
        Task<bool> UpdateAsync(TModel model);
        Task<bool> RemoveAsync(TModel model);
    }
}
