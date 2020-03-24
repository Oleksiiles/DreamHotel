using System.Collections.Generic;
using System.Linq;
using dreamHotel.Models;
using dreamHotel.Controllers;
using dreamHotel.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dreamHotel.Services
{
    public class SearchService
    {
        private ApplicationDbContext _context;

        public IEnumerable<Room> AllRooms()
        {
            return _context.Rooms;
        }

        public SearchService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Room> SearchByDate(DateTime checkIn, DateTime checkOut)
        {
            IEnumerable<Room> allRooms = AllRooms();
            List<Room> freeRooms = new List<Room>();

            IEnumerable<Reservation> reservations = _context.Reservations;
            IEnumerable<Reservation> bookForSerarchDay = reservations
            .Where(reservation => checkIn >= reservation.CheckInDate && checkIn <= reservation.CheckOutDate);

            foreach (var room in allRooms)
            {
                bool hasReserve = false;
                foreach (var reservation in bookForSerarchDay)
                {
                    if (room.Id == reservation.Room.Id)
                    {
                        hasReserve = true;
                    }
                }
                if (!hasReserve)
                {
                    freeRooms.Add(room);
                }
            }



            return freeRooms;
        }

        public IEnumerable<Room> SearchByType(string type)
        {
            var rooms = _context.Rooms;
            return rooms.Where(room => room.Type == type);
        }

        public IEnumerable<Room> SearchByNumberOfBeds(int numberOfBeds)
        {
            var rooms = _context.Rooms;
            return rooms.Where(room => room.NumberOfBeds == numberOfBeds);
        }

        public IEnumerable<Room> SearchByPrice(int minPrice, int maxPrice)
        {
            var rooms = _context.Rooms;
            return rooms.Where(room => room.Price >= minPrice && room.Price <= maxPrice);
        }
    }
}