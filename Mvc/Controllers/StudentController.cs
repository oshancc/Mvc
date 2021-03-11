using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Students.Include("Course").ToList(); 
                return View(data);
            
           
        }

       
        public IActionResult Create(int id)
        {
            var student = db.Students.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View(student);
            
        }

        [HttpPost]
        public IActionResult Create(Student objStudent)
        {
            db.Students.Add(objStudent);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = objStudent.CourseId });

        }
    }
}
