using Microsoft.AspNetCore.Mvc;
using PriceBuildCalculate.DAL.Interfaces;

namespace PriceBuildCalculate.Controllers
{
    public class MaterialController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetMaterials() 
        {

            return View();
        }

    }
}
