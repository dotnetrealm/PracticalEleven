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
            return PartialView("_UserDetails", data);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public JsonResult Create([Bind(include: new[] { "Name, DOB, Address" })] User user)
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
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return PartialView("_Edit", data);
        }

        [HttpPost]
        public JsonResult Edit(int id, [Bind("Name, DOB, Address")] User user)
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

                UserService.UpdateUser(id, user);
                user.Id = id;
                return Json(new { Result = "OK", Data = new { user } });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            UserService.RemoveUserById(id);
            return Json(new { Result = "OK" });
        }
    }
}