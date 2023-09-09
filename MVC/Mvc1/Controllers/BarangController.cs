using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc1.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Mvc1.Controllers
{
    public class BarangController : Controller
    {
        private static List<BarangViewModel> barangs = new List<BarangViewModel>
        {
            new BarangViewModel { Id = 1, Nama = "Tas", stock = 20},
            new BarangViewModel { Id = 2, Nama = "Baju", stock = 25 },
            new BarangViewModel { Id = 3, Nama = "Celana", stock = 12 }
        };

        private int lastId = 3;
        // GET: BarangController1
        public ActionResult Index()
        {
            return View(barangs);
        }

        // GET: BarangController1/Details/5
        public ActionResult Details(int id)
        {
            var barang = barangs.FirstOrDefault(i => i.Id == id);
            if (barang == null)
                return NotFound();

            return View(barang);
        }

        // GET: BarangController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarangController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarangViewModel barang)
        {
            try
            {
                lastId++;
                barang.Id = lastId;
                barangs.Add(barang);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BarangController1/Edit/5
        public ActionResult Edit(int id)
        {
            var barang = barangs.FirstOrDefault(i => i.Id == id);
            if (barang == null)
                return NotFound();

            return View(barang);
        }

        // POST: BarangController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BarangViewModel barang)
        {
            try
            {
                var existBarang = barangs.FirstOrDefault(i => i.Id == id);
                if (existBarang == null)
                    return NotFound();

                existBarang.Nama = barang.Nama;
                existBarang.stock = barang.stock;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BarangController1/Delete/5
        public ActionResult Delete(int id)
        {
            var barang = barangs.FirstOrDefault(i => i.Id == id);
            if (barang == null)
                return NotFound();

            return View(barang);
        }

        // POST: BarangController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var barang = barangs.FirstOrDefault(x => x.Id == id);
                if (barang == null)
                    return NotFound();

                barangs.Remove(barang);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
