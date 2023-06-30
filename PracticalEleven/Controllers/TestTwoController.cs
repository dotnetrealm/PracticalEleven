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
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserService.AddUser(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return View(data);
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

        public IActionResult Delete(int id)
        {
            UserService.RemoveUserById(id);
            return RedirectToAction("Index");
        }
    }
}