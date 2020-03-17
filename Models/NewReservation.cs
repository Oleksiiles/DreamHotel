using System;
using System.ComponentModel.DataAnnotations;


namespace dreamHotel.Models
{
    public class NewReservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Дата заезда не установлена")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Дата выезда не установлена")]
        public DateTime CheckOutDate { get; set; }
        public bool Breakfast { get; set; }
        public Room Room { get; set; }
        public NewReservation()
        {

        }

        public NewReservation(
            DateTime checkInDate,
            DateTime checkOutDate,
            bool breakfast,
            Room room
            )
        {
            CheckOutDate = checkOutDate;
            CheckInDate = checkInDate;
            Breakfast = breakfast;
            Room = room;
        }
    }

}
