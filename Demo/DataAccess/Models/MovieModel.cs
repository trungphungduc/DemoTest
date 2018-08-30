using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class MovieModel : BaseModel
    {
        public string Title { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
