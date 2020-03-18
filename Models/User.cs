using System.ComponentModel.DataAnnotations;

namespace dreamHotel.Models
{
    public class User
    {
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указан пароль пользователя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Недопустимая длина пароля")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан email пользователя")]
        public string Email { get; set; }

        public string Role { get; set; } = "client";


        public User()
        {

        }


        public User(string id, string name, string password, string email, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

    }


}

