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

        public IEnumerable<Reservation> AllReservation(int userId)
        {
            return _context.Reservations.Where(reservation => reservation.UserId == userId);

        }

        public Reservation Update(int id, Reservation newReservation)
        {
            foreach (var Reservation in _context.Reservations)
            {
                if (Reservation.Id == id)
                {
                    Reservation.UserId = newReservation.UserId;
                    Reservation.CheckInDate = newReservation.CheckInDate;
                    Reservation.CheckOutDate = newReservation.CheckOutDate;
                    Reservation.TotalCost = newReservation.TotalCost;
                    Reservation.OneDayPrice = newReservation.OneDayPrice;
                    Reservation.Paid = newReservation.Paid;
                    Reservation.Breakfast = newReservation.Breakfast;
                }
            }
            _context.SaveChanges();
            return newReservation;
        }

        public ActionResult<IEnumerable<Reservation>> Remove(int id)
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
        // public dynamic VerifyId(int id)
        // {
        //     return _context.Reservations.FindAsync(id);
        // }

    }
}
