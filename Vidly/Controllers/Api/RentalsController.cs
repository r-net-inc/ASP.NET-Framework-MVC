using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
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

        // GET /api/rentals
        public IHttpActionResult GetRentals()
        {
            var rentals = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToList();

            return Ok(rentals);
        }

        // POST: /Api/Rentals
        [HttpPost]
        public  IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No Movie IDs have been provided.");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("Invalid Customer ID.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more Movie IDs are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult ReturnRental (int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return NotFound();

            rental.DateReturned = DateTime.Today;
            rental.Movie.NumberAvailable++;

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return Ok();
        }



        // PUT /api/rentals/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageRentals)]
        public IHttpActionResult ReturnRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rentalInDb = _context.Rentals.SingleOrDefault(r => r.Id == rentalDto.Id);

            if (rentalInDb == null)
                return NotFound();

            rentalInDb.DateReturned = DateTime.Today;
            rentalInDb.Movie.NumberAvailable++;

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); // (Source, Destination)
            Mapper.Map(rentalDto, rentalInDb); // (Source, Destination)

            _context.SaveChanges();

            return Ok(new Uri(Request.RequestUri.ToString()));
        }
    }
}
