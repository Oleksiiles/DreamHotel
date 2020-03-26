using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using dreamHotel.Models;
using dreamHotel.Services;

namespace asp_react.Controllers
{
    [Route("api/search")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;
        public SearchController(SearchService searchService)
        {
            this._searchService = searchService;
        }

        // GET api/search
        [HttpGet("")]
        public IEnumerable<Room> GetReservations()
        {
            return _searchService.AllRooms();
        }

        // GET api/search/date
        [HttpGet("")]
        public ActionResult<Reservation> GetSearchByDateRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var rooms = _searchService.SearchByDate(checkInDate, checkOutDate);
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // GET api/search/type
        [HttpGet("")]
        public ActionResult<Reservation> GetSearchByTypeRooms(string type)
        {
            var rooms = _searchService.SearchByType(type);
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // GET api/search/NumberOfBeds
        [HttpGet("")]
        public ActionResult<Reservation> GetSearchByNumberOfBedsRooms(int NumberOfBeds)
        {
            var rooms = _searchService.SearchByNumberOfBeds(NumberOfBeds);
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // GET api/search/price
        [HttpGet("")]
        public ActionResult<Reservation> GetSearchByPriceRooms(int minPrice, int maxPrice)
        {
            var rooms = _searchService.SearchByPrice(minPrice, maxPrice);
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }


    }
}