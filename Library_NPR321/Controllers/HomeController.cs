using Library_NPR321.Models;
using Library_NPR321.Models.ViewModels;
using Library_NPR321.Repositories.Authors;
using Library_NPR321.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Library_NPR321.Services;
using System.Collections;

namespace Library_NPR321.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            var favoriteBooks = GetFavoriteBookItems();

            var bookModels = _bookRepository.Books
                .Select(b => new FavoriteBookVM
                {
                    Book = b,
                    IsFavorite = favoriteBooks.Any(f => f.BookId == b.Id)
                });

            var viewModel = new HomeVM
            {
                Books = bookModels,
                Authors = _authorRepository.Authors
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AddToFavorite(int id)
        {
            var books = GetFavoriteBookItems();

            books.Add(new FavoriteBookItem { BookId = id });

            HttpContext.Session.Set(Settings.FavoriteSessionKey, books);

            return RedirectToAction("Index");
        }

        public IActionResult FavoritePage()
        {
            var items = GetFavoriteBookItems();
            var books = _bookRepository.Books
                .Where(b => items.Any(i => i.BookId == b.Id));

            return View(books);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                // якщо книга не знайдена, повертаЇмо помилку 404
                return NotFound();
            }

            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RemoveFromFavorite(int id)
        {
            var items = GetFavoriteBookItems();
            var newItems = items.Where(i => i.BookId != id);
            HttpContext.Session.Set(Settings.FavoriteSessionKey, newItems);

            return RedirectToAction("FavoritePage");
        }

        private List<FavoriteBookItem> GetFavoriteBookItems()
        {
            var items = HttpContext.Session.Get<List<FavoriteBookItem>>(Settings.FavoriteSessionKey);

            if (items == null)
            {
                items = new List<FavoriteBookItem>();
            }

            return items;
        }
    }
}
