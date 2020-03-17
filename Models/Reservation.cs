using System;
using System.ComponentModel.DataAnnotations;


namespace dreamHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пользователь не установлен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Дата заезда не установлена")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Дата выезда не установлена")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Общая стоимость не установлена")]
        public decimal TotalCost { get; set; }

        [Required(ErrorMessage = "Дневная стоимость проживания не установлена")]
        public decimal OneDayPrice { get; set; }
        public bool Paid { get; set; }
        public bool Breakfast { get; set; }

        public Room Room { get; set; }

        public Reservation()
        {

        }

        public Reservation(
            int id,
            int userId,
            Room room,
            DateTime checkInDate,
            DateTime checkOutDate,
            decimal oneDayPrice,
            decimal totalCost,
            bool paid,
            bool breakfast
            )
        {
            Id = id;
            UserId = userId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalCost = totalCost;
            OneDayPrice = oneDayPrice;
            Paid = paid;
            Breakfast = breakfast;
            Room = room;
        }
    }

}
