using ASPNET_Core.Data;
using ASPNET_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_Core.Controllers
{
    public class KitaplarController : Controller
    {
        // we are creating a private readonly ApplicationDbContext object to use it in the controller
        private readonly ApplicationDbContext _db;
        // we are creating a constructor that takes an ApplicationDbContext object as a parameter
        public KitaplarController(ApplicationDbContext db)
        {
            _db = db; // we are assigning the ApplicationDbContext object to the private readonly ApplicationDbContext object
        }

        public IActionResult Index()
        {
            return View(_db.Kitaplars.ToList());
        }

        //Kaydetme işlemi 
        public IActionResult Create()
        {
            // we are creating a list of SelectListItem objects to use it in the view
            // we are selecting the id of the Turlers table and adding it to the SelectListItem object
            List<SelectListItem> turid_liste = (from x in _db.Turlers
                                                select new SelectListItem{
                                                    Value = x.id.ToString(),
                                                    Text = x.KitapTur}).ToList();
           ViewBag.TurId = turid_liste;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitaplar kitap)
        {
            _db.Kitaplars.Add(kitap);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Güncelleme işlemi
        public IActionResult Edit(int id)
        {
            List<SelectListItem> turid_liste = (from x in _db.Turlers
                                                select new SelectListItem
                                                {
                                                    Value = x.id.ToString(),
                                                    Text = x.KitapTur
                                                }).ToList();
            ViewBag.TurId = turid_liste;
            return View(_db.Kitaplars.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Kitaplar kitap)
        {
            _db.Kitaplars.Update(kitap);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme işlemi (direk butonla silinecek)
        public IActionResult Delete(int id)
        {
            var sil = _db.Kitaplars.Find(id);
            _db.Kitaplars.Remove(sil);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}
