namespace dreamHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int RloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public decimal Price {get; set;}

        public int NumberOfBeds{get; set;}
        



    }
}
