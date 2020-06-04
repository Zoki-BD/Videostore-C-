using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videostore.Dtos;
using Videostore.Models;

namespace Videostore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        //problemi 1,2 i 3  se stavaat pri deffensive aproach koga app bi bila public ama nasata 
        //e za privatna upotreba i odime so optimistic aproach
        
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        { 
            
            var customer = _context.Customers.Single(
              c => c.Id == newRental.CustomerId);

            // //Ocekuvani problemi:1.CustomerId is invalid
            // if(customer == null)
            //     return BadRequest("CustomerId is not valid");

            List<Movie> movies = _context.Movies.Where(
                 m => newRental.MovieIds.Contains(m.Id)).ToList();

            // //Ocekuvani problemi:2.No MoviesIds
            // if(newRental.MovieIds.Count == 0)
            //     return BadRequest("No Movie Ids have been given.");

            // //Ocekuvani problemi:3. One or more MovieIds are invalid
            // if (movies.Count != newRental.MovieIds.Count)
            //     return BadRequest("One or more MovieIds are invalid.");

            foreach (Movie movie in movies)
            {
                //Ocekuvani problemi:4. One or more MovieIds are not available
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
    }
}
