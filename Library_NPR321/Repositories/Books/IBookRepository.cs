using Library_NPR321.Models;

namespace Library_NPR321.Repositories.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> Books { get; }
        Task<Book?> GetByIdAsync(int? id);
    }
}
