using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc1.Models;

namespace Mvc1.Controllers
{
    public class BookController : Controller
    {
        private static List<BookViewModel> books = new List<BookViewModel>
        {
            new BookViewModel { Id = 1, BookTitle = "Harry Potter", Author = "J.K. Rowling", Price = 10.99m, CreatedAt = DateTime.Now },
            new BookViewModel { Id = 2, BookTitle = "Marmut Merah Jambu", Author = "Raditya Dika", Price = 19.99m, CreatedAt = DateTime.Now },
            new BookViewModel { Id = 3, BookTitle = "Naruto", Author = "Masashi Kishimoto", Price = 5.99m, CreatedAt = DateTime.Now }
        };

        private int lastId = 3;

        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = books.FirstOrDefault(i => i.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                book.Id = lastId++;
                book.CreatedAt = DateTime.Now;
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(i => i.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookViewModel book)
        {
            try
            {
                var ExistBook = books.FirstOrDefault(i => i.Id == id);
                if (ExistBook == null)
                    return NotFound();

                ExistBook.CreatedAt = book.CreatedAt;
                ExistBook.Author = book.Author;
                ExistBook.BookTitle = book.BookTitle;
                ExistBook.Price = book.Price;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(i => i.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var book = books.FirstOrDefault(x => x.Id == id);
                if (book == null)
                    return NotFound();
                books.Remove(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
