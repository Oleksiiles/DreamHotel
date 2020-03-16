using System;

namespace dreamHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalCost { get; set; }
        public decimal OneDayPrice { get; set; }

        public bool paid { get; set; }
        public bool Breakfast {get; set;}
    }
}
