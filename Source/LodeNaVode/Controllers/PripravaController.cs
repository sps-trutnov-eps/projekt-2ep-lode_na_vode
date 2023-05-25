using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public float pocetLodi = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            Debug.WriteLine("Zvolit");
            Debug.WriteLine(pocetLodi);
            return View(pocetLodi);
        }

        public IActionResult KliknutiPlus()
        {
            Debug.WriteLine("KliknutiPlus");
            pocetLodi ++;
            Debug.WriteLine(pocetLodi);
            return View("Zvolit", pocetLodi);
        }

    }

}
