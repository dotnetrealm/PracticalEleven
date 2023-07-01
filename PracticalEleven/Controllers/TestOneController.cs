using Microsoft.AspNetCore.Mvc;
using PracticalEleven.Models;
using PracticalEleven.Services;

namespace PracticalEleven.Controllers
{
    public class TestOneController : Controller
    {
        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View(UserService.GetAllUsers());
        }

        /// <summary>
        /// Get specific user by Id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserDetails(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return View(data);
        }

        /// <summary>
        /// Redirect to create user page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns></returns>
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

        /// <summary>
        /// Return edit user view with user data
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = UserService.GetUserById(id);
            if (data == null) return new StatusCodeResult(404);
            return View(data);
        }

        /// <summary>
        /// Edit user by id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="user">User object</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete user by Id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            UserService.RemoveUserById(id);
            return RedirectToAction("Index");
        }
    }
}