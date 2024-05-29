using ASPNET_Core.Data;
using ASPNET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core.Controllers
{
    public class TurlerController : Controller
    {
        // mvcde yaptıgımız gibi modeldeki classtan nesne üretmiyoruz. Bunun yerine dependency injection yapıyoruz.
        private readonly ApplicationDbContext _db;

        public TurlerController(ApplicationDbContext db)
        {
            _db = db;
        }

        // listeleme işlemi için index action'ı oluşturuyoruz.
        public IActionResult Index()
        {
            return View(_db.Turlers.ToList());
        }

        // Create action'ı oluşturuyoruz.
        public IActionResult Create()
        {
            return View();
        }

        // Create action'ı için post işlemi oluşturuyoruz.
        [HttpPost]
        public IActionResult Create(Turler tur)
        {
                _db.Turlers.Add(tur);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // Güncelle
        public IActionResult Edit(int id)
        {
            // var guncelle = _db.Turlers.Where(i => i.id == id).FirstOrDefault();
            var guncelle = _db.Turlers.Find(id); // find core'a özgü bir metot. id'ye göre veriyi getirir.
            return View(guncelle);
        }

        // Güncelleme işlemi için post işlemi oluşturuyoruz.
        [HttpPost]
        public IActionResult Edit(int id, Turler tur)
        {
            _db.Turlers.Update(tur); // güncelleme işlemi için update metotunu kullanıyoruz.
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme işlemi view'ı oluşturuyoruz.
        public IActionResult Delete(int id)
        {
            return View(_db.Turlers.Find(id));
        }

        // Silme işlemi için post işlemi oluşturuyoruz.
        [HttpPost]
        public IActionResult Delete(int id,Turler tur)
        {
            _db.Turlers.Remove(tur); // silme işlemi için remove metotunu kullanıyoruz.
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
