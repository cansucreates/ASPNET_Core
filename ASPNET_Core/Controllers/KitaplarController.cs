using ASPNET_Core.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        // 
    }
}
