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
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Employees  
        public ActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        // Get  
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _context.Clients.SingleOrDefault(e => e.CID == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _context.Clients.SingleOrDefault(e => e.CID == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _context.Clients.SingleOrDefault(e => e.CID == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var client = _context.Clients.SingleOrDefault(x => x.CID == id);
            _context.Clients.Remove(client ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}