using AspnetNote.MVC.DataContent;
using AspnetNote.MVC.Models;
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
            var list = new List<Note>();

            using(var db = new AspnetNoteDbContext())
            {
                list = db.Notes.ToList();
                return View(list); // in view page -> Model

            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if(ModelState.IsValid)
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
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
