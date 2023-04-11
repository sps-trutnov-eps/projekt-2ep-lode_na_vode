using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{
    public class TahController : Controller
    {
        public IActionResult Policko(int id)
        {
            Debug.WriteLine(id);

            return View();
        }
    }
}
