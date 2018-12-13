using SDMS.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}