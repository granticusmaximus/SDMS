using SDMS.App.Entities;
using SDMS.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SDMS.App.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Employees  
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // Get  
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
            _context.Employees.Remove(employee ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}