using AspnetNote.MVC.DataContent;
using AspnetNote.MVC.Models;
using AspnetNote.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Login 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID, Password : requried
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    // Linq - method chaining
                    // A => B : A goes to B
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId)
                        && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        // Login Success
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }

                // Login Fail
                ModelState.AddModelError(string.Empty, "Please Check User ID or Password");

            }
            return View(model);
        }


        /// <summary>
        /// Register
        /// </summary>
        /// <returns></returns>
        public IActionResult Register() //[HttpGet] - Default
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // DB Connection On & OFF - using statement
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model); // Data will be stored in memory
                    db.SaveChanges(); // Store to DB, commit
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
