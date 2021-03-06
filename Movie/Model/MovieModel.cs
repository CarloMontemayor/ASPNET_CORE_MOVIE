using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Model
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRented { get; set; }
        public DateTime RentalDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
