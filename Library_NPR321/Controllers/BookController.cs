using Library_NPR321.Models;
using Library_NPR321.Models.ViewModels;
using Library_NPR321.Repositories.Authors;
using Library_NPR321.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_NPR321.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.Books;

            return View(books);
        }

        // GET
        public IActionResult Create()
        {
            BookVM viewModel = new BookVM
            {
                Book = new Book { Title = "", Language = "", Genre = "" },
                ListItems = _authorRepository.Authors.Select(a =>
                {
                    return new SelectListItem
                    {
                        Text = $"{a.FirstName} {a.LastName}",
                        Value = a.Id.ToString()
                    };
                })
            };

            return View(viewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookVM model)
        {
            var files = HttpContext.Request.Form.Files;
            string? imageName = null;

            if(files.Count > 0)
            {
                var imageFile = files[0];
                var types = imageFile.ContentType.Split("/");

                if (types[0] == "image" && types.Length > 1)
                {
                    var ext = types[1];
                    imageName = Guid.NewGuid().ToString() + "." + ext;
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, Settings.BookImagePath, imageName);

                    using(var stream = System.IO.File.OpenWrite(imagePath))
                    {
                        imageFile.OpenReadStream().CopyTo(stream);
                    }
                }
            }

            model.Book.Image = imageName;
            await _bookRepository.AddAsync(model.Book);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _bookRepository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            BookVM viewModel = new BookVM
            {
                Book = book,
                ListItems = _authorRepository.Authors.Select(a =>
                {
                    return new SelectListItem
                    {
                        Text = $"{a.FirstName} {a.LastName}",
                        Value = a.Id.ToString()
                    };
                })
            };

            return View(viewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(BookVM model)
        {
            await _bookRepository.RemoveAsync(model.Book);

            return RedirectToAction("index");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BookVM model)
        {
            var files = HttpContext.Request.Form.Files;
            string? imageName = null;

            if (files.Count > 0)
            {
                var imageFile = files[0];
                var types = imageFile.ContentType.Split("/");

                if (types[0] == "image" && types.Length > 1)
                {
                    var ext = types[1];
                    imageName = Guid.NewGuid().ToString() + "." + ext;
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, Settings.BookImagePath, imageName);

                    using (var stream = System.IO.File.OpenWrite(imagePath))
                    {
                        imageFile.OpenReadStream().CopyTo(stream);
                    }

                    if(model.Book.Image != null)
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, Settings.BookImagePath, model.Book.Image);

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    model.Book.Image = imageName;
                }
            }

            await _bookRepository.UpdateAsync(model.Book);

            return RedirectToAction("Index");
        }
    }
}
