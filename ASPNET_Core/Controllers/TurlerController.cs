using ASPNET_Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core.Controllers
{
    public class TurlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
