using Library_NPR321.Models;
using Library_NPR321.Repositories.Authors;
using Microsoft.AspNetCore.Mvc;

namespace Library_NPR321.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.Authors;

            return View(authors);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author model)
        {
            if(ModelState.IsValid)
            {
                await _authorRepository.AddAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Update(int? id)
        {
            var model = await _authorRepository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Author model)
        {
            if(ModelState.IsValid)
            {
                await _authorRepository.UpdateAsync(model);
                return RedirectToAction("index");
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _authorRepository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Author model)
        {
            await _authorRepository.RemoveAsync(model);

            return RedirectToAction("index");
        }
    }
}
