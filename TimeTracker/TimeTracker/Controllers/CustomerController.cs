using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Data;

namespace TimeTracker.Controllers
{
    public class CustomerController : Controller
    {
        private Tracker tracker;

        public CustomerController(Tracker tracker)
        {
            this.tracker = tracker;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(tracker.Clients);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client model)
        {
            try//if (ModelState.IsValid)
            {
                Client customer = new Client { ClientID = model.ClientID, CompanyName = model.CompanyName, CompanyPhone = model.CompanyPhone, CompanyPoc = model.CompanyPoc };
                tracker.Clients.Add(customer);
                tracker.SaveChanges();
                return RedirectToAction("Index");

                //else
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        ModelState.AddModelError(string.Empty, error.Description);
                //    }
                //}

            }
            catch
            {
                return View(model);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = tracker.Clients.Where(x => x.ClientID == id).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            Client model = new Client { ClientID = customer.ClientID, CompanyName = customer.CompanyName, CompanyPhone = customer.CompanyPhone, CompanyPoc = customer.CompanyPoc };
            return View(model);
            //return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client collection)
        {

            if (ModelState.IsValid)
            {
                var customer = tracker.Clients.Where(x => x.ClientID == id).FirstOrDefault();
                if (customer != null)
                {
                    customer.CompanyName = collection.CompanyName;
                    customer.CompanyPhone = collection.CompanyPhone;
                    customer.CompanyPoc = collection.CompanyPoc;
                    try
                    {
                        // TODO: Add update logic here
                        tracker.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View(collection);
                    }
                    
                    
                }
            }
            return View(collection);

            
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = tracker.Clients.Where(x => x.ClientID == id).FirstOrDefault();
            if (customer != null)
            {
                tracker.Clients.Remove(customer);
                tracker.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Customer/Delete/5
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