using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View();
        }

    }

}
