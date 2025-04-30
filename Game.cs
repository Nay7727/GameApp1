using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Title { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
