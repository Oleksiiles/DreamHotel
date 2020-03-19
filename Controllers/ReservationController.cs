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
        public ActionResult GetReservations()
        {
            var reservation = _bookService.AllReservation(UserId);
            if (reservation == null)
            {
                return NotFound();

            }
            return Ok(reservation);

        }

        // GET api/reservation/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservationById(int id)
        {
            var reservation = _bookService.GetById(UserId, id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        // POST api/reservation
        [HttpPost("")]
        public ActionResult PostTask(NewReservation newReservation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            newReservation.UserId = UserId;
            var reservation = _bookService.Create(newReservation);
            return Ok(reservation);
        }


        // PUT api/reservation/5
        [HttpPut("{id}")]
        public ActionResult PutTask(int id, Reservation reservation)
        {
            var newReservation = _bookService.Update(id, reservation);

            if (newReservation == null)
            {
                return NotFound();
            }
            return Ok(newReservation);
        }

        // DELETE api/reservation/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTaskById(int id)
        {
            var reservation = _bookService.Remove(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
    }
}