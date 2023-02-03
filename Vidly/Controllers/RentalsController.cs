using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /Rentals
        public ActionResult Index()
        {
            //if (User.IsInRole(RoleName.CanManageRentals))
            //    return View("Index");

            //return View("ReadOnlyIndex");

            var rentals = _context.Rentals.Include(r => r.Movie).ToList();

            return View(rentals);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Return(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rentalInDb == null)
                return HttpNotFound();

            rentalInDb.DateReturned = DateTime.Today;
            rentalInDb.Movie.NumberAvailable++;

            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", id);
        }
    }
}