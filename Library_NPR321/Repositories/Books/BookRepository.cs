using Library_NPR321.Data;
using Library_NPR321.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_NPR321.Repositories.Books
{
    public class BookRepository
        : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books => GetAll()
            .AsNoTracking()
            .Include(b => b.Author);

        public async Task<Book?> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Додаємо Include для завантаження автора
            var res = await GetAll()
                .AsNoTracking()
                .Include(b => b.Author)  // Додаємо автора
                .FirstOrDefaultAsync(b => b.Id == id);

            return res;
        }
    }
}
