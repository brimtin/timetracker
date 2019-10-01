using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class ProjectsController : Controller
    {
        private Tracker tracker;

        public ProjectsController(Tracker tracker)
        {
            this.tracker = tracker;
        }
        // GET: Projects
        public ActionResult Index()
        {
            return View(tracker.Projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project model)
        {
            try//if (ModelState.IsValid)
            {
                Project project = new Project { ProjectName = model.ProjectName, StartDate = model.StartDate, DueDate = model.DueDate, TotalTime = DateTime.Now, ClientID = 1, ProjectManagerID = 1 };
                tracker.Projects.Add(project);
                tracker.SaveChanges();
                return RedirectToAction("Index");

          

            }
            catch
            {
                return View(model);
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}