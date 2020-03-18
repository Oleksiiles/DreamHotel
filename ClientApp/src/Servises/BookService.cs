using System.Collections.Generic;
using System.Linq;
using dreamHotel.Models;
using dreamHotel.Controllers;
using dreamHotel.Data;
using Microsoft.AspNetCore.Mvc;

namespace dreamHotel.Services
{
    public class BookService
    {
        private ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Reservation CreateСompleteReservation(NewReservation newReservation)
        {
            decimal OneDayPrice = newReservation.Room.Price;
            var countStayDay = newReservation.CheckOutDate.Subtract(newReservation.CheckInDate).Days;
            decimal TotalCost = countStayDay * OneDayPrice;

            return new Reservation(
                newReservation.Id,
                newReservation.UserId,
                newReservation.Room,
                newReservation.CheckInDate,
                newReservation.CheckOutDate,
                OneDayPrice,
                TotalCost,
                false,
                newReservation.Breakfast
                );
        }

        public Reservation Create(NewReservation newReservation)
        {
            var completeReservation = CreateСompleteReservation(newReservation);
            _context.Reservations.Add(completeReservation);
            _context.SaveChanges();

            return completeReservation;
        }

        public IEnumerable<Reservation> AllReservation(string userId)
        {
            return _context.Reservations.Where(reservation => reservation.UserId == userId);

        }

        public Reservation GetById(string userId, string reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservationId != null && reservation.UserId == userId)
            {
                return reservation;
            }
            return null;
        }

        public Reservation Update(string id, Reservation newReservation)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {

                reservation.UserId = newReservation.UserId;
                reservation.CheckInDate = newReservation.CheckInDate;
                reservation.CheckOutDate = newReservation.CheckOutDate;
                reservation.TotalCost = newReservation.TotalCost;
                reservation.OneDayPrice = newReservation.OneDayPrice;
                reservation.Paid = newReservation.Paid;
                reservation.Breakfast = newReservation.Breakfast;
                _context.SaveChanges();
                return newReservation;
            }
            else
            {
                return null;


            }

        }

        public ActionResult<IEnumerable<Reservation>> Remove(string id)
        {
            foreach (var reservation in _context.Reservations)
            {
                if (reservation.Id == id)
                {
                    _context.Reservations.Remove(reservation);
                }
            }
            _context.SaveChanges();
            return _context.Reservations.ToList();
        }


    }
}
