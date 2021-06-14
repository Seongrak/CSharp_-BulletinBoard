using AspnetNote.MVC.DataContent;
using AspnetNote.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        ///  Bulletin Board List
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // when not log in
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var list = new List<Note>();

            using(var db = new AspnetNoteDbContext())
            {
                list = db.Notes.ToList();
                return View(list); // in view page -> Model

            }
        }

        public IActionResult Detail(int noteNo)
        {   
            // when not log in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            using(var db=new AspnetNoteDbContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.NoteNo.Equals(noteNo));
                return View(note);
            }

        }

        public IActionResult Add()
        {
            // when not log in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            // when not log in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);
                    if(db.SaveChanges() > 0) // commit, when its true
                    {
                        return Redirect("Index");
                    }
                   
                }
                ModelState.AddModelError(string.Empty, "Failed to Post the note");
            }

            return View(model);
        }
        public IActionResult Edit()
        {
            // when not log in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Delete()
        {
            // when not log in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
