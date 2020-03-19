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
            IEnumerable<Room> freeRooms = new List<Room>();
            IEnumerable<Reservation> reservations = _context.Reservations;

            // TODO: compare the request date with the reservation dates and determine 
            //which rooms are free and return their list

            // reservations.Where(reservation => reservation.CheckInDate)
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