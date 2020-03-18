using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using dreamHotel.Models;
using dreamHotel.Services;

namespace asp_react.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly BookService _bookService;
        public ReservationController(BookService bookService)
        {
            this._bookService = bookService;
        }
        private string UserId
        {
            get
            {
                return User.Claims
                    .Where(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)
                    .Select(c => c.Value)
                    .First();
            }
        }

        // GET api/reservation
        [HttpGet("")]
        public IEnumerable<Reservation> GetReservations()
        {
            return _bookService.AllReservation(UserId);
        }

        // GET api/reservation/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetTaskById(int id)
        {
            return null;
        }

        // POST api/reservation
        [HttpPost("")]
        public Reservation PostTask(NewReservation newReservation)
        {
            newReservation.UserId = UserId;
            return _bookService.Create(newReservation);
        }


        // PUT api/reservation/5
        [HttpPut("{id}")]
        public void PutTask(string id, Reservation reservation)
        {
            _bookService.Update(id, reservation);
        }

        // DELETE api/reservation/5
        [HttpDelete("{id}")]
        public void DeleteTaskById(string id)
        {
            _bookService.Remove(id);
        }
    }
}