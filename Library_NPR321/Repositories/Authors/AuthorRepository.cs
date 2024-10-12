using Library_NPR321.Data;
using Library_NPR321.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_NPR321.Repositories.Authors
{
    public class AuthorRepository 
        : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Author> Authors => GetAll()
            .AsNoTracking()
            .Include(a => a.Books);

        public async Task<Author?> GetByIdAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }

            var model = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            return model;
        }
    }
}
