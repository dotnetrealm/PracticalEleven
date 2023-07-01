using Microsoft.AspNetCore.Mvc;
using PracticalEleven.Models;
using PracticalEleven.Services;

namespace PracticalEleven.Controllers
{
    public class TestTwoController : Controller
    {
        public ViewResult Index()
        {
            return View(UserService.GetAllUsers());
        }

        [HttpGet]
        public IActionResult UserDetails(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return View(data);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public JsonResult Create([Bind(include: new[] { "Name, DOB, Address"})]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    throw new Exception(messages);
                }

                user.Id = UserService.AddUser(user);
                return Json(new { Result = "OK", Data = new { user } });
            } catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return PartialView(data);
        }

        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                UserService.UpdateUser(id, user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            UserService.RemoveUserById(id);
            return RedirectToAction("Index");
        }
    }
}