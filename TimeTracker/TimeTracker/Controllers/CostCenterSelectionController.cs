using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class CostCenterSelectionController : Controller
    {
        private Tracker tracker;

        public CostCenterSelectionController(Tracker tracker)
        {
            this.tracker = tracker;
        }

        public IActionResult Index()
        {
            var cost = tracker.Projects.Where(x => x.ClientID == id).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            Client model = new Client { ClientID = customer.ClientID, CompanyName = customer.CompanyName, CompanyPhone = customer.CompanyPhone, CompanyPoc = customer.CompanyPoc };
            return View();
        }

        public IActionResult Start()
        {
            try
            {
                Session session = new Session { StartTime = DateTime.Now, EndTime = DateTime.MaxValue, EmployeeID = 1, ProjectID = 1 };
                tracker.Sessions.Add(session);
                tracker.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}