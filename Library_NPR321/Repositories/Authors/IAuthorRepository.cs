using Library_NPR321.Models;
using System.Collections;

namespace Library_NPR321.Repositories.Authors
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        IEnumerable<Author> Authors { get; }
        Task<Author?> GetByIdAsync(int? id);
    }
}
