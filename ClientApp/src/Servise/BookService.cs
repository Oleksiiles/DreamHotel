using System.Collections.Generic;
using System.Linq;
using dreamHotel.Models;
using dreamHotel.Controllers;
using dreamHotel.Data;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Service
{
    public class BookService
    {
        private ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            this._context = context;
        }


        public Reservation BookCreate(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return reservation;
        }

        public ActionResult<IEnumerable<Reservation>> All()
        {
            return _context.Reservations.ToList();
        }

        public Reservation Update(int id, Reservation newReservation)
        {
            foreach (var Reservation in _context.Reservations)
            {
                if (Reservation.Id == id)
                {
                    Reservation.User = newReservation.User;
                    Reservation.CheckInDate = newReservation.CheckInDate;
                    Reservation.CheckOutDate = newReservation.CheckOutDate;
                    Reservation.TotalCost = newReservation.TotalCost;
                    Reservation.OneDayPrice = newReservation.OneDayPrice;
                    Reservation.Paid  = newReservation.Paid;
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
