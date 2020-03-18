using System.ComponentModel.DataAnnotations;


namespace dreamHotel.Models
{
    public class Room
    {

        [Required(ErrorMessage = "Идентификатор комнаты не установлен")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Тип комнаты не установлен")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Этаж не установлен")]
        public int FloorNumber { get; set; }

        [Required(ErrorMessage = "Номер комнати не установлен")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Цена не установлена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Количество кроватей не установлено")]
        [Range(1, 3, ErrorMessage = "Недопустимое количество кроватей")]
        public int NumberOfBeds { get; set; }

        public Room()
        {

        }
        public Room(string id, string type, int floorNumber, int roomNumber, decimal price, int numberOfBeds)
        {
            Id = id;
            Type = type;
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
            Price = price;
            NumberOfBeds = numberOfBeds;
        }




    }
}
