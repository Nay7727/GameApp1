using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public ICollection<User> Friends { get; set; } = new List<User>();
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
