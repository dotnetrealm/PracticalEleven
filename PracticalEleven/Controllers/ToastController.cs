using Microsoft.AspNetCore.Mvc;

namespace PracticalEleven.Controllers
{
    public class ToastController:Controller
    {
        public IActionResult Index(string message = "Success!!")
        {
            ViewData["Message"] = message;
            return PartialView("_Toast");
        }
    }
}
